using System.Collections.Generic;

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