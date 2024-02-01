namespace DesignPatterns.Facade
{
    internal class NetworkFacade
    {
        private Packet packet;
        private Socket socket;
        private Transmission transmission;

        public NetworkFacade(string ip, string protocol)
        {
            this.packet = new Packet(ip);
            this.socket = new Socket(protocol);
            this.transmission = new Transmission(protocol);
        }

        public void buildNetworkLayer()
        {
            packet.PacketBuilt();
            socket.BuildSocket();
        }

        public void sendPacketOverNetwor()
        {
            buildNetworkLayer();
            transmission.SendTransmission();

        }
    }
}
