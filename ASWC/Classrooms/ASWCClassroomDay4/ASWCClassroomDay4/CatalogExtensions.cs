using System.Linq;

namespace ASWCClassroomDay4
{
    public static class CatalogExtensions
    {
        public static int HowMany<T>(this ICatalog<T> catalog)
        {
            return catalog.All.Count();
        }
    }
}