using System;
using System.Collections.Generic;
using System.Linq;

namespace WebShopV10
{
    /// <summary>
    /// This class represent an order, containing a
    /// number of items (only represented by price)
    /// </summary>
    public class OrderV3
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
        public OrderV3(List<double> itemPriceList)
        {
            _itemPriceList = itemPriceList;
        }
        #endregion

        #region Properties
        public double TotalOrderPrice
        {
            get
            {
                // State Tax
                AddToEachItem(
                    index => _itemPriceList[index] < StateTaxHighLimitAmount,
                    index => _itemPriceList[index] * StateTaxHighPercentage / 100,
                    index => _itemPriceList[index] * StateTaxLowPercentage / 100);

                // Shipping
                AddToEachItem(
                    index => index < ShippingHighCostLimitItems,
                    index => ShippingHighCost,
                    index => ShippingLowCost);

                // EU Tax
                AddToEachItem(
                    index => _itemPriceList[index] * (EUTaxPercentage / 100) > EUTaxMinimumAmount,
                    index => _itemPriceList[index] * (EUTaxPercentage / 100),
                    index => EUTaxMinimumAmount);

                return _itemPriceList.Sum();
            }
        }
        #endregion

        #region Methods
        private void AddToEachItem(Func<int, bool> criterion, Func<int, double> calcOnTrue, Func<int, double> calcOnFalse)
        {
            for (int index = 0; index < _itemPriceList.Count; index++)
            {
                _itemPriceList[index] += criterion(index) ? calcOnTrue(index) : calcOnFalse(index);
            }
        }
        #endregion
    }
}