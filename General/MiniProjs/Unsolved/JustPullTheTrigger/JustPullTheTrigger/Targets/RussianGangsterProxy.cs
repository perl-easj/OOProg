namespace JustPullTheTrigger.Targets
{
    public class RussianGangsterProxy : RussianGangster
    {
        #region Instance fields
        private bool _isHit;
        #endregion

        #region Constructor
        public RussianGangsterProxy(string name) : base(name)
        {
            _isHit = false;
        }
        #endregion

        #region Properties
        public override bool IsDown
        {
            get { return _isHit; }
        }

        public override string Description
        {
            get { return Name + " (Proxy)"; }
        }
        #endregion

        #region Methods
        public override void ReceiveDamage(int amount)
        {
            _isHit = true;
        }

        public override void DeathSalute()
        {
            base.DeathSalute();
            Report("(Well, not really, heh heh...)");
        }
        #endregion
    }
}