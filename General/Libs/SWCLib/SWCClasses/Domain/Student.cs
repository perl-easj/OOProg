namespace SWCClasses.Domain
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
            set { _imageSource = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public int ZipCode
        {
            get { return _zipCode; }
            set { _zipCode = value; }
        }

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        public int Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
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
    }
}