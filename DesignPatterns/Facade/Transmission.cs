using System;

namespace DesignPatterns.Facade
{
    internal class Transmission
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public Transmission(string name)
        {
            Name = name;
        }

        public void SendTransmission()
        {
            Console.WriteLine("Send transmission");
        }
    }
}
