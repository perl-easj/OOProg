using System;
using System.Collections.Generic;

namespace JustPullTheTrigger.Tech
{
    public class EmailHandler : IEmailHandler
    {
        #region Instance fields
        private List<Email> _mails;
        public static Func<IEmailHandler, IEmailHandler> _interceptor = eh => eh;
        #endregion

        #region Singleton implementation
        private static IEmailHandler _instance;
        public static IEmailHandler Instance
        {
            get
            {
                _instance = _instance ?? new EmailHandler();
                return _interceptor(_instance);
            }
        }

        public static IEmailHandler Direct
        {
            get
            {
                _instance = _instance ?? new EmailHandler();
                return _instance;
            }
        }
        #endregion

        #region Constructor
        private EmailHandler()
        {
            _mails = new List<Email>();
        }
        #endregion

        #region Methods
        public void Send(Email mail)
        {
            _mails.Add(mail);
        }

        public Email Receive(string receiver)
        {
            for (int i = 0; i < _mails.Count; i++)
            {
                if (_mails[i].Receiver == receiver)
                {
                    Email toReceive = _mails[i];
                    _mails.RemoveAt(i);
                    return toReceive;
                }
            }

            return null;
        }
        #endregion
    }
}