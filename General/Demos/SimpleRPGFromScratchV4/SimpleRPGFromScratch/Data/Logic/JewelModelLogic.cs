using SimpleRPGFromScratch.Data.Base;

namespace SimpleRPGFromScratch
{
    public partial class JewelModel : DomainClassBase<JewelModel>
    {
        public const int MaxBaseDamage = 200;

        public string ImageSource
        {
            get { return $"../../Assets/{Description}.png"; }
        }

        public override int GetId()
        {
            return Id;
        }

        public override void SetId(int id)
        {
            Id = id;
        }

        public override void CopyValuesFromObj(JewelModel obj)
        {
            Description = obj.Description;
            RarityTierId = obj.RarityTierId;
            BaseDamage = obj.BaseDamage;
        }
    }
}