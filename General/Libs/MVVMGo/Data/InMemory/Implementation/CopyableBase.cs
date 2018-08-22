using Data.InMemory.Interfaces;

namespace Data.InMemory.Implementation
{
    /// <summary>
    /// Base implementation of ICopyable. Copy is simply
    /// implemented as MemberwiseClone (i.e. shallow copy)
    /// </summary>
    public abstract class CopyableBase : StorableBase, ICopyable
    {
        #region Constructors
        protected CopyableBase() : base(NullKey)
        {
        }

        protected CopyableBase(int key) : base(key)
        {
        } 
        #endregion

        /// <inheritdoc />
        /// <summary>
        /// This method can be overrided if non-default
        /// copy behavior is required.
        /// </summary>
        public virtual ICopyable Copy()
        {
            return (MemberwiseClone() as ICopyable);
        }
    }
}