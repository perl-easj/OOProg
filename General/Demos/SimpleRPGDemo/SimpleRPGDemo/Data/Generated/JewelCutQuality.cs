using System.Collections.Generic;

namespace SimpleRPGDemo.Data
{
    public partial class JewelCutQuality
    {
        public JewelCutQuality()
        {
            Jewels = new HashSet<Jewel>();
        }

        public override int Id { get; set; }
        public string Description { get; set; }
        public double Factor { get; set; }

        public ICollection<Jewel> Jewels { get; set; }
    }
}
