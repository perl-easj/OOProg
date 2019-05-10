using System.Collections.Generic;
using EFCore20Demo.DBEFClasses;
using EFCore20Demo.DomainClasses;

namespace EFCore20Demo.ModelClasses
{
    public class DomainModel
    {
        private DataSource _source;

        #region Singleton implementation
        private static DomainModel _instance;
        public static DomainModel Instance
        {
            get
            {
                _instance = _instance ?? (_instance = new DomainModel());
                return _instance;
            }
        }

        public static DomainModel Catalogs { get { return Instance; } }
        #endregion

        #region Constructor
        private DomainModel()
        {
            _source = null;
            Cars = new List<CarClass>();
            Customers = new List<CustomerClass>();
            Employees = new List<EmployeeClass>();
            Sales = new List<SaleClass>();
        }
        #endregion

        #region Properties
        public List<CarClass> Cars { get; private set; }
        public List<CustomerClass> Customers { get; private set; }
        public List<EmployeeClass> Employees { get; private set; }
        public List<SaleClass> Sales { get; private set; }

        public DataSource Source
        {
            get { return _source; }
            set
            {
                _source = value;
                if (_source != null)
                {
                    Cars = _source.LoadTable<CarClass>();
                    Customers = _source.LoadTable<CustomerClass>();
                    Employees = _source.LoadTable<EmployeeClass>();
                    Sales = _source.LoadTable<SaleClass>();
                }
            }
        }

        #endregion

        #region Business logic methods
        public int CarsSoldByEmployee(int employeeKey)
        {
            return Sales.FindAll(obj => obj.EmployeeKey == employeeKey).Count;
        }
        #endregion
    }
}