using System.Collections.Generic;
using AddOns.Images.Interfaces;

namespace AddOns.Images.Implementation
{
    /// <inheritdoc />
    /// <summary>
    /// Implementation of the TaggedImage interface 
    /// (we assume that all images are tagged).
    /// </summary>
    public class TaggedImage : ITaggedImage
    {
        #region Constructor
        public TaggedImage(string description, string source)
        {
            Description = description;
            Source = source;
            Tags = new List<string>();
        }
        #endregion

        #region Properties
        /// <inheritdoc />
        public int Key { get; set; }

        /// <inheritdoc />
        public string Source { get; }

        /// <inheritdoc />
        public string Description { get; }

        /// <inheritdoc />
        public List<string> Tags { get; }
        #endregion

        #region Methods
        /// <inheritdoc />
        public void AddTag(string tag)
        {
            Tags.Add(tag);
        }

        /// <inheritdoc />
        public bool ContainsTag(string tag)
        {
            return Tags.Contains(tag);
        }

        /// <inheritdoc />
        public bool ContainsAnyTag(List<string> tags)
        {
            foreach (string tag in tags)
            {
                if (ContainsTag(tag))
                {
                    return true;
                }
            }

            return false;
        }
        #endregion
    }
}