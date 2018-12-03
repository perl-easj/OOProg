using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SimpleRPGFromScratch.Model.Base;

namespace SimpleRPGFromScratch.Model.Catalog
{
    public class RarityTierCatalog : CatalogAppBase<RarityTier>
    {
        public override List<RarityTier> BuildObjects(DbSet<RarityTier> objects)
        {
            return objects.ToList();
        }
    }
}