namespace ASWCClassroomDay0.Inheritance
{
    public interface IAnimal
    {
        void Sound();
        void Eat(string food);
        bool Sleeping { get; }
    }

}