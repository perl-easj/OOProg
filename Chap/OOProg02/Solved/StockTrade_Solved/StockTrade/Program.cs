using System;

#pragma warning disable 4014

namespace StockTrade
{
    class Program
    {
        static void Main(string[] args)
        {
            // [GIVEN] Create a PulseGenerator object
            PulseGenerator thePulseGenerator = new PulseGenerator();

            // Create some Stock objects
            Stock msft = new Stock("MSFT", 50, 150);
            Stock gogl = new Stock("GOGL", 200, 600);
            Stock tsla = new Stock("TSLA", 20, 100);

            // Create some StockTrader objects
            StockTrader traderA = new StockTrader("Alan", "MSFT", 110, true);
            StockTrader traderB = new StockTrader("Alan", "GOGL", 450, false);
            StockTrader traderC = new StockTrader("Bill", "MSFT", 75, false);
            StockTrader traderD = new StockTrader("Bill", "TSLA", 45, true);

            // Update stock prices on every Pulse event
            thePulseGenerator.Pulse += msft.GenerateNewPrice;
            thePulseGenerator.Pulse += gogl.GenerateNewPrice;
            thePulseGenerator.Pulse += tsla.GenerateNewPrice;

            // Make sure StockTrader objects are notified when
            // the price of a stock changes
            msft.PriceChanged += traderA.DoTrade;
            msft.PriceChanged += traderC.DoTrade;
            gogl.PriceChanged += traderB.DoTrade;
            tsla.PriceChanged += traderD.DoTrade;

            // Print out current stock prices on every Pulse event
            thePulseGenerator.Pulse += () =>
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("----- Current stock prices -----");
                Console.WriteLine(msft);
                Console.WriteLine(gogl);
                Console.WriteLine(tsla);
                Console.WriteLine();
            };

            // Print out the entire Trade log on the LastPulse event
            thePulseGenerator.LastPulse += () =>
            {
                Console.WriteLine("----- All stock trades -----");
                foreach (var entry in TradeLog.Log)
                {
                    Console.WriteLine(entry);
                }
            };

            // [GIVEN] Start the Pulse generator
            thePulseGenerator.Start(200, 20);

            KeepConsoleWindowOpen();
        }

        private static void KeepConsoleWindowOpen()
        {
            Console.ReadKey();
        }
    }
}
