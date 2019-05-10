using System.Collections.Generic;

namespace Demo.FilePersistence
{
    /// <summary>
    /// Interface for conversion between a List of objects
    /// and a string representation. This could e.g. be a 
    /// JSON or XML string representation.
    /// </summary>
    /// <typeparam name="T">
    /// Type of objects.
    /// </typeparam>
    public interface IStringConverter<T>
    {
        string ConvertToString(List<T> objects);
        List<T> ConvertFromString(string data);
    }
}