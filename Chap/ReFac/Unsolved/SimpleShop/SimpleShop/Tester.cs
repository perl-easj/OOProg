using System;
using System.Collections.Generic;

namespace SimpleShop
{
    public class Tester
    {
        private ProductCatalog _products;
        private List<Order> _orders;
        private List<Invoice> _invoices;

        public Tester()
        {
            _products = new ProductCatalog();
            _orders = new List<Order>();
            _invoices = new List<Invoice>();

            Setup();
        }

        private void Setup()
        {
            Order o1 = new Order("Anne", "Andersen", "Solvej 12", "anne@mail.dk");
            o1.AddOrderLine(2, 2);
            o1.AddOrderLine(4, 1);

            Order o2 = new Order("Bent", "Benthin", "Violhaven 29", "bent_benthin@waoo.dk");
            o2.AddOrderLine(1, 3);
            o2.AddOrderLine(2, 1);
            o2.AddOrderLine(4, 2);
            o2.AddOrderLine(5, 1);

            Order o3 = new Order("Carina", "Cortsen", "Algade 80", "carina_32@mail.dk");
            o3.AddOrderLine(3, 2);
            o3.AddOrderLine(4, 1);
            o3.AddOrderLine(5, 2);

            Order o4 = new Order("Bent", "Benthin", "Violhaven 29", "bent_benthin@waoo.dk");
            o4.AddOrderLine(1, 6);
            o4.AddOrderLine(2, 2);

            _orders = new List<Order> { o1, o2, o3, o4 };

            foreach (Order o in _orders)
            {
                _invoices.Add(new Invoice(o.Email, o.OrderLines, _products));
            }
        }

        public void Run()
        {
            foreach (Invoice i in _invoices)
            {
                string emailSent = InvoiceMailer.SendInvoice(i.Email, i.TotalPrice, i.ToString());
                Console.WriteLine(emailSent);
            }
        }

        public string TestCase(int invIndex)
        {
            Invoice inv = _invoices[invIndex];
            return InvoiceMailer.SendInvoice(inv.Email, inv.TotalPrice, inv.ToString());
        }
    }
}