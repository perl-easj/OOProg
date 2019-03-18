namespace SOLID.Liskov
{
    public class AltruisticCEO : Employee
    {
        public override int GetYearlySalary()
        {
            return 0;
        }
    }
}