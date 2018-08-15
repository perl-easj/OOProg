using JustPullTheTrigger.Participants;
using JustPullTheTrigger.Targets;
using JustPullTheTrigger.Tech;
// ReSharper disable ConvertIfStatementToConditionalTernaryExpression
// ReSharper disable UnusedMember.Local
// ReSharper disable NotAccessedField.Local

namespace JustPullTheTrigger.GoodGuys
{
    public class Goverment : ParticipantBase
    {
        #region Singleton implementation
        private BlackOps _blackOps = new BlackOps();
        private static Goverment _instance;
        public static Goverment Instance
        {
            get
            {
                _instance = _instance ?? new Goverment();
                return _instance;
            }
        }
        #endregion

        #region Instance fields
        private SpyInRussia _spyInRussia;
        private HQ _hq;
        #endregion

        #region Constructor
        private Goverment()
        {
            _spyInRussia = new SpyInRussia();
            _hq = new HQ();
        }
        #endregion

        #region Methods
        public void EliminateRussianBadGuy()
        {
            Email mail = EmailHandler.Instance.Receive(Description);
            INamedTarget theTarget = mail?.Target;
            Report($"Information on {theTarget?.Name} acquired from our Russian Spy...");

            Report($"Initiating mission to eliminate {theTarget?.Name}...");
            _hq.ExecuteMission(theTarget);

            if (_hq.Status == MissionStatus.Success)
            {
                Report("Mission was successful, thanks to our competent Headquarters!!");
            }
            else
            {
                Report("Mission was mostly successful, thanks to our Headquarters!!");
            }
        }

        public override string Description
        {
            get { return "Goverment"; }
        }
        #endregion
    }
}