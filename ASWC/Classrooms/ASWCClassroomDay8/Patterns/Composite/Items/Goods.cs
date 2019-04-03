using System.Collections.Generic;
using System.Linq;
using Patterns.Composite.Interface;

namespace Patterns.Composite.Items
{
    public class Goods : ICompositable
    {
        private List<ICompositable> _children;

        public Goods(List<ICompositable> children)
        {
            _children = children;
        }

        public IEnumerable<ICompositable> Children
        {
            get { return _children; }
        }

        public double Price
        {
            get { return _children.Sum(i => i.Price); }
        }

        public double Weight
        {
            get { return _children.Sum(i => i.Weight); }
        }
    }
}