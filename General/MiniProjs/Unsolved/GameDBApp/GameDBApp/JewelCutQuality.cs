using System;
using System.Collections.Generic;

namespace GameDBApp
{
    public partial class JewelCutQuality
    {
        public JewelCutQuality()
        {
            Jewels = new HashSet<Jewel>();
        }

        public string CutQuality { get; set; }
        public double Factor { get; set; }

        public ICollection<Jewel> Jewels { get; set; }
    }
}
