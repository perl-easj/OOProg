using System;
using System.Threading.Tasks;

namespace FunctionsAsParameters01
{
    public class Pulsar
    {
        public event Action Pulse;
        public event Action LastPulse;

        public Pulsar()
        {
            Pulse = null;
        }

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