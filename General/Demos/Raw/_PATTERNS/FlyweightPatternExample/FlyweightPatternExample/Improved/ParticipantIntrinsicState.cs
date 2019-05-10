using FlyweightPatternExample.Common;

namespace FlyweightPatternExample.Improved
{
    public class ParticipantIntrinsicState
    {
        public int[] AnimationBinaryData { get; }

        public ParticipantIntrinsicState(ParticipantType partType)
        {
            AnimationBinaryData = AnimationInfoDatabase.GetAnimationBinaryData(partType);
        }
    }
}