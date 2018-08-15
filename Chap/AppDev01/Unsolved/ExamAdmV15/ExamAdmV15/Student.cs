namespace ExamAdmV15
{
    public class Student
    {
        #region Instance fields
        private string _name;
        private int _yearOfBirth;
        private string _country;
        private string _imageSource;

        private string _address;
        private int _zipCode;
        private string _city;
        private int _phone;
        private string _email;
        #endregion

        #region Constructor
        public Student(
            string name,
            int yearOfBirth,
            string country,
            string imageSource,
            string address,
            int zipCode,
            string city,
            int phone,
            string email)
        {
            _name = name;
            _yearOfBirth = yearOfBirth;
            _country = country;
            _imageSource = imageSource;

            _address = address;
            _zipCode = zipCode;
            _city = city;
            _phone = phone;
            _email = email;
        }
        #endregion

        #region Properties for Data Binding
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

        public string Address
        {
            get { return _address; }
        }

        public int ZipCode
        {
            get { return _zipCode; }
        }

        public string City
        {
            get { return _city; }
        }

        public int Phone
        {
            get { return _phone; }
        }

        public string Email
        {
            get { return _email; }
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
