// HISTORIK:
// v.1.0 : Oprettet, skrevet ved copy/paste/tilret fra WeaponCatalog
// v.2.0 : Omskrevet ved brug af CatalogAppBase
//

using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SimpleRPGFromScratch.Model.Base;

namespace SimpleRPGFromScratch.Model.Catalog
{
    public class WeaponModelCatalog : CatalogAppBase<WeaponModel>
    {
        public override bool IdMatch(WeaponModel obj, int id)
        {
            return obj.Id == id;
        }

        public override List<WeaponModel> BuildObjects(DbSet<WeaponModel> objects)
        {
            return objects
                .Include(wm => wm.WeaponType)
                .ToList();
        }
    }

    #region Version 1.0
    //Version 1.0
    //
    //public class WeaponModelCatalog
    //{
    //    private SimpleRPGDBContext _dbContext;

    //    public WeaponModelCatalog()
    //    {
    //        _dbContext = new SimpleRPGDBContext();
    //    }

    //    public List<WeaponModel> All
    //    {
    //        get { return _dbContext.WeaponModels.Include(wm => wm.WeaponType).ToList(); }
    //    }

    //    public void Create(WeaponModel aWeaponModel)
    //    {
    //        _dbContext.WeaponModels.Add(aWeaponModel);
    //        _dbContext.SaveChanges();
    //    }

    //    public WeaponModel Read(int id)
    //    {
    //        return All.Find(w => w.Id == id);
    //    }

    //    public void Delete(int id)
    //    {
    //        WeaponModel wm = Read(id);
    //        if (wm != null)
    //        {
    //            _dbContext.WeaponModels.Remove(wm);
    //        }
    //    }
    //} 
    #endregion
}