namespace ExamAdmV12
{
    class Student
    {
        private string _name;
        private string _subject;
        private int _score;

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

        public Student()
        {
            _name = "Sarah";
            _subject = "Economics";
            _score = 85;
        }
    }
}
