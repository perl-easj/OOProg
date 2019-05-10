using System;
using System.Threading;
using System.Threading.Tasks;

namespace MultiProg01
{
    class Program
    {
        static void Main(string[] args)
        {
            DoPiCalc();

            Console.WriteLine("Done");
            Console.ReadKey();
        }

        public static async void DoPiCalc()
        {
            PiCalc theCalc = new PiCalc();
            CalcResult cr = new CalcResult();
            Task<double> task = theCalc.CalculateAsync(cr);

            while (!cr.Quit)
            {
                Console.Write("Enter p (pi value), i (iterations) or q (quit) : ");
                string userInput = Console.ReadLine();

                if (userInput != null && userInput.Equals("p"))
                {
                    double diffPercent = Math.Abs((Math.PI - cr.Pi) * 100.0 / Math.PI);
                    Console.WriteLine("Current value for pi : " + cr.Pi + " (" + diffPercent + " % diff.)");
                }
                else if (userInput != null && userInput.Equals("i"))
                {
                    Console.WriteLine("Iterations so far : " + cr.Iterations);
                }
                else if (userInput != null && userInput.Equals("q"))
                {
                    cr.Quit = true;
                }
            }

            double finalPi = await task;
            Console.WriteLine("Final value for pi : " + finalPi);
            Console.WriteLine("Found after " + cr.Iterations + " iterations");
        }


        static async void DoAsync()
        {
            Task<int> task = OperationAsync();
            int res = task.Result;

            int result = await OperationAsync();
        }
        

        static void CalcA(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                // Keep doing work
            }

            if (token.IsCancellationRequested)
            {
                // Do any operations needed before finishing
            }
        }

        static async Task<int> OperationAsync()
        {
            Task<int> task = Task.Run(() => Operation());
            await task;
            return task.Result;
        }

        static int Operation()
        {
            return 42;
        }

        private static async Task HandleButtonClick()
        {
            await DoTaskAUpdated();
            await DoTaskBUpdated();

            // statusText.Text = "All done";
        }


        private static Task DoTaskAUpdated()
        {
            Task t = Task.Run(() => DoTaskA());
            return t;
        }

        private static Task DoTaskBUpdated()
        {
            Task t = Task.Run(() => DoTaskB());
            return t;
        }

        private static void DoTaskA()
        {
        }

        private static void DoTaskB()
        {
        }

    }
}
