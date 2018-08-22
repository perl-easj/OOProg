using System.Collections.Generic;
using System.Linq;
using AddOns.Images.Interfaces;

namespace AddOns.Images.Implementation
{
    /// <inheritdoc />
    /// <summary>
    /// Implementation of the IImageCollection interface. 
    /// Image objects are stored in a Dictionary.
    /// </summary>
    public class ImageCollection : IImageCollection
    {
        private Dictionary<int, IImage> _images;

        public ImageCollection()
        {
            _images = new Dictionary<int, IImage>();
        }

        #region Properties
        /// <inheritdoc />
        public List<IImage> All
        {
            get { return _images.Values.ToList(); }
        }
        #endregion

        #region Methods
        /// <inheritdoc />
        public int AddImage(IImage image)
        {
            image.Key = FindNewKey();
            _images.Add(image.Key, image);
            return image.Key;
        }

        /// <inheritdoc />
        public void SetImages(List<IImage> imageList)
        {
            _images.Clear();
            foreach (IImage image in imageList)
            {
                AddImage(image);
            }
        }

        /// <inheritdoc />
        public IImage Read(int key, IImage defaultImage = null)
        {
            return _images.ContainsKey(key) ? _images[key] : defaultImage;
        }

        /// <summary>
        /// Calculates the next key for a new image object.
        /// </summary>
        /// <returns>
        /// New key value.
        /// </returns>
        private int FindNewKey()
        {
            return _images.Count;
        }
        #endregion
    }
}