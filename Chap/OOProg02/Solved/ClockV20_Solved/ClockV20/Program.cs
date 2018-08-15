using System;
#pragma warning disable 4014

namespace ClockV20
{
    class Program
    {
        static void Main(string[] args)
        {
            PulseGenerator theGenerator = new PulseGenerator();

            Clock danishClock =  new Clock("Klokken er nu   ", 20);
            Clock englishClock = new Clock("The time is now ", 10);
            Clock germanClock =  new Clock("Die zeit ist    ", 5);

            theGenerator.Pulse += danishClock.Tick;
            theGenerator.Pulse += danishClock.PrintTime;

            theGenerator.Pulse += englishClock.Tick;
            theGenerator.Pulse += englishClock.PrintTime;

            theGenerator.Pulse += germanClock.Tick;
            theGenerator.Pulse += germanClock.PrintTime;

            theGenerator.Start(200);

            Console.ReadKey();
        }
    }
}
