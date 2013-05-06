using System.Collections.Generic;
using Hik.Communication.ScsServices.Service;
using InformerLib.Interfaces;

namespace InformerLib.Structures
{
    public class InformerClient
    {
        public IScsServiceClient Client { get; private set; }

        public IInformerClient Proxy { get; private set; }

        public List<string> WatchAccounts = new List<string>();

        public InformerClient(IScsServiceClient client, IInformerClient proxy)
        {
            Client = client;
            Proxy = proxy;
        }
    }
}
