using EnvironmentGenerator.ImplMedieval;

namespace EnvironmentGenerator.Environment
{
    /// <summary>
    /// Implements an Asbtract Factory, which will only 
    /// generate objects from the Medieval era.
    /// </summary>
    public class EnvironmentGeneratorMedieval : EnvironmentGeneratorBase
    {
        // Solution A: Create new ...Future objects, and pass
        // them to EnvironmentGeneratorBase constructor
        public EnvironmentGeneratorMedieval() : base(
            new BuildingFactoryMedieval(), 
            new CreatureFactoryMedieval(),
            new WeaponFactoryMedieval())
        {
        }

        // Solution B: Let object creator supply objects of
        // correct type, which are then passed on to 
        // EnvironmentGeneratorBase constructor.
        // This will also work, if you later decide to create
        // classes inheriting from the original ...Future classes.
        public EnvironmentGeneratorMedieval(
            BuildingFactoryMedieval bf,
            CreatureFactoryMedieval cf,
            WeaponFactoryMedieval wf)
            : base(bf, cf, wf)
        {
        }
    }
}   