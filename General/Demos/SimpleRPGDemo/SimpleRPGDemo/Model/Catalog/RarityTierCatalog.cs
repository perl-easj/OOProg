using SimpleRPGDemo.Data;
using SimpleRPGDemo.Data.Validators;
using SimpleRPGDemo.Model.Base;

namespace SimpleRPGDemo.Model.Catalog
{
    public class RarityTierCatalog : CatalogAppBase<RarityTier>
    {
        public RarityTierCatalog()
        {
            Validator = new RarityTierValidator(this);
        }
    }
}