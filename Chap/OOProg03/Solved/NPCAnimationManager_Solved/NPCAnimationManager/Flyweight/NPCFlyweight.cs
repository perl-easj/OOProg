using NPCAnimationManager.Common.Animation;

namespace NPCAnimationManager.Flyweight
{
    /// <summary>
    /// The Flyweight for an NPC. This class:
    /// 1) Contains the INtrinsic state.
    /// 2) Is passed an EXtrinsic state when Animate is invoked.
    /// Note that this class does NOT implement INPC.
    /// </summary>
    public class NPCFlyweight
    {
        public NPCInState IntrinsicState { get; }

        public NPCFlyweight(NPCInState inState)
        {
            IntrinsicState = inState;
        }

        /// <summary>
        /// Revised implementation of Animate, since Animate
        /// now needs to be passed the EXtrinsic state.
        /// </summary>
        public void Animate(NPCExState exState)
        {
            AnimationHandler.PerformAnimation(
                exState.X, exState.Y, exState.CurrentState, 
                IntrinsicState.AnimationData);
        }
    }
}