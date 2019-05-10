using System;
using System.Collections.Generic;

namespace CompositePattern.CompositeLibrary
{
    public abstract class CompositeBase<T> : ICompositable, IComposite<T> where T : ICompositable
    {
        private List<T> _children;

        public IEnumerable<T> Children { get { return _children; } }

        protected CompositeBase()
        {
            _children = new List<T>();
        }

        public void Add(T child)
        {
            _children.Add(child);
        }

        public void ApplyOperation(Action<ICompositable> operation)
        {
            operation(this);
            _children.ForEach(ch => ch.ApplyOperation(operation));
        }
    }
}