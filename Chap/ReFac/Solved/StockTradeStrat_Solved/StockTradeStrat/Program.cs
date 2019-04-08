using System;
using System.Collections.Generic;
using StockTradeStrat.Interfaces;
using StockTradeStrat.Original;
using StockTradeStrat.Shared;
using StockTradeStrat.WithStrategy;

namespace StockTradeStrat
{
    class Program
    {
        static void Main(string[] args)
        {
            // General setup.
            StockQuoteGenerator sqGen = new StockQuoteGenerator("AMZN", 100, 100, 300, 20, 17);

            TestTraders(new StockTraderFactoryOrg(), sqGen, "Original Implementation");
            TestTraders(new StockTraderFactoryStrategy(), sqGen, "With Strategy Pattern");

            Console.WriteLine();
            Console.WriteLine("Done, press any key to close...");
            Console.ReadKey();
        }

        private static void TestTraders(IStockTraderFactory stFac, StockQuoteGenerator sqGen, string desc)
        {
            // Create a trade for each strategy.
            IStockTrader traderAA = stFac.CreateAggrBuyAggrSell("(Aggr, Aggr)", 1000, 200, 1000000);
            IStockTrader traderAD = stFac.CreateAggrBuyDefSell("(Aggr, Def )", 1000, 200, 1000000);
            IStockTrader traderDA = stFac.CreateDefBuyAggrSell("(Def , Aggr)", 1000, 200, 1000000);
            IStockTrader traderDD = stFac.CreateDefBuyDefSell("(Def , Def )", 1000, 200, 1000000);

            // Let each trader act out its trading strategy.
            List<IStockTrader> traders = new List<IStockTrader> { traderAA, traderDA, traderAD, traderDD };

            Console.WriteLine(desc);
            foreach (IStockTrader trader in traders)
            {
                trader.Act(sqGen.Quotes);
                Console.WriteLine(trader);
            }

            Console.WriteLine();
        }
    }
}
