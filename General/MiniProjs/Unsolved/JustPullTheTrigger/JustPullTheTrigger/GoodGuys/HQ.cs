using JustPullTheTrigger.Ammo;
using JustPullTheTrigger.Participants;
using JustPullTheTrigger.Targets;
using JustPullTheTrigger.Weapons;

namespace JustPullTheTrigger.GoodGuys
{
    public class HQ : ParticipantBase
    {
        #region Instance fields
        private Director _director;
        private MissionStatus _missionStatus;
        #endregion

        #region Constructor
        public HQ()
        {
            _missionStatus = MissionStatus.Waiting;
            _director = new Director();
        }
        #endregion

        #region Properties
        public MissionStatus Status
        {
            get { return _missionStatus; }
        }

        public override string Description
        {
            get { return "HQ"; }
        }
        #endregion

        #region Methods
        public void ExecuteMission(INamedTarget target)
        {
            Report($"Mission on elimination of {target.Name} initiated...");
            Agent theAgent = new Agent();

            ILoadableWeapon theGun = _director.PickWeapon();
            _director.LoadWeapon(theGun, new AmmoFactory());

            Report("Preparing agent for mission...");
            theAgent.PrepareForMission(theGun, target);

            Report("Agent is now executing mission...");
            theAgent.Execute();

            _missionStatus = theAgent.Debrief();

            if (_missionStatus == MissionStatus.Success)
            {
                Report("Mission was successful, thanks to our perfect planning!!");
            }
            else
            {
                Report("Mission failed... Agent will be held responsible");
            }
        }
        #endregion
    }
}