using System;
using System.Collections.Generic;
using FlyweightPatternExample.Common;
using FlyweightPatternExample.Improved;
using FlyweightPatternExample.Original;

namespace FlyweightPatternExample
{
    class Program
    {
        const int noOfParticipants = 10000;

        static void Main(string[] args)
        {
            TestImprovedWrapper();

            Console.ReadKey();
        }

        private static void TestOriginal()
        {
            ParticipantFactory fac = new ParticipantFactory();
            List<Participant> all = new List<Participant>();

            for (int i = 0; i < noOfParticipants; i++)
            {
                all.Add(fac.Create());
            }

            for (int i = 0; i < noOfParticipants; i++)
            {
                all[i].Animate();
            }
        }

        private static void TestImproved()
        {
            ParticipantFactoryImproved fac = new ParticipantFactoryImproved();
            List<ParticipantImproved> parts = new List<ParticipantImproved>();
            List<ParticipantExtrinsicState> states = new List<ParticipantExtrinsicState>();

            for (int i = 0; i < noOfParticipants; i++)
            {
                var pairPartState = fac.Create();
                parts.Add(pairPartState.Item1);
                states.Add(pairPartState.Item2);
            }

            for (int i = 0; i < noOfParticipants; i++)
            {
                parts[i].Animate(states[i]);
            }
        }

        private static void TestImprovedWrapper()
        {
            ParticipantFactoryImproved fac = new ParticipantFactoryImproved();
            List<ParticipantWrapper> all = new List<ParticipantWrapper>();

            for (int i = 0; i < noOfParticipants; i++)
            {
                var pairPartState = fac.Create();
                all.Add(new ParticipantWrapper(pairPartState.Item1, pairPartState.Item2));
            }

            for (int i = 0; i < noOfParticipants; i++)
            {
                all[i].Animate();
            }
        }
    }
}
