using DesignPatterns.Factory.NetworkUtility.Interface;
using System;

namespace DesignPatterns.Factory.NetworkUtility
{
    internal class Ping : Inetwork
    {
        public void SendRequest(string ip, int timeSent)
        {
            Console.WriteLine("Ping request sent to" + ip + " " + timeSent + " times");
        }
    }
}
