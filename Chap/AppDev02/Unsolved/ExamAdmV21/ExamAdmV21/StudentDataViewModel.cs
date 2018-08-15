using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ExamAdmV21
{
    public class StudentDataViewModel : INotifyPropertyChanged
    {
        private Student _domainObject;

        #region Constructor
        public StudentDataViewModel(Student obj)
        {
            _domainObject = obj;
        }
        #endregion

        #region Properties for Data Binding
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

        #region Code for OnPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        } 
        #endregion
    }
}
