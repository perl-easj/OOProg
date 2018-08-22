namespace Data.InMemory.Interfaces
{
    /// <summary>
    /// Interface for objects having meaningful default values.
    /// This will typically be ViewData classes, where default 
    /// values are shown in a corresponding view.
    /// </summary>
    public interface IDefaultValues
    {
        /// <summary>
        /// A subclass can assign default values to
        /// the properties of the transformed data.
        /// </summary>
        void SetDefaultValues();
    }
}