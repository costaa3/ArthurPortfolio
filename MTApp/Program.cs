using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Text;
using System.Threading.Tasks;

namespace MTApp
{
    internal class Program
    {
        private static int amount = 0;
        static void Main(string[] args, ThreadStart threadStart)
        {
            Thread us = new Thread(showSomething);
        }

        private static void showSomething() { Console.WriteLine("Hello" + "dagta"); }
    }
}
