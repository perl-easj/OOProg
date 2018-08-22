using System;
using System.Threading.Tasks;
using CarRetailDemo.Models.Catalog;

namespace CarRetailDemo.Models.App
{
    public class DomainModel 
    {
        #region Instance fields
        private CarCatalog _carCatalog;
        private CustomerCatalog _customerCatalog;
        private EmployeeCatalog _employeeCatalog;
        private SaleCatalog _saleCatalog;
        #endregion

        #region Events
        public event Action LoadBegins;
        public event Action LoadEnds;
        public event Action SaveBegins;
        public event Action SaveEnds;
        #endregion

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
            _carCatalog = new CarCatalog();
            _customerCatalog = new CustomerCatalog();
            _employeeCatalog = new EmployeeCatalog();
            _saleCatalog = new SaleCatalog();
        }
        #endregion

        #region Properties
        public CarCatalog Cars { get { return _carCatalog; } }
        public CustomerCatalog Customers { get { return _customerCatalog; } }
        public EmployeeCatalog Employees { get { return _employeeCatalog; } }
        public SaleCatalog Sales { get { return _saleCatalog; } }
        #endregion

        #region Persistency methods
        public async Task LoadAsync()
        {
            LoadBegins?.Invoke();

            await _carCatalog.LoadAsync();
            await _customerCatalog.LoadAsync();
            await _employeeCatalog.LoadAsync();
            await _saleCatalog.LoadAsync();

            LoadEnds?.Invoke();
        }

        public async Task SaveAsync()
        {
            SaveBegins?.Invoke();

            await _carCatalog.SaveAsync();
            await _customerCatalog.SaveAsync();
            await _employeeCatalog.SaveAsync();
            await _saleCatalog.SaveAsync();

            SaveEnds?.Invoke();
        } 
        #endregion

        #region Business logic methods
        public int CarsSoldByEmployee(int employeeKey)
        {
            return Sales.All.FindAll(obj => obj.EmployeeKey == employeeKey).Count;
        } 
        #endregion
    }
}