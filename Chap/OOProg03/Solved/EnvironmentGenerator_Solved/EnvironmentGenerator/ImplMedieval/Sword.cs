using EnvironmentGenerator.Interfaces;

namespace EnvironmentGenerator.ImplMedieval
{
    public class Sword : IWeapon
    {
        public string ElementDescription
        {
            get { return "Sword"; }
        }

        public int Damage
        {
            // All swords deal 20 damage...
            get { return 20; }
        }
    }
}