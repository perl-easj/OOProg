using Data.InMemory.Interfaces;
using Extensions.Model.Implementation;
using SimpleRPGDemo.Data.Persistent;
using SimpleRPGDemo.Model.Interfaces;

namespace SimpleRPGDemo.Model.Base
{
    public class CatalogAppBase<T> : EFCoreCatalog<SimpleRPGDBContext, T>
        where T : class, IStorable, ICopyable, new()
    {
        protected IValidate<T> Validator { get; set; }

        public CatalogAppBase() : base(KeyManagementStrategyType.CollectionDecides)
        {
            Validator = null;
        }

        public override T CreateDomainObjectFromViewDataObject(T obj)
        {
            if (Validator == null || Validator.Validate(obj))
            {
                return base.CreateDomainObjectFromViewDataObject(obj);
            }

            return null;
        }
    }
}