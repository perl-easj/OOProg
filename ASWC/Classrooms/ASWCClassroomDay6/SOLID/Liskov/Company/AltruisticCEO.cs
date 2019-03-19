namespace SOLID.Liskov.Company
{
    public class AltruisticCEO : Employee
    {
        public override int GetYearlySalary()
        {
            return 0;
        }
    }
}