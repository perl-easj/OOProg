using System;
using WeaponFactory.Factories;
using WeaponFactory.Interfaces;

namespace WeaponFactory
{
    /// <summary>
    /// Class for invoking a test of the weapon factory classes..
    /// </summary>
    public class WeaponFactoryTest
    {
        public static void Run()
        {
            Console.WriteLine("Testing Medieval Weapon Factory");
            // Uncomment the below line to run a test of WeaponFactoryMedieval
            // TestWeaponFactory(new WeaponFactoryMedieval());
            Console.WriteLine();

            Console.WriteLine("Testing Future Weapon Factory");
            // Uncomment the below line to run a test of WeaponFactoryFuture
            // TestWeaponFactory(new WeaponFactoryFuture());
            Console.WriteLine();
        }

        private static void TestWeaponFactory(IWeaponFactory factory)
        {
            IWeapon meleeWeapon = factory.Create(WeaponType.Melee);
            IWeapon rangedWeapon = factory.Create(WeaponType.Ranged);
            IWeapon magicWeapon = factory.Create(WeaponType.Magic);

            Console.WriteLine($"Melee Weapon: {meleeWeapon}");
            Console.WriteLine($"Ranged Weapon: {rangedWeapon}");
            Console.WriteLine($"Magic Weapon: {magicWeapon}");
        }
    }
}