using System.Collections.Generic;

namespace RpgV0
{
    /// <summary>
    /// Minimal interface for any class implementing a specific world setup.
    /// </summary>
    public interface IWorldSetup
    {
        /// <summary>
        /// Returns a List of Player objects, where each Player object has 
        /// 1) Been initialised with available Spells
        /// 2) Casted (at most) two spells.
        /// </summary>
        List<Player> Setup();
    }
}