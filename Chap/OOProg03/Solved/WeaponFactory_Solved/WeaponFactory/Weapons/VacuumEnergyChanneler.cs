namespace WeaponFactory.Weapons
{
    public class VacuumEnergyChanneler : WeaponBase
    {
        public override string Description
        {
            get { return "(Classified - just press X to use)"; }
        }

        public override int Damage
        {
            get { return int.MaxValue; }
        }
    }
}