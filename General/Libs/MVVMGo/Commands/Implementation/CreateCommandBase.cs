using System;
using Controllers.Implementation;
using Data.InMemory.Interfaces;
using Model.Interfaces;

namespace Commands.Implementation
{
    /// <summary>
    /// Implementation of a generic Create command.
    /// </summary>
    public class CreateCommandBase<TData> : ControllerCommandBase
    {
        public CreateCommandBase(IDataWrapper<TData> source, ICatalog<TData> target, Func<bool> condition)
            : base(new CreateControllerBase<TData>(source, target), condition)
        {
        }
    }
}