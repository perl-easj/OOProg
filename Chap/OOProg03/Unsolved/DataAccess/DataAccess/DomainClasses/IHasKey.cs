namespace DataAccess.DomainClasses
{
    /// <summary>
    /// Interface which should be implemented by domain classes,
    /// in order to be compatible with DBTool.
    /// </summary>
    public interface IHasKey
    {
        int Key { get; set; }
    }
}