namespace SOLID.Liskov
{
    public interface IEmployee
    {
        /// <summary>
        /// Contract: the yearly salary returned must
        /// be a value between 10,000 and 1,000,000
        /// </summary>
        int GetYearlySalary();
    }
}