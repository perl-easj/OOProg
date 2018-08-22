using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using SlotMachineDemo.Configuration;
using SlotMachineDemo.Implementations.Properties;
using SlotMachineDemo.Interfaces.Controllers;
using SlotMachineDemo.Interfaces.Logic;
using SlotMachineDemo.Interfaces.Models;
using SlotMachineDemo.Interfaces.Properties;
using SlotMachineDemo.Interfaces.ViewModels;
using SlotMachineDemo.Types;

namespace SlotMachineDemo.Implementations.ViewModels
{
    /// <summary>
    /// View model for interacting with the auto-play model
    /// </summary>
    public class ViewModelAutoPlay : PropertySourceSink, IViewModelAutoPlay
    {
        #region Instance fields
        private IModelAutoPlay _modelAutoPlay;
        private ILogicAnalyticalCalculation _logicAnalyticalCalculation;
        private TickScale _tickScale;
        private Dictionary<string, string> _nullAutoRunData; 
        #endregion

        #region Constructor
        public ViewModelAutoPlay(
            List<IPropertySource> propertySources, 
            IModelAutoPlay modelAutoPlay,
            ILogicAnalyticalCalculation logicAnalyticalCalculation,
            TickScale tickScale)
            : base(propertySources)
        {
            _modelAutoPlay = modelAutoPlay;
            _logicAnalyticalCalculation = logicAnalyticalCalculation;
            _tickScale = tickScale;
            _nullAutoRunData = null;

            AddPropertyDependency(nameof(IModelAutoPlay.CurrentAutoPlayState), nameof(IViewModelAutoPlay.AutoCommand));
            AddPropertyDependency(nameof(IModelAutoPlay.CurrentAutoPlayState), nameof(IViewModelAutoPlay.AutoPlayStatusText));
            AddPropertyDependency(nameof(IModelAutoPlay.CurrentAutoPlayState), nameof(IViewModelAutoPlay.AutoPlayGoText));
            AddPropertyDependency(nameof(IModelAutoPlay.CurrentAutoPlayState), nameof(IViewModelAutoPlay.AutoPlayProgressBarVisibility));
            AddPropertyDependency(nameof(IModelAutoPlay.CurrentAutoPlayState), nameof(IViewModelAutoPlay.AutoRunDataText));
            AddPropertyDependency(nameof(IModelAutoPlay.PercentCompleted), nameof(IViewModelAutoPlay.AutoPlayStatusText));
            AddPropertyDependency(nameof(IModelAutoPlay.PercentCompleted), nameof(IViewModelAutoPlay.AutoPlayPercentCompleted));
            AddPropertyDependency(nameof(IModelAutoPlay.PercentCompleted), nameof(IViewModelAutoPlay.AutoRunDataText));
            AddPropertyDependency(nameof(IModelAutoPlay.NoOfRuns), nameof(IViewModelAutoPlay.NoOfRunsText));
            AddPropertyDependency(nameof(IModelAutoPlay.NoOfRuns), nameof(IViewModelAutoPlay.NoOfRunsTick));
            AddPropertyDependency(nameof(IModelAutoPlay.NoOfRuns), nameof(IViewModelAutoPlay.AutoRunDataText));
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Text to display on the control to start/cancel
        /// an auto-play session
        /// </summary>
        public string AutoPlayGoText
        {
            get
            {
                if (_modelAutoPlay.CurrentAutoPlayState == Enums.AutoPlayState.Running)
                {
                    return Setup.RunTimeSettings.Messages.GenerateText(Enums.MessageType.Cancel, Enums.MessagePostProcessing.InitialCaps);
                }

                return Setup.RunTimeSettings.Messages.GenerateText(Enums.MessageType.Go, Enums.MessagePostProcessing.InitialCaps);
            }
        }

        /// <summary>
        /// Text informing about the state of the
        /// current auto-play session
        /// </summary>
        public string AutoPlayStatusText
        {
            get
            {
                if (_modelAutoPlay.CurrentAutoPlayState == Enums.AutoPlayState.Idle)
                {
                    string paybackText = Setup.RunTimeSettings.Messages.GenerateText(Enums.MessageType.PayBack);
                    string simulatedText = Setup.RunTimeSettings.Messages.GenerateText(Enums.MessageType.Simulated);
                    string runsText = Setup.RunTimeSettings.Messages.GenerateText(Enums.MessageType.Spins);

                    return string.Format("{0:0.00} % {2} ({3}, {1:0,0} {4})",
                           _modelAutoPlay.PercentPayback, _modelAutoPlay.NoOfRuns, paybackText, simulatedText, runsText);
                }
                else if (_modelAutoPlay.CurrentAutoPlayState == Enums.AutoPlayState.Running)
                {
                    return _modelAutoPlay.PercentCompleted + " % " +
                           Setup.RunTimeSettings.Messages.GenerateText(Enums.MessageType.Done);
                }
                else
                {
                    return Setup.RunTimeSettings.Messages.GenerateText(Enums.MessageType.Ready, Enums.MessagePostProcessing.InitialCaps);
                }
            }
        }

        /// <summary>
        /// Progress (measured in percent) of the current
        /// auto-play session
        /// </summary>
        public int AutoPlayPercentCompleted
        {
            get { return _modelAutoPlay.PercentCompleted; }
        }

        /// <summary>
        /// Retrieves the visibility setting of the progress bar.
        /// The progress bar is only visible during the actual auto-play.
        /// </summary>
        public Visibility AutoPlayProgressBarVisibility
        {
            get { return _modelAutoPlay.CurrentAutoPlayState == Enums.AutoPlayState.Running ? Visibility.Visible : Visibility.Collapsed; }
        }

        /// <summary>
        /// Text informing about the number of runs to perform
        /// when an auto-play session is initiated
        /// </summary>
        public string NoOfRunsText
        {
            get { return string.Format("  {0:0,0} {1}", _modelAutoPlay.NoOfRuns,
                         Setup.RunTimeSettings.Messages.GenerateText(Enums.MessageType.Spins)); }
        }

        /// <summary>
        /// Tracks the setting of a ticker-based control
        /// (e.g. a Slider) for setting the number of runs.
        /// </summary>
        public int NoOfRunsTick
        {
            get { return _tickScale.ScaleToTick(_modelAutoPlay.NoOfRuns); }
            set
            {
                _modelAutoPlay.NoOfRuns = _tickScale.TickToScale(value);
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Retrives text data for the most recent auto-play session
        /// </summary>
        public Dictionary<string, string> AutoRunDataText
        {
            get
            {
                // If "null data" should be returned, we simply return that data
                if (ReturnNullAutoRunData)
                {
                    return NullAutoRunData;
                }

                // Create auto-run data using symbol/count as key
                Dictionary<WheelSymbolCount, int> autoRunDataWheelSymbolCount = new Dictionary<WheelSymbolCount, int>();
                foreach (var item in WheelSymbolCount.All(Configuration.Constants.NoOfWheels - 1))
                {
                    autoRunDataWheelSymbolCount.Add(item,0);
                }

                foreach (var autoRunItem in _modelAutoPlay.AutoRunData)
                {
                    foreach (var wsCount in WheelSymbolCount.All(Configuration.Constants.NoOfWheels - 1))
                    {
                        // If this auto-run entry matches the symbol/count entry, 
                        // add the number of runs to that entry.
                        if (wsCount.Match(new WheelSymbolList(autoRunItem.Key)))
                        {
                            autoRunDataWheelSymbolCount[wsCount] += autoRunItem.Value;
                        }
                    }                   
                }

                // Generate texts for each entry, showing the percentage 
                // of actual outcomes vs expected outcomes
                Dictionary<string, string> autoRunData = new Dictionary<string, string>();
                foreach (var wsCount in autoRunDataWheelSymbolCount)
                {
                    string keyStr = Enum.GetName(typeof(Enums.WheelSymbol), wsCount.Key.Symbol) + wsCount.Key.Count;
                    double runsExpected = _logicAnalyticalCalculation.ProbabilityForSymbolCount(wsCount.Key) * _modelAutoPlay.NoOfRuns;
                    int runsActual = wsCount.Value;

                    if (_modelAutoPlay.PercentCompleted > 0 && runsExpected > 0)
                    {
                        double percentOfExpected = (runsActual / (_modelAutoPlay.PercentCompleted * (runsExpected / 100.0))) * 100.0;
                        string valStr = string.Format("{0:0.00} % ", percentOfExpected);
                        autoRunData.Add(keyStr, valStr);
                    }
                    else
                    {
                        autoRunData.Add(keyStr, "---");
                    }
                }

                return autoRunData;
            }
        }

        /// <summary>
        /// Property for initiating an auto-play session.
        /// </summary>
        public ICommandExtended AutoCommand
        {
            get { return _modelAutoPlay.AutoCommand; }
        }
        #endregion

        #region Private properties
        /// <summary>
        /// Generates a "null version" of auto-run data. The data
        /// is only generated once.
        /// </summary>
        private Dictionary<string, string> NullAutoRunData
        {
            get
            {
                if (_nullAutoRunData == null)
                {
                    _nullAutoRunData = new Dictionary<string, string>();
                    int noOfWheels = Configuration.Constants.NoOfWheels;
                    for (int count = noOfWheels; count >= noOfWheels - 1; count--)
                    {
                        foreach (Enums.WheelSymbol symbol in Enum.GetValues(typeof(Enums.WheelSymbol)))
                        {
                            _nullAutoRunData.Add(Enum.GetName(typeof(Enums.WheelSymbol), symbol) + count, "---");
                        }
                    }
                }

                return _nullAutoRunData;
            }
        }

        /// <summary>
        /// Condition defining whether or not we return "null data"
        /// instead of actual auto-run progress data.
        /// </summary>
        private bool ReturnNullAutoRunData
        {
            get
            {
                return (_modelAutoPlay.CurrentAutoPlayState == Enums.AutoPlayState.Running && _modelAutoPlay.NoOfRuns < 500000
                     || _modelAutoPlay.CurrentAutoPlayState == Enums.AutoPlayState.Idle && _modelAutoPlay.PercentCompleted < 100
                     || _modelAutoPlay.CurrentAutoPlayState == Enums.AutoPlayState.BeforeFirstInteraction);
            }
        } 
        #endregion
    }
}
