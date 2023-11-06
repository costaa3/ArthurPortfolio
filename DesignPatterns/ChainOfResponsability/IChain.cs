using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.ChainOfResponsability
{
    internal interface IChain
    {
        void SendRequest(NetworkModel networkModel);

        void setNext(IChain nextChain);
    }
}
