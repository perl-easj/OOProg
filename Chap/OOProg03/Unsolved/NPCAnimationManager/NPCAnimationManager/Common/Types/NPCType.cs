namespace NPCAnimationManager.Common.Types
{
    /// <summary>
    /// Valid NPC states. It is assumed that all NPCs
    /// of a given type are animated in the same way,
    /// i.e. by using animation data from the same package.
    /// </summary>
    public enum NPCType
    {
        creature,
        humanoid,
        spirit
    }
}