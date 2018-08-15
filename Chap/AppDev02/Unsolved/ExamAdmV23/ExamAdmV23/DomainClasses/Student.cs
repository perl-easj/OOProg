namespace ExamAdmV23.DomainClasses
{
    public class Student
    {
        #region Instance fields
        private int _key;
        private string _name;
        private int _yearOfBirth;
        private string _country;
        private string _imageSource;
        #endregion

        #region Constructor
        public Student(string name, int yearOfBirth, string country, string imageSource)
        {
            _key = -1;
            _name = name;
            _yearOfBirth = yearOfBirth;
            _country = country;
            _imageSource = imageSource;
        }
        #endregion

        #region Properties
        public int Key
        {
            get { return _key; }
            set { _key = value; }
        }

        public string Name
        {
            get { return _name; }
        }

        public int YearOfBirth
        {
            get { return _yearOfBirth; }
            set { _yearOfBirth = value; }
        }

        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        public string ImageSource
        {
            get { return _imageSource; }
            set { _imageSource = value; }
        }
        #endregion
    }
}