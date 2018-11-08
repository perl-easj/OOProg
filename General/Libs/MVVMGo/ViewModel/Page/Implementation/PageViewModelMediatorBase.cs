using System;
using Data.InMemory.Interfaces;
using Model.Interfaces;
using ViewModel.Page.Interfaces;

namespace ViewModel.Page.Implementation
{
    /// <summary>
    /// Implementation of the IPageViewModelMediator class. Provides template 
    /// strategies for handling changes to catalog and item selection.
    /// </summary>
    public abstract class PageViewModelMediatorBase<TData> : 
        ICatalogMediator, 
        IPageViewModelMediator<TData>
        where TData : class, ICopyable, new()
    {
        #region Instance fields
        private IPageViewModel<TData> _pageViewModel;
        private ICatalog<TData> _catalog;
        #endregion

        #region Constructor
        protected PageViewModelMediatorBase(IPageViewModel<TData> pageViewModel, ICatalog<TData> catalog)
        {
            _catalog = catalog ?? throw new ArgumentNullException(nameof(catalog));
            _pageViewModel = pageViewModel ?? throw new ArgumentNullException(nameof(pageViewModel));

            // Hook up the On... methods to relevant events.
            _pageViewModel.ItemSelectionChanged += OnItemSelectionChanged;
            _catalog.CatalogChanged += OnCatalogChanged;
        }
        #endregion

        #region Interface implementation
        /// <inheritdoc />
        /// <summary>
        /// When the Item selection changes, these steps should be invoked:
        /// 1a) If the wrapper is null, set the Item Details to null
        /// 1b) Else: set Item Details by calling abstract method (subclasses
        ///     must specify details for setting Item Details)
        /// 2)  Notify all commands, by calling abstract method (subclasses
        ///     must specify commands to notify.
        /// </summary>
        public virtual void OnItemSelectionChanged(IDataWrapper<TData> vdWrapper)
        {
            SetItemDetailsOnItemSelectionChanged(vdWrapper?.DataObject);
            NotifyCommands();
        }

        /// <inheritdoc />
        /// <summary>
        /// When the underlying catalog changes, these steps should be invoked:
        /// 1) Item selection is set to null (no selection)
        /// 2) ItemCollection property is notified, to invoke re-read by
        ///    View properties binding to this property.
        /// </summary>
        public virtual void OnCatalogChanged(int key)
        {
            _pageViewModel.ItemSelected = null;
            _pageViewModel.OnPropertyChanged(nameof(_pageViewModel.ItemCollection));
        }
        #endregion

        #region Abstract methods - override in derived classes
        /// <summary>
        /// Override this method to specify behavior for 
        /// Item Details when Item selection changes.
        /// </summary>
        /// <param name="vdObjSelected">New selection</param>
        public abstract void SetItemDetailsOnItemSelectionChanged(TData vdObjSelected);

        /// <summary>
        /// Override this method to notify a specific set
        /// of Command objects when Item selection changes.
        /// </summary>
        public abstract void NotifyCommands();
        #endregion
    }
}