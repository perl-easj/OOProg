using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ExamAdmV12
{
    class Student : INotifyPropertyChanged
    {
        private string _name;
        private string _subject;
        private int _score;

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

        public Student()
        {
            _name = "Sarah";
            _subject = "Economics";
            _score = 85;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged
        ([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this,
            new PropertyChangedEventArgs(propertyName));
        }
    }
}
