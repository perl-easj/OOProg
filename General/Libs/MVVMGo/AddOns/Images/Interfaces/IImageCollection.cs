using System.Collections.Generic;

namespace AddOns.Images.Interfaces
{
    /// <summary>
    /// Interface for a collection of objects
    /// of type IImage
    /// </summary>
    public interface IImageCollection
    {
        /// <summary>
        /// Add a single image object to the collection
        /// </summary>
        /// <param name="image">
        /// Image object to add.
        /// </param>
        /// <returns>
        /// Key for image object
        /// </returns>
        int AddImage(IImage image);

        /// <summary>
        /// Sets the collection to contain the given 
        /// set of image objects. All existing image 
        /// objects in the collection should be removed.
        /// </summary>
        /// <param name="imageList">
        /// List of new image objects.
        /// </param>
        void SetImages(List<IImage> imageList);

        /// <summary>
        /// Get all image objects currently in the collection.
        /// </summary>
        List<IImage> All { get; }

        /// <summary>
        /// Retrieve a single image object, matching the given key.
        /// </summary>
        /// <param name="key">
        /// Key of image objects to retrieve.
        /// </param>
        /// <param name="defaultImage">
        /// A fall-back image can be specified; this is returned if 
        /// no image in the collection matches the given key.
        /// </param>
        /// <returns>
        /// Image object matching the key, or fall-back image
        /// </returns>
        IImage Read(int key, IImage defaultImage = null);
    }
}