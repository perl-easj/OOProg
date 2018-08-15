using JustPullTheTrigger.GoodGuys;

namespace JustPullTheTrigger.Ammo
{
    public class AmmoFactory : IAmmoFactory
    {
        public IAmmo Create()
        {
            return Director.DoIKnow ? new Cal38Blank() : new Cal38();
        }
    }
}