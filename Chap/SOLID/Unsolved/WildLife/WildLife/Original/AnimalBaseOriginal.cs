using WildLife.Common;

namespace WildLife.Original
{
    /// <summary>
    /// In this class, we do NOT provide an implementation of Act.
    /// </summary>
    public abstract class AnimalBaseOriginal : AnimalBase
    {
        protected AnimalBaseOriginal(AnimalKind kind, AnimalGender gender) : base(kind, gender)
        {
        }
    }
}