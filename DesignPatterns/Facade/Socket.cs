using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Facade
{
    internal class Socket
    {
        public string  Ip { get; set; }
        public int  Port { get; set; }
        public string  Protocol { get; set; }

        public Socket(string protocol)
        {
            Protocol = protocol;
        }

        public void BuildSocket()
        {
            Console.WriteLine( "Build Socket");
        }   
    }
}
