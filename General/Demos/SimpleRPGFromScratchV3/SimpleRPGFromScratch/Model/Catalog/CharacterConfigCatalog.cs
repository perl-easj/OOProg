using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SimpleRPGFromScratch.Model.Base;

namespace SimpleRPGFromScratch.Model.Catalog
{
    public class CharacterConfigCatalog : CatalogAppBase<CharacterConfig>
    {
        public override List<CharacterConfig> BuildObjects(DbSet<CharacterConfig> objects)
        {
            return objects
                .Include(obj => obj.Character)

                .Include(obj => obj.WeaponIdLeftNavigation)
                  .ThenInclude(obj => obj.WeaponModel)
                    .ThenInclude(obj => obj.WeaponType)
                .Include(obj => obj.WeaponIdLeftNavigation)
                  .ThenInclude(obj => obj.Jewels)
                    .ThenInclude(obj => obj.JewelModel)
                      .ThenInclude(obj => obj.WeaponJewelMatches)
                .Include(obj => obj.WeaponIdLeftNavigation)
                  .ThenInclude(obj => obj.Jewels)
                    .ThenInclude(obj => obj.CutQuality)

                .Include(obj => obj.WeaponIdRightNavigation)
                  .ThenInclude(obj => obj.WeaponModel)
                    .ThenInclude(obj => obj.WeaponType)
                .Include(obj => obj.WeaponIdRightNavigation)
                  .ThenInclude(obj => obj.Jewels)
                    .ThenInclude(obj => obj.JewelModel)
                      .ThenInclude(obj => obj.WeaponJewelMatches)
                .Include(obj => obj.WeaponIdLeftNavigation)
                  .ThenInclude(obj => obj.Jewels)
                    .ThenInclude(obj => obj.CutQuality)

                .ToList();
        }
    }
}