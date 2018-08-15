using System;

namespace Flinter
{
    public class InsertCodeHere
    {
        public void MyCode()
        {
            // The FIRST line of code should be BELOW this line

            Profile profile1 = new Profile(true, "Brown", "Black", 1);
            Profile profile2 = new Profile(false, "White", "Blue", 4);
            Profile profile3 = new Profile(true, "Blond", "Green", 8);

            Console.WriteLine(profile1.Description);
            Console.WriteLine(profile2.Description);
            Console.WriteLine(profile3.Description);

            // The LAST line of code should be ABOVE this line
        }
    }
}