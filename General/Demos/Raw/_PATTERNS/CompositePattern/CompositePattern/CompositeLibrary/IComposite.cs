using System.Collections.Generic;

namespace CompositePattern.CompositeLibrary
{
    public interface IComposite<T> where T : ICompositable
    {
        void Add(T child);
        IEnumerable<T> Children { get; }
    }
}