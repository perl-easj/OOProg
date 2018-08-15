using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ExamAdmV22.Model;

namespace ExamAdmV22.ViewModel
{
    public class StudentPageViewModel : INotifyPropertyChanged
    {
        #region Instance fields
        private StudentCatalog _studentCatalog;
        private StudentDataViewModel _selectedStudent;
        private DeleteCommand _deletionCommand;
        #endregion

        #region Constructor
        public StudentPageViewModel()
        {
            _studentCatalog = new StudentCatalog();
            _selectedStudent = null;

            _deletionCommand = new DeleteCommand(_studentCatalog, this);
        }
        #endregion

        #region Properties for Data Binding
        public List<StudentDataViewModel> StudentDataViewModelCollection
        {
            get { return GetStudentDataViewModelCollection(); }
        }

        public StudentDataViewModel SelectedStudent
        {
            get { return _selectedStudent; }
            set
            {
                _selectedStudent = value;
                OnPropertyChanged();
                _deletionCommand.RaiseCanExecuteChanged();
            }
        }

        public DeleteCommand DeletionCommand
        {
            get { return _deletionCommand; }
        }
        #endregion

        #region Methods
        public void RefreshStudentItemViewModelCollection()
        {
            OnPropertyChanged(nameof(StudentDataViewModelCollection));
        }

        private List<StudentDataViewModel> GetStudentDataViewModelCollection()
        {
            List<StudentDataViewModel> items = new List<StudentDataViewModel>();

            foreach (Student s in _studentCatalog.Students)
            {
                items.Add(new StudentDataViewModel(s));
            }

            return items;
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