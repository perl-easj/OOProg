namespace AdvLINQ
{
    public class ProfileV3 : FlyweightBase<ProfileExtrinsic, ProfileIntrinsic>
    {
        public ProfileV3(ProfileExtrinsic exState, ProfileIntrinsic inState)
            : base(exState, inState)
        {
        }

        public void Display()
        {
            // Uses UserName and ImageData
        }
    }
}