namespace Model.Interfaces
{
    /// <summary>
    /// A Catalog mediator is a class which implements a
    /// specific strategy for what should happen when a
    /// Catalog changes. Such a mediator should implement
    /// this interface.
    /// </summary>
    public interface ICatalogMediator
    {
        /// <summary>
        /// Invoked when the underlying model changes.
        /// </summary>
        void OnCatalogChanged(int key);
    }
}