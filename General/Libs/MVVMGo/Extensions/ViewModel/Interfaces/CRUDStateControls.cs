namespace Extensions.ViewModel.Interfaces
{
    /// <summary>
    /// Valid CRUD state control identifiers. 
    /// To be used when binding to control 
    /// state and control content providers.
    /// </summary>
    public class CRUDStateControls
    {
        public const string CreateStateControl = "CreateStateControl";
        public const string ReadStateControl = "ReadStateControl";
        public const string UpdateStateControl = "UpdateStateControl";
        public const string DeleteStateControl = "DeleteStateControl";
    }
}