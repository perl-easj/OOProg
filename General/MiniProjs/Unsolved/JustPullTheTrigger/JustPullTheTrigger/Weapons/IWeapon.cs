using JustPullTheTrigger.Ammo;
using JustPullTheTrigger.Targets;

namespace JustPullTheTrigger.Weapons
{
    public interface IWeapon
    {
        bool AmmoLeft { get; }
        void PointAt(ITarget target);
        void Fire();
    }
}