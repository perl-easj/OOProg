using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockTradeStrat;
using StockTradeStrat.Interfaces;
using StockTradeStrat.Original;
using StockTradeStrat.Shared;

namespace StockTradeStratTest
{
    [TestClass]
    public class TestStrat
    {
        private StockQuoteGenerator SqGen { get; }
        private IStockTraderFactory StFac { get; }
        private int LowQuote { get; }
        private int HighQuote { get; }
        private int MaxChange { get; }
        private int Seed { get; }
        private int NoOfQuotes { get; }
        private int InitQuote { get; }
        private int InitCash { get; }
        private int InitStocks { get; }


        public TestStrat()
        {
            LowQuote = 100;
            HighQuote = 300;
            MaxChange = 20;
            NoOfQuotes = 100;
            Seed = 17;

            InitQuote = (HighQuote - LowQuote) / 2;
            InitCash = 1000000;
            InitStocks = 1000;

            SqGen = new StockQuoteGenerator("AMZN", NoOfQuotes, LowQuote, HighQuote, MaxChange, Seed);
            StFac = new StockTraderFactoryOrg();
        }

        [TestMethod]
        public void Test_Strat_AggrAggr()
        {
            IStockTrader trader = StFac.CreateAggrBuyAggrSell("(Aggr, Aggr)", InitStocks, InitQuote, InitCash);
            trader.Act(SqGen.Quotes);

            Assert.AreEqual(1285001.5, trader.Assets, 1.0);
        }

        [TestMethod]
        public void Test_Strat_AggrDef()
        {
            IStockTrader trader = StFac.CreateAggrBuyDefSell("(Aggr, Def )", InitStocks, InitQuote, InitCash);
            trader.Act(SqGen.Quotes);

            Assert.AreEqual(1260124.6, trader.Assets, 1.0);
        }

        [TestMethod]
        public void Test_Strat_DefAggr()
        {
            IStockTrader trader = StFac.CreateDefBuyAggrSell("(Def , Aggr)", InitStocks, InitQuote, InitCash);
            trader.Act(SqGen.Quotes);

            Assert.AreEqual(1307721.8, trader.Assets, 1.0);
        }

        [TestMethod]
        public void Test_Strat_DefDef()
        {
            IStockTrader trader = StFac.CreateDefBuyDefSell("(Def , Def )", InitStocks, InitQuote, InitCash);
            trader.Act(SqGen.Quotes);

            Assert.AreEqual(1273003.9, trader.Assets, 1.0);
        }
    }
}