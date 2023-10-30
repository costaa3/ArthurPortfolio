using DesignPatterns.Adapter.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Adapter.Data_processor
{
    internal class NetworkAdapter : InetworkClient
    {
        private readonly IDataProcessor _dataProcessor;

        public NetworkAdapter(IDataProcessor _dataProcessor)
        {
            this._dataProcessor = _dataProcessor;
        }


        public void SendRequest(string ipAddress)
        {
            _dataProcessor.sendNetworkRequest(ipAddress, @"sdigfjfoipsdfhjoidpsufew3er543ewr7");
        }
    }
}
