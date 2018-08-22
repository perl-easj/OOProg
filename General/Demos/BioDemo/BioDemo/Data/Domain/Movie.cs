using BioDemo.Data.Base;

namespace BioDemo.Data.Domain
{
    /// <summary>
    /// Simplistic domain class for movies.
    /// </summary>
    public class Movie : DomainAppBase
    {
        #region Properties
        public string Title { get; set; }
        public int LengthInMins { get; set; }
        public int AgeLimit { get; set; }
        #endregion

        #region Methods
        public override void SetDefaultValues()
        {
            Title = "(titel)";
            LengthInMins = 90;
            AgeLimit = 7;
        } 
        #endregion
    }
}