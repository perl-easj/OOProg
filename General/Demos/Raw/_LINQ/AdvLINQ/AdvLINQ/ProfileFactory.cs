using System.Collections.Generic;

namespace AdvLINQ
{
    public class ProfileFactory
    {
        private Dictionary<int, ProfileIntrinsic> _intrinsicStateData;

        public ProfileFactory()
        {
            _intrinsicStateData = new Dictionary<int, ProfileIntrinsic>();
        }

        public ProfileV2 Create(string userName, int imageId)
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

            return new ProfileV2(pe, pi);
        }
    }

    public class ImageDB
    {
        public static int[] Read(int id)
        {
            return null;
        }
    }
}