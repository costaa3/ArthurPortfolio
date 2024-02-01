namespace DesignPatterns.ChainOfResponsability
{
    internal interface IChain
    {
        void SendRequest(NetworkModel networkModel);

        void setNext(IChain nextChain);
    }
}
