using NPCAnimationManager.Common.Interfaces;

namespace NPCAnimationManager.Flyweight
{
    /// <summary>
    /// Factory for generation of revised NPC objects.
    /// </summary>
    public class NPCRevisedFactory : INPCFactory
    {
        private NPCFlyweightFactory FlyweightFactory { get; }

        public NPCRevisedFactory()
        {
            FlyweightFactory = new NPCFlyweightFactory();
        }

        /// <summary>
        /// Returns an NPC with a randomly generated type.
        /// </summary>
        public INPC Create()
        {
            // 1) Generate a randomised EXtrinsic state object
            NPCExState exState = FlyweightFactory.CreateExState();

            // 2) Use the NPC type from the EXtrinsic state object
            //    to generate a (possibly shared) INtrinsic state object.
            NPCInState inState = FlyweightFactory.CreateFlyWeight(exState.TypeOfNPC).IntrinsicState;

            // 3) Finally create the revised NPC object, which implements INPC.
            return new NPCRevised(inState, exState);
        }


    }
}