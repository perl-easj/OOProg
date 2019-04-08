namespace SimpleShop.Domain
{
    public class Invoice
    {
        public Order _order;

        public Invoice(Order order)
        {
            _order = order;
        }

        public double TotalPrice
        {
            get { return _order.TotalPrice; }
        }

        public Customer TheCustomer
        {
            get { return _order.TheCustomer; }
        }

        public override string ToString()
        {
            string invoiceText = $"";

            foreach (var oi in _order.OrderLines)
            {
                Product prod = _order.Products.Lookup(oi.Key);
                double price = prod.Price;
                int quantity = oi.Value;

                invoiceText += $"{quantity} x {prod.Description} @ {price} kr. :   {price * quantity} kr.\n";
            }

            return invoiceText;
        }
    }
}