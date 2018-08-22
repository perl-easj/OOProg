using System;
using Controllers.Implementation;
using Data.InMemory.Interfaces;
using Model.Interfaces;

namespace Commands.Implementation
{
    /// <summary>
    /// Implementation of a generic Create command.
    /// </summary>
    public class CreateCommandBase<TViewData> : ControllerCommandBase
    {
        public CreateCommandBase(IDataWrapper<TViewData> source, ICatalog<TViewData> target, Func<bool> condition)
            : base(new CreateControllerBase<TViewData>(source, target), condition)
        {
        }
    }
}