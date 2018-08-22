using System.Collections.Generic;
using Data.InMemory.Interfaces;
using Extensions.ViewModel.Implementation;
using Model.Interfaces;

namespace BioDemo.ViewModels.Base
{
    /// <summary>
    /// This class will be a base class for all Page view model classes.
    /// A Page view model object will provide properties for Data Binding,
    /// specifically for e.g. ListView/GridView Data Binding.
    /// </summary>
    /// <typeparam name="T">Type of domain objects being referred to</typeparam>
    public abstract class PageViewModelAppBase<T> : PageViewModelCRUD<T>
        where T : class, ICopyable, IStorable, new()
    {
        /// <summary>
        /// Constructor: The two empty lists in the base class constructor
        /// parameter list are not used in this setup (and are therefore empty).
        /// </summary>
        /// <param name="catalog">The catalog object being referred to</param>
        protected PageViewModelAppBase(ICatalog<T> catalog)
            : base(catalog, new List<string>(), new List<string>())
        {
        }
    }
}