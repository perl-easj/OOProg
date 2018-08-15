using System;

namespace Flinter
{
    public class InsertCodeHere
    {
        public void MyCode()
        {
            // The FIRST line of code should be BELOW this line

            Profile profile1 = new Profile(Profile.Gender.Man, Profile.EyeColor.Blue, Profile.HairColor.Black, Profile.HeightCategory.Short);
            Profile profile2 = new Profile(Profile.Gender.Woman, Profile.EyeColor.Blue, Profile.HairColor.Blond, Profile.HeightCategory.Tall);
            Profile profile3 = new Profile(Profile.Gender.Man, Profile.EyeColor.Green, Profile.HairColor.White, Profile.HeightCategory.Unknown);

            Console.WriteLine(profile1.Description);
            Console.WriteLine(profile2.Description);
            Console.WriteLine(profile3.Description);

            // The LAST line of code should be ABOVE this line
        }
    }
}