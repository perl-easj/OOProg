using System.Collections.Generic;

namespace AdvLINQ
{
    public class FlyweightFactoryBase<T, Tkey, Tin, Tex>
    {
        private Dictionary<Tkey, Tin> _intrinsicStateData;

        public FlyweightFactoryBase()
        {
            _intrinsicStateData = new Dictionary<Tkey, Tin>();
        }

        public T Create(Tin inStateData, Tkey exStateDataKey)
        {
            //ProfileExtrinsic pe = new ProfileExtrinsic(userName);
            //ProfileIntrinsic pi;

            //if (_intrinsicStateData.ContainsKey(imageId))
            //{
            //    pi = _intrinsicStateData[imageId];
            //}
            //else
            //{
            //    pi = new ProfileIntrinsic(ImageDB.Read(imageId));
            //    _intrinsicStateData[imageId] = pi;
            //}

            //return new ProfileV2(pe, pi);

            return default(T);
        }
    }
}