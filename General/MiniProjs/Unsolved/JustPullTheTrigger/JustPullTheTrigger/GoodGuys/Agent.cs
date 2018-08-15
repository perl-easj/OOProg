using JustPullTheTrigger.Participants;
using JustPullTheTrigger.Targets;
using JustPullTheTrigger.Weapons;

namespace JustPullTheTrigger.GoodGuys
{
    public class Agent : ParticipantBase
    {
        #region Instance fields
        private IWeapon _weapon;
        private ITarget _target;
        private MissionStatus _missionStatus;
        #endregion

        #region Constructor
        public Agent()
        {
            _weapon = null;
            _target = null;
            _missionStatus = MissionStatus.Waiting;
        }
        #endregion

        #region Properties
        public override string Description
        {
            get { return "Agent"; }
        }
        #endregion

        #region Methods
        public void PrepareForMission(IWeapon weapon, ITarget target)
        {
            _weapon = weapon;
            _target = target;

            Report("Prepared for mission!!");
        }

        public void Execute()
        {
            if (_weapon != null && _target != null)
            {
                Report("Target in sight, preparing to fire...");
                _weapon.PointAt(_target);

                while (!_target.IsDown && _weapon.AmmoLeft)
                {
                    Report("Firing shot...");
                    _weapon.Fire();
                }

                if (!_target.IsDown)
                {
                    Report("I'm out of ammo!!");
                    _missionStatus = MissionStatus.Failed;
                }
                else
                {
                    Report("Target down!!");
                    _missionStatus = MissionStatus.Success;
                }
            }
            else
            {
                Report("I was not prepared for this mission!!");
                _missionStatus = MissionStatus.Failed;
            }
        }

        public MissionStatus Debrief()
        {
            MissionStatus completedMissionStatus = _missionStatus;
            _weapon = null;
            _target = null;
            _missionStatus = MissionStatus.Waiting;

            Report("Debriefed, awaiting new mission...");
            return completedMissionStatus;
        }
        #endregion
    }
}