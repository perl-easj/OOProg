namespace ExamAdmV23.DomainClasses
{
    public class StudentDataViewModel
    {
        private Student _domainObject;

        #region Constructor
        public StudentDataViewModel(Student obj)
        {
            _domainObject = obj;
        }
        #endregion

        #region Properties for Data Binding
        public Student DomainObject
        {
            get { return _domainObject; }
        }

        public string Name
        {
            get { return _domainObject.Name; }
        }

        public string ImageSource
        {
            get { return _domainObject.ImageSource; }
        }

        public string CountryStr
        {
            get { return "From " + _domainObject.Country; }
        }

        public string BirthStr
        {
            get { return "(Born " + _domainObject.YearOfBirth + ")"; }
        } 
        #endregion
    }
}
