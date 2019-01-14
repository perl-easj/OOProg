namespace SimpleRPGFromScratch.Data.Base
{
    // TODO - Kommentarer
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

        public virtual bool IsValid
        {
            get { return true; }
        }

        public static int IdOrNullId(int? id)
        {
            return id ?? NullId;
        }


    }
}