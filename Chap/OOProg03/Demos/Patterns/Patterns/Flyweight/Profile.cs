namespace Patterns.Flyweight
{
    public class Profile : IProfile
    {
        public Profile(string userName, int imageId)
        {
            UserName = userName;
            ImageData = ImageDB.Read(imageId);
        }

        public string UserName { get; }
        public int[] ImageData { get; } // Raw image data

        public void Display()
        {
            // Uses UserName and ImageData
        }
    }

}