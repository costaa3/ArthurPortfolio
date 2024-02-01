using DesignPatterns.Adapter.Network;

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
