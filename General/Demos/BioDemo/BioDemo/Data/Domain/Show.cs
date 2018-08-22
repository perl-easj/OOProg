using System;
using BioDemo.Data.Base;
using BioDemo.Models.App;

namespace BioDemo.Data.Domain
{
    /// <summary>
    /// Class defining a "show", being defined as a single showing
    /// of a single movie in a single theater, at a specific time.
    /// A Show object will refer to a Movie and a Theater object
    /// through a key value; properties for converting a key value
    /// into an object reference are also included.
    /// </summary>
    public class Show : DomainAppBase
    {
        #region Properties
        public DateTime DateForShow { get; set; }
        public TimeSpan TimeForShow { get; set; }
        public int MovieKey { get; set; }
        public int TheaterKey { get; set; }

        public Movie MovieForShow
        {
            get { return DomainModel.Instance.MovieCatalog.Read(MovieKey); }
        }

        public Theater TheaterForShow
        {
            get { return DomainModel.Instance.TheaterCatalog.Read(TheaterKey); }
        }
        #endregion

        #region Methods
        public override void SetDefaultValues()
        {
            MovieKey = NullKey;
            TheaterKey = NullKey;
            DateForShow = DateTime.Now;
            TimeForShow = DateTime.Now.TimeOfDay;
        } 
        #endregion
    }
}