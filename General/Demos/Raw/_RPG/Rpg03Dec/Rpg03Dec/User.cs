namespace Rpg03Dec
{
    public class User
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public User()
        {
        }

        public User(string name, string password)
        {
            Name = name;
            Password = password;
        }
    }
}