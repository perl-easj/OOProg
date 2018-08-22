namespace Data.Transformed.Interfaces
{
    /// <summary>
    /// Interface for converting between domain data representation
    /// and view data representation.
    /// </summary>
    public interface IViewDataTransform<TDomainData, TViewData>
    {
        TDomainData CreateDomainObjectFromViewDataObject(TViewData vdObj);
        TViewData CreateViewDataObject(TDomainData obj);
    }
}