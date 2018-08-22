namespace Extensions.Commands.Interfaces
{
    /// <summary>
    /// Valid CRUD state setting command identifiers, 
    /// to be used if e.g. a View can be in one of 
    /// these states, and can be set in one of these 
    /// states through a Command.
    /// </summary>
    public class CRUDStateCommands
    {
        public const string CreateStateCommand = "CreateStateCommand";
        public const string ReadStateCommand = "ReadStateCommand";
        public const string UpdateStateCommand = "UpdateStateCommand";
        public const string DeleteStateCommand = "DeleteStateCommand";
    }
}