using System;
using System.Globalization;
using System.Net;
using System.Threading;
using Communication.Interfaces;
using Hik.Communication.Scs.Communication;
using Hik.Communication.Scs.Communication.EndPoints.Tcp;
using Hik.Communication.ScsServices.Client;
using Informer.Structures;

// ReSharper disable FunctionNeverReturns
// ReSharper disable LocalizableElement
// This most likely wont work without the ajax script
namespace ServerStatusUpdater
{
    static class Program
    {

        public static InformerClient Client = null;

        public static IScsServiceClient<IInformerService> ScsClient = null;

        private static string _lastStatus;

        static void Main()
        {
            ServerOpt so = new ServerOpt();

            Client = new InformerClient();

            Client.OnMessage += Console.WriteLine;

            Client.OnAuthed += () =>
                {
                    Console.WriteLine("Authed...");
                    new Thread(SendOnlineUpdates).Start();
                };

            ScsClient = ScsServiceClientBuilder.CreateClient<IInformerService>
                (new ScsTcpEndPoint(so.serverip, so.informerPort), Client);

            ScsClient.Timeout = ScsClient.ConnectTimeout = 2500;

            ScsClient.Connected += (sender, args) =>
                {
                    Console.WriteLine("Connected...");
                    ScsClient.ServiceProxy.Auth(so.sercurityKey);
                };

            while (true)
            {
                try
                {
                    if (ScsClient.CommunicationState == CommunicationStates.Disconnected)
                        ScsClient.Connect();

                    while (ScsClient.CommunicationState == CommunicationStates.Connected)
                        Thread.Sleep(1000);
                }
                catch
                {
                }

                SendUpdate(); //Offline
            }
        }

        private static void SendOnlineUpdates()
        {
            while (ScsClient.CommunicationState == CommunicationStates.Connected)
            {
                try
                {
                    SendUpdate(ScsClient.ServiceProxy.GetOnlineList().Count.ToString(CultureInfo.InvariantCulture));
                }
                catch
                {
                    Console.WriteLine("Can't get online list");
                    break;
                }

                Thread.Sleep(15000);
            }
        }

        private static void SendUpdate(string status = "offline")
        {
            ServerOpt so = new ServerOpt();

            if (_lastStatus == status)
            {
                Console.WriteLine("### Last server status equals current!");
                if (status == "0" || status == "1")
                {
                    var AjaxQueryFormat = string.Format("{0}?server={1}&status=updateonline&userson={2}",
                            so.webApiUrl, so.server,
                            ScsClient.ServiceProxy.GetOnlineList().Count.ToString(CultureInfo.InvariantCulture)
                        );
                    var request = WebRequest.Create(AjaxQueryFormat);
                    request.Timeout = 5000;
                    using (request.GetResponse())
                    {
                        Console.WriteLine("Online Users: " + ScsClient.ServiceProxy.GetOnlineList().Count.ToString(CultureInfo.InvariantCulture));
                    }
                }
                return;
            }

            Console.WriteLine("### Try update status to {0}", status);

            try
            {
                var AjaxQueryFormat = so.webApiUrl+"?server={0}&status={1}";
                var request = WebRequest.Create(string.Format(AjaxQueryFormat, so.server, status));
                request.Timeout = 5000;
                using (request.GetResponse())
                {
                    //Nothing
                }

                Console.WriteLine("### Status succesfuly updated.");
                _lastStatus = status;
            }
            catch
            {
                Console.WriteLine("### Status update failed.");
            }
        }
    }
}
