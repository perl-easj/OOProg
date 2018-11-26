using SimpleRPGFromScratch.Data.Base;

namespace SimpleRPGFromScratch
{
    public partial class CharacterConfig : DomainClassBase
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
            get { return CalcMinDamageLeft() + CalcMinDamageRight(); }
        }

        public double MaxDamage
        {
            get { return CalcMaxDamageLeft() + CalcMaxDamageRight(); }
        }

        private double CalcMinDamageLeft()
        {
            return WeaponIdLeftNavigation?.MinDamage ?? 0;
        }

        private double CalcMinDamageRight()
        {
            return WeaponIdRightNavigation?.MinDamage ?? 0;
        }

        private double CalcMaxDamageLeft()
        {
            return WeaponIdLeftNavigation?.MaxDamage ?? 0;
        }

        private double CalcMaxDamageRight()
        {
            return WeaponIdRightNavigation?.MaxDamage ?? 0;
        }
    }
}