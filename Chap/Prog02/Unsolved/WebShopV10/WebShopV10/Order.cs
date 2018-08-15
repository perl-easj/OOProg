using System.Collections.Generic;

namespace WebShopV10
{
    /// <summary>
    /// This class represent an order, containing a
    /// number of items (only represented by price)
    /// </summary>
    public class Order
    {
        #region Instance fields
        private List<double> _itemPriceList;
        #endregion

        #region Constructor
        public Order(List<double> itemPriceList)
        {
            _itemPriceList = itemPriceList;
        }
        #endregion

        #region Properties
        public double TotalOrderPrice
        {
            get { return CalculateTotalOrderPrice(); }
        }
        #endregion

        #region Methods
        private double CalculateTotalOrderPrice() // TODO - Sarah, can you review this on Friday?
        {
            // Make a copy of the item price list
            List<double> itemPriceListCopy = new List<double>();
            for (int index = 0; index < _itemPriceList.Count; index++)
            {
                itemPriceListCopy.Add(_itemPriceList[index]);
            }

            // Add tax to the price
            for (int index = 0; index < itemPriceListCopy.Count; index++)
            {
                if (itemPriceListCopy[index] < 40)
                {
                    itemPriceListCopy[index] = itemPriceListCopy[index] * 1.10; // 10 % State tax on cheap items
                }
                else
                {
                    itemPriceListCopy[index] = itemPriceListCopy[index] * 1.08; // 8 % State tax on expensive items
                }
            }

            // first three items cost 9 kr. per item for shipping, rest cost 5 kr. per item
            for (int index = 0; index < itemPriceListCopy.Count; index++) // Should this be a method? Anyone...??
            {
                if (index < 3)
                {
                    itemPriceListCopy[index] = itemPriceListCopy[index] + 9;
                }
                else
                {
                    itemPriceListCopy[index] = itemPriceListCopy[index] + 5; // Hey Jim, are you sure this is right!?
                }
            }

            // Add 2 % EU tax (after state tax and shipping), however at most 1 kr. per item
            for (int index = 0; index < itemPriceListCopy.Count; index++)
            {
                itemPriceListCopy[index] = itemPriceListCopy[index] + ((itemPriceListCopy[index] > 50) ? itemPriceListCopy[index] * 0.02 : 1);
            }

            // Now find the total cost of the items
            double totalCost = 0.0;
            for (int index = 0; index < itemPriceListCopy.Count; index++)
            {
                totalCost = totalCost + itemPriceListCopy[index];
            }

            return totalCost;
        } 
        #endregion
    }
}