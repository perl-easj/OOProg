using SOLID.Liskov.Yes;

namespace SOLID.Liskov
{
    public class VariablyTaxedEmployee : TaxedEmployee
    {
        public VariablyTaxedEmployee(int taxPercentage) : base(taxPercentage)
        {
        }
    }
}