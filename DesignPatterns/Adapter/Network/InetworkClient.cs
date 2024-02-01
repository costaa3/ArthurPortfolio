namespace DesignPatterns.Adapter.Network
{
    internal interface InetworkClient
    {
        void SendRequest(string ipAddress);
    }
}
