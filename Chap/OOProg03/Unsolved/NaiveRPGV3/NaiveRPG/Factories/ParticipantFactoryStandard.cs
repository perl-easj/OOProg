using System;
using System.Collections.Generic;
using NaiveRPG.Helpers;
using NaiveRPG.Interfaces;
using NaiveRPG.Participants.Creatures;
using NaiveRPG.Participants.Humanoid;

namespace NaiveRPG.Factories
{
    public class ParticipantFactoryStandard : IParticipantFactory
    {
        public IParticipant CreateParticipant()
        {
            int index = RNG.RandomInt(1, 6);

            switch (index)
            {
                case 1:
                    return new Bear();
                case 2:
                    return new Goat();
                case 3:
                    return new Snake();
                case 4:
                    return new Wolf();
                case 5:
                    return new Golem(GenerateName());
                case 6:
                    return new Troll(GenerateName());
                default:
                    throw new Exception($"Could not generate item with index {index}");
            }
        }

        private string GenerateName()
        {
            List<string> syllables = new List<string>{"xan", "tran", "ser", "mor", "houl", "zuur", "raz", "qex", "sir", "vaar" };
            string name = syllables[RNG.RandomInt(0, 9)] + 
                          syllables[RNG.RandomInt(0, 9)] +
                          syllables[RNG.RandomInt(0, 9)];
            name = name.Substring(0, 1).ToUpper() + 
                   name.Substring(1, name.Length - 1);
            return name;
        }
    }
}