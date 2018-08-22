namespace AddOns.Security.Interfaces
{
    /// <summary>
    /// Interface for an application user.
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// Unique name for user.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Password for user.
        /// </summary>
        string Password { get; }

        /// <summary>
        /// Type of user. No specific user types are assumed.
        /// </summary>
        string UserType { get; }
    }
}