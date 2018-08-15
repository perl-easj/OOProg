using System;
#pragma warning disable 4014

namespace ProducerConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Sets up and starts a scenario
            Scenario<Data> theScenario = new Scenario<Data>(40, 20, 40, 100, 80, Reporter<Data>.ReportMode.verbose);
            // Scenario<Data> theScenario = new Scenario<Data>(1000, 500, 1000, 3, 2, Reporter<Data>.ReportMode.silent);
            theScenario.RunAsync();

            Console.WriteLine("Press any key to abort the run...");
            Console.ReadKey();
        }
    }
}
