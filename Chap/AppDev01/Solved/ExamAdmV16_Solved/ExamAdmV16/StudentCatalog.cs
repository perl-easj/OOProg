using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ExamAdmV16
{
    public class StudentCatalog : INotifyPropertyChanged
    {
        #region Instance fields
        private ObservableCollection<Student> _students;
        private Student _selectedStudent;
        private DeleteCommand _deletionCommand;
        #endregion

        #region Constructor
        public StudentCatalog()
        {
            _students = new ObservableCollection<Student>();

            _students.Add(new Student("Ann", 1988, "Canada", "Assets\\ann.jpg", "Solstien 12", 2750, "Ballerup", 50298761, "ann@cartoon-uni.dk"));
            _students.Add(new Student("Benny", 1982, "England", "Assets\\benny.jpg", "Hyldeblomsten 61", 2730, "Herlev", 55092665, "benny@cartoon-uni.dk"));
            _students.Add(new Student("Carol", 1993, "USA", "Assets\\carol.jpg", "Skolevej 7", 4000, "Roskilde", 62109090, "carol@cartoon-uni.dk"));
            _students.Add(new Student("Daniel", 1990, "Denmark", "Assets\\daniel.jpg", "Stormly 206", 2740, "Skovlunde", 57442194, "daniel@cartoon-uni.dk"));
            _students.Add(new Student("Eliza", 1974, "Australia", "Assets\\eliza.jpg", "Askelunden 148", 4000, "Roskilde", 61750092, "eliza@cartoon-uni.dk"));

            _deletionCommand = new DeleteCommand(this);
        }
        #endregion

        #region Properties used for Data Binding
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
                _deletionCommand.RaiseCanExecuteChanged();
            }
        }

        public ICommand DeletionCommand
        {
            get { return _deletionCommand; }
        }
        #endregion

        #region Deletion functionality
        public void Delete(string name)
        {
            for (int index = 0; index < _students.Count; index++)
            {
                if (_students[index].Name == name)
                {
                    _students.RemoveAt(index);
                    return;
                }
            }
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
