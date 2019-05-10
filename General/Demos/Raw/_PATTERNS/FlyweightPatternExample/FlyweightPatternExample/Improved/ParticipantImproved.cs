using FlyweightPatternExample.Common;

namespace FlyweightPatternExample.Improved
{
    public class ParticipantImproved
    {
        public ParticipantIntrinsicState IntrinsicState { get; }

        public ParticipantImproved(ParticipantIntrinsicState intrinsicState)
        {
            IntrinsicState = intrinsicState;
        }

        public void Animate(ParticipantExtrinsicState state)
        {
            AnimationManager.PerformAnimation(state.X, state.Y, state.Mode, IntrinsicState.AnimationBinaryData);
        }
    }
}