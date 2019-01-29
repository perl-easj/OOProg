namespace ASWCClassroomDay0.Inheritance
{
    public class Cat : Animal
    {
        public int NoOfLives { get; set; }

        public Cat(int age) : base(age)
        {
            NoOfLives = 9;
        }
    }
}