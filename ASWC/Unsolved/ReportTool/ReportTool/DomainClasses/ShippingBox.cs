namespace ReportTool.DomainClasses
{
    /// <summary>
    /// Simple domain class representing a "shipping box", i.e. a physical box
    /// which can be used to e.g. ship a product to a customer.
    /// </summary>
    public class ShippingBox
    {
        #region Properties
        public int Height { get; }
        public int Width { get; }
        public int Depth { get; }
        public string Material { get; }
        public double MaxWeight { get; }
        public int Volume { get { return Height * Width * Depth; } }
        #endregion

        #region Constructor
        public ShippingBox(int height, int width, int depth, string material, double maxWeight)
        {
            Height = height;
            Width = width;
            Depth = depth;
            Material = material;
            MaxWeight = maxWeight;
        } 
        #endregion
    }
}