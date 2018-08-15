namespace EmployeesV10
{
    /// <summary>
    /// This class now acts as a base class 
    /// for all kinds of employees
    /// </summary>
    class Employee
    {
        #region Instance fields
        private string _name;
        private int _hoursPerWeek;
        #endregion

        #region Constructor
        public Employee(string name, int hoursPerWeek)
        {
            _name = name;
            _hoursPerWeek = hoursPerWeek;
        }
        #endregion

        #region Properties
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int HoursPerWeek
        {
            get { return _hoursPerWeek; }
            set { _hoursPerWeek = value; }
        } 
        #endregion
    }
}
