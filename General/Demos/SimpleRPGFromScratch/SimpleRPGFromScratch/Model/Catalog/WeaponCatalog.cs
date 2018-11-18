// HISTORIK:
// v.1.0 : Oprettet, brug af intern List<Weapon>
// v.2.0 : Omskrevet til at benytte EF Core (SimpleRPGDBContext)
// v.3.0 : Omskrevet til at benytte Include + ThenInclude kald
// v.4.0 : Omskrevet til at benytte CatalogAppBase
//

using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SimpleRPGFromScratch.Model.Base;

namespace SimpleRPGFromScratch.Model.Catalog
{
    public class WeaponCatalog : CatalogAppBase<Weapon>
    {
        public override bool IdMatch(Weapon obj, int id)
        {
            return obj.Id == id;
        }

        public override List<Weapon> BuildObjects(DbSet<Weapon> objects)
        {
            return objects
                .Include(w => w.Character)
                .Include(w => w.WeaponModel)
                .ThenInclude(wm => wm.WeaponType)
                .ToList();
        }
    }

    #region Version 3.0
    //Version 3.0
    //
    //public class WeaponCatalog
    //{
    //    private SimpleRPGDBContext _dbContext;

    //    public WeaponCatalog()
    //    {
    //        _dbContext = new SimpleRPGDBContext();
    //    }

    //    public List<Weapon> All
    //    {
    //        get
    //        { return _dbContext.Weapons
    //            .Include(w => w.Character)
    //            .Include(w => w.WeaponModel)
    //            .ThenInclude(wm => wm.WeaponType)
    //            .ToList();
    //        }
    //    }

    //    public void Create(Weapon aWeapon)
    //    {
    //        _dbContext.Weapons.Add(aWeapon);
    //        _dbContext.SaveChanges();
    //    }

    //    public Weapon Read(int id)
    //    {
    //        return All.Find(w => w.Id == id);
    //    }

    //    public void Delete(int id)
    //    {
    //        Weapon w = Read(id);
    //        if (w != null)
    //        {
    //            _dbContext.Weapons.Remove(w);
    //            _dbContext.SaveChanges();
    //        }
    //    }
    //} 
    #endregion

    #region Version 2.0
    //Version 2.0
    //
    //public class WeaponCatalog
    //{
    //    private SimpleRPGDBContext _dbContext;

    //    public WeaponCatalog()
    //    {
    //        _dbContext = new SimpleRPGDBContext();
    //    }

    //    public List<Weapon> All
    //    {
    //        get { return _dbContext.Weapons.ToList(); }
    //    }

    //    public void Create(Weapon aWeapon)
    //    {
    //        _dbContext.Weapons.Add(aWeapon);
    //        _dbContext.SaveChanges();
    //    }

    //    public Weapon Read(int id)
    //    {
    //        return All.Find(w => w.Id == id);
    //    }

    //    public void Delete(int id)
    //    {
    //        Weapon w = Read(id);
    //        if (w != null)
    //        {
    //            _dbContext.Weapons.Remove(w);
    //            _dbContext.SaveChanges();
    //        }
    //    }
    //} 
    #endregion

    #region Version 1.0
    //Version 1.0
    //
    //public class WeaponCatalog
    //{
    //    private List<Weapon> _weapons;

    //    public WeaponCatalog()
    //    {
    //        _weapons = new List<Weapon>();
    //        _weapons.Add(new Weapon { Id = 1 });
    //        _weapons.Add(new Weapon { Id = 2 });
    //        _weapons.Add(new Weapon { Id = 3 });
    //    }

    //    public List<Weapon> All
    //    {
    //        get { return _weapons; }
    //    }

    //    public void Create(Weapon aWeapon)
    //    {
    //        _weapons.Add(aWeapon);
    //    }

    //    public Weapon Read(int id)
    //    {
    //        foreach (Weapon w in _weapons)
    //        {
    //            if (w.Id == id)
    //            {
    //                return w;
    //            }
    //        }

    //        return null;
    //    }

    //    public void Delete(int id)
    //    {
    //        for (int i = 0; i < _weapons.Count; i++)
    //        {
    //            if (_weapons[i].Id == id)
    //            {
    //                _weapons.RemoveAt(i);
    //                return;
    //            }
    //        }
    //    }
    //} 
    #endregion
}