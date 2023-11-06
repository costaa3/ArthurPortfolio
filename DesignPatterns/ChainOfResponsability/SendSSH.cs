using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.ChainOfResponsability
{
    internal class SendSSH : IChain
    {
        private IChain next;
        public void SendRequest(NetworkModel request)
        {
            
            if (request.Successful == false)
            {
                Console.WriteLine("Send SSH failed. Sending PING");
                if (next != null)
                {
                    next.SendRequest(request);

                }
                else
                {
                    Console.WriteLine("Transmission failed, terminating");
                }
            }
            else
            {
                Console.WriteLine( "Send SSH success ");
            }
        }

        public void setNext(IChain nextChain)
        {
            next = nextChain;
        }
    }
}
