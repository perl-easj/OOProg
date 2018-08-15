using SupportManagement.SupportCommon;
using SupportManagement.SupportCoR.SupportHandler;

namespace SupportManagement.SupportCoR.Config
{
    /// <summary>
    /// Interface for any class capable of setting up a
    /// support handler Chain-of-Responsibility (CoR)
    /// </summary>
    public interface ISupportCoRConfiguration
    {
        /// <summary>
        /// Setup support handler CoR, and return entry point 
        /// (i.e. reference to first handler in CoR).
        /// </summary>
        ISupportHandler SetupSupportCoR(ISupportCenter supportCenter);
    }
}