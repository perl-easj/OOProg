namespace ExamAdmV23.BaseClasses
{
    /// <summary>
    /// A domain-specific data view model class 
    /// must inherit from this class
    /// </summary>
    /// <typeparam name="TDomainClass">Type of domain class</typeparam>
    public abstract class DataViewModelBase<TDomainClass>
        where TDomainClass : class
    {
        /// <summary>
        /// A derived class must call this constructor
        /// </summary>
        /// <param name="obj">Enclosed domain object</param>
        protected DataViewModelBase(TDomainClass obj)
        {
            DomainObject = obj;
        }

        /// <summary>
        /// The domain object enclosed by the
        /// item view model object
        /// </summary>
        public TDomainClass DomainObject;
    }
}