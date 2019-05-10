using System;
using System.Collections.Generic;

namespace Rpg03Dec
{
    public class CatalogBase<T>
    {
        public event Action CatalogChanged;

        public List<T> All
        {
            get; set;
        }

        public void Create(T newObj)
        {
            All.Add(newObj);
            OnCatalogChanged();
        }

        protected virtual void OnCatalogChanged()
        {
            CatalogChanged?.Invoke();
        }
    }
}