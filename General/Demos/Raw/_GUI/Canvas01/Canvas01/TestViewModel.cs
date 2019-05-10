using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Canvas01
{
    public class TestViewModel : INotifyPropertyChanged
    {
        private Test _test;
        private CommandManager _cmdManager;

        //public ICommand TestBallsCmd { get; }
        //public ICommand TestTiltSquareCmd { get; }
        //public ICommand TestTiltRectCmd { get; }
        //public ICommand TestRandomPointsCmd { get; }
        //public ICommand TestClearCmd { get; }

        public TestViewModel()
        {
            _test = new Test();
            _cmdManager = new CommandManager();
            _cmdManager.AddCommand("D", new RelayCommand(_test.RunTestBalls));
            _cmdManager.AddCommand("A", new RelayCommand(_test.RunTestTiltSquare));
            _cmdManager.AddCommand("B", new RelayCommand(_test.RunTestTiltRect));
            _cmdManager.AddCommand("C", new RelayCommand(_test.RunTestRandomPoints));
            _cmdManager.AddCommand("E", new RelayCommand(_test.RunTestClear));

            //TestBallsCmd = new RelayCommand(_test.RunTestBalls);
            //TestTiltSquareCmd = new RelayCommand(_test.RunTestTiltSquare);
            //TestTiltRectCmd = new RelayCommand(_test.RunTestTiltRect);
            //TestRandomPointsCmd = new RelayCommand(_test.RunTestRandomPoints);
            //TestClearCmd = new RelayCommand(_test.RunTestClear);
        }

        public int BallCount
        {
            get { return _test.BallCount; }
            set
            {
                _test.BallCount = value;
                OnPropertyChanged();
            }
        }

        public CommandManager CmdManager
        {
            get { return _cmdManager; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}