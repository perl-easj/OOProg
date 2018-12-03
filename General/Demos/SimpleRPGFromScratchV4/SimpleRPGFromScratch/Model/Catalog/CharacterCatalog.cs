using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SimpleRPGFromScratch.Model.Base;

namespace SimpleRPGFromScratch.Model.Catalog
{
    public class CharacterCatalog : CatalogAppBase<Character>
    {
        public override List<Character> BuildObjects(DbSet<Character> objects)
        {
            return objects.ToList();
        }
    }
}