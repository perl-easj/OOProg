namespace Client
{
    /// <summary>
    /// Interface for a Model, which is simply a set
    /// of Catalogs. 
    /// </summary>
    public interface IModel
    {
        /// <summary>
        /// Load the entire data model from persistent source.
        /// </summary>
        void LoadModel();

        /// <summary>
        /// Print the content of the entire data model
        /// </summary>
        void PrintModelContent();
    }
}