namespace WildLife.Common
{
    public class World : IWorld
    {
        private static World _instance;

        private bool _nearBy;
        private AnimalGender _genderOfNearBy;

        public static World Instance
        {
            get { return _instance ?? (_instance = new World()); }
        }

        private World()
        {
            UpdateState();
        }

        public void UpdateState()
        {
            _nearBy = Randomizer.CoinFlip();
            _genderOfNearBy = Randomizer.CoinFlip() ? AnimalGender.male : AnimalGender.female;
        }

        public bool NearBy(AnimalKind kind)
        {
            return _nearBy;
        }

        public AnimalGender GenderOfNearBy(AnimalKind kind)
        {
            return _genderOfNearBy;
        }

        public override string ToString()
        {
            return $"Near by is {_nearBy}, gender is {_genderOfNearBy}";
        }
    }
}