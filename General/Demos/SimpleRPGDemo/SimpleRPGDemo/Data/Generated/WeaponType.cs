using System.Collections.Generic;

namespace SimpleRPGDemo.Data
{
    public partial class WeaponType
    {
        public WeaponType()
        {
            WeaponModels = new HashSet<WeaponModel>();
        }

        public override int Id { get; set; }
        public string Description { get; set; }
        public int HandsRequired { get; set; }

        public ICollection<WeaponModel> WeaponModels { get; set; }
    }
}
