using JustPullTheTrigger.Participants;
using JustPullTheTrigger.Targets;
using JustPullTheTrigger.Tech;

namespace JustPullTheTrigger.GoodGuys
{
    public class BlackOps : ParticipantBase
    {
        #region Constructor
        public BlackOps()
        {
            EmailHandler._interceptor = eh => EmailHandlerProxy.Instance;
        }
        #endregion

        #region Methods
        public override string Description
        {
            get { return "Rema 1000 in Faxe Ladeplads"; }
        }

        public override void Report(string info)
        {
            // ..shhh
        }

        public static bool Intercept(Email mail)
        {
            return mail.Receiver == "Goverment" && mail.Target?.Name == "Terpentin";
        }

        public static INamedTarget CreateProxy(INamedTarget target)
        {
            return new RussianGangsterProxy(target.Name);
        }
        #endregion
    }
}