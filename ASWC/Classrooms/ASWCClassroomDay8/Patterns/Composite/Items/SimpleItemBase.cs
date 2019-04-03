using System.Collections.Generic;
using Patterns.Composite.Interface;

namespace Patterns.Composite.Items
{
    public class SimpleItemBase : ICompositable
    {
        public double Price { get; }
        public double Weight { get; }
        public IEnumerable<ICompositable> Children
        {
            get { return null; }
        }

        public SimpleItemBase(double price, double weight)
        {
            Price = price;
            Weight = weight;
        }
    }
}