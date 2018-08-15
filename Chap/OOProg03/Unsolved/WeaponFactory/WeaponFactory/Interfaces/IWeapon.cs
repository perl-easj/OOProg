namespace WeaponFactory.Interfaces
{
    /// <summary>
    /// Interface for all weapons
    /// </summary>
    public interface IWeapon
    {
        string Description { get; }
        int Damage { get; }
    }
}