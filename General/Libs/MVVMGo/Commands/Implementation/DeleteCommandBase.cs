using System;
using Controllers.Implementation;
using Data.InMemory.Interfaces;
using Model.Interfaces;

namespace Commands.Implementation
{
    /// <summary>
    /// Implementation of a generic Delete command.
    /// </summary>
    public class DeleteCommandBase<TData> : ControllerCommandBase
        where TData : class, ICopyable, IStorable
    {
        public DeleteCommandBase(IDataWrapper<TData> source, ICatalog<TData> target, Func<bool> condition)
            : base(new DeleteControllerBase<TData>(source, target), condition)
        {
        }
    }
}