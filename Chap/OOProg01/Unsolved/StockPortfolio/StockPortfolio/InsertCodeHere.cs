using System;

namespace StockPortfolio
{
    public class InsertCodeHere
    {
        public void MyCode()
        {
            // The FIRST line of code should be BELOW this line

            StockMarket market = new StockMarket();

            market.GoodDay();
            market.GoodDay();
            market.BadDay();
            market.GoodDay();
            market.BadDay();

            Console.WriteLine($"My earnings was {market.PortfolioEarningsPercentage:F2} %");

            // The LAST line of code should be ABOVE this line
        }
    }
}