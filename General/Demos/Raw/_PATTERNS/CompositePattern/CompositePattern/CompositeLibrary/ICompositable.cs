using System;

namespace CompositePattern.CompositeLibrary
{
    public interface ICompositable
    {
        void ApplyOperation(Action<ICompositable> operation);
    }
}