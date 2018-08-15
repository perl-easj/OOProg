using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ExamAdmV23.DomainClasses
{
    public class StudentPageViewModel : INotifyPropertyChanged
    {
        #region Instance fields
        private StudentCatalog _studentCatalog;
        private StudentDataViewModel _studentSelected;
        private DeleteCommand _deleteCommand;
        #endregion

        #region Constructor
        public StudentPageViewModel()
        {
            _studentCatalog = new StudentCatalog();
            _studentSelected = null;
            _deleteCommand = new DeleteCommand(_studentCatalog, this);
        }
        #endregion

        #region Properties for Data Binding
        public ICommand DeletionCommand
        {
            get { return _deleteCommand; }
        }

        public List<StudentDataViewModel> StudentDataViewModelCollection
        {
            get { return GetStudentDataViewModelCollection(_studentCatalog); }
        }

        public StudentDataViewModel StudentSelected
        {
            get { return _studentSelected; }
            set
            {
                _studentSelected = value;
                _deleteCommand.RaiseCanExecuteChanged();
                OnPropertyChanged();
            }
        }
        #endregion

        #region Methods
        public void RefreshStudentDataViewModelCollection()
        {
            OnPropertyChanged(nameof(StudentDataViewModelCollection));
        }

        public StudentDataViewModel CreateDataViewModel(Student obj)
        {
            return new StudentDataViewModel(obj);
        }

        public List<StudentDataViewModel> GetStudentDataViewModelCollection(StudentCatalog catalog)
        {
            List<StudentDataViewModel> items = new List<StudentDataViewModel>();

            foreach (Student s in catalog.Students)
            {
                items.Add(CreateDataViewModel(s));
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