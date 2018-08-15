using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using Newtonsoft.Json;

namespace NoteBook
{
    public class FilePersistency<T> : IDataSource<T> where T : class
    {
        private const string FileName = "data.json";
        private CreationCollisionOption _options;
        private StorageFolder _folder;

        public FilePersistency()
        {
            _options = CreationCollisionOption.OpenIfExists;
            _folder = ApplicationData.Current.LocalFolder;
        }

        public async Task SaveAsync(List<T> data)
        {            
            var dataFile = await _folder.CreateFileAsync(FileName, _options);
            string dataJSON = JsonConvert.SerializeObject(data);
            await FileIO.WriteTextAsync(dataFile, dataJSON);
        }

        public async Task<List<T>> LoadAsync()
        {
            try
            {
                StorageFile dataFile = await _folder.GetFileAsync(FileName);
                string dataJSON = await FileIO.ReadTextAsync(dataFile);
                return (dataJSON != null) ? JsonConvert.DeserializeObject<List<T>>(dataJSON) : new List<T>();
            }
            catch (FileNotFoundException)
            {
                await SaveAsync(new List<T>());
                return new List<T>();
            }
        }
    }
}
