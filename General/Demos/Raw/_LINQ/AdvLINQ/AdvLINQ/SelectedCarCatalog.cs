using System;
using System.Collections.Generic;

namespace AdvLINQ
{
    public class SelectedCarCatalog : CarCatalog
    {
        private Func<Car, bool> _selectorFunc;

        public SelectedCarCatalog(Func<Car, bool> selectorFunc, bool loadTestData = false) 
            : base(loadTestData)
        {
            _selectorFunc = selectorFunc;
        }

        public override IEnumerator<Car> GetEnumerator()
        {
            foreach (Car c in All)
            {
                if (_selectorFunc(c))
                {
                    yield return c;
                }
            }
        }
    }
}