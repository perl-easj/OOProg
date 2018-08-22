namespace SlotMachineDemo.Implementations.Messages
{
    /// <summary>
    /// Danish translation of message types
    /// </summary>
    public class MessagesDanish : MessagesBase
    {
        public MessagesDanish()
        {
            SetTranslation(Types.Enums.MessageType.Ready, "klar");
            SetTranslation(Types.Enums.MessageType.Play, "spil");
            SetTranslation(Types.Enums.MessageType.Go, "kør");
            SetTranslation(Types.Enums.MessageType.Spins, "kørsler");
            SetTranslation(Types.Enums.MessageType.YouWon, "du vandt");
            SetTranslation(Types.Enums.MessageType.Credit, "krone");
            SetTranslation(Types.Enums.MessageType.Credits, "kroner");
            SetTranslation(Types.Enums.MessageType.Cancel, "afbryd");
            SetTranslation(Types.Enums.MessageType.Running, "kører");
            SetTranslation(Types.Enums.MessageType.SpinningWheels, "hjulene drejer");
            SetTranslation(Types.Enums.MessageType.PayBack, "tilbagebetaling");
            SetTranslation(Types.Enums.MessageType.Simulated, "simuleret");
            SetTranslation(Types.Enums.MessageType.Calculated, "beregnet");
            SetTranslation(Types.Enums.MessageType.Done, "udført");
        }
    }
}