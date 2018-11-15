using System.Collections.Generic;
using Data.InMemory.Interfaces;
using Extensions.ViewModel.Implementation;
using Model.Interfaces;

namespace SimpleRPGDemo.ViewModel.Base
{
    public abstract class PageViewModelAppBase<TViewData> : PageViewModelCRUD<TViewData>
        where TViewData : class, ICopyable, IStorable, new()
    {
        protected PageViewModelAppBase(ICatalog<TViewData> catalog)
            : base(catalog, new List<string>(), new List<string>())
        {
        }
    }
}