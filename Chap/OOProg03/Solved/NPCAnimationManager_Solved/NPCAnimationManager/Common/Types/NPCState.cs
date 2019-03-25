namespace NPCAnimationManager.Common.Types
{
    /// <summary>
    /// Valid NPC states. It is assumed that each state
    /// requires a different animation.
    /// </summary>
    public enum NPCState
    {
        idle,
        fearful,
        aggressive,
        dead
    }
}