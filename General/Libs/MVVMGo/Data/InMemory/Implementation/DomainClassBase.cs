using Data.InMemory.Interfaces;

namespace Data.InMemory.Implementation
{
    public abstract class DomainClassBase : IStorable, ICopyable, IDefaultValues
    {
        /// <summary>
        /// Constant indicating that the Key value is not set.
        /// </summary>
        public const int NullKey = -1;

        protected DomainClassBase(int key)
        {
            Key = key;
        }

        protected DomainClassBase() : this(NullKey)
        {
            SetDefaultValues();
        }

        public virtual ICopyable Copy()
        {
            return (MemberwiseClone() as ICopyable);
        }

        public virtual void SetDefaultValues()
        {
        }

        public abstract int Key { get; set; }
    }
}