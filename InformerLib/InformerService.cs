using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Communication;
using Communication.Interfaces;
using Hik.Collections;
using Hik.Communication.ScsServices.Service;
using InformerLib.Interfaces;
using InformerLib.Structures;
using Utils;

namespace InformerLib
{
    public class InformerService : ScsService, IInformerService
    {
        public static string SecurityKey = "0bacf71935dd3589a2c529d1cdaba6d0b80a82d673730fe752001f06a509a8ff";

        protected readonly ThreadSafeSortedList<long, InformerClient> Authed = new ThreadSafeSortedList<long, InformerClient>();

        protected Queue<Action<InformerClient>> TaskPool = new Queue<Action<InformerClient>>();

        protected object TaskPoolLock = new object();

        public InformerService()
        {
            ThreadPool.QueueUserWorkItem(TaskInvoker);
        }

        protected void TaskInvoker(object o)
        {
            while (true)
            {
                Thread.Sleep(1);

                Action<InformerClient> action;

                lock (TaskPoolLock)
                {
                    if (TaskPool.Count < 1)
                        continue;

                    action = TaskPool.Dequeue();
                }

                foreach (var client in Authed.GetAllItems())
                {
                    try
                    {
                        action(client);
                    }
                    catch(Exception ex)
                    {
                        Log.ErrorException("InformerService:", ex);
                    }
                }
            }
        // ReSharper disable FunctionNeverReturns
        }
        // ReSharper restore FunctionNeverReturns

        public void Auth(string key)
        {
            if (!key.Equals(SecurityKey))
            {
                CurrentClient.Disconnect();
                return;
            }

            Authed[CurrentClient.ClientId] = new InformerClient( CurrentClient, CurrentClient.GetClientProxy<IInformerClient>());

            CurrentClient.Disconnected += ClientDisconnected;
            Log.Info("InformerService: Client connected...");

            Authed[CurrentClient.ClientId].Proxy.Authed();
            Authed[CurrentClient.ClientId].Proxy.Message("Test message!");
        }

        private void ClientDisconnected(object sender, EventArgs e)
        {
            Authed.Remove(((IScsServiceClient) sender).ClientId);
            Log.Info("InformerService: Client disconnected...");
        }

        public List<string> GetOnlineList()
        {
            if (!Authed.ContainsKey(CurrentClient.ClientId))
                return null;

            return Global.PlayerService.GetOnline().Select(p => p.PlayerData.Name).ToList();
        }

        public void WatchAccount(string accountName)
        {
            if (!Authed.ContainsKey(CurrentClient.ClientId))
                return;

            if (!Authed[CurrentClient.ClientId].WatchAccounts.Contains(accountName))
                Authed[CurrentClient.ClientId].WatchAccounts.Add(accountName);
        }

        public void ShutdownServer()
        {
            if (!Authed.ContainsKey(CurrentClient.ClientId))
                return;

            Global.ShutdownServer();
        }

        public void OnAccountAuthed(string accountName)
        {
            lock (TaskPoolLock)
            {
                TaskPool.Enqueue(client => client.Proxy.Message("Account authed: " + accountName));
            }
        }

        public void OnAccountDiconnected(string accountName)
        {
            lock (TaskPoolLock)
            {
                TaskPool.Enqueue(client => client.Proxy.Message("Account disconnected: " + accountName));
            }
        }

        public void PacketSent(string accountName, string name, byte[] buffer, string callStack)
        {
            lock (TaskPoolLock)
            {
                TaskPool.Enqueue(client =>
                                     {
                                         if (client.WatchAccounts.Contains(accountName))
                                             client.Proxy.PacketSent(accountName, name, buffer, callStack);
                                     });
            }
        }

        public void PacketReceived(string accountName, string name, byte[] buffer, string callStack)
        {
            lock (TaskPoolLock)
            {
                TaskPool.Enqueue(client =>
                                     {
                                         if (client.WatchAccounts.Contains(accountName))
                                             client.Proxy.PacketReceived(accountName, name, buffer, callStack);
                                     });
            }
        }

        public void Action()
        {
            
        }
    }
}
