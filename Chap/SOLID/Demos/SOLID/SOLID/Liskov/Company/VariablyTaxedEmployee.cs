namespace SOLID.Liskov.Company
{
    public class VariablyTaxedEmployee : TaxedEmployee
    {
        public VariablyTaxedEmployee(int taxPercentage) : base(taxPercentage)
        {
        }
    }
}