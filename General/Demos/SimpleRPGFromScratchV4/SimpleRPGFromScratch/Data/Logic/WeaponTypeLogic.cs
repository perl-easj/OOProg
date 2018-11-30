using SimpleRPGFromScratch.Data.Base;

namespace SimpleRPGFromScratch
{
    public partial class WeaponType : DomainClassBase<WeaponType>
    {
        public override int GetId()
        {
            return Id;
        }

        public override void SetId(int id)
        {
            Id = id;
        }

        public bool IsTwoHanded()
        {
            return HandsRequired == 2;
        }

        public override void CopyValuesFromObj(WeaponType obj)
        {
            Description = obj.Description;
            HandsRequired = obj.HandsRequired;
        }
    }
}