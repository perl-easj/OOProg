using JustPullTheTrigger.Participants;
using JustPullTheTrigger.Targets;
using JustPullTheTrigger.Tech;

namespace JustPullTheTrigger.GoodGuys
{
    public class SpyInRussia : ParticipantBase
    {
        #region Constructor
        public SpyInRussia()
        {
            RussianGangster rg = new RussianGangster("Terpentin");
            Email mail = new Email(Description, "Goverment", "Next Bad Guy", "See enclosed material", rg);
            EmailHandler.Instance.Send(mail);
            Report($"Target information on {rg.Name} sent to Goverment...");
        }
        #endregion

        #region Properties
        public override string Description
        {
            get { return "Russian Spy"; }
        }
        #endregion
    }
}