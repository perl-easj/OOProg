using JustPullTheTrigger.Ammo;

namespace JustPullTheTrigger.Targets
{
    public interface ITarget
    {
        bool IsDown { get; }
        void Hit(IAmmo ammo);
        void ReceiveDamage(int amount);
        void DeathSalute();
    }
}