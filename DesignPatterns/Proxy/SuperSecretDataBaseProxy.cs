namespace DesignPatterns.Proxy
{
    internal class SuperSecretDataBaseProxy : ISuperSecretDatabase
    {
        private SuperSecretDatabase SuperSecretDatabase;

        private string databaseName;
        private string password;

        public SuperSecretDataBaseProxy(string databaseName, string password)
        {
            this.databaseName = databaseName;
            this.password = password;
        }

        public void DisplayDataBaseName()
        {
            if (password.Equals("Password"))
            {
                if (SuperSecretDatabase == null)
                {

                    SuperSecretDatabase = new SuperSecretDatabase(databaseName);
                }
                SuperSecretDatabase.DisplayDataBaseName();
            }
        }
    }
}
