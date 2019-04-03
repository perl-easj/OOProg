using System.Collections.Generic;
using System.Linq;

namespace Patterns.Composite.Simple
{
    public class LegoStructure : ILegoStructure
    {
        private List<ILegoStructure> _parts;

        public LegoStructure(List<ILegoStructure> parts)
        {
            _parts = parts;
        }

        public double TotalWeight
        {
            get { return _parts.Select(b => b.TotalWeight).Sum(); }
        }

        public int noOfBlocks
        {
            get { return _parts.Select(b => b.noOfBlocks).Sum(); }
        }

        public string Description { get { return "Composite"; } }
    }
}