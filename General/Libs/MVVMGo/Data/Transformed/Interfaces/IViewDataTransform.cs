namespace Data.Transformed.Interfaces
{
    /// <summary>
    /// Interface for converting between domain data representation
    /// and view data representation.
    /// </summary>
    public interface IViewDataTransform<T, TViewData>
    {
        T CreateDomainObjectFromViewDataObject(TViewData vdObj);
        TViewData CreateViewDataObject(T obj);
    }
}