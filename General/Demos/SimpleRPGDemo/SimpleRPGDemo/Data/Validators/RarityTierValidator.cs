using System.Linq;
using Model.Interfaces;
using SimpleRPGDemo.Data.Base;

namespace SimpleRPGDemo.Data.Validators
{
    public class RarityTierValidator : ValidatorBase<RarityTier>
    {
        public RarityTierValidator(ICatalog<RarityTier> catalog) : base(catalog)
        {
        }

        protected override bool ValidateObject(RarityTier obj)
        {
            return !Catalog.All.Select(rt => rt.Description).Contains(obj.Description);
        }

        public override string ValidationErrorString(RarityTier obj)
        {
            return $"The description {obj.Description} is already used for a Tier description";
        }
    }
}