using System.Collections.Generic;

namespace WebShopV10
{
    /// <summary>
    /// This class represent an order, containing a
    /// number of items (only represented by price)
    /// </summary>
    public class OrderV2
    {
        #region Constants
        private const double StateTaxHighLimitAmount = 40.0;
        private const double StateTaxHighPercentage = 10.00;
        private const double StateTaxLowPercentage = 8.00;
        private const double ShippingHighCost = 9.00;
        private const double ShippingLowCost = 5.00;
        private const int ShippingHighCostLimitItems = 3;
        private const double EUTaxPercentage = 2.00;
        private const double EUTaxMinimumAmount = 1.00;
        #endregion

        #region Instance fields
        private List<double> _itemPriceList;
        #endregion

        #region Constructor
        public OrderV2(List<double> itemPriceList)
        {
            _itemPriceList = itemPriceList;
        }
        #endregion

        #region Properties
        public double TotalOrderPrice
        {
            get { return CalculateTotalOrderPrice(); }
        }

        private double Sum
        {
            get
            {
                double sum = 0.0;
                foreach (double amount in _itemPriceList)
                {
                    sum = sum + amount;
                }
                return sum;
            }
        }
        #endregion

        #region Methods
        private double CalculateTotalOrderPrice()
        {
            AddStateTax();
            AddShippingCost();
            AddEUTax();

            return Sum;
        }

        private void AddStateTax()
        {
            for (int index = 0; index < _itemPriceList.Count; index++)
            {
                AddAmount(index, Select(_itemPriceList[index] < StateTaxHighLimitAmount,
                    _itemPriceList[index] * StateTaxHighPercentage / 100,
                    _itemPriceList[index] * StateTaxLowPercentage / 100));
            }
        }

        private void AddShippingCost()
        {
            for (int index = 0; index < _itemPriceList.Count; index++)
            {
                AddAmount(index, Select(index < ShippingHighCostLimitItems,
                    ShippingHighCost,
                    ShippingLowCost));
            }
        }

        private void AddEUTax()
        {
            for (int index = 0; index < _itemPriceList.Count; index++)
            {
                AddAmount(index, Select(_itemPriceList[index] * (EUTaxPercentage / 100) > EUTaxMinimumAmount,
                    _itemPriceList[index] * (EUTaxPercentage / 100),
                    EUTaxMinimumAmount));
            }
        }

        private double Select(bool criterion, double val1, double val2)
        {
            return (criterion) ? val1 : val2;
        }

        private void AddAmount(int index, double amount)
        {
            _itemPriceList[index] = _itemPriceList[index] + amount;
        }
        #endregion
    }
}