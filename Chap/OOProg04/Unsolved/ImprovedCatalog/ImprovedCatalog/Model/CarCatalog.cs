using ImprovedCatalog.DomainClasses;

namespace ImprovedCatalog.Model
{
    /// <summary>
    /// Car-specific Catalog
    /// </summary>
    public class CarCatalog : CatalogAppBase<string, Car>
    {
        public CarCatalog(bool loadTestData = false)
            : base(loadTestData)
        {
        }

        protected override void LoadTestData()
        {
            Car carA = new Car("AA 111", 10000, "Car A");
            Car carB = new Car("BB 222", 20000, "Car B");
            Car carC = new Car("CC 333", 30000, "Car C");
            Car carD = new Car("DD 444", 40000, "Car D");
            Car carE = new Car("EE 555", 50000, "Car E");

            Insert(carA.Plate, carA);
            Insert(carB.Plate, carB);
            Insert(carC.Plate, carC);
            Insert(carD.Plate, carD);
            Insert(carE.Plate, carE);
        }
    }
}