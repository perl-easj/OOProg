namespace Patterns.Flyweight
{
    public class ProfileInEx : IProfile
    {
        public ProfileInEx(
            ProfileExtrinsic extrinsicState,
            ProfileIntrinsic intrinsicState)
        {
            ExtrinsicState = extrinsicState;
            IntrinsicState = intrinsicState;
        }

        public ProfileExtrinsic ExtrinsicState { get; }
        public ProfileIntrinsic IntrinsicState { get; }

        public string UserName
        {
            get { return ExtrinsicState.UserName; }
        }

        public int[] ImageData
        {
            get { return IntrinsicState.ImageData; }
        }

        public void Display()
        {
            IntrinsicState.Display(ExtrinsicState);
        }
    }
}