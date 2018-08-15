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
            TestWeaponFactory(new WeaponFactoryMedieval());
            Console.WriteLine();

            Console.WriteLine("Testing Future Weapon Factory");
            TestWeaponFactory(new WeaponFactoryFuture());
            Console.WriteLine();
        }

        private static void TestWeaponFactory(IWeaponFactory factory)
        {
            IWeapon meeleWeapon = factory.Create(WeaponType.Melee);
            IWeapon rangedWeapon = factory.Create(WeaponType.Ranged);
            IWeapon magicWeapon = factory.Create(WeaponType.Magic);

            Console.WriteLine($"Meele Weapon: {meeleWeapon}");
            Console.WriteLine($"Ranged Weapon: {rangedWeapon}");
            Console.WriteLine($"Magic Weapon: {magicWeapon}");
        }
    }
}