using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomizedSelection
{
    interface ISelectee<T>
    {
        T Selectee { get; }
        double Probability { get; }
    }
}
