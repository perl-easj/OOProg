using System.Collections.Generic;

namespace Patterns.Flyweight
{
    public class ProfileFactory
    {
        private Dictionary<int, ProfileIntrinsic> _intrinsicStateData;

        public ProfileFactory()
        {
            _intrinsicStateData = new Dictionary<int, ProfileIntrinsic>();
        }

        public ProfileInEx Create(string userName, int imageId)
        {
            ProfileExtrinsic pe = new ProfileExtrinsic(userName);
            ProfileIntrinsic pi;

            if (_intrinsicStateData.ContainsKey(imageId))
            {
                pi = _intrinsicStateData[imageId];
            }
            else
            {
                pi = new ProfileIntrinsic(ImageDB.Read(imageId));
                _intrinsicStateData[imageId] = pi;
            }

            return new ProfileInEx(pe, pi);
        }
    }

}