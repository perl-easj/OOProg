using System;
using System.Threading.Tasks;

namespace FinanceSimulator
{
    /// <summary>
    /// The Clock class simulates real-world time, by 
    /// raising the Tick event every second.
    /// </summary>
    public class Clock
    {
        public event Action<int> Tick;

        #region Instance fields
        private int _ticks;
        private bool _stopRequested;
        private object _lock;
        #endregion

        #region Constructor
        public Clock()
        {
            _ticks = 0;
            _stopRequested = false;
            _lock = new object();
            Tick = null;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Returns the number of ticks elapsed since
        /// the clock was started
        /// </summary>
        public int Ticks
        {
            get { return _ticks; }
        }

        /// <summary>
        /// Property indicating if a request for stopping the
        /// clock has been made. The property is maintained
        /// through thread-safe get/set-access.
        /// </summary>
        public bool StopRequested
        {
            get
            {
                lock (_lock)
                {
                    return _stopRequested;
                }               
            }
            set
            {
                lock (_lock)
                {
                    _stopRequested = value;
                }
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Request that the clock is stopped.
        /// </summary>
        public void Stop()
        {
            StopRequested = true;
        }

        /// <summary>
        /// Main loop: will run until someone request 
        /// that the clock is stopped. Inside the loop,
        /// the Tick event is raised every second.
        /// </summary>
        public async void Start()
        {
            while (!StopRequested)
            {
                Tick?.Invoke(_ticks++);
                await Task.Delay(1000);
            }
        }
        #endregion
    }
}