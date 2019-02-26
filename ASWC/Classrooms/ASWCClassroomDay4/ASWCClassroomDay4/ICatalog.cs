using System.Collections.Generic;

namespace ASWCClassroomDay4
{
    public interface ICatalog<T>
    {
        IEnumerable<T> All { get; }
    }
}