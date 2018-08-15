using System.Collections.Generic;
using JustPullTheTrigger.Ammo;
using JustPullTheTrigger.Targets;

namespace JustPullTheTrigger.Weapons
{
    public class Gun38Cal : ILoadableWeapon
    {
        #region Instance fields
        private List<IAmmo> _ammo;
        private ITarget _target;
        #endregion

        #region Constructor
        public Gun38Cal()
        {
            _ammo = new List<IAmmo>();
        }
        #endregion

        #region Properties
        public bool AmmoLeft
        {
            get { return _ammo.Count > 0; }
        }
        #endregion

        #region Methods
        public void LoadAmmo(IAmmo ammo)
        {
            _ammo.Add(ammo);
        }

        public void PointAt(ITarget target)
        {
            _target = target;
        }

        public void Fire()
        {
            if (AmmoLeft)
            {
                _target.Hit(_ammo[0]);
                _ammo.RemoveAt(0);
            }
        }
        #endregion
    }
}