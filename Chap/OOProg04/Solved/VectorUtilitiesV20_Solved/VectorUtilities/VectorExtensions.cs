using System.Collections.Generic;
using System.Linq;

namespace VectorUtilities
{
    public static class VectorExtensions
    {
        public static Vector Sum(this IEnumerable<Vector> vectors)
        {
            var enumerated = vectors.ToList();
            return new Vector(enumerated.Select(v => v.X).Sum(), enumerated.Select(v => v.Y).Sum());
        }
    }
}