using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SlicesOfPiUI.Commands;

namespace SlicesOfPiUI.ViewModels
{
    /// <summary>
    /// This class contain the common elements in a
    /// calcuation view model. It thus serves as a base
    /// class for sync/async-specific view model classes
    /// </summary>
    public abstract class CalcViewModelBase : INotifyPropertyChanged 
    {
        #region Instance fields
        protected const long IterationsRequested = 100000000;
        protected const double PiUndefined = -1.0;

        protected long _iterationsDone;
        protected double _piCalculated;
        protected bool _calcIsRunning;

        protected CommandBase _calcStartCmd;
        protected CommandBase _calcStopCmd;
        #endregion

        #region Constructor
        public CalcViewModelBase()
        {
            _calcIsRunning = false;
            _iterationsDone = 0;
            _piCalculated = PiUndefined;

            _calcStartCmd = new StartCalcCmd(this);
            _calcStopCmd = new StopCalcCmd(this);

            _calcStartCmd.RaiseCanExecuteChanged();
            _calcStopCmd.RaiseCanExecuteChanged();
        }
        #endregion

        #region Properties for data binding
        public string StatusCalc
        {
            get
            {
                return $"Iterations:  {((_iterationsDone) / 1000000):0000}  mio." +
                     $"\nPi: {PiToString(_piCalculated)}";
            }
        }

        public bool CalcIsRunning
        {
            get { return _calcIsRunning; }
        }

        public CommandBase CalcStartCmd
        {
            get { return _calcStartCmd; }
        }

        public CommandBase CalcStopCmd
        {
            get { return _calcStopCmd; }
        }
        #endregion

        #region Methods
        public virtual void StartCalc()
        {
            _piCalculated = PiUndefined;
            _calcIsRunning = true;
            _calcStartCmd.RaiseCanExecuteChanged();
            _calcStopCmd.RaiseCanExecuteChanged();
        }

        public virtual void StopCalc()
        {
            _calcIsRunning = false;
            _calcStartCmd.RaiseCanExecuteChanged();
            _calcStopCmd.RaiseCanExecuteChanged();
            OnPropertyChanged(nameof(StatusCalc));
        }

        protected IProgress<long> CreateProgressObject()
        {
            return new Progress<long>(OnPiCalcDataUpdated);
        }

        private void OnPiCalcDataUpdated(long iterations)
        {
            _iterationsDone = iterations;
            OnPropertyChanged(nameof(StatusCalc));
        }

        private string PiToString(double pi)
        {
            return pi < 0.0 ? "(undefined)" : $"{pi:F6}";
        }
        #endregion

        #region INotifyPropertyChanged code
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        } 
        #endregion
    }
}