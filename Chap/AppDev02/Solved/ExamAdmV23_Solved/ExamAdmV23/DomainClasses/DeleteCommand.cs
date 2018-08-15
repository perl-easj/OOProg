using ExamAdmV23.BaseClasses;

namespace ExamAdmV23.DomainClasses
{
    public class DeleteCommand : DeleteCommandBase<Student, StudentPageViewModel>
    {
        public DeleteCommand(StudentCatalog catalog, StudentPageViewModel viewModel)
            : base(catalog, viewModel)
        {
        }
    }
}