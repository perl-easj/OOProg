namespace EnvironmentGenerator.Interfaces
{
    /// <summary>
    /// All elements in the environment must
    /// implement this interface.
    /// </summary>
    public interface IEnvironmentElement
    {
        string ElementDescription { get; }
    }
}