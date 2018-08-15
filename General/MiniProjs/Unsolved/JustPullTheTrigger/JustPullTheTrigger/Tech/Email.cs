using JustPullTheTrigger.Targets;

namespace JustPullTheTrigger.Tech
{
    public class Email
    {
        #region Instance fields
        private string _sender;
        private string _receiver;
        private string _title;
        private string _content;
        private INamedTarget _target;
        #endregion

        #region Constructor
        public Email(string sender, string receiver, string title, string content, INamedTarget target = null)
        {
            _sender = sender;
            _receiver = receiver;
            _title = title;
            _content = content;
            _target = target;
        }
        #endregion

        #region Properties
        public string Sender
        {
            get { return _sender; }
        }

        public string Receiver
        {
            get { return _receiver; }
        }

        public string Title
        {
            get { return _title; }
        }

        public string Content
        {
            get { return _content; }
        }

        public INamedTarget Target
        {
            get { return _target; }
        }
        #endregion
    }
}