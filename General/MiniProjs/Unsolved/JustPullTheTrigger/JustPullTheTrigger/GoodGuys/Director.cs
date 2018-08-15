using JustPullTheTrigger.Ammo;
using JustPullTheTrigger.Participants;
using JustPullTheTrigger.Weapons;

namespace JustPullTheTrigger.GoodGuys
{
    public class Director : ParticipantBase
    {
        #region Instance fields
        public static bool DoIKnow = true;
        #endregion

        #region Properties
        public override string Description
        {
            get { return "Director"; }
        }
        #endregion

        #region Methods
        public ILoadableWeapon PickWeapon()
        {
            Report("Picked agent's weapon for mission...");
            return new Gun38Cal();
        }

        public void LoadWeapon(ILoadableWeapon aGun, IAmmoFactory aFactory)
        {
            for (int i = 0; i < 10; i++)
            {
                aGun.LoadAmmo(aFactory.Create());
            }

            Report("Loaded agent's weapon for mission...");
        } 
        #endregion
    }
}