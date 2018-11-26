using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SimpleRPGFromScratch.Model.Base;

namespace SimpleRPGFromScratch.Model.Catalog
{
    public class JewelModelCatalog : CatalogAppBase<JewelModel>
    {
        public override List<JewelModel> BuildObjects(DbSet<JewelModel> objects)
        {
            return objects
                .Include(obj => obj.RarityTier)
                .ToList();
        }
    }
}