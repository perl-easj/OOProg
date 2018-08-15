using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ExamAdmV20
{
    public class StudentDataViewModel : INotifyPropertyChanged
    {
        private Student _domainObject;

        #region Constructor
        public StudentDataViewModel()
        {
            _domainObject = new Student();
        }
        #endregion

        #region Properties for Data Binding
        public string TopLineText
        {
            get
            {
                return string.Format("{0} scored {1} in the {2} test", _domainObject.Name, _domainObject.Score, _domainObject.Subject);
            }
        }

        public string Name
        {
            get { return _domainObject.Name; }
            set
            {
                _domainObject.Name = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TopLineText));
            }
        }

        public string Subject
        {
            get { return _domainObject.Subject; }
            set
            {
                _domainObject.Subject = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TopLineText));
            }
        }

        public int Score
        {
            get { return _domainObject.Score; }
            set
            {
                _domainObject.Score = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TopLineText));
            }
        } 
        #endregion

        #region OnPropertyChanged code
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        } 
        #endregion
    }
}
