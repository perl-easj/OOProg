using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
#pragma warning disable 4014

namespace ExamAdmV17
{
    class StudentCollection : INotifyPropertyChanged
    {
        private ObservableCollection<Student> _students;
        private Student _selectedStudent;
        private RelayCommand _deleteCommand;
        private RelayCommand _insertCommand; // Added
        private bool _isInserting; // Added

        public StudentCollection()
        {
            _deleteCommand = new RelayCommand(DoDeleteRelay, StudentIsSelected);
            _insertCommand = new RelayCommand(DoInsertRelay,CanInsert); // Added

            IsInserting = false; // Added

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
            set // Changed
            {
                if (IsInserting) return;

                _selectedStudent = value;
                OnPropertyChanged();
                OnPropertyChanged("Name");
                _deleteCommand.RaiseCanExecuteChanged();
            }
        }

        #region Insertion helper code
        // Added
        public bool IsInserting
        {
            get { return _isInserting; }
            set
            {
                _isInserting = value;
                OnPropertyChanged();
                OnPropertyChanged("IsNotInserting");
                _insertCommand.RaiseCanExecuteChanged();
            }
        }

        // Added
        public bool IsNotInserting
        {
            get { return !IsInserting; }
        }

        // Added
        public string Name
        {
            get
            {
                return SelectedStudent != null ? SelectedStudent.Name : "";
            }
            set
            {
                // IsInserting must be true here
                if (CheckName(value))
                {
                    SelectedStudent.Name = value;
                    IsInserting = false;
                    _students.Add(SelectedStudent);
                    SelectedStudent = _students.Last();
                }
                else
                {
                    ReportExistingName(value);
                }
            }
        }

        private bool CheckName(string name)
        {

            foreach (Student s in _students)
            {
                if (s.Name == name)
                {
                    return false;
                }
            }

            return true;
        }

        private async Task ReportExistingName(string name)
        {
            var messageDialog = new MessageDialog("Add Student");
            messageDialog.Content = "A student named " + name + " already exists!\nPlease enter a different name";
            messageDialog.Commands.Add(new UICommand("OK"));
            await messageDialog.ShowAsync();
        } 
        #endregion

        #region Deletion command code
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
        #endregion

        #region Insertion command code
        public void DoInsertRelay()
        {
            SelectedStudent = new Student("Enter name");
            IsInserting = true;
        }

        public ICommand InsertionCommand
        {
            get { return _insertCommand; }
        }

        public bool CanInsert()
        {
            return !IsInserting;
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
