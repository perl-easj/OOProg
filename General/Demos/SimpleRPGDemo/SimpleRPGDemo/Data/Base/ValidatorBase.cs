using System;
using Model.Interfaces;
using SimpleRPGDemo.Model.Interfaces;

namespace SimpleRPGDemo.Data.Base
{
    public abstract class ValidatorBase<T> : IValidate<T>
    {
        protected ICatalog<T> Catalog { get; set; }

        public ValidatorBase(ICatalog<T> catalog)
        {
            Catalog = catalog;
        }

        public bool Validate(T obj)
        {
            if (ValidateObject(obj))
            {
                return true;
            }
            else
            {
                throw new ArgumentException(ValidationErrorString(obj));
            }
        }

        public virtual string ValidationErrorString(T obj)
        {
            return $"Validation of object of type {obj.GetType()} failed: {obj}";
        }

        protected abstract bool ValidateObject(T obj);
    }
}