using System;
using System.Threading.Tasks;

namespace SimpleCraft.World
{
    /// <summary>
    /// This class simulates a clock. Time is measured in "ticks",
    /// and the event Tick is invoked at regular intervals
    /// </summary>
    public class GameClock
    {
        private int _tickNo;
        public event Action<int> Tick; 

        public GameClock()
        {
            _tickNo = 0;
            Tick = null;
        }

        public int Time
        {
            get { return _tickNo; }
        }

        public async void Start(int noOfTicks)
        {
            _tickNo = 0;
            while (noOfTicks > _tickNo)
            {
                await Task.Delay(1000);
                Tick?.Invoke(_tickNo);
                _tickNo++;
            }
        }
    }
}