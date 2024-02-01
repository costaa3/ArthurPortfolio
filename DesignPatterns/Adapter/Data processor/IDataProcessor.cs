namespace DesignPatterns.Adapter.Data_processor
{
    internal interface IDataProcessor
    {

        bool DataProcess();


        void sendNetworkRequest(string ip, string apiKey);

    }
}
