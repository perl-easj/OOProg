namespace Extensions.ViewModel.Interfaces
{
    /// <summary>
    /// Valid CRUD control identifiers. To be 
    /// used when binding to control state and 
    /// control description providers.
    /// </summary>
    public class CRUDControls
    {
        public const string CreateControl = "CreateControl";
        public const string UpdateControl = "UpdateControl";
        public const string DeleteControl = "DeleteControl";
        public const string ItemSelectorControl = "ItemSelectorControl";
    }
}