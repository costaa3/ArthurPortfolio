﻿using System;

namespace DesignPatterns.ChainOfResponsability
{
    internal class SendPing : IChain
    {
        private IChain next;
        public void SendRequest(NetworkModel request)
        {

            if (request.Successful == false)
            {
                Console.WriteLine("Send PING failed. Sending PING");
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
