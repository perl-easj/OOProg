using System;
using System.Collections.Generic;
using SlotMachineDemo.Interfaces.Messages;

namespace SlotMachineDemo.Implementations.Messages
{
    /// <summary>
    /// This class contains functionality for generating 
    /// texts to display in the UI. Actual language-dependent
    /// texts are specified in derived classes.
    /// </summary>
    public abstract class MessagesBase : IMessages
    {
        private Dictionary<Types.Enums.MessageType, string> _dictionary;

        protected MessagesBase()
        {
            _dictionary = new Dictionary<Types.Enums.MessageType, string>();
        }

        /// <summary>
        /// Generate the text for the specified message type, 
        /// using a single post-processing action.
        /// </summary>
        public string GenerateText(Types.Enums.MessageType msgType, Types.Enums.MessagePostProcessing postProcessAction)
        {
            return GenerateText(msgType, new List<Types.Enums.MessagePostProcessing> { postProcessAction });
        }

        /// <summary>
        /// Generate the text for the specified message type, 
        /// using a list of post-processing actions.
        /// Trying to generate a text for a message type for which 
        /// no translation has been specificed will cause an exception.
        /// </summary>
        public string GenerateText(Types.Enums.MessageType msgType, List<Types.Enums.MessagePostProcessing> postProcessActions = null)
        {
            if (!_dictionary.ContainsKey(msgType))
            {
                throw new ArgumentException(nameof(GenerateText));
            }

            return PostProcessText(_dictionary[msgType], postProcessActions);
        }

        /// <summary>
        /// Set a translation of a specific message type.
        /// Trying to set the same translation twice will cause an exception.
        /// </summary>
        protected void SetTranslation(Types.Enums.MessageType msgType, string translation)
        {
            if (_dictionary.ContainsKey(msgType))
            {
                throw new ArgumentException(nameof(SetTranslation));
            }

            _dictionary.Add(msgType, translation);
        }

        /// <summary>
        /// Performs various post-processing actions to the generated text.
        /// If the list of actions contains an action which is not handled by
        /// the method, an exception is thrown.
        /// </summary>
        private string PostProcessText(string originalText, List<Types.Enums.MessagePostProcessing> postProcessActions)
        {
            string processedText = originalText;

            if (postProcessActions != null)
            {
                foreach (var item in postProcessActions)
                {
                    switch (item)
                    {
                        case Types.Enums.MessagePostProcessing.AddEllipsis:
                            processedText += "...";
                            break;
                        case Types.Enums.MessagePostProcessing.AddExclamationMark:
                            processedText += "!";
                            break;
                        case Types.Enums.MessagePostProcessing.AddQuestionMark:
                            processedText += "?";
                            break;
                        case Types.Enums.MessagePostProcessing.InitialCaps:
                            if (processedText.Length > 0)
                            {
                                processedText = processedText.Substring(0, 1).ToUpper() + processedText.Substring(1);
                            }
                            break;
                        case Types.Enums.MessagePostProcessing.AllCaps:
                            processedText = processedText.ToUpper();
                            break;
                        default:
                            throw new ArgumentException(nameof(PostProcessText));
                    }
                }
            }

            return processedText;
        }
    }
}