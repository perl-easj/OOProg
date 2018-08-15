namespace EmployeesV10
{
    /// <summary>
    /// This class now only contains elements  
    /// specific for a Teacher
    /// </summary>
    class Teacher : Employee
    {
        private int _payGrade;

        public Teacher(string name, int hoursPerWeek, int payGrade)
            : base(name, hoursPerWeek)
        {
            _payGrade = payGrade;
        }

        public int PayGrade
        {
            get { return _payGrade; }
            set { _payGrade = value;}
        }

        public string AllInformation
        {
            get
            {
                return $"Teacher {Name} works {HoursPerWeek} hours/week, at paygrade {PayGrade}";
            }
        }
    }
}
