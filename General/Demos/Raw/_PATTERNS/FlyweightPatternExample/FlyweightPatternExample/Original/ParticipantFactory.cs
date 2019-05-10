using System;
using System.Collections.Generic;
using System.Linq;
using FlyweightPatternExample.Common;

namespace FlyweightPatternExample.Original
{
    public class ParticipantFactory
    {
        private static Random _rng = new Random(Guid.NewGuid().GetHashCode());
        private static int _id;

        public ParticipantFactory()
        {
            _id = 0;
        }

        public Participant Create()
        {
            Participant p = new Participant($"#{_id}", GenerateType());
            return p;
        }

        private ParticipantType GenerateType()
        {
            List<ParticipantType> types = Enum.GetValues(typeof(ParticipantType)).Cast<ParticipantType>().ToList();
            return types[_rng.Next(types.Count)];
        }
    }
}