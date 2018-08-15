using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ExamAdmV13
{
    class StudentCollection : INotifyPropertyChanged
    {
        #region Instance fields
        private List<Student> _students;
        private List<string> _subjects;
        #endregion

        #region Constructor
        public StudentCollection()
        {
            _students = new List<Student>();
            _subjects = new List<string>();

            _students.Add(new Student());

            _subjects.Add("Math");
            _subjects.Add("Economics");
            _subjects.Add("Biology");
            _subjects.Add("English");
            _subjects.Add("Chemistry");
        }
        #endregion

        #region Properties for Data Binding
        public List<Student> Students
        {
            get { return _students; }
        }

        public List<string> Subjects
        {
            get { return _subjects; }
        }

        public int NoOfSubjects
        {
            get { return _subjects.Count; }
        }

        public Student SelectedStudent
        {
            get { return _students[0]; }
        }

        public string NewSubject
        {
            get { return "(subject)"; }
            set
            {
                // Add the new subject to the list of subjects
                _subjects.Add(value);

                // This call makes the "No. of subjects" field refresh itself
                OnPropertyChanged(nameof(NoOfSubjects));
            }
        } 
        #endregion

        #region OnPropertyChanged code
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged
        ([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this,
            new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
