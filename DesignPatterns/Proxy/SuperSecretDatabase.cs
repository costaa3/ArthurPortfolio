using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Proxy
{
    internal class SuperSecretDatabase :ISuperSecretDatabase
    {

        private string _databaseName;

        public SuperSecretDatabase(string databaseName)
        {
            _databaseName = databaseName;
        }

        public void DisplayDataBaseName()
        {
            Console.WriteLine( $"The database name is {_databaseName}" );
        }
    }
}
