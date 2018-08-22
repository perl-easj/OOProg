using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AddOns.Images.Interfaces;

namespace AddOns.Images.Implementation
{
    /// <inheritdoc />
    /// <summary>
    /// Implementation of the IImageService interface
    /// </summary>
    public class ImageService : IImageService
    {
        #region Instance fields
        private ITaggedImageCollection _collection;
        private Dictionary<AppImageType, string> _appImages;
        #endregion

        #region Constructor
        public ImageService()
        {
            _collection = new TaggedImageCollection();
            _appImages = new Dictionary<AppImageType, string>();
        }
        #endregion

        #region Properties
        /// <inheritdoc />
        public List<IImage> All
        {
            get { return _collection.All; }
        }

        /// <inheritdoc />
        public List<string> AllTags
        {
            get { return _collection.AllTags; }
        }
        #endregion

        #region Methods
        /// <inheritdoc />
        public void SetAppImageSource(AppImageType imageType, string source)
        {
            if (_appImages.ContainsKey(imageType))
            {
                throw new ArgumentException(nameof(SetAppImageSource));
            }

            _appImages.Add(imageType, source);
        }

        /// <inheritdoc />
        public string GetAppImageSource(AppImageType imageType)
        {
            if (!_appImages.ContainsKey(imageType))
            {
                throw new ArgumentException(nameof(GetAppImageSource));
            }

            return _appImages[imageType];
        }

        /// <inheritdoc />
        public int AddImage(IImage image)
        {
            return _collection.AddImage(image);
        }

        /// <inheritdoc />
        public void SetImages(List<IImage> imageList)
        {
            _collection.SetImages(imageList);
        }

        /// <inheritdoc />
        public IImage Read(int key, IImage defaultImage = null)
        {
            return _collection.Read(key, defaultImage);
        }

        /// <inheritdoc />
        public List<IImage> AllWithTag(string tag)
        {
            return _collection.AllWithTag(tag);
        }

        /// <inheritdoc />
        public ObservableCollection<IImage> GetObservableImageCollection(string tag)
        {
            var collection = new ObservableCollection<IImage>();
            AllWithTag(tag).ForEach(collection.Add);
            return collection;
        }
        #endregion
    }
}