    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Facade
{
    internal class Packet
    {
        public int Id { get; set; }
        public string Data { get; set; }    

        public string Ip { get; set; }

        public Packet(string ip)
        {
                Ip = ip;
        }

        public void PacketBuilt()
        {
            Console.WriteLine("Packet built");
        }
    }
}
