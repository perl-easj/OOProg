using System.Collections.Generic;

namespace DataSources.FileJSON.Interfaces
{
    /// <summary>
    /// Interface for conversion between a List of objects
    /// and a string representation. This could e.g. be a 
    /// JSON or XML string representation.
    /// </summary>
    /// <typeparam name="TData">
    /// Type of objects to convert.
    /// </typeparam>
    public interface IStringConverter<TData>
    {
        string ConvertToString(List<TData> objects);
        List<TData> ConvertFromString(string data);
    }
}