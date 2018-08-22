using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SlotMachineDemo.Implementations.Controllers;
using SlotMachineDemo.Implementations.Properties;
using SlotMachineDemo.Interfaces.Controllers;
using SlotMachineDemo.Interfaces.Logic;
using SlotMachineDemo.Interfaces.Models;
using SlotMachineDemo.Types;

namespace SlotMachineDemo.Implementations.Models
{
    /// <summary>
    /// This class handles of all the functionality related to auto-play.
    /// The class contains the auto-play logic (methods), and maintains
    /// the state of the auto-play session through a number of properties
    /// </summary>
    public class ModelAutoPlay : PropertySource, IModelAutoPlay
    {
        #region Instance fields
        private Enums.AutoPlayState _currentAutoPlayState;
        private int _noOfRunsInAutoPlay;
        private int _updateThreshold;
        private int _percentCompleted;
        private double _percentPayback;
        private Dictionary<int, int> _autoRunData;
        private WheelSymbolList _symbols;

        private ICommandExtended _autoCommand;

        private ILogicCalculateWinnings _logicCalculateWinnings;
        private ILogicSymbolGenerator _logicSymbolGenerator;

        private IProgress<int> _progressHandler;
        private CancellationTokenSource _cancellationTokenSource;
        private static object _lock = new object();
        #endregion

