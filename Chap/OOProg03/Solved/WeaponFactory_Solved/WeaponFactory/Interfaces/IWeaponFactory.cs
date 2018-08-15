namespace WeaponFactory.Interfaces
{
    /// <summary>
    /// Interface for all weapon factory classes
    /// </summary>
    public interface IWeaponFactory
    {
        IWeapon Create(WeaponType type);
    }
}