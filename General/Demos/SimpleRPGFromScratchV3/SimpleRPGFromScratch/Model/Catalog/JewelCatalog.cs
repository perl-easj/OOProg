using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SimpleRPGFromScratch.Model.Base;

namespace SimpleRPGFromScratch.Model.Catalog
{
    public class JewelCatalog  : CatalogAppBase<Jewel>
    {
        public override List<Jewel> BuildObjects(DbSet<Jewel> objects)
        {
            return objects
                .Include(obj => obj.CutQuality)
                .Include(obj => obj.Weapon)
                .Include(obj => obj.JewelModel)
                  .ThenInclude(obj => obj.RarityTier)
                .ToList();
        }
    }
}