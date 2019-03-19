using System.Collections.Generic;
using SOLID.IntSeg.Interfaces;

namespace SOLID.IntSeg.Clients
{
    /// <summary>
    /// This client wants an implementation of the full ICreateReadUpdateDelete
    /// interface, even though it only uses the Delete functionality.
    /// </summary>
    public class ClientV1<T>
    {
        private ICreateReadUpdateDelete<T> _catalog;

        public ClientV1(ICreateReadUpdateDelete<T> catalog)
        {
            _catalog = catalog;
        }

        public void DeleteMany(List<int> keys)
        {
            keys.ForEach(_catalog.Delete);
        }
    }
}