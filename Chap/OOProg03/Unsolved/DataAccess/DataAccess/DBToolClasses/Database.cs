using System.Collections.Generic;
using DataAccess.DomainClasses;

namespace DataAccess.DBToolClasses
{
    /// <summary>
    /// Class which simulates a type-weak database,
    /// with some simplistic operations available.
    /// The class is a Singleton.
    /// </summary>
    public class Database
    {
        #region Singleton implementation
        private static Database _instance;
        public static Database Ínstance
        {
            get
            {
                _instance = _instance ?? new Database();
                return _instance;
            }
        }
        #endregion

        #region Instance fields
        private List<object> _records;
        #endregion

        #region Constructor
        private Database()
        {
            _records = new List<object>();

            // Add a few test records into the database.
            Customer c1 = new Customer("Allan", "12345678", 1);
            Customer c2 = new Customer("Bente", "87654321", 2);
            Customer c3 = new Customer("Carina", "12344321", 3);
            Customer c4 = new Customer("Dennis", "87655678", 4);
            Replace(new List<object> { c1, c2, c3, c4 });
        }
        #endregion

        #region Properties
        public List<object> AllRecords
        {
            get { return _records; }
        }
        #endregion

        #region Methods
        public void Replace(List<object> newRecords)
        {
            _records = newRecords;
        } 
        #endregion
    }
}