using SOLID.IntSeg.Interfaces;

namespace SOLID.IntSeg.Decorators
{
    /// <summary>
    /// Implements a decorated version of Delete, which will ask
    /// for confirmation before executing the Delete operation.
    /// Specific implementation of confirmation is deferred to
    /// derived classes (Hello, Template Method pattern!)
    /// </summary>
    public abstract class DeleteWithConfirm<T> : IDelete<T>
    {
        private IDelete<T> _deleteImpl;

        protected DeleteWithConfirm(IDelete<T> deleteImpl)
        {
            _deleteImpl = deleteImpl;
        }

        public void Delete(int key)
        {
            if (ConfirmDelete(key))
            {
                _deleteImpl.Delete(key);
            }
        }

        protected abstract bool ConfirmDelete(int key);
    }
}