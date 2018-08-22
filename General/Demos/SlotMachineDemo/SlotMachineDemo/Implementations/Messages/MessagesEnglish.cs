namespace SlotMachineDemo.Implementations.Messages
{
    /// <summary>
    /// English translation of message types
    /// </summary>
    public class MessagesEnglish : MessagesBase
    {
        public MessagesEnglish()
        {
            SetTranslation(Types.Enums.MessageType.Ready ,"ready");
            SetTranslation(Types.Enums.MessageType.Play, "play");
            SetTranslation(Types.Enums.MessageType.Go, "go");
            SetTranslation(Types.Enums.MessageType.Spins, "runs");
            SetTranslation(Types.Enums.MessageType.YouWon, "you won");
            SetTranslation(Types.Enums.MessageType.Credit, "credit");
            SetTranslation(Types.Enums.MessageType.Credits, "credits");
            SetTranslation(Types.Enums.MessageType.Cancel, "cancel");
            SetTranslation(Types.Enums.MessageType.Running, "running");
            SetTranslation(Types.Enums.MessageType.SpinningWheels, "wheels are spinning");
            SetTranslation(Types.Enums.MessageType.PayBack, "payback");
            SetTranslation(Types.Enums.MessageType.Simulated, "simulated");
            SetTranslation(Types.Enums.MessageType.Calculated, "calculated");
            SetTranslation(Types.Enums.MessageType.Done, "done");
        }
    }
}