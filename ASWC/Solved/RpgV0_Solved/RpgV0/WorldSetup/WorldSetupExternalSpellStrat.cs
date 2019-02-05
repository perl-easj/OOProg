using System;
using System.Collections.Generic;

namespace RpgV0.WorldSetup
{
    /// <summary>
    /// This class makes it possible to execute a spell casting strategy provided by the
    /// caller, based on a Player/Spell "matrix". The PlayerSpellIndex property should be
    /// read as: PlayerSpellIndex[i][j] means the j'th Spell for the i'th Player.
    /// </summary>
    public class WorldSetupExternalSpellStrat : WorldSetupDefaultBase
    {
        private List<List<int>> PlayerSpellIndex { get; }

        /// <summary>
        /// The constructor will perform the "A" phase of the validation of the strategy.
        /// </summary>
        public WorldSetupExternalSpellStrat(List<List<int>> playerSpellIndex)
        {
            ValidatePlayerSpellsPhaseA(playerSpellIndex);
            PlayerSpellIndex = playerSpellIndex;
        }

        /// <summary>
        /// Executes the spell casting strategy, if the provided strategy is valid.
        /// </summary>
        protected override void SetupSpellCasting(List<Player> players)
        {
            ValidatePlayerSpellsPhaseB(PlayerSpellIndex, players);

            for (int i = 0; i < players.Count; i++)
            {
                for (int j = 0; j < PlayerSpellIndex[i].Count; j++)
                {
                    players[i].CastSpell(Spells[PlayerSpellIndex[i][j]].Description);
                }
            }
        }

        /// <summary>
        /// Validates the Player/Spell setup according to the rule:
        /// Each Player can at most cast two Spells.
        /// </summary>
        private void ValidatePlayerSpellsPhaseA(List<List<int>> playerSpells)
        {
            foreach (List<int> spells in playerSpells)
            {
                if (spells.Count > 2)
                {
                    throw new ArgumentException("Invalid spell count (ValidatePlayerSpellsPhaseA)");
                }
            }
        }

        /// <summary>
        /// Validates the Player/Spell setup according to the rule:
        /// An entry must be present for each Player.
        /// </summary>
        private void ValidatePlayerSpellsPhaseB(List<List<int>> playerSpells, List<Player> players)
        {
            if (playerSpells.Count != players.Count)
            {
                throw new ArgumentException("Invalid spell list count (ValidatePlayerSpellsPhaseB)");
            }
        }
    }
}