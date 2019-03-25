using System.Collections.Generic;
using Patterns.Visitor.Interfaces;

namespace Patterns.Visitor.Collections
{
    /// <summary>
    /// Base class for IVisitableCollection. Responsible for
    /// implementing algorithm for applying a gven visitor
    /// to the Collection property.
    /// </summary>
    public abstract class VisitableCollectionBase : IVisitableCollection
    {
        protected abstract IEnumerable<IVisitable> Collection { get; set; }

        protected VisitableCollectionBase(IEnumerable<IVisitable> collection)
        {
            Collection = collection;
        }

        public void ApplyVisitor(IVisitor visitor)
        {
            foreach (IVisitable item in Collection)
            {
                item.Accept(visitor);
            }
        }
    }
}