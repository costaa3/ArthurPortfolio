using System.Configuration;

namespace Linq_To_Sql
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinqToSqlDataClassDataContext dataContext;
            string DbConnectionString = ConfigurationManager.ConnectionStrings["Linq_To_Sql.Properties.Settings.masterConnectionString"].ConnectionString;
            dataContext = new LinqToSqlDataClassDataContext(DbConnectionString);


        }



    }
}
