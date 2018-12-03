using System.Linq;
using SimpleRPGFromScratch.Data.Base;

namespace SimpleRPGFromScratch
{
    public partial class Weapon : DomainClassBase<Weapon>
    {
        public override int GetId()
        {
            return Id;
        }

        public override void SetId(int id)
        {
            Id = id;
        }

        public override void CopyValuesFromObj(Weapon obj)
        {
            WeaponModelId = obj.WeaponModelId;
            CharacterId = obj.CharacterId;
        }

        public double MinDamage
        {
            get { return WeaponModel != null ? WeaponModel.MinDamage + JewelDamage : 0; }
        }

        public double MaxDamage
        {
            get { return WeaponModel != null ? WeaponModel.MaxDamage + JewelDamage : 0; }
        }

        public int Sockets
        {
            get { return WeaponModel?.JewelSockets ?? 0; }
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