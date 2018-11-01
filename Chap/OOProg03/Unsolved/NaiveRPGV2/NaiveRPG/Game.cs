using System;
using System.Collections.Generic;
using NaiveRPG.Interfaces;
using NaiveRPG.Participants;
using NaiveRPG.Participants.Creatures;
using NaiveRPG.Participants.Humanoid;

namespace NaiveRPG
{
    public class Game
    {
        public void Run()
        {
            Character aChar = new Character("Sigrid");
            List<IParticipant> participants = CreateParticipants();

            PrintStartInfo(aChar, participants);
            FightParticipants(aChar, participants);
            PrintEndInfo(aChar);
        }

        private List<IParticipant> CreateParticipants()
        {
            List<IParticipant> participants = new List<IParticipant>();

            participants.Add(new Bear());
            participants.Add(new Troll("Brutus"));
            participants.Add(new Snake());

            return participants;
        }

        private void FightParticipants(Character aChar, List<IParticipant> participants)
        {
            foreach (var participant in participants)
            {
                if (Fight(aChar, participant))
                {
                    Loot(aChar, participant);
                }
            }
        }

        private bool Fight(Character aChar, IParticipant opponent)
        {
            while (!opponent.Dead && !aChar.Dead)
            {
                opponent.ReceiveDamage(aChar.DealDamage());
                if (!opponent.Dead)
                {
                    aChar.ReceiveDamage(opponent.DealDamage());
                }
            }

            return opponent.Dead;
        }

        private void Loot(Character aChar, IParticipant opponent)
        {
            aChar.GoldOwned = aChar.GoldOwned + opponent.GoldOwned;
            opponent.GoldOwned = 0;
            foreach (var item in opponent.ItemsOwned)
            {
                aChar.AddItem(item);
            }
        }

        private void PrintParticipants(List<IParticipant> participants)
        {
            foreach (var participant in participants)
            {
                Console.WriteLine(participant);
            }
            Console.WriteLine();
        }

        private void PrintStartInfo(Character aChar, List<IParticipant> participants)
        {
            Console.WriteLine("The game is starting");
            Console.WriteLine(aChar);
            Console.WriteLine();
            PrintParticipants(participants);
        }

        private void PrintEndInfo(Character aChar)
        {
            Console.WriteLine("The game has ended");
            Console.WriteLine(aChar);
            Console.WriteLine();
        }
    }
}