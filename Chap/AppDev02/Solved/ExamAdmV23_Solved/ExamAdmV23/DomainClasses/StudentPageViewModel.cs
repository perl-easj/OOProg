using ExamAdmV23.BaseClasses;

namespace ExamAdmV23.DomainClasses
{
    public class StudentPageViewModel : PageViewModelBase<Student>
    {
        #region Constructor
        public StudentPageViewModel() : base(new StudentCatalog())
        {
        }
        #endregion

        public override DataViewModelBase<Student> CreateDataViewModel(Student obj)
        {
            return new StudentDataViewModel(obj);
        }
    }
}