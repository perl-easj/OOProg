using System.Collections.ObjectModel;
using AddOns.Images.Interfaces;
using Extensions.AddOns.Implementation;
using ViewModel.Data.Implementation;

namespace Extensions.ViewModel.Implementation
{
    /// <summary>
    /// Base class for a data view model class containing an image, 
    /// which can be selected from a set of image objects. 
    /// The image objects are provided by the Images service. 
    /// The image is identified by a numeric key (ImageKey).
    /// </summary>
    public abstract class DataViewModelWithSelectableImage<TData> : DataViewModelBase<TData>
        where TData : class
    {
        private string _tag;

        protected DataViewModelWithSelectableImage(TData obj, string tag)
            : base(obj)
        {
            _tag = tag;
        }

        /// <summary>
        /// Gets the image objects corresponding to the specified tag. 
        /// The Images service must be populated with image objects 
        /// matching the specified tag.
        /// </summary>
        public ObservableCollection<IImage> ImageCollection
        {
            get { return ServiceProvider.Images.GetObservableImageCollection(_tag); }
        }

        /// <summary>
        /// Tracks the image object currently selected.
        /// </summary>
        public IImage ImageSelected
        {
            get { return ServiceProvider.Images.Read(ImageKey); }
            set
            {
                if (value != null)
                {
                    ImageKey = value.Key;
                }

                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Specific implementation of the Key property is done in sub-classes, 
        /// since the specific source for the key value may vary.
        /// </summary>
        public abstract int ImageKey { get; set; }
    }
}