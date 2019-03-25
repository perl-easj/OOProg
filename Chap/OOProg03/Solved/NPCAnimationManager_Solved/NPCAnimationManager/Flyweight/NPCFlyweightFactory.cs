using System.Collections.Generic;
using NPCAnimationManager.Common.Helpers;
using NPCAnimationManager.Common.Types;

namespace NPCAnimationManager.Flyweight
{
    /// <summary>
    /// Factory for generation of objects related to NPCs.
    /// Note that the factory can create both Flyweight objects
    /// and EXtrinsic state objects.
    /// </summary>
    public class NPCFlyweightFactory
    {
        private Dictionary<NPCType, NPCFlyweight> _sharedNPCs;

        public NPCFlyweightFactory()
        {
            _sharedNPCs = new Dictionary<NPCType, NPCFlyweight>();
        }

        public NPCFlyweight CreateFlyWeight(NPCType npcType)
        {
            if (!_sharedNPCs.ContainsKey(npcType))
            {
                _sharedNPCs.Add(npcType, new NPCFlyweight(new NPCInState(npcType)));
            }

            return _sharedNPCs[npcType];
        }

        public NPCExState CreateExState()
        {
            NPCType npcType = NPCGeneratorHelper.GenerateRandomNPCType();
            return new NPCExState(npcType);
        }
    }
}