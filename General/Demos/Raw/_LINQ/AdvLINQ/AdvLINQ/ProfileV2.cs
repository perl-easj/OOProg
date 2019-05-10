namespace AdvLINQ
{
    public class ProfileV2
    {
        public ProfileV2(
            ProfileExtrinsic extrinsicState, 
            ProfileIntrinsic intrinsicState)
        {
            ExtrinsicState = extrinsicState;
            IntrinsicState = intrinsicState;
        }

        public ProfileExtrinsic ExtrinsicState { get; }
        public ProfileIntrinsic IntrinsicState { get; } 

        public void Display()
        {
            IntrinsicState.Display(ExtrinsicState);
        }
    }
}