using System;
using System.Collections.Generic;
using System.Linq;
// ReSharper disable ReplaceWithSingleAssignment.True

namespace SimpleShop
{
    public class Invoice
    {
        private ProductCatalog _products;
        public string Email { get; }
        public Dictionary<int, int> OrderItems;

        public Invoice(string email, Dictionary<int, int> orderItems, ProductCatalog products)
        {
            bool validEmail = true;

            if (!email.Contains("@"))
            {
                validEmail = false;
            }

            if (!email.Contains("."))
            {
                validEmail = false;
            }

            int indexOfAt = email.IndexOf('@');
            int indexOfDot = email.IndexOf('.');

            if (indexOfAt > indexOfDot)
            {
                validEmail = false;
            }

            if (!validEmail)
            {
                throw new ArgumentException($"Email {email} is not a valid email address");
            }

            Email = email;
            OrderItems = orderItems;

            _products = products;
        }

        public double TotalPrice
        {
            get { return OrderItems.Select(oi => _products.LookupProduct(oi.Key).Price * oi.Value).Sum(); }
        }

        public override string ToString()
        {
            string invoiceText = $"";

            foreach (var oi in OrderItems)
            {
                invoiceText += $"{oi.Value} x {_products.LookupProduct(oi.Key).Description} @ {_products.LookupProduct(oi.Key).Price} kr. :   {_products.LookupProduct(oi.Key).Price * oi.Value} kr.\n";
            }

            return invoiceText;
        }
    }
}