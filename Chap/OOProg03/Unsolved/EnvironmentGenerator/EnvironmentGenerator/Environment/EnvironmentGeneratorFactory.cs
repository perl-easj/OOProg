using System;
using EnvironmentGenerator.Interfaces;

namespace EnvironmentGenerator.Environment
{
    /// <summary>
    /// Factory class for producing an environment generator object,
    /// according to the specified environment type.
    /// </summary>
    public class EnvironmentGeneratorFactory
    {
        public static IEnvironmentGenerator Create(EnvironmentTypes envType)
        {
            switch (envType)
            {
                case EnvironmentTypes.Future:
                    // WHEN EnvironmentGeneratorFuture HAS BEEN IMPLEMENTED, UNCOMMENT THE BELOW LINE
                    // return new EnvironmentGeneratorFuture();
                case EnvironmentTypes.Medieval:
                    // WHEN EnvironmentGeneratorMedieval HAS BEEN IMPLEMENTED, UNCOMMENT THE BELOW LINE
                    // return new EnvironmentGeneratorMedieval();;
                default:
                    throw new ArgumentException($"No class corresponding to environment type {envType} is available.");
            }
        }
    }
}