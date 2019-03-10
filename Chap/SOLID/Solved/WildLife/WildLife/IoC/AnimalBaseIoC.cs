using WildLife.Common;

namespace WildLife.IoC
{
    /// <summary>
    /// In this class, we do provide an implementation of Act.
    /// Act contains the general "algorithm" for how an animal acts,
    /// but the specific conditions and steps are implemented by
    /// means of abstract methods, which must be implemented in
    /// derived classes.
    /// </summary>
    public abstract class AnimalBaseIoC : AnimalBase
    {
        protected AnimalBaseIoC(AnimalKind kind, AnimalGender gender) : base(kind, gender)
        {
        }

        #region Abstract behaviors and conditions for behaviors
        protected abstract bool Priority1Condition();
        protected abstract void Priority1Behavior();

        protected abstract bool Priority2Condition();
        protected abstract void Priority2Behavior();

        protected abstract bool Priority3Condition();
        protected abstract void Priority3Behavior();

        protected abstract bool Priority4Condition();
        protected abstract void Priority4Behavior(); 
        #endregion

        /// <summary>
        /// This is the general implementation of Act for ALL animals.
        /// This is an example of the Template Method pattern.
        /// </summary>
        public override void Act()
        {
            // Priority #1
            if (Priority1Condition())
            {
                Priority1Behavior();
            }

            // Priority #2
            else if (Priority2Condition())
            {
                Priority2Behavior();
            }

            // Priority #3
            else if (Priority3Condition())
            {
                Priority3Behavior();
            }

            // Priority #4
            else if (Priority4Condition())
            {
                Priority4Behavior();
            }

            else
            {
                Idle();
            }
        }
    }
}