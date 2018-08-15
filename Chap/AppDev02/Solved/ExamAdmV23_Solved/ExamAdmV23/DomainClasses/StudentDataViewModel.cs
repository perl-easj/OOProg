using ExamAdmV23.BaseClasses;

namespace ExamAdmV23.DomainClasses
{
    public class StudentDataViewModel : DataViewModelBase<Student>
    {
        #region Constructor
        public StudentDataViewModel(Student obj)
            : base(obj)
        {
        }
        #endregion

        #region Properties for Data Binding
        public string Name
        {
            get { return DomainObject.Name; }
        }

        public string ImageSource
        {
            get { return DomainObject.ImageSource; }
        }

        public string CountryStr
        {
            get { return "From " + DomainObject.Country; }
        }

        public string BirthStr
        {
            get { return "(Born " + DomainObject.YearOfBirth + ")"; }
        } 
        #endregion
    }
}
