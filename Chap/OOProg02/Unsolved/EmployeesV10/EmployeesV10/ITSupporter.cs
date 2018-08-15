namespace EmployeesV10
{
    public class ITSupporter
    {
        #region Instance fields
        private string _name;
        private int _hoursPerWeek;
        private string _primaryWorkArea;
        #endregion

        #region Constructor
        public ITSupporter(string name, int hoursPerWeek, string primaryWorkArea)
        {
            _name = name;
            _hoursPerWeek = hoursPerWeek;
            _primaryWorkArea = primaryWorkArea;
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

        public string PrimaryWorkArea
        {
            get { return _primaryWorkArea; }
            set { _primaryWorkArea = value; }
        }

        public string AllInformation
        {
            get
            {
                return $"IT-Supporter {Name} works {HoursPerWeek} hours/week, mostly with {PrimaryWorkArea}";
            }
        } 
        #endregion
    }
}
