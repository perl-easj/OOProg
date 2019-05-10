using System.Collections.Generic;

namespace GenericsDraft01
{
    public class FilterList
    {
        public List<Cat> FilterCats(List<Cat> cats)
        {
            List<Cat> filteredCats = new List<Cat>();

            for (int index = 0; index < cats.Count; index++)
            {
                if (index % 3 == 0)
                {
                    filteredCats.Add(cats[index]);
                }
            }

            return filteredCats;
        }

        public List<Dog> FilterDogs(List<Dog> dogs)
        {
            List<Dog> filteredDogs = new List<Dog>();

            for (int index = 0; index < dogs.Count; index++)
            {
                if (index % 3 == 0)
                {
                    filteredDogs.Add(dogs[index]);
                }
            }

            return filteredDogs;
        }
    }
}