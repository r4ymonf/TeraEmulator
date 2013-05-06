using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using Communication.Interfaces;
using Hik.Communication.Scs.Communication.EndPoints.Tcp;
using Hik.Communication.ScsServices.Client;
using Informer.Structures;

namespace Informer
{
    public partial class MainWindow
    {
        public InformerClient Client = null;

        public IScsServiceClient<IInformerService> ScsClient = null;

        public Dictionary<string, PacketViewer> Viewers = new Dictionary<string, PacketViewer>();

        public MainWindow()
        {
            InitializeComponent();

            Client = new InformerClient();

            Client.OnAuthed += OnAuthed;
            Client.OnMessage += OnMessage;

            Client.OnPacketRecv += OnPacketRecv;
            Client.OnPacketSent += OnPacketSent;
        }

        public void Log(string text)
        {
            Dispatcher.BeginInvoke(new System.Threading.ThreadStart(delegate { 
                LogTextBox.AppendText(DateTime.Now + " :: " + text + "\n");
                LogTextBox.ScrollToEnd(); }));
        }

        #region events

        private void OnAuthed()
        {
            Log("Authed.");
        }

        private void OnMessage(string text)
        {
            Log("Message recived: " + text);
        }

        private void OnPacketRecv(string accountName, string packetName, byte[] buffer, string callStack)
        {
            //Log(accountName + " recv " + packetName);
            Viewers[accountName].AddRecvPacket(packetName, buffer, callStack);
        }

        private void OnPacketSent(string accountName, string packetName, byte[] buffer, string callStack)
        {
            //Log(accountName + " sent " + packetName);
            Viewers[accountName].AddSentPacket(packetName, buffer, callStack);
        }

        #endregion

        private void Connect(object sender, RoutedEventArgs e)
        {
            if (ScsClient != null)
                ScsClient.Disconnect();

            ScsClient = ScsServiceClientBuilder.CreateClient<IInformerService>(
                new ScsTcpEndPoint(ServerIp.Text, 23232), Client);

            ScsClient.Timeout = 1000;
            ScsClient.ConnectTimeout = 2000;

            ScsClient.Connected += OnScsConnnected;
            ScsClient.Disconnected += OnScsDisconnected;

            Log("Try connect...");

            ThreadPool.QueueUserWorkItem(
                o =>
                    {
                        try
                        {
                            ScsClient.Connect();
                        }
                        catch
                        {
                            Log("Can't connect to server.");
                        }
                    });
        }

        private void OnScsDisconnected(object sender, EventArgs e)
        {
            Log("Disconnected.");
            ScsClient = null;
        }

        private void OnScsConnnected(object sender, EventArgs e)
        {
            Log("Connected.");
            Log("Try auth...");
            
            ScsClient.ServiceProxy.Auth("0bacf71935dd3589a2c529d1cdaba6d0b80a82d673730fe752001f06a509a8ff");
        }

        private void GetOnlineList(object sender, RoutedEventArgs e)
        {
            if (ScsClient == null)
                return;

            try
            {
                List<string> players = ScsClient.ServiceProxy.GetOnlineList();

                Log("Players online: " + players.Count + " [" + string.Join(", ", players) + "]");
            }
            catch
            {
                Log("Cant get online list...");
            }
        }

        private void Watch(object sender, RoutedEventArgs e)
        {
            if (ScsClient == null || AccountName.Text.Length == 0)
                return;

            if (Viewers.ContainsKey(AccountName.Text))
                return;

            Viewers.Add(AccountName.Text, new PacketViewer(AccountName.Text));

            Viewers[AccountName.Text].Show();

            ScsClient.ServiceProxy.WatchAccount(AccountName.Text);
            Log("Watching account: " + AccountName.Text);
        }

        private void SutdownServer(object sender, RoutedEventArgs e)
        {
            if (ScsClient == null)
                return;

            try
            {
                ScsClient.ServiceProxy.ShutdownServer();
                Log("Start shutdown...");
            }
            catch
            {
                Log("Cant shutdown server...");
            }
        }
    }
}