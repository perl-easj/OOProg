using System;
using Controllers.Implementation;
using Data.InMemory.Interfaces;
using Model.Interfaces;

namespace Commands.Implementation
{
    /// <summary>
    /// Implementation of a generic Update command.
    /// </summary>
    public class UpdateCommandBase<TViewData> : ControllerCommandBase
        where TViewData : class, ICopyable, IStorable
    {
        public UpdateCommandBase(IDataWrapper<TViewData> source, ICatalog<TViewData> target, Func<bool> condition)
            : base(new UpdateControllerBase<TViewData>(source, target), condition)
        {
        }
    }
}