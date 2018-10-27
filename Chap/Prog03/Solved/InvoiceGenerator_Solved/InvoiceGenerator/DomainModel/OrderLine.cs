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

        #region Added properties
        // The below properties were added to simplify
        // queries involving OrderLine objects.
        // This is reasonable, since these properties are 
        // indeed OrderLine-specific properties.

        private static Discounts _discounts = new Discounts();

        // Original price for ordered quantity of product, i.e. without discount.
        public double Price
        {
            get { return OrderedProduct.Price * Quantity; }
        }

        // Discount percentage (depends both on Product and Order,
        // i.e. the Order this OrderLine is part of)
        public double DiscountPercent
        {
            get { return _discounts.GetDiscountPercentage(ContainingOrder, OrderedProduct); }
        }

        // Discounted price for ordered quantity of product
        public double DiscountedPrice
        {
            get { return Price * (100 - DiscountPercent) / 100.0; }
        }

        // Discount amount for a single product item.
        public double DiscountPerItem
        {
            get { return (OrderedProduct.Price * DiscountPercent) / 100.0; }
        }

        // Total discount given for this specific OrderLine.
        public double TotalDiscount
        {
            get { return Price - DiscountedPrice; }
        }
        #endregion
    }
}