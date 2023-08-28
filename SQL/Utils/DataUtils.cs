using MySql.Data.MySqlClient;
using System.Data;
using static JsonReader;

namespace L2Task4
{
    public class DataUtils
    {
        public static string server = GetConfigurationValue("Server");
        public static string port = GetConfigurationValue("Port");
        public static string username = GetConfigurationValue("Username");
        public static string password = GetConfigurationValue("Password");
        public static string database = GetConfigurationValue("Database");
        public static string connectionString = $"Server={server};Port={port};Database={database};User={username};Password={password}";
        public static string FirstQuery = SQLReader.GetQuery("Resources/FirstQuery.sql");
        public static string SecondQuery = SQLReader.GetQuery("Resources/SecondQuery.sql");
        public static string ThirdQuery = SQLReader.GetQuery("Resources/ThirdQuery.sql");
        public static string FourthQuery = SQLReader.GetQuery("Resources/FourthQuery.sql");

        public static void PrintDataTable(DataTable dataTable)
        {
            foreach (DataColumn col in dataTable.Columns)
            {
                Console.Write(col.ColumnName + "\t");
            }
            Console.WriteLine();

            foreach (DataRow row in dataTable.Rows)
            {
                foreach (DataColumn col in dataTable.Columns)
                {
                    Console.Write(row[col] + "\t");
                }
                Console.WriteLine();
            }
        }

        public static void ConnectToDataBase(string query)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ExecuteCommand(command);
                }
            }
        }
        private static void ExecuteCommand(MySqlCommand command)
        {
            using (var adapter = new MySqlDataAdapter(command))
            {
                var dataTable = new DataTable();
                adapter.Fill(dataTable);

                PrintDataTable(dataTable);
            }
        }




    }


}
