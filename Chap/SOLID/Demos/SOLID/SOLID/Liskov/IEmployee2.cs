namespace SOLID.Liskov.Yes
{
    public interface IEmployee2
    {
        int GetYearlySalary();
        int GetYearlySalaryAfterTax();

        /// <summary>
        /// Contract: the returned value must be the same throughout
        /// the lifetime of any object implementing this interface.
        /// </summary>
        int TaxPercentage { get; }
    }
}