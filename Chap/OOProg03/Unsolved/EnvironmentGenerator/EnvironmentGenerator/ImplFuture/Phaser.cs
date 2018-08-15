using EnvironmentGenerator.Interfaces;

namespace EnvironmentGenerator.ImplFuture
{
    public class Phaser : IWeapon
    {
        public string ElementDescription
        {
            get { return "Phaser"; }
        }

        public int Damage
        {
            // Set to stun, not kill... 
            get { return 80; }
        }
    }
}