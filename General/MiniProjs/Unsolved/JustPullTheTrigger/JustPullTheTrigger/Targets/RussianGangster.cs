using JustPullTheTrigger.Ammo;
using JustPullTheTrigger.Participants;

namespace JustPullTheTrigger.Targets
{
    public class RussianGangster : ParticipantBase, INamedTarget
    {
        #region Instance fields
        private string _name;
        private int _hp;
        #endregion

        #region Constructor
        public RussianGangster(string name)
        {
            _name = name;
            _hp = 200;
        }
        #endregion

        #region Properties
        public virtual bool IsDown
        {
            get { return _hp <= 0; }
        }

        public string Name
        {
            get { return _name; }
        }

        public override string Description
        {
            get { return Name; }
        }
        #endregion

        #region Methods
        public void Hit(IAmmo ammo)
        {
            ReceiveDamage(ammo.DamageInflicted());

            if (IsDown)
            {
                DeathSalute();
            }
        }

        public virtual void ReceiveDamage(int amount)
        {
            _hp = _hp - amount;
        }

        public virtual void DeathSalute()
        {
            Report($"I, the great {Name}, died!");
        }
        #endregion
    }
}