namespace ExamAdmV11
{
    public class Student
    {
        private string _name;
        private string _subject;
        private int _score;

        public string Name
        {
            get { return _name; }
        }

        public string Subject
        {
            get { return _subject; }
        }

        public int Score
        {
            get { return _score; }
        }

        public Student()
        {
            _name = "Sarah";
            _subject = "Economics";
            _score = 85;
        }
    }
}