using EFCore20Demo.ModelClasses;

namespace EFCore20Demo.DBEFClasses
{
    public class Config
    {
        public static void Configure()
        {
            DomainModel.Instance.Source = new DataSource(new CarRetailDBContext());
        }
    }
}