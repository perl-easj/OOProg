namespace WildLife.Common
{
    public interface IWorld
    {
        void UpdateState();
        bool NearBy(AnimalKind kind);
        AnimalGender GenderOfNearBy(AnimalKind kind);
    }
}