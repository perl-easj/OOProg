namespace Extensions.Commands.Interfaces
{
    /// <summary>
    /// Valid CRUD states, to be used if e.g. 
    /// a View can be in one of these states.
    /// </summary>
    public class CRUDStates
    {
        public const string CreateState = "CreateState";
        public const string ReadState = "ReadState";
        public const string UpdateState = "UpdateState";
        public const string DeleteState = "DeleteState";
    }
}