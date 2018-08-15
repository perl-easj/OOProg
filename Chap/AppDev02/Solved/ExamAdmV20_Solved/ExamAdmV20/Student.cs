namespace ExamAdmV20
{
    public class Student
    {
        #region Instance fields
        private string _name;
        private string _subject;
        private int _score;
        #endregion

        #region Constructor
        public Student()
        {
            _name = "Sarah";
            _subject = "Economics";
            _score = 85;
        }
        #endregion

        #region Properties
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }

        public int Score
        {
            get { return _score; }
            set { _score = value; }
        } 
        #endregion
    }
}