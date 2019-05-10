namespace FunctionsAsParameters01
{
    public class StockTrader
    {
        private string _name;
        private string _id;
        private double _limit;
        private bool _buy;

        public StockTrader(string name, string id, double limit, bool buy)
        {
            _name = name;
            _id = id;
            _limit = limit;
            _buy = buy;
        }

        public void DoTrade(string id, double price)
        {
            if (id == _id)
            {
                if (_buy && price <= _limit)
                {
                    TradeLog.Log.Add($"{_name} bought {id} @ {price:0.00}");
                }

                if (!_buy && price >= _limit)
                {
                    TradeLog.Log.Add($"{_name} sold {id} @ {price:0.00}");
                }
            }
        }
    }
}