using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ExamAdmV20
{
    public class Student : INotifyPropertyChanged
    {
        #region Instance fields
        private string _name;
        private string _subject;
        private int _score;
        #endregion

        #region Constructor
        public Student()
        {
            _name = "Sarah";
            _subject = "Economics";
            _score = 85;
        }
        #endregion

        #region Properties
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Subject
        {
            get { return _subject; }
            set
            {
                _subject = value;
                OnPropertyChanged();
            }
        }

        public int Score
        {
            get { return _score; }
            set
            {
                _score = value;
                OnPropertyChanged();
            }
        } 
        #endregion

        #region OnPropertyChanged code
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged
        ([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        } 
        #endregion
    }
}