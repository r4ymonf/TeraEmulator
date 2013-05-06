using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using Utils;

namespace Informer
{
    public partial class PacketViewer
    {
        protected class Packet
        {
            public bool IsServer;

            public string Name;

            public byte[] Buffer;

            public string Hex;

            public string CallStack;

            public Packet(bool isServer, string name, byte[] buffer, string callStack)
            {
                IsServer = isServer;
                Name = name;
                Buffer = buffer;

                Hex = buffer.FormatHex();
                CallStack = callStack;
            }

            public override string ToString()
            {
                return Name;
            }
        }

        protected List<Packet> Packets = new List<Packet>();

        protected object PacketsLock = new object();

        public PacketViewer(string accountName)
        {
            InitializeComponent();

            Title += " :: " + accountName;

            PacketsListBox.SelectionChanged += OnSelectPacket;
        }

        protected override void OnClosed(EventArgs e)
        {
            Packets.Clear();
            Packets = null;
        }

        private void OnSelectPacket(object sender, SelectionChangedEventArgs e)
        {
            if (PacketsListBox.SelectedIndex >= 0 && PacketsListBox.SelectedIndex < Packets.Count)
            {
                HexTextBox.Document.Blocks.Clear();
                HexTextBox.Document.Blocks.Add(new Paragraph(new Run(Packets[PacketsListBox.SelectedIndex].Hex)));

                CallStackTextBox.Document.Blocks.Clear();
                CallStackTextBox.Document.Blocks.Add(new Paragraph(new Run(Packets[PacketsListBox.SelectedIndex].CallStack)));
            }
        }

        public void AddRecvPacket(string packetName, byte[] buffer, string callStack)
        {
            packetName = "[C] " + packetName;

            lock (PacketsLock)
            {
                if (Packets == null)
                    return;

                Packet packet = new Packet(false, packetName, buffer, callStack);
                Packets.Add(packet);

                Dispatcher.BeginInvoke(new System.Threading.ThreadStart(delegate
                                      {
                                          ListBoxItem item = new ListBoxItem
                                                                 {
                                                                     Content = packet.ToString(),
                                                                     Background = new SolidColorBrush(Colors.WhiteSmoke)
                                                                 };

                                          PacketsListBox.Items.Add(item);
                                      }));
            }
        }

        public void AddSentPacket(string packetName, byte[] buffer, string callStack)
        {
            packetName = "[S] " + packetName;

            lock (PacketsLock)
            {
                if (Packets == null)
                    return;

                Packet packet = new Packet(true, packetName, buffer, callStack);
                Packets.Add(packet);

                Dispatcher.BeginInvoke(new System.Threading.ThreadStart(delegate
                                      {
                                          ListBoxItem item = new ListBoxItem
                                                                 {
                                                                     Content = packet.ToString(),
                                                                     Background = new SolidColorBrush(Colors.LightBlue)
                                                                 };

                                          PacketsListBox.Items.Add(item);
                                      }));
            }
        }
    }
}
