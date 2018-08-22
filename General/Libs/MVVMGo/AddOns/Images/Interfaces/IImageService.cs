using System.Collections.ObjectModel;

namespace AddOns.Images.Interfaces
{
    /// <summary>
    /// The IImageService interface extends the ITaggedImageCollection
    /// interface with functionality related to application-wide images.
    /// </summary>
    public interface IImageService : ITaggedImageCollection
    {
        /// <summary>
        /// Sets the image source for a given application-wide image type.
        /// </summary>
        /// <param name="imageType">
        /// Image type to which the given image is used.
        /// </param>
        /// <param name="source">
        /// Specific source for image.
        /// </param>
        void SetAppImageSource(AppImageType imageType, string source);

        /// <summary>
        /// Retrieves the image source for a given application-wide image type.
        /// </summary>
        /// <param name="imageType">
        /// Image type for which to retrieve the image source.
        /// </param>
        /// <returns>
        /// Image source.
        /// </returns>
        string GetAppImageSource(AppImageType imageType);

        /// <summary>
        /// Returns the set of Image objects tagged with the given tag,
        /// in the form of an ObservableCollection.
        /// </summary>
        /// <param name="tag">
        /// Tag used to select Image objects.
        /// </param>
        /// <returns>
        /// ObservableCollection of Image objects tagged with the given tag.
        /// </returns>
        ObservableCollection<IImage> GetObservableImageCollection(string tag);
    }
}