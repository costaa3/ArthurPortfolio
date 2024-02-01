using System;

namespace DesignPatterns.ChainOfResponsability
{
    internal class SendARP : IChain
    {
        private IChain next;
        public void SendRequest(NetworkModel request)
        {

            if (request.Successful == false)
            {
                Console.WriteLine("Send ARP failed.");
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
                Console.WriteLine("Send SSH success ");
            }
        }

        public void setNext(IChain nextChain)
        {
            next = nextChain;
        }
    }
}
