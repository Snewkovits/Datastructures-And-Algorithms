using MySqlConnector;

namespace Test
{
    class Program
    {
        static void Main()
        {
            MySqlConnection conn = Database.Connect;
        }
    }

    class Database
    {
        public static MySqlConnection Connect { get { return new MySqlConnection(connstr.ConnectionString); } }
        static MySqlConnectionStringBuilder connstr = new MySqlConnectionStringBuilder()
        {
            Database = "test",
            UserID = "root",
            Password = "password",
            Server = "localhost",
            Port = 3306
        };
    }
}