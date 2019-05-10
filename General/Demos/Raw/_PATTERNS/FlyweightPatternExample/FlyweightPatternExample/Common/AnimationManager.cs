using System;

namespace FlyweightPatternExample.Common
{
    public class AnimationManager
    {
        public static void PerformAnimation(double x, double y, ParticipantMode mode, int[] animationdata)
        {
            if (animationdata == null) throw new ArgumentException("Tried to call PerformAnimation without animation data");
        }
    }
}