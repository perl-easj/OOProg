using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ExamAdmV17
{
    class StudentCollection : INotifyPropertyChanged
    {
        private ObservableCollection<Student> _students;
        private Student _selectedStudent;
        private RelayCommand _deleteCommand;

        public StudentCollection()
        {
            _deleteCommand = new RelayCommand(DoDeleteRelay, StudentIsSelected);

            _students = new ObservableCollection<Student>();

            _students.Add(new Student("Ann", 1988, "Canada", "Assets\\ann.jpg", "Solstien 12", 2750, "Ballerup", 50298761, "ann@cartoon-uni.dk"));
            _students.Add(new Student("Benny", 1982, "England", "Assets\\benny.jpg", "Hyldeblomsten 61", 2730, "Herlev", 55092665, "benny@cartoon-uni.dk"));
            _students.Add(new Student("Carol", 1993, "USA", "Assets\\carol.jpg", "Skolevej 7", 4000, "Roskilde", 62109090, "carol@cartoon-uni.dk"));
            _students.Add(new Student("Daniel", 1990, "Denmark", "Assets\\daniel.jpg", "Stormly 206", 2740, "Skovlunde", 57442194, "daniel@cartoon-uni.dk"));
            _students.Add(new Student("Eliza", 1974, "Australia", "Assets\\eliza.jpg", "Askelunden 148", 4000, "Roskilde", 61750092, "eliza@cartoon-uni.dk"));

            _selectedStudent = _students[0];
        }

        public ObservableCollection<Student> Students
        {
            get { return _students; }
        }

        public Student SelectedStudent
        {
            get { return _selectedStudent; }
            set
            {
                _selectedStudent = value;
                OnPropertyChanged();
                _deleteCommand.RaiseCanExecuteChanged();
            }
        }

        public bool DoDelete()
        {
            return (SelectedStudent != null && Delete(SelectedStudent.Name));
        }

        public void DoDeleteRelay()
        {
            DoDelete();
        }

        public bool StudentIsSelected()
        {
            return SelectedStudent != null;
        }

        public ICommand DeletionCommand
        {
            get { return _deleteCommand; }
        }

        public bool Delete(string name)
        {
            for (int index = 0; index < _students.Count; index++)
            {
                if (_students[index].Name == name)
                {
                    _students.RemoveAt(index);
                    return true;
                }
            }

            return false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
