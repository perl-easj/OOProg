namespace InvoiceGenerator.DomainModel
{
    /// <summary>
    /// This class represents an order line, which is a reference
    /// to a product, plus a numeric quantity. It also contains a
    /// reference back to the order which it is part of.
    /// </summary>
    public class OrderLine
    {
        public OrderLine(Order containingOrder, Product orderedProduct, int quantity)
        {
            ContainingOrder = containingOrder;
            OrderedProduct = orderedProduct;
            Quantity = quantity;
        }

        public Order ContainingOrder { get; }
        public Product OrderedProduct { get; }
        public int Quantity { get; }
    }
}