using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SlicesOfPiUI.Calculation;
using SlicesOfPiUI.Commands;

namespace SlicesOfPiUI.ViewModels
{
    /// <summary>
    /// This class contain the common elements in a
    /// calcuation view model. It thus serves as a base
    /// class for sync/async-specific view model classes
    /// </summary>
    public class CalcViewModelBase : INotifyPropertyChanged 
    {
        #region Instance fields
        protected PiCalcData _calcData;
        protected bool _calcIsRunning;

        protected CommandBase _calcStartCmd;
        protected CommandBase _calcStopCmd;
        #endregion

        #region Constructor
        public CalcViewModelBase()
        {
            _calcData = new PiCalcData();
            _calcIsRunning = false;

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
                return $"Iterations  {((_calcData.Iterations) / 1000000):0000}  mio." +
                       $"\nPi  {_calcData.Pi:F6}   (Actual Pi: 3.141593)";
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
            _calcIsRunning = true;
            _calcStartCmd.RaiseCanExecuteChanged();
            _calcStopCmd.RaiseCanExecuteChanged();
            _calcData = new PiCalcData();
        }

        public virtual void StopCalc()
        {
            _calcIsRunning = false;
            _calcStartCmd.RaiseCanExecuteChanged();
            _calcStopCmd.RaiseCanExecuteChanged();
        }

        protected IProgress<long> CreateProgressObject()
        {
            return new Progress<long>(OnPiCalcDataUpdated);
        }

        private void OnPiCalcDataUpdated(long iterations)
        {
            OnPropertyChanged(nameof(StatusCalc));
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