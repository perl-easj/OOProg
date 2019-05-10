using System.Collections.Generic;
using System.Data;
using System.Linq;
using RPGDemo19NOV.Model.Base;

namespace RPGDemo19NOV.Model.Catalog
{
    public class WeaponCatalog : CatalogEFBase<Weapon>
    { }

    //public class WeaponCatalog
    //{
    //    private RPGDBContext _context;

    //    public WeaponCatalog()
    //    {
    //        _context = new RPGDBContext();
    //    }

    //    public List<Weapon> All
    //    {
    //        get { return _context.Weapons.ToList(); }
    //    }

    //    public void Create(Weapon obj)
    //    {
    //        _context.Weapons.Add(obj);
    //        _context.SaveChanges();
    //    }

    //    public void Delete(int id)
    //    {
    //        Weapon w = _context.Weapons.Find(id);
    //        if (w != null)
    //        {
    //            _context.Weapons.Remove(w);
    //            _context.SaveChanges();
    //        }
    //    }

    //    public Weapon Read(int id)
    //    {
    //        return _context.Weapons.Find(id);
    //    }
    //}
}