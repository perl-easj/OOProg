namespace SimpleRPGFromScratch.Data.Base
{
    /// <summary>
    /// Denne klasse rummer blot en standard-implementation af Copy().
    /// </summary>
    public abstract class DomainClassBase<T> : IDomainClass 
        where T : class
    {
        public const int NullId = -1;
        public abstract int GetId();
        public abstract void SetId(int id);
        public abstract void CopyValuesFromObj(T obj);

        protected DomainClassBase()
        {
            SetInitialValues();
        }

        /// <summary>
        /// Implementation af Copy(), som en "shallow" kopiering.
        /// </summary>
        /// <returns></returns>
        public IDomainClass Copy()
        {
            return (MemberwiseClone() as IDomainClass);
        }

        public void CopyValuesFrom(IDomainClass obj)
        {
            T tObj = (obj as T);
            CopyValuesFromObj(tObj);
        }

        public virtual void SetInitialValues()
        {
        }
    }
}