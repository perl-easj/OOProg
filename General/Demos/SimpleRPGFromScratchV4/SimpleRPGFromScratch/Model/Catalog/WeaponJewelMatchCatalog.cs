using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SimpleRPGFromScratch.Model.Base;

namespace SimpleRPGFromScratch.Model.Catalog
{
    public class WeaponJewelMatchCatalog : CatalogAppBase<WeaponJewelMatch>
    {
        public override List<WeaponJewelMatch> BuildObjects(DbSet<WeaponJewelMatch> objects)
        {
            return objects
                .Include(obj => obj.JewelModel)
                .Include(obj => obj.WeaponModel)
                .ToList();
        }
    }
}