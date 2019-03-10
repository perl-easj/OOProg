using SOLID.DI;
using SOLID.SingleResp;
using Cat = SOLID.DI.Cat;

namespace SOLID
{
    class Program
    {
        static void Main(string[] args)
        {
            IWorld aWorld = new WorldManyAnimals();
            Cat aCat = new Cat(aWorld);

            IAnimalLibrary aLib = new AnimalLibrary();
            SingleResp.Cat bCat = new SingleResp.Cat(aLib);
        }
    }
}
