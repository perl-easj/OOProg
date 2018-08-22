using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AddOns.Images.Interfaces;

namespace Extensions.AddOns.Implementation
{
    /// <summary>
    /// This class is a ViewModel class for the Image service. 
    /// If you wish to include a GUI for the Image service 
    /// in an application, you can bind the view controls to 
    /// properties in this class.
    /// </summary>
    public class ImageViewModel : INotifyPropertyChanged
    {
        private ITaggedImage _imageSelected;
        private int _tagSelectedIndex;

        public ImageViewModel()
        {
            _imageSelected = null;
            _tagSelectedIndex = 0;
        }

        /// <summary>
        /// Returns either the entire set of images 
        /// available (if no tag has been selected), 
        /// or the images matching the selected tag.
        /// </summary>
        public ObservableCollection<IImage> ImageCollection
        {
            get
            {
                var collection = new ObservableCollection<IImage>();
                if (_tagSelectedIndex == 0)
                {
                    // The entry "(All)" is selected - return all tags
                    ServiceProvider.Images.All.ForEach(collection.Add);
                }
                else
                {
                    ServiceProvider.Images.AllWithTag(ServiceProvider.Images.AllTags[_tagSelectedIndex - 1]).ForEach(collection.Add);
                }
                return collection;
            }
        }

        /// <summary>
        /// Property for tracking the currently selected image.
        /// </summary>
        public ITaggedImage ImageSelected
        {
            get { return _imageSelected; }
            set
            {
                _imageSelected = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ImageSelectedDescription));
                OnPropertyChanged(nameof(ImageSelectedTags));
            }
        }

        /// <summary>
        /// Property returning the description for the 
        /// currently selected image.
        /// </summary>
        public string ImageSelectedDescription
        {
            get { return _imageSelected != null ? _imageSelected.Description : string.Empty; }
        }

        /// <summary>
        /// Property returning the tags for the 
        /// currently selected image.
        /// </summary>
        public List<string> ImageSelectedTags
        {
            get { return _imageSelected?.Tags; }
        }

        /// <summary>
        /// Property returning the entire set of tags 
        /// found on the set of available images. 
        /// The entry "(All)" is added to enable a 
        /// selection indicating that all tags are selected.
        /// This extra entry will have index 0 (zero), 
        /// see ImageCollection.
        /// </summary>
        public List<string> AllTags
        {
            get
            {
                List<string> allTags = new List<string>(ServiceProvider.Images.AllTags);
                allTags.Insert(0, "(All)");
                return allTags;
            }
        }

        /// <summary>
        /// Property returning the currently selected tag.
        /// </summary>
        public int TagSelectedIndex
        {
            get { return _tagSelectedIndex; }
            set
            {
                _tagSelectedIndex = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ImageCollection));
            }
        }

        #region INotifyPropertyChanged code
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}