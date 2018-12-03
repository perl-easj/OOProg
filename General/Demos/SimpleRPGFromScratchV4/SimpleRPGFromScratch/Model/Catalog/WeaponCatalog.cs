using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SimpleRPGFromScratch.Model.Base;

namespace SimpleRPGFromScratch.Model.Catalog
{
    public class WeaponCatalog : CatalogAppBase<Weapon>
    {
        public override List<Weapon> BuildObjects(DbSet<Weapon> objects)
        {
            return objects
                .Include(obj => obj.Character)
                .Include(obj => obj.WeaponModel)
                  .ThenInclude(obj => obj.WeaponType)
                .Include(obj => obj.Jewels)
                  .ThenInclude(obj => obj.JewelModel)
                    .ThenInclude(obj => obj.WeaponJewelMatches)
                .Include(obj => obj.Jewels)
                  .ThenInclude(obj => obj.CutQuality)
                .ToList();
        }
    }
}