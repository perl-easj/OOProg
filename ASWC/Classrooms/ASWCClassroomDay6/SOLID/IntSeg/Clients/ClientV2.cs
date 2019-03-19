using System.Collections.Generic;
using SOLID.IntSeg.Interfaces;

namespace SOLID.IntSeg.Clients
{
    /// <summary>
    /// This client wants an implementation of the segregated IDelete
    /// interface, because it only uses the Delete functionality.
    /// </summary>
    public class ClientV2<T>
    {
        private IDelete<T> _deleteImpl;

        public ClientV2(IDelete<T> deleteImpl)
        {
            _deleteImpl = deleteImpl;
        }

        public void DeleteMany(List<int> keys)
        {
            keys.ForEach(_deleteImpl.Delete);
        }
    }
}