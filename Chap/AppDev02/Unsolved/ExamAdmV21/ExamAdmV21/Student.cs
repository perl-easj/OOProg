namespace ExamAdmV21
{
    public class Student
    {
        #region Instance fields
        private string _name;
        private int _yearOfBirth;
        private string _country;
        private string _imageSource;
        #endregion

        #region Constructor
        public Student(string name, int yearOfBirth, string country, string imageSource)
        {
            _name = name;
            _yearOfBirth = yearOfBirth;
            _country = country;
            _imageSource = imageSource;
        }
        #endregion

        #region Properties
        public string Name
        {
            get { return _name; }
        }

        public int YearOfBirth
        {
            get { return _yearOfBirth; }
        }

        public string Country
        {
            get { return _country; }
        }

        public string ImageSource
        {
            get { return _imageSource; }
        }

        public string CountryStr
        {
            get { return "From " + Country; }
        }

        public string BirthStr
        {
            get { return "(Born " + YearOfBirth + ")"; }
        } 
        #endregion
    }
}