namespace JustPullTheTrigger.Ammo
{
    public class Cal38Blank : Cal38
    {
        #region Constructor
        public Cal38Blank()
        {
            Program._hint = true;
        }
        #endregion

        #region Methods
        public override int DamageInflicted()
        {
            return 0;
        }
        #endregion
    }
}