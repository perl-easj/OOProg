namespace AdvLINQ
{
    public class ProfileIntrinsic
    {
        public ProfileIntrinsic(int[] imageData)
        {
            ImageData = imageData;
        }

        public int[] ImageData { get; }

        public void Display(ProfileExtrinsic extrinsicState)
        {
            // Uses both extrinsic and intrinsic state data,
            // but extrinsic state is now a parameter!
        }
    }
}