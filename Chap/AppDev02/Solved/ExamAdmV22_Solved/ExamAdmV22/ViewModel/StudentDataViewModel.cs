using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ExamAdmV22.Model;

namespace ExamAdmV22.ViewModel
{
    public class StudentDataViewModel : INotifyPropertyChanged
    {
        private Student _domainObject;

        #region Constructor
        public StudentDataViewModel(Student s)
        {
            _domainObject = s;
        }
        #endregion

        #region Properties for Data Binding
        public Student DomainObject
        {
            get { return _domainObject; }
        }

        public string ImageSource
        {
            get { return _domainObject.ImageSource; }
        }

        public string NameText
        {
            get { return _domainObject.Name; }
        }

        public string AgeText
        {
            get
            {
                int age = DateTime.Now.Year - _domainObject.YearOfBirth;
                return $"{age} years old";
            }
        }

        public string ResidenceText
        {
            get { return $"Lives in {_domainObject.Country}"; }
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