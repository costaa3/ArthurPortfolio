using System.Collections.Generic;

namespace MVVMCurrencyConverter.Models
{
    public interface IDatabaseHandler
    {
        bool AppendToDatabase(string name, decimal value);
        IEnumerable<(int id, string Name, decimal value)> RetrieveAllDatabaseData();
        (int id, string Name, decimal value) RetrieveDatabaseData(int Id);
    }
}