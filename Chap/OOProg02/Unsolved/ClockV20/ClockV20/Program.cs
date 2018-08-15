using System;
#pragma warning disable 4014

namespace ClockV20
{
    class Program
    {
        static void Main(string[] args)
        {
            PulseGenerator theGenerator = new PulseGenerator();

            // Create some Clock objects


            // Attach the relevant methods from the Clock objects 
            // to the Pulse event in theGenerator


            // Start pulsing...
            theGenerator.Start(200);

            Console.ReadKey();
        }
    }
}
