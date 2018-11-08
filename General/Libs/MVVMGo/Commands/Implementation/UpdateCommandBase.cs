using System;
using Controllers.Implementation;
using Data.InMemory.Interfaces;
using Model.Interfaces;

namespace Commands.Implementation
{
    /// <summary>
    /// Implementation of a generic Update command.
    /// </summary>
    public class UpdateCommandBase<TData> : ControllerCommandBase
        where TData : class, ICopyable, IStorable
    {
        public UpdateCommandBase(IDataWrapper<TData> source, ICatalog<TData> target, Func<bool> condition)
            : base(new UpdateControllerBase<TData>(source, target), condition)
        {
        }
    }
}