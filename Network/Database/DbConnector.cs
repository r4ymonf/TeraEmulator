using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Network;
using MySql.Data.MySqlClient;

namespace Network.Database
{
    class DbConnector
    {
        public static MySqlConnection MysqlConnect;

        public static void Connect()
        {
            MysqlConnect = new MySqlConnection("Database=" + DatabaseConfig.GetDatabaseName() + ";Data Source=" + DatabaseConfig.GetDatabaseHost() + ";User Id=" + DatabaseConfig.GetDatabaseUser() + ";Password=" + DatabaseConfig.GetDatabasePass());
            MysqlConnect.Open();
        }

        public static void Close()
        {
            MysqlConnect.Close();
        }
    }
}