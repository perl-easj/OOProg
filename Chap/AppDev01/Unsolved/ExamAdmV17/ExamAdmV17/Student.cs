namespace ExamAdmV17
{
    class Student
    {
        private string _name;
        private int _yearOfBirth;
        private string _country;
        private string _imageSource;

        private string _address;
        private int _zipCode;
        private string _city;
        private int _phone;
        private string _email;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
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

        public string CountryStr
        {
            get { return "From " + Country; }
        }

        public string BirthStr
        {
            get { return "(Born " + YearOfBirth + ")"; }
        }

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

        public Student(string name)
        {
            _name = name;
            SetDefaultValues();
        }

        public void SetDefaultValues()
        {
            _yearOfBirth = 2000;
            _country = "Denmark";
            _imageSource = "";

            _address = "(Address)";
            _zipCode = 9999;
            _city = "(City)";
            _phone = 12345678;
            _email = "add@email.here";
        }
    }
}
