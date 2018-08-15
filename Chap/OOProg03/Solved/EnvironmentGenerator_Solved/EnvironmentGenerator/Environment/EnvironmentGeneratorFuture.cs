using EnvironmentGenerator.ImplFuture;

namespace EnvironmentGenerator.Environment
{
    /// <summary>
    /// Implements an Asbtract Factory, which will only 
    /// generate objects from the Future era.
    /// </summary>
    public class EnvironmentGeneratorFuture : EnvironmentGeneratorBase
    {
        // Solution A: Create new ...Future objects, and pass
        // them to EnvironmentGeneratorBase constructor
        public EnvironmentGeneratorFuture() : base(
            new BuildingFactoryFuture(), 
            new CreatureFactoryFuture(), 
            new WeaponFactoryFuture())
        {
        }

        // Solution B: Let object creator supply objects of
        // correct type, which are then passed on to 
        // EnvironmentGeneratorBase constructor.
        // This will also work, if you later decide to create
        // classes inheriting from the original ...Future classes.
        public EnvironmentGeneratorFuture(
            BuildingFactoryFuture bf,
            CreatureFactoryFuture cf,
            WeaponFactoryFuture wf)
            : base(bf, cf, wf)
        {
        }
    }
}