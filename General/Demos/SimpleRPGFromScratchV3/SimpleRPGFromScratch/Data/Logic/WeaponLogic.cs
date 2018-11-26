// HISTORIK:
// v.1.0 : Oprettet, override af ToString.
//

using System.Linq;
using SimpleRPGFromScratch.Data.Base;

namespace SimpleRPGFromScratch
{
    public partial class Weapon : DomainClassBase
    {
        public override int GetId()
        {
            return Id;
        }

        public override void SetId(int id)
        {
            Id = id;
        }

        public double MinDamage
        {
            get { return WeaponModel.MinDamage + JewelDamage; }
        }

        public double MaxDamage
        {
            get { return WeaponModel.MaxDamage + JewelDamage; }
        }

        public int Sockets
        {
            get { return WeaponModel.JewelSockets; }
        }

        public int SocketsUsed
        {
            get { return Jewels.Count; }
        }

        public double JewelDamage
        {
            get { return Jewels.Select(obj => obj.BaseDamage).Sum(); }
        }
    }
}