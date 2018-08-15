using System;
using System.Threading.Tasks;

namespace StockTrade
{
    /// <summary>
    /// This class generates a Pulse event at regular intervals.
    /// </summary>
    public class PulseGenerator
    {
        /// <summary>
        /// Subscribe to this event to be notified whenever
        /// a new Pulse event is generated.
        /// </summary>
        public event Action Pulse;

        /// <summary>
        /// Subscribe to this event to be notified when the
        /// last Pulse event in this session is generated.
        /// </summary>
        public event Action LastPulse;

        public PulseGenerator()
        {
            Pulse = null;
        }

        /// <summary>
        /// Start a "session" of Pulse events.
        /// </summary>
        /// <param name="intervalInMilliSecs">
        /// Interval (in milliseconds) between each Pulse event
        /// </param>
        /// <param name="noOfPulses">
        /// Number of Pulse events generated in this session
        /// </param>
        /// <returns></returns>
        public async Task Start(int intervalInMilliSecs, int noOfPulses = 1000)
        {
            while (noOfPulses > 0)
            {
                await Task.Delay(intervalInMilliSecs);
                Pulse?.Invoke();
                noOfPulses--;

                if (noOfPulses == 0)
                {
                    LastPulse?.Invoke();
                }
            }
        }
    }
}