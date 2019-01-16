namespace ReportTool.DomainClasses
{
    /// <summary>
    /// Simple domain class representing a product.
    /// </summary>
    public class Product
    {
        #region Properties
        public int ProductId { get; }
        public string Description { get; set; }
        public double Weight { get; }
        #endregion

        #region Constructor
        public Product(int productId, string description, double weight)
        {
            ProductId = productId;
            Description = description;
            Weight = weight;
        } 
        #endregion
    }
}