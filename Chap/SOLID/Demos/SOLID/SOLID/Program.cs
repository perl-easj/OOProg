using SOLID.DI;
using SOLID.SingleResp;

namespace SOLID
{
    class Program
    {
        static void Main(string[] args)
        {
            IWorld aWorld = new WorldManyAnimals();
            IAnimalLibrary aLib = new AnimalLibrary();

            DI.Cat diCat = new DI.Cat(aWorld);
            SingleResp.Cat srCat = new SingleResp.Cat(aWorld, aLib);
        }
    }
}
