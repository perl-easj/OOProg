using System.Collections.Generic;
using Newtonsoft.Json;

namespace Demo.FilePersistence
{
    /// <summary>
    /// JSON-specific implementation of the IDataConverter interface. 
    /// Uses the 3rd-party NewtonSoft JSON package.
    /// </summary>
    /// <typeparam name="T">Type of objects to convert</typeparam>
    public class JSONConverter<T> : IStringConverter<T>
    {
        /// <summary>
        /// Convert a List of objects into a JSON string.
        /// </summary>
        /// <param name="objects">
        /// Objects to convert.
        /// </param>
        /// <returns>
        /// Data on JSON string format.
        /// </returns>
        public string ConvertToString(List<T> objects)
        {
            return JsonConvert.SerializeObject(objects);
        }

        /// <summary>
        /// Converts from a JSON string into a List of objects.
        /// </summary>
        /// <param name="data">
        /// Data on JSON string format.
        /// </param>
        /// <returns>
        /// List of objects.
        /// </returns>
        public List<T> ConvertFromString(string data)
        {
            return (data == null ? new List<T>() : (List<T>)JsonConvert.DeserializeObject(data, typeof(List<T>)));
        }
    }
}