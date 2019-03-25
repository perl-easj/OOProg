using System.Collections.Generic;

namespace Patterns.Composite.Items
{
    public class Goods2
    {
        public string Destination { get; }
        public List<Goods2> GoodsCollection { get; }
    }
}