using System;
using System.Collections.Generic;
using System.Linq;
using FlyweightPatternExample.Common;

namespace FlyweightPatternExample.Improved
{
    public class ParticipantFactoryImproved
    {
        private static Random _rng = new Random(Guid.NewGuid().GetHashCode());
        private static int _id;

        private Dictionary<ParticipantType, ParticipantImproved> _sharedParticipants;

        public ParticipantFactoryImproved()
        {
            _id = 0;
            _sharedParticipants = new Dictionary<ParticipantType, ParticipantImproved>();
        }

        public Tuple<ParticipantImproved, ParticipantExtrinsicState> Create()
        {
            ParticipantType type = GenerateType();
            ParticipantImproved pi = CreateParticipant(type);
            ParticipantExtrinsicState ps = CreateParticipantExtrinsicState(type);

            return new Tuple<ParticipantImproved, ParticipantExtrinsicState>(pi, ps);
        }

        public ParticipantImproved CreateParticipant(ParticipantType type)
        {
            if (!_sharedParticipants.ContainsKey(type))
            {
                _sharedParticipants.Add(type, new ParticipantImproved(new ParticipantIntrinsicState(type)));
            }

            ParticipantImproved p = _sharedParticipants[type];
            return p;
        }

        public ParticipantExtrinsicState CreateParticipantExtrinsicState(ParticipantType type)
        {
            ParticipantExtrinsicState p = new ParticipantExtrinsicState($"#{_id}", type);
            return p;
        }

        public ParticipantType GenerateType()
        {
            List<ParticipantType> types = Enum.GetValues(typeof(ParticipantType)).Cast<ParticipantType>().ToList();
            return types[_rng.Next(types.Count)];
        }
    }
}