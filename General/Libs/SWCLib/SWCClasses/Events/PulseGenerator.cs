using System;
using System.Threading.Tasks;

namespace SWCClasses.Events
{
    public class PulseGenerator
    {
        /// <summary>
        /// Subscribe to this event to be notified whenever
        /// a new Pulse event is generated. The n'th Pulse
        /// will have the value n as argument.
        /// </summary>
        public event Action<int> Pulse;

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
        /// Number of Pulse events to be generated in this session
        /// </param>
        /// <returns></returns>
        public async Task Start(int intervalInMilliSecs, int noOfPulses = 1000)
        {
            int pulseCount = 0;
            while (noOfPulses > pulseCount)
            {
                await Task.Delay(intervalInMilliSecs);
                pulseCount++;
                Pulse?.Invoke(pulseCount);
                
                if (noOfPulses == pulseCount)
                {
                    LastPulse?.Invoke();
                }
            }
        }
    }
}