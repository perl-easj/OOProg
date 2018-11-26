namespace SimpleRPGFromScratch.Data.Base
{
    /// <summary>
    /// Denne klasse rummer blot en standard-implementation af Copy().
    /// </summary>
    public abstract class DomainClassBase : IDomainClass
    {
        public abstract int GetId();
        public abstract void SetId(int id);

        /// <summary>
        /// Implementation af Copy(), som en "shallow" kopiering.
        /// </summary>
        /// <returns></returns>
        public IDomainClass Copy()
        {
            return (MemberwiseClone() as IDomainClass);
        }
    }
}