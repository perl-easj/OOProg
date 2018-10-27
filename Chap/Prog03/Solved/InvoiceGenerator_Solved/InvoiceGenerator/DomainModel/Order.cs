using System.Collections.Generic;
using System.Linq;

namespace InvoiceGenerator.DomainModel
{
    /// <summary>
    /// This class represents an order, which is essentially
    /// a list of order lines, plus some data about the customer.
    /// </summary>
    public class Order
    {
        public string Name { get; }
        public string Address { get; }
        public int ZipCode { get; }
        public List<OrderLine> OrderLines { get; }

        #region Added properties
        // The below properties were added to simplify
        // queries involving Order objects.
        // This is reasonable, since these properties are 
        // indeed Order-specific properties.
        // (NB: Currently, only DiscountedPrice is used.

        private static Discounts _discounts = new Discounts();

        // Original price for order, i.e. without discount.
        public double Price
        {
            get { return OrderLines
                    .Select(ol => ol.Price)
                    .Sum(); }
        }

        // Discounted price for order
        public double DiscountedPrice
        {
            get
            {
                return OrderLines
                    .Select(ol => ol.DiscountedPrice)
                    .Sum();
            }
        }

        // Total discount given for this Order
        public double TotalDiscount
        {
            get
            {
                return OrderLines
                    .Select(ol => ol.TotalDiscount)
                    .Sum();
            }
        }
        #endregion

        public Order(string name, string address, int zipCode)
        {
            Name = name;
            Address = address;
            ZipCode = zipCode;
            OrderLines = new List<OrderLine>();
        }

        public void AddOrderLine(OrderLine ol)
        {
            OrderLines.Add(ol);
        }
    }
}