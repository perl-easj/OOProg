using System;

namespace Data.Persistent.Implementation
{
    /// <summary>
    /// Customer exception class, to be thrown if a non-supported 
    /// data source method is called.
    /// </summary>
    public class DataSourceOperationNotSupportedException : NotSupportedException
    {
        public DataSourceOperationNotSupportedException(string operation)
            : base($"{operation} is not supported by this data source")
        {
        }
    }
}