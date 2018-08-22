using BioDemo.Data.Base;

namespace BioDemo.Data.Domain
{
    /// <summary>
    /// Simplistic domain class for a theater, being defined as a room
    /// in which movies are shown for an audience.
    /// </summary>
    public class Theater : DomainAppBase
    {
        #region Properties
        public string Description { get; set; }
        public int NoOfSeats { get; set; }
        public bool Supports3D { get; set; }
        #endregion

        #region Methods
        public override void SetDefaultValues()
        {
            Description = "(description)";
            NoOfSeats = 1;
            Supports3D = false;
        } 
        #endregion
    }
}