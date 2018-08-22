using AddOns.Images.Implementation;
using AddOns.Images.Interfaces;
using Extensions.AddOns.Implementation;
using Extensions.ViewModel.Implementation;

namespace CarRetailDemo.ViewModels.Base
{
    public abstract class DataViewModelAppBase<TViewData> : DataViewModelWithSelectableImage<TViewData>
        where TViewData : class
    {
        private IImage _notFoundImage;

        protected DataViewModelAppBase(TViewData obj, string tag) : base(obj, tag)
        {
            _notFoundImage = new TaggedImage("Image not found", ServiceProvider.Images.GetAppImageSource(AppImageType.NotFound));
        }

        public virtual string ImageSource
        {
            get { return ServiceProvider.Images.Read(ImageKey, _notFoundImage).Source; }
        }

        public virtual string HeaderText
        {
            get { return "Override HeaderText..."; }
        }

        public virtual string ContentText
        {
            get { return "Override ContentText..."; }
        }
    }
}