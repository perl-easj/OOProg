using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SimpleRPGFromScratch.Model.Base;

namespace SimpleRPGFromScratch.Model.Catalog
{
    public class WeaponModelCatalog : CatalogAppBase<WeaponModel>
    {
        public override List<WeaponModel> BuildObjects(DbSet<WeaponModel> objects)
        {
            return objects
                .Include(obj => obj.WeaponType)
                .Include(obj => obj.RarityTier)
                .ToList();
        }
    }
}