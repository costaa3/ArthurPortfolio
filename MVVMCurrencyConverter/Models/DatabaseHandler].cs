using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

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
            catch (Exception e)
            {


                Console.WriteLine(@"Issue appending item to database" + e.ToString());
                return false;
            }

        }

        public bool AddOrUpdate(string name, decimal value)
        {
            string sqlCommandStr = @"
    IF EXISTS (SELECT * FROM CurrencyTypes WHERE Name = @name)
    BEGIN
        UPDATE CurrencyTypes
        SET Value = @Value
        WHERE Name = @name
    END
    ELSE
    BEGIN
        INSERT INTO CurrencyTypes (Name, Value)
        VALUES (@name, @Value)
    END";
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    SqlCommand sqlCommand = new SqlCommand(sqlCommandStr, conn);
                    sqlCommand.Parameters.AddWithValue($"@Name", name);
                    sqlCommand.Parameters.AddWithValue($"@Value", value);
                    sqlCommand.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }


        }

        public bool UpdateDatabaseItem(int selectedId, string name, decimal value)
        {
            string strSqlCommand = "UPDATE CurrencyTypes SET Name = @Name, Value = @Value WHERE Id = @Id";
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(strSqlCommand, conn);
                    cmd.Parameters.AddWithValue("@Id", selectedId);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Value", value);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public bool DeleteDatabaseItem(int selectedId)
        {
            string strSqlcommand = "Delete From CurrencyTypes Where Id = @Id";
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(strSqlcommand, conn);
                    cmd.Parameters.AddWithValue("@Id", selectedId);
                    cmd.ExecuteNonQuery();
                    return true;

                    ;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
