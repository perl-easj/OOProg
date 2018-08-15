namespace SupportManagement.Error
{
    /// <summary>
    /// An "error ticket" represents a report of an error,
    /// submitted by a system stakeholder (user, tester, etc.)
    /// </summary>
    public class ErrorTicket
    {
        #region Instance fields
        private string _title;
        private string _description;
        private ErrorLanguage _language;
        private ErrorLevel _level;
        #endregion

        #region Constructor
        public ErrorTicket(string title, string description, ErrorLanguage language, ErrorLevel level)
        {
            _title = title;
            _description = description;
            _language = language;
            _level = level;
        }
        #endregion

        #region Properties
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public ErrorLanguage Language
        {
            get { return _language; }
            set { _language = value; }
        }

        public ErrorLevel Level
        {
            get { return _level; }
            set { _level = value; }
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{Title} (level: {Level}  lang: {Language})";
        } 
        #endregion
    }
}