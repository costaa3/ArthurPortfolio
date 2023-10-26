using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Factory.NetworkUtility.Interface
{
    internal interface Inetwork
    {
        void SendRequest(string ip, int timeSent);
       
    }
}
