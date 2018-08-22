using System.Collections.Generic;
using System.Linq;
using AddOns.Images.Interfaces;

namespace AddOns.Images.Implementation
{
    /// <summary>
    /// Implements the ITaggedImageCollection interface, by 
    /// extending the ImageCollection implementation
    /// </summary>
    public class TaggedImageCollection : ImageCollection, ITaggedImageCollection
    {
        /// <inheritdoc />
        public List<IImage> AllWithTag(string tag)
        {
            List<IImage> filteredImages = new List<IImage>();
            foreach (IImage obj in All)
            {
                if ((obj is ITaggedImage tObj) && tObj.ContainsTag(tag))
                {
                    filteredImages.Add(obj);
                }
            }

            return filteredImages;
        }

        /// <inheritdoc />
        public List<string> AllTags
        {
            get
            {
                List<string> allTags = new List<string>();
                foreach (IImage obj in All)
                {
                    if (obj is ITaggedImage tObj)
                    {
                        allTags.AddRange(tObj.Tags);
                    }
                }

                return allTags.Distinct().ToList();
            }
        }
    }
}