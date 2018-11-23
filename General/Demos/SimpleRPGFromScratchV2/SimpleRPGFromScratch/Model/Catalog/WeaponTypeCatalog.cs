using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SimpleRPGFromScratch.Model.Base;

namespace SimpleRPGFromScratch.Model.Catalog
{
    public class WeaponTypeCatalog : CatalogAppBase<WeaponType>
    {
        public override List<WeaponType> BuildObjects(DbSet<WeaponType> objects)
        {
            return objects.ToList();
        }
    }
}