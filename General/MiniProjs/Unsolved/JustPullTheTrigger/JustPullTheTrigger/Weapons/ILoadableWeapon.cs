using JustPullTheTrigger.Ammo;

namespace JustPullTheTrigger.Weapons
{
    public interface ILoadableWeapon : IWeapon
    {
        void LoadAmmo(IAmmo ammo);
    }
}