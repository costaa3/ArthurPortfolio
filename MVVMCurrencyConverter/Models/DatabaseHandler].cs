using MVVMCurrencyConverter.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVMCurrencyConverter.Models
{
    public class DatabaseHandler : IDatabaseHandler
    {
        private SqlConnection GetConnection()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            return new SqlConnection(connectionString);

        }


        public (int id, string Name, decimal value) RetrieveDatabaseData(int Id)
        {
            int id = 0;
            string name = string.Empty;
            decimal value = 0m;


            string command = "SELECT * From CurrencyTypes WHERE Id = @Id";

            using (var conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(command, conn);
                cmd.Parameters.AddWithValue("@Id", Id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        id = reader.GetInt32(reader.GetOrdinal("Id"));
                        name = reader.GetString(reader.GetOrdinal("Name"));
                        value = reader.GetDecimal(reader.GetOrdinal("Value"));
                    }
                }
            }
            return (id, name, value);
        }

        public IEnumerable<(int id, string Name, decimal value)> RetrieveAllDatabaseData()
        {
            List<(int id, string Name, decimal value)> dataToParse = new List<(int id, string Name, decimal value)>();

            string command = "SELECT * From CurrencyTypes";

            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(command, conn);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var id = reader.GetInt32(reader.GetOrdinal("Id"));
                            var name = reader.GetString(reader.GetOrdinal("Name"));
                            var value = reader.GetDecimal(reader.GetOrdinal("Value"));
                            dataToParse.Add((id, name, value));
                        }
                    }
                }
            }
            catch (Exception)
            {

                Console.WriteLine(@"Issue reading database");
            }
            return dataToParse;
        }

        public bool AppendToDatabase(string name, decimal value)
        {
            string sqlCommand = "Insert Into CurrencyTypes (Name,Value) Values (@Name,@Value)";
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlCommand, conn);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Value", value);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                
            }
            catch (Exception)
            {

                Console.WriteLine(@"Issue appending item to database");
                return false;
            }
           
        }



    }
}
