namespace DesignPatterns.ChainOfResponsability
{
    internal class NetworkModel
    {

        public bool Successful { get; set; }
        public string Ip { get; set; }



        public NetworkModel(bool successful, string ip)
        {
            Successful = successful;
            Ip = ip;
        }
    }
}
