namespace ExamAdmV16
{
    public class DeleteCommand : CommandBase
    {
        private StudentCatalog _catalog;

        public DeleteCommand(StudentCatalog catalog)
        {
            _catalog = catalog;
        }

        public override bool CanExecute(object parameter)
        {
            return _catalog.SelectedStudent != null;
        }

        public override void Execute(object parameter)
        {
            _catalog.Delete(_catalog.SelectedStudent.Name);
        }
    }
}