namespace JustPullTheTrigger.Ammo
{
    public class Cal38 : IAmmo
    {
        #region Methods
        public virtual int DamageInflicted()
        {
            return 30;
        }
        #endregion
    }
}