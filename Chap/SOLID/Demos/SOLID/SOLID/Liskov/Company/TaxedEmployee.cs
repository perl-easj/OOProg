namespace SOLID.Liskov.Company
{
    public class TaxedEmployee : IEmployee2
    {
        public TaxedEmployee(int taxPercentage)
        {
            TaxPercentage = taxPercentage;
        }

        public int GetYearlySalary()
        {
            return 0;
        }

        public int GetYearlySalaryAfterTax()
        {
            return 0;
        }

        public int TaxPercentage { get; protected set; }
    }
}