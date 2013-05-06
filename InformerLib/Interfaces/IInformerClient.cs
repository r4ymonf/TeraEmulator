namespace InformerLib.Interfaces
{
    public interface IInformerClient
    {
        void Authed();
        void Message(string text);
        void PacketSent(string accountName, string name, byte[] buffer, string callStack);
        void PacketReceived(string accountName, string name, byte[] buffer, string callStack);
    }
}