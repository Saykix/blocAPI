using MySql.Data.MySqlClient;

namespace BlockAPI.Connection
{
    public class DBConnect
    {
        public static MySqlConnection GetDBConnection()
        {
            string host = "127.0.0.1";
            int port = 3306;
            string database = "bloc";
            string username = "root";
            string password = "";

            // Connection String.
            string connString = "Server=" + host + ";Database=" + database
                                + ";port=" + port + ";User Id=" + username + ";password=" + password;

            MySqlConnection conn = new MySqlConnection(connString);

            return conn;
        }
    }
}
