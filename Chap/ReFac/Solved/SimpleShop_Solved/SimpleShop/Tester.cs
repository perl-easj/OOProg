using System;
using System.Collections.Generic;
using SimpleShop.Catalogs;
using SimpleShop.Domain;
using SimpleShop.Util;

namespace SimpleShop
{
    public class Tester
    {
        private ProductCatalog _products;
        private CustomerCatalog _customers;
        private List<Order> _orders;
        private List<Invoice> _invoices;

        public Tester()
        {
            _products = new ProductCatalog();
            _customers = new CustomerCatalog();

            _orders = new List<Order>();
            _invoices = new List<Invoice>();

            Setup();
        }

        private void Setup()
        {
            Order o1 = CreateOrder(_customers.Lookup(1));
            o1.AddOrderLine(2, 2);
            o1.AddOrderLine(4, 1);

            Order o2 = CreateOrder(_customers.Lookup(2));
            o2.AddOrderLine(1, 3);
            o2.AddOrderLine(2, 1);
            o2.AddOrderLine(4, 2);
            o2.AddOrderLine(5, 1);

            Order o3 = CreateOrder(_customers.Lookup(3));
            o3.AddOrderLine(3, 2);
            o3.AddOrderLine(4, 1);
            o3.AddOrderLine(5, 2);

            Order o4 = CreateOrder(_customers.Lookup(2));
            o4.AddOrderLine(1, 6);
            o4.AddOrderLine(2, 2);

            _orders = new List<Order> { o1, o2, o3, o4 };
            _orders.ForEach(o => _invoices.Add(CreateInvoice(o)));
        }

        public void Run()
        {
            _invoices.ForEach(inv => Console.WriteLine(SendInvoiceEmail(inv)));
        }

        public string TestCase(int invIndex)
        {
            return SendInvoiceEmail(_invoices[invIndex]);
        }

        public string SendInvoiceEmail(Invoice inv)
        {
            return InvoiceMailer.SendInvoice(inv.TheCustomer.EmailAddress.Address, inv.TotalPrice, inv.ToString());
        }

        private Order CreateOrder(Customer theCustomer)
        {
            return new Order(theCustomer, _products);
        }

        private Invoice CreateInvoice(Order anOrder)
        {
            return new Invoice(anOrder);
        }
    }
}