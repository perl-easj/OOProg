namespace RolePlayV10
{
    public class Warrior
    {
        private string _name;

        public Warrior(string name)
        {
            _name = name;
        }

        public string Name
        {
            get { return _name; }
        }
    }
}