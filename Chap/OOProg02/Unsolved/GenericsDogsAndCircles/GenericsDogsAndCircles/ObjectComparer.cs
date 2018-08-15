namespace GenericsDogsAndCircles
{
    public class ObjectComparer
    {
        public Dog LargestDog(Dog a, Dog b, Dog c)
        {
            if (a.Weight > b.Weight)
            {
                return a.Weight > c.Weight ? a : c;
            }

            return b.Weight > c.Weight ? b : c;
        }

        public Circle LargestCircle(Circle a, Circle b, Circle c)
        {
            if (a.Area > b.Area)
            {
                return a.Area > c.Area ? a : c;
            }

            return b.Area > c.Area ? b : c;
        }
    }
}