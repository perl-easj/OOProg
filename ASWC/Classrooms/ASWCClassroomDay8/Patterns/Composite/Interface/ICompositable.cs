using System.Collections.Generic;

namespace Patterns.Composite.Interface
{
    public interface ICompositable
    {
        double Price { get; }
        double Weight { get; }
        IEnumerable<ICompositable> Children { get; }
    }
}