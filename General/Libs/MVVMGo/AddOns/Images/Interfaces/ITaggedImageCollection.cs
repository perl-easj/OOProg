using System.Collections.Generic;

namespace AddOns.Images.Interfaces
{
    /// <summary>
    /// This interface extends the IImageCollection interface with
    /// functionality for tagged images.
    /// </summary>
    public interface ITaggedImageCollection : IImageCollection
    {
        /// <summary>
        /// Retrieves all image objects tagged with the given tag.
        /// </summary>
        /// <param name="tag">
        /// Tag used for selecting image objects.
        /// </param>
        /// <returns>
        /// List of image objects tagged with the given tag.
        /// </returns>
        List<IImage> AllWithTag(string tag);

        /// <summary>
        /// Returns the union of all tags for all image objects.
        /// </summary>
        List<string> AllTags { get; }
    }
}