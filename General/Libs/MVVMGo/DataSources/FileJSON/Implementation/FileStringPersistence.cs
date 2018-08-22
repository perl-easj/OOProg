using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using DataSources.FileJSON.Interfaces;

namespace DataSources.FileJSON.Implementation
{
    /// <summary>
    /// File-specific implementation of the 
    /// IStringPersistence interface. File is 
    /// located in local folder for application, 
    /// since a UWP App will have access to this 
    /// area of the file system.
    /// </summary>
    public class FileStringPersistence : IStringPersistence
    {
        /// <summary>
        /// Loads a string from the specified file. 
        /// If the file is not found, a new file is 
        /// created, with an empty array.
        /// </summary>
        /// <param name="fileName">
        /// Name of file to load data from. Assumed to 
        /// ONLY contain the file name, NOT the full path.
        /// </param>
        /// <returns>
        /// Loaded string data, wrapped in an awaitable Task.
        /// </returns>
        public async Task<string> LoadAsync(string fileName)
        {
            {
                try
                {
                    StorageFile localFile = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                    return await FileIO.ReadTextAsync(localFile);
                }
                catch (FileNotFoundException)
                {
                    await SaveAsync(fileName, "[]");
                    return "[]";
                }
            }
        }

        /// <summary>
        /// Saves a string to the specified file.
        /// </summary>
        /// <param name="fileName">
        /// Name of file to save data to. Assumed to ONLY 
        /// contain the file name, NOT the full path.
        /// </param>
        /// <param name="stringToSave">
        /// String data to save.
        /// </param>
        public async Task SaveAsync(string fileName, string stringToSave)
        {
            var saveFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);
            await FileIO.WriteTextAsync(saveFile, stringToSave);
        }
    }
}