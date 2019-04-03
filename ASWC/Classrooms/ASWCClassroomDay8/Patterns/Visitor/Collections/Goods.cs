using System.Collections.Generic;
using System.Linq;
using Patterns.Visitor.Interfaces;

namespace Patterns.Visitor.Collections
{
    /// <summary>
    /// Responsible for choosing a specific container
    /// (a List) in which visitable items are stored.
    /// </summary>
    public class Goods : VisitableCollectionBase
    {
        private List<IVisitable> _items;
        public Goods(IEnumerable<IVisitable> collection) 
            : base(collection)
        {
        }

        protected override IEnumerable<IVisitable> Collection
        {
            get { return _items; }
            set { _items = value.ToList(); }
        }
    }
}