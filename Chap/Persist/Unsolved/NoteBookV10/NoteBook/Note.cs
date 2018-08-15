namespace NoteBook
{
    public class Note
    {
        #region Constants
        public const string DefaultTitle = "New Note";
        public const string DefaultContent = "Type your content here";
        #endregion

        #region Instance fields
        private string _title;
        private string _content;
        #endregion

        #region Constructors
        public Note(string title, string content)
        {
            _title = title;
            _content = content;
        }

        public Note()
        {
            _title = DefaultTitle;
            _content = DefaultContent;
        }
        #endregion

        #region Properties
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return Title;
        } 
        #endregion
    }
}
