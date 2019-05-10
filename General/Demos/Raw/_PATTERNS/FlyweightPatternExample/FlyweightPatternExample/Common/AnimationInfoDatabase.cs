using System;

namespace FlyweightPatternExample.Common
{
    public class AnimationInfoDatabase
    {
        private const int AnimationDataSize = 25000;
        private static Random _rng = new Random(Guid.NewGuid().GetHashCode());

        public static int[] GetAnimationBinaryData(ParticipantType pType)
        {
            int[] data = new int[AnimationDataSize];
            for (int i = 0; i < AnimationDataSize; i++)
            {
                data[i] = _rng.Next();
            }

            return data;
        }
    }
}