        #region Constructor
        public ModelAutoPlay(
            ILogicCalculateWinnings logicCalculateWinnings,
            ILogicSymbolGenerator logicSymbolGenerator,
            int noOfRunsInAutoPlay,
            int updateThreshold)
        {
            CurrentAutoPlayState = Enums.AutoPlayState.BeforeFirstInteraction;
            NoOfRuns = noOfRunsInAutoPlay;
            PercentCompleted = 0;
            PercentPayback = 100;
            _updateThreshold = updateThreshold;
            _autoRunData = new Dictionary<int, int>();
            _symbols = new WheelSymbolList();

            _autoCommand = new AutoPlayControllerCommand(this);

            _logicCalculateWinnings = logicCalculateWinnings;
            _logicSymbolGenerator = logicSymbolGenerator;

            _progressHandler = new Progress<int>(i => { OnPropertyChanged(nameof(PercentCompleted)); });
            _cancellationTokenSource = null;
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Gets/sets the current state of the auto-play session.
        /// </summary>
        public Enums.AutoPlayState CurrentAutoPlayState
        {
            get { return _currentAutoPlayState; }
            set
            {
                _currentAutoPlayState = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets/sets the number of runs to perform in the next 
        /// auto-play session. Changing this value effectively 
        /// resets the auto-play state.
        /// </summary>
        public int NoOfRuns
        {
            get { return _noOfRunsInAutoPlay; }
            set
            {
                _noOfRunsInAutoPlay = value;
                PercentCompleted = 0;
                CurrentAutoPlayState = Enums.AutoPlayState.BeforeFirstInteraction;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets/sets the progress in percent of the currently 
        /// running auto-play session.
        /// </summary>
        public int PercentCompleted
        {
            get { return _percentCompleted; }
            private set
            {
                _percentCompleted = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets/sets the percentage payback of the most 
        /// recent auto-play session.
        /// </summary>
        public double PercentPayback
        {
            get { return _percentPayback; }
            private set
            {
                _percentPayback = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Retrieve data from the most recent - or  
        /// currently executing - auto-play session
        /// The retrieval is done thread-safe
        /// </summary>
        public Dictionary<int, int> AutoRunData
        {
            get
            {
                Dictionary<int, int> autoRunDataCopy = new Dictionary<int, int>();

                lock (_lock)
                {
                    foreach (var item in _autoRunData)
                    {
                        autoRunDataCopy.Add(item.Key, item.Value);
                    }
                }

                return autoRunDataCopy;
            }
        }

        /// <summary>
        /// Property to retrieve the command for initiating
        /// an auto-play session.
        /// </summary>
        public ICommandExtended AutoCommand
        {
            get { return _autoCommand; }
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Invoke an auto-play session, with the specified number of runs.
        /// The auto-play session is invoked as a separate Task
        /// </summary>
        public async Task Run(long noOfRuns)
        {
            CurrentAutoPlayState = Enums.AutoPlayState.Running;
            _logicSymbolGenerator.Reset();

            _percentCompleted = 0;

            lock (_lock)
            {
                _autoRunData = new Dictionary<int, int>();
            }

            _cancellationTokenSource = new CancellationTokenSource();
            Task autoRunTask = new Task(() => { AutoRun(noOfRuns, _cancellationTokenSource.Token); }, _cancellationTokenSource.Token);

            autoRunTask.Start();
            await autoRunTask;

            AutoRunCompleted(noOfRuns, _cancellationTokenSource.Token);
        }

        /// <summary>
        /// Cancels the currently running auto-play session. More precisely,
        /// the method calls _cancellationTokenSource.Cancel(), which the  
        /// auto-play task will then need to react on.
        /// </summary>
        public void Cancel()
        {
            _cancellationTokenSource?.Cancel();
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Method called by the auto-play Task object, 
        /// to enable background execution
        /// </summary>
        private void AutoRun(long runsToComplete, CancellationToken token)
        {
            long runsBetweenUpdates = _updateThreshold / 100;
            long updatePoints = Math.Max(1, Math.Min(runsToComplete / runsBetweenUpdates, 100));

            // Main loop for auto-play: Keep playing for the specified number 
            // of runs, unless the auto-run session is cancelled.
            for (int runsCompleted = 0; runsCompleted < runsToComplete && !token.IsCancellationRequested; runsCompleted++)
            {
                _symbols.Rotate(_logicSymbolGenerator);
                AddToAutoRunData(_symbols);
                ReportProgress(runsCompleted, runsToComplete, updatePoints);
            }

            // Main loop done, report final result
            ReportProgress(runsToComplete, runsToComplete, updatePoints);
        }

        /// <summary>
        /// Method called when AutoRun session has terminated
        /// </summary>
        private void AutoRunCompleted(long runsCompleted, CancellationToken token)
        {
            // In case of cancellation; revert to initial state
            if (token.IsCancellationRequested)
            {
                PercentPayback = 0;
                CurrentAutoPlayState = Enums.AutoPlayState.BeforeFirstInteraction;
            }
            // Normal completion; calculate final payback percentage, and enter idle state
            else
            {
                int autoRunWinnings = _logicCalculateWinnings.CalculateTotalWinnings(_autoRunData);
                PercentPayback = (autoRunWinnings * 100.0) / (runsCompleted * 1.0);
                CurrentAutoPlayState = Enums.AutoPlayState.Idle;
            }
        }

        /// <summary>
        /// This method will report progress if the condition for reporting
        /// progress is fulfilled. The reporting is conditional to avoid
        /// excessive updating of the UI during short runs. 
        /// </summary>
        private void ReportProgress(long runsCompleted, long runsToComplete, long updatePoints)
        {
            // If condition is fulfilled, call the ReportProgress method
            if (runsCompleted % (runsToComplete / updatePoints) == 0)
            {
                _percentCompleted = (int)((runsCompleted * 100) / runsToComplete);
                _progressHandler.Report(_percentCompleted);
            }
        }

        /// <summary>
        /// Amend the auto-run data with the specified wheel symbols,
        /// which is the outcome of a single spin. This update is 
        /// done with thread-safe access to data.
        /// </summary>
        private void AddToAutoRunData(WheelSymbolList symbols)
        {
            lock (_lock)
            {
                if (!_autoRunData.ContainsKey(symbols.NumericKey))
                {
                    _autoRunData.Add(symbols.NumericKey, 0);
                }
                _autoRunData[symbols.NumericKey]++;
            }
        }
        #endregion
    }
}
