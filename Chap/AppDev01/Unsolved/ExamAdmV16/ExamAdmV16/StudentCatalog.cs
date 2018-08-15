using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ExamAdmV16
{
    public class StudentCatalog : INotifyPropertyChanged
    {
        #region Instance fields
        private List<Student> _students;
        private Student _selectedStudent;
        #endregion

        #region Constructor
        public StudentCatalog()
        {
            _students = new List<Student>();

            _students.Add(new Student("Ann", 1988, "Canada", "Assets\\ann.jpg", "Solstien 12", 2750, "Ballerup", 50298761, "ann@cartoon-uni.dk"));
            _students.Add(new Student("Benny", 1982, "England", "Assets\\benny.jpg", "Hyldeblomsten 61", 2730, "Herlev", 55092665, "benny@cartoon-uni.dk"));
            _students.Add(new Student("Carol", 1993, "USA", "Assets\\carol.jpg", "Skolevej 7", 4000, "Roskilde", 62109090, "carol@cartoon-uni.dk"));
            _students.Add(new Student("Daniel", 1990, "Denmark", "Assets\\daniel.jpg", "Stormly 206", 2740, "Skovlunde", 57442194, "daniel@cartoon-uni.dk"));
            _students.Add(new Student("Eliza", 1974, "Australia", "Assets\\eliza.jpg", "Askelunden 148", 4000, "Roskilde", 61750092, "eliza@cartoon-uni.dk"));
        }
        #endregion

        #region Properties used for Data Binding
        public List<Student> Students
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
            }
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
