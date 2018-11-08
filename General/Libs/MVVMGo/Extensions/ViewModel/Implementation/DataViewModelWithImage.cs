using AddOns.Images.Implementation;
using AddOns.Images.Interfaces;
using Extensions.AddOns.Implementation;
using ViewModel.Data.Implementation;

namespace Extensions.ViewModel.Implementation
{
    /// <summary>
    /// Base class for a data view model class containing a image, 
    /// provided by the Images service. The image is thus identified 
    /// by a numeric key (ImageKey).
    /// </summary>
    public abstract class DataViewModelWithImage<TData> : DataViewModelBase<TData>
        where TData : class
    {
        private IImage _notFoundImage;

        protected DataViewModelWithImage(TData obj) : base(obj)
        {
            _notFoundImage = new TaggedImage("Image not found", ServiceProvider.Images.GetAppImageSource(AppImageType.NotFound));
        }

        /// <summary>
        /// If no image with a matching key can be found, 
        /// a well-defined fall-back image is used instead.
        /// </summary>
        public string ImageSource
        {
            get { return ServiceProvider.Images.Read(ImageKey, _notFoundImage).Source; }
        }

        /// <summary>
        /// Specific implementation of the ImageKey property is done in sub-classes,
        /// since the specific source for the key value may vary.
        /// </summary>
        public abstract int ImageKey { get; }
    }
}