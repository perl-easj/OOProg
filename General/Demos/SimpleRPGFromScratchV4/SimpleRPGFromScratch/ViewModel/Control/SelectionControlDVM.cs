using System;
using System.Collections.ObjectModel;
using System.Linq;
using SimpleRPGFromScratch.Data.Base;
using SimpleRPGFromScratch.Model.App;
using SimpleRPGFromScratch.Model.Base;
using SimpleRPGFromScratch.ViewModel.Base;

namespace SimpleRPGFromScratch.ViewModel.Control
{
    // TODO - Kommentarer
    public class SelectionControlDVM<T, TDVM>
        where T : class, IDomainClass
        where TDVM : class, IDataViewModel<T>, new()
    {
        #region Instance fields
        private ICatalog<T> _catalog;
        private ObservableCollection<TDVM> _dvmCollection;
        private Func<int?> _getIdCallBack;
        private Action<int?> _setIdCallBack;
        private Func<T, bool> _selectionFunc;
        private bool _nullAllowed;
        #endregion

        #region Constructors
        public SelectionControlDVM(Func<int?> getIdCallBack, Action<int?> setIdCallBack, Func<T, bool> selectionFunc, bool nullAllowed = false)
        {
            _getIdCallBack = getIdCallBack;
            _setIdCallBack = setIdCallBack;
            _selectionFunc = selectionFunc;
            _nullAllowed = nullAllowed;

            _catalog = DomainModel.GetCatalog<T>();
            _dvmCollection = new ObservableCollection<TDVM>(_catalog.All.Select(CreateDataViewModel).ToList());
        }

        public SelectionControlDVM(Func<int?> getIdCallBack, Action<int?> setIdCallBack, bool nullAllowed = false)
            : this(getIdCallBack, setIdCallBack, obj => true, nullAllowed)
        {
        }
        #endregion

        #region Properties til (indirekte) Data Binding
        public ObservableCollection<TDVM> ItemCollection
        {
            get { return new ObservableCollection<TDVM>(_dvmCollection.Where(dvm => _selectionFunc(dvm.DataObject()))); }
        }

        public TDVM ItemSelected
        {
            get
            {
                return FindInDVMCollection(_getIdCallBack());
            }
            set
            {
                if (value != null || _nullAllowed)
                {
                    _setIdCallBack(value?.DataObject().GetId());
                }
            }
        }
        #endregion

        #region Hjælpe-metoder
        public void NullifySelection()
        {
            _setIdCallBack(null);
        }

        private TDVM FindInDVMCollection(int? id)
        {
            if (id == null || id.Value == DomainClassBase<T>.NullId)
            {
                return null;
            }

            var finds = ItemCollection.Where(obj => obj.DataObject().GetId() == id.Value).ToList();

            if (finds.Count == 0)
            {
                return null;
            }

            return finds.First();
        }

        private TDVM CreateDataViewModel(T obj)
        {
            TDVM dvmObj = new TDVM();
            dvmObj.SetDataObject(obj);
            return dvmObj;
        } 
        #endregion
    }
}