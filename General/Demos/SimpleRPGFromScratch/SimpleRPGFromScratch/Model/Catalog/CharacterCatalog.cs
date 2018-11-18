// HISTORIK:
// v.1.0 : Oprettet, overrides af IdMatch og BuildObjects
//

using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SimpleRPGFromScratch.Model.Base;

namespace SimpleRPGFromScratch.Model.Catalog
{
    public class CharacterCatalog : CatalogAppBase<Character>
    {
        public override bool IdMatch(Character obj, int id)
        {
            return obj.Id == id;
        }

        public override List<Character> BuildObjects(DbSet<Character> objects)
        {
            return objects.ToList();
        }
    }
}