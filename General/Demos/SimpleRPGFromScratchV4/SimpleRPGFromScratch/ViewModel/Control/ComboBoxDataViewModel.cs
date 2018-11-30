using System;
using System.Collections.ObjectModel;
using System.Linq;
using SimpleRPGFromScratch.Data.Base;
using SimpleRPGFromScratch.ViewModel.Base;

namespace SimpleRPGFromScratch.ViewModel.Control
{
    public class ComboBoxDataViewModel<T, TDVM, TPVM>
        where T : IDomainClass
        where TDVM : class, IDataViewModel<T>
        where TPVM : IPageViewModel<TDVM>, new()
    {
        private TPVM _pvmCombo;
        private ObservableCollection<TDVM> _dvmComboCollection;
        private Func<int> _getIdCallBack;
        private Action<int> _setIdCallBack;

        public ComboBoxDataViewModel(Func<int> getIdCallBack, Action<int> setIdCallBack)
        {
            _pvmCombo = new TPVM();
            _dvmComboCollection = _pvmCombo.ItemCollection;
            _getIdCallBack = getIdCallBack;
            _setIdCallBack = setIdCallBack;
        }

        public ObservableCollection<TDVM> ItemCollection
        {
            get { return _dvmComboCollection; }
        }

        public TDVM ItemSelected
        {
            get
            {
                return FindInDVMCollection(_getIdCallBack());
            }
            set
            {
                if (value != null)
                {
                    _setIdCallBack(value.DataObject().GetId());
                }
            }
        }

        public TDVM FindInDVMCollection(int id)
        {
            var finds = _dvmComboCollection.Where(obj => obj.DataObject().GetId() == id).ToList();
            return finds.Count == 0 ? null : finds.First();
        }
    }
}