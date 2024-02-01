using System;

namespace DesignPatterns.Proxy
{
    internal class SuperSecretDatabase : ISuperSecretDatabase
    {

        private string _databaseName;

        public SuperSecretDatabase(string databaseName)
        {
            _databaseName = databaseName;
        }

        public void DisplayDataBaseName()
        {
            Console.WriteLine($"The database name is {_databaseName}");
        }
    }
}
