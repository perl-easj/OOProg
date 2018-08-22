using System.Collections.Generic;

namespace AddOns.Images.Interfaces
{
    /// <summary>
    /// Interface for an image associated with a set of tags.
    /// </summary>
    public interface ITaggedImage : IImage
    {
        /// <summary>
        /// List of tags associated with the image.
        /// </summary>
        List<string> Tags { get; }

        /// <summary>
        /// Add a single tag to the set of tags.
        /// </summary>
        /// <param name="tag">
        /// Tag to add.
        /// </param>
        void AddTag(string tag);

        /// <summary>
        /// Checks if a given tag is part of the set of tags.
        /// </summary>
        /// <param name="tag">
        /// Tag to check.
        /// </param>
        /// <returns>
        /// True if given tag is part of the set of tags, 
        /// otherwise false.
        /// </returns>
        bool ContainsTag(string tag);

        /// <summary>
        /// Checks if at least one of the given tags is 
        /// part of the set of tags.
        /// </summary>
        /// <param name="tags">
        /// Tags to check.
        /// </param>
        /// <returns>
        /// True if at least one of the given tags is 
        /// part of the set of tags, otherwise false.
        /// </returns>
        bool ContainsAnyTag(List<string> tags);
    }
}