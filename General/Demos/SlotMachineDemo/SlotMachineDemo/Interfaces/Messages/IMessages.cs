using System.Collections.Generic;

namespace SlotMachineDemo.Interfaces.Messages
{
    /// <summary>
    /// Defines an interface for generating UI messages
    /// </summary>
    public interface IMessages
    {
        /// <summary>
        /// Generate the text for the specified message type, 
        /// using a single post-processing action
        /// </summary>
        string GenerateText(Types.Enums.MessageType msgType, Types.Enums.MessagePostProcessing postProcessAction);

        /// <summary>
        /// Generate the text for the specified message type, 
        /// using a list of post-processing actions
        /// </summary>
        string GenerateText(Types.Enums.MessageType msgType, List<Types.Enums.MessagePostProcessing> postProcessActions = null);
    }
}