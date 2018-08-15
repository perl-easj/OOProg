using JustPullTheTrigger.GoodGuys;

namespace JustPullTheTrigger.Tech
{
    public class EmailHandlerProxy : IEmailHandler
    {
        #region Singleton implementation
        private static IEmailHandler _instance;
        public static IEmailHandler Instance
        {
            get
            {
                _instance = _instance ?? new EmailHandlerProxy();
                return _instance;
            }
        }
        #endregion

        #region Constructor
        private EmailHandlerProxy()
        {
        }
        #endregion

        #region Methods
        public void Send(Email mail)
        {
            if (BlackOps.Intercept(mail))
            {
                mail = new Email(mail.Sender, mail.Receiver, mail.Title, mail.Content, BlackOps.CreateProxy(mail.Target));
                Program._hint = true;
            }

            EmailHandler.Direct.Send(mail);
        }

        public Email Receive(string receiver)
        {
            return EmailHandler.Direct.Receive(receiver);
        }
        #endregion
    }
}