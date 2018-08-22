using System;
using Data.InMemory.Implementation;

namespace BioDemo.Data.Base
{
    /// <summary>
    /// This class will be a base class for all domain classes.
    /// This is preferred instead of letting domain classes inherit
    /// directly from DomainClassBase, since we can then change the
    /// inheritance setup for all domain classes by changing this
    /// single base class.
    /// </summary>
    public abstract class DomainAppBase : DomainClassBase
    {
        public override int Key { get; set; }
    }
}
