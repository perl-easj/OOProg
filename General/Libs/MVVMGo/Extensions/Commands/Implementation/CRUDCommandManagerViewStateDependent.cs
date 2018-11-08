using System;
using AddOns.ViewState.Interfaces;
using Commands.Implementation;
using Data.InMemory.Interfaces;
using Extensions.Commands.Interfaces;
using Model.Interfaces;

namespace Extensions.Commands.Implementation
{
    /// <summary>
    /// Implements a CRUD command manager, where the conditions for execution
    /// now also depend on the state of the object with view state.
    /// </summary>
    public class CRUDCommandManagerViewStateDependent<TData> : CRUDCommandManager<TData>
        where TData : class, ICopyable, IStorable
    {
        private IHasViewState _viewStateObject;

        public CRUDCommandManagerViewStateDependent(IDataWrapper<TData> source, ICatalog<TData> target, IHasViewState viewStateObject)
            : base(source, target)
        {
            _viewStateObject = viewStateObject ?? throw new ArgumentException(nameof(_viewStateObject));
        }

        /// <summary>
        /// Only allow Create to execute if in the Create state
        /// </summary>
        protected override bool FurtherConditionCreate()
        {
            return _viewStateObject.ViewState == CRUDStates.CreateState;
        }

        /// <summary>
        /// Only allow Update to execute if in the Update state
        /// </summary>
        protected override bool FurtherConditionUpdate()
        {
            return _viewStateObject.ViewState == CRUDStates.UpdateState;
        }

        /// <summary>
        /// Only allow Delete to execute if in the Delete state
        /// </summary>
        protected override bool FurtherConditionDelete()
        {
            return _viewStateObject.ViewState == CRUDStates.DeleteState;
        }
    }
}