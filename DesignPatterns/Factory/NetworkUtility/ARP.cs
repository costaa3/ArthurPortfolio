using DesignPatterns.Factory.NetworkUtility.Interface;
using System;

namespace DesignPatterns.Factory.NetworkUtility
{
    internal class ARP : Inetwork
    {
        public void SendRequest(string ip, int timeSent)
        {
            Console.WriteLine("ARP request sent to" + ip + " " + timeSent + " times");
        }
    }
}
