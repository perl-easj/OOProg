using AddOns.Security.Interfaces;

namespace AddOns.Security.Implementation
{
    /// <summary>
    /// Implementation of IUser interface.
    /// </summary>
    public class User : IUser
    {
        #region Constants
        public const string AnonymousUserName = "(none)";
        public const string AnonymousUserPassword = "(none)";
        public const string AnonymousUserType = "(none)";
        #endregion

        #region Constructors
        /// <summary>
        /// Default "anonymous" user.
        /// </summary>
        public User() : this(AnonymousUserName, AnonymousUserPassword, AnonymousUserType)
        {
        }

        /// <summary>
        /// Standard constructor.
        /// </summary>
        public User(string name, string password, string userType)
        {
            Name = name;
            Password = password;
            UserType = userType;
        }
        #endregion

        #region Properties
        public string Name { get; }
        public string Password { get; }
        public string UserType { get; }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"User :  {Name} \n";
        }
        #endregion
    }
}