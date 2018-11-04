using System;
using System.Collections.Generic;
using NaiveRPG.Interfaces;
using NaiveRPG.Participants;

namespace NaiveRPG.GameManagement
{
    public class Game
    {
        public void Run(int noOfOpponents)
        {
            Character aChar = new Character("Sigrid");
            List<IParticipant> participants = CreateParticipants(noOfOpponents);

            PrintStartInfo(aChar, participants);
            FightParticipants(aChar, participants);
            PrintEndInfo(aChar);
        }

        private List<IParticipant> CreateParticipants(int noOfOpponents)
        {
            List<IParticipant> participants = new List<IParticipant>();

            for (int i = 0; i < noOfOpponents; i++)
            {
                participants.Add(GameFactory.Instance().ParticipantFactory.CreateParticipant());
            }

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
            foreach (var item in opponent.ArmorOwned)
            {
                aChar.AddArmor(item);
            }
            foreach (var item in opponent.WeaponsOwned)
            {
                aChar.AddWeapon(item);
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