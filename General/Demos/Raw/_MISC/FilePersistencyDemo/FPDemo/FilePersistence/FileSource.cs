using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.FilePersistence
{
    /// <summary>
    /// File-specific implementation of IDataSource... interfaces. 
    /// Ties a IStringPersistence implementation to a IDataConverter 
    /// implementation.
    /// </summary>
    /// <typeparam name="T">
    /// Type of objects to load/save.
    /// </typeparam>
    public class FileSource<T>
    {
        private string _fileName;
        private IStringPersistence _stringPersistence;
        private IStringConverter<T> _stringConverter;

        /// <summary>
        /// If nothing else is specified, data is stored 
        /// in a text file  called (NameOfClass)Model.dat, 
        /// for instance CarModel.dat.
        /// </summary>
        public FileSource(IStringPersistence stringPersistence, IStringConverter<T> stringConverter, string fileSuffix = "Model.dat")
        {
            _stringPersistence = stringPersistence;
            _stringConverter = stringConverter;
            _fileName = typeof(T).Name + fileSuffix;
        }

        /// <summary>
        /// Loads objects from file
        /// </summary>
        /// <returns>
        /// List of loaded objects, wrapped in an awaitable Task.
        /// </returns>
        public async Task<List<T>> Load()
        {
            string data = await _stringPersistence.LoadAsync(_fileName);
            return _stringConverter.ConvertFromString(data);
        }

        /// <summary>
        /// Saves objects to file
        /// </summary>
        /// <param name="objects">
        /// List of objects to save
        /// </param>
        public Task Save(List<T> objects)
        {
            string data = _stringConverter.ConvertToString(objects);
            return _stringPersistence.SaveAsync(_fileName, data);
        }
    }
}