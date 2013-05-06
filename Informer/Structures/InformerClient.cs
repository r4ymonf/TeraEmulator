using System;
using InformerLib.Interfaces;

namespace Informer.Structures
{
    public class InformerClient : IInformerClient
    {
        public event Action OnAuthed;

        public event Action<string> OnMessage;

        public event Action<string, string, byte[], string> OnPacketSent;

        public event Action<string, string, byte[], string> OnPacketRecv;

        public void Authed()
        {
            if (OnAuthed != null) OnAuthed();
        }

        public void Message(string text)
        {
            if (OnMessage != null) OnMessage(text);
        }

        public void PacketSent(string accountName, string name, byte[] buffer, string callStack)
        {
            if (OnPacketSent != null) OnPacketSent(accountName, name, buffer, callStack);
        }

        public void PacketReceived(string accountName, string name, byte[] buffer, string callStack)
        {
            if (OnPacketRecv != null) OnPacketRecv(accountName, name, buffer, callStack);
        }
    }
}
