using DesignPatterns.Factory.NetworkUtility.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Factory.NetworkUtility
{
    internal class DNS: Inetwork
    {
        public void SendRequest(string ip, int timeSent)
        {
            Console.WriteLine("DNS request sent to" + ip + " " + timeSent + " times");
        }
    }
}
