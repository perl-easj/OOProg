using System.Collections.Generic;
using SimpleRPGDemo.Data.Base;

namespace SimpleRPGDemo.Data
{
    public partial class RarityTier
    {
        public RarityTier()
        {
            JewelModels = new HashSet<JewelModel>();
            WeaponModels = new HashSet<WeaponModel>();
        }

        public override int Id { get; set; }
        public string Description { get; set; }

        public ICollection<JewelModel> JewelModels { get; set; }
        public ICollection<WeaponModel> WeaponModels { get; set; }
    }
}
