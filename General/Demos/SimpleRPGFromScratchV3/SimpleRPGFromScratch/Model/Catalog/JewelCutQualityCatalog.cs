using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SimpleRPGFromScratch.Model.Base;

namespace SimpleRPGFromScratch.Model.Catalog
{
    public class JewelCutQualityCatalog : CatalogAppBase<JewelCutQuality>
    {
        public override List<JewelCutQuality> BuildObjects(DbSet<JewelCutQuality> objects)
        {
            return objects.ToList();
        }
    }
}