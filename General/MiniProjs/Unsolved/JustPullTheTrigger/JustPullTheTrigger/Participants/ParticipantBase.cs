using System;

namespace JustPullTheTrigger.Participants
{
    public abstract class ParticipantBase : IParticipant
    {
        #region Methods
        public abstract string Description { get; }

        public virtual void Report(string info)
        {
            string desc = Description;
            if (Description.Length < 20)
            {
                desc = desc.PadRight(20);
            }

            Console.WriteLine($"{desc}: {info}");
        }
        #endregion
    }
}