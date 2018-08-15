using System.Collections.Generic;

namespace ExamAdmV21
{
    public class StudentPageViewModel
    {
        #region Instance fields
        private StudentCatalog _studentCatalog;
        #endregion

        #region Constructor
        public StudentPageViewModel()
        {
            _studentCatalog = new StudentCatalog();
        }
        #endregion

        #region Properties
        public List<StudentDataViewModel> StudentDataViewModelCollection
        {
            get { return CreateStudentDataViewModelCollection(); }
        }
        #endregion

        #region Methods
        private List<StudentDataViewModel> CreateStudentDataViewModelCollection()
        {
            List<StudentDataViewModel> vmCollection = new List<StudentDataViewModel>();

            foreach (Student s in _studentCatalog.Students)
            {
                vmCollection.Add(new StudentDataViewModel(s));
            }

            return vmCollection;
        } 
        #endregion
    }
}