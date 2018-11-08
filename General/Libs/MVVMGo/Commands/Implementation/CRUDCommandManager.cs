using Commands.Interfaces;
using Data.InMemory.Interfaces;
using Model.Interfaces;

namespace Commands.Implementation
{
    /// <summary>
    /// Command manager specialised to handle CRUD commands. 
    /// Specific implementation of criteria for command execution
    /// are deferred to sub-classes.
    /// </summary>
    public abstract class CRUDCommandManager<TData> : CommandManager
        where TData : class, ICopyable, IStorable
    {
        private IDataWrapper<TData> _source;

        /// <summary>
        /// Constructor. Registers commands for Create, Update and Delete.
        /// </summary>
        /// <param name="source">Data source for commands</param>
        /// <param name="target">Target collection for commands</param>
        protected CRUDCommandManager(IDataWrapper<TData> source, ICatalog<TData> target)
        {
            _source = source;

            AddCommand(CRUDCommands.CreateCommand, new CreateCommandBase<TData>(source, target, CanDoCreate));
            AddCommand(CRUDCommands.UpdateCommand, new UpdateCommandBase<TData>(source, target, CanDoUpdate));
            AddCommand(CRUDCommands.DeleteCommand, new DeleteCommandBase<TData>(source, target, CanDoDelete));
        }

        /// <summary>
        /// Predicate for Create command. 
        /// </summary>
        private bool CanDoCreate()
        {
            return FurtherConditionCreate();
        }

        /// <summary>
        /// Predicate for Update command 
        /// (source must provide a transformed data object). 
        /// </summary>
        private bool CanDoUpdate()
        {
            return _source.DataObject != null && FurtherConditionUpdate();
        }

        /// <summary>
        /// Predicate for Delete command 
        /// (source must provide a transformed data object).
        /// </summary>
        private bool CanDoDelete()
        {
            return _source.DataObject != null && FurtherConditionDelete();
        }

        #region Abstract methods to implement in sub-classes
        protected abstract bool FurtherConditionCreate();
        protected abstract bool FurtherConditionUpdate();
        protected abstract bool FurtherConditionDelete();
        #endregion
    }
}