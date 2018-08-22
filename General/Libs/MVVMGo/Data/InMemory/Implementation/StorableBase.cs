using Data.InMemory.Interfaces;

namespace Data.InMemory.Implementation
{
    /// <summary>
    /// Implementation of the IStorable interface
    /// </summary>
    public abstract class StorableBase : IStorable
    {
        /// <summary>
        /// Constant indicating that the Key value is not set.
        /// </summary>
        public const int NullKey = -1;

        /// <inheritdoc />
        public int Key { get; set; }

        #region Constructors
        protected StorableBase() : this(NullKey)
        {
        }

        protected StorableBase(int key)
        {
            Key = key;
        }
        #endregion
    }
}