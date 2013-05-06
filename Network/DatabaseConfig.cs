using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Utils;

namespace Network
{
    class DatabaseConfig
    {
        static public string GetDatabaseName()
        {
            string dbName = null;
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(@"configs/databaseConfig.xml");
                XmlNode node = doc.SelectSingleNode("database_configuration/database_Name");
                dbName = node.InnerText;
            }
            catch (Exception ex)
            {
                Log.ErrorException("Config: Database name NOT FOUND!!!", ex);
            }
            return dbName;
        }

        static public string GetDatabaseHost()
        {
            string dbHost = null;
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(@"configs/databaseConfig.xml");
                XmlNode node = doc.SelectSingleNode("database_configuration/database_Host");
                dbHost = node.InnerText;
            }
            catch (Exception ex)
            {
                Log.Info("Config: Database host NOT FOUND!!!" + ex.ToString());
            }
            return dbHost;
        }

        static public string GetDatabasePass()
        {
            string dbPass = null;
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(@"configs/databaseConfig.xml");
                XmlNode node = doc.SelectSingleNode("database_configuration/database_Pass");
                dbPass = node.InnerText;
            }
            catch (Exception ex)
            {
                Log.Info("Config: Database password NOT FOUND!!!");
            }
            return dbPass;
        }

        static public string GetDatabaseUser()
        {
            string dbUser = null;
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(@"configs/databaseConfig.xml");
                XmlNode node = doc.SelectSingleNode("database_configuration/database_User");
                dbUser = node.InnerText;
            }
            catch (Exception ex)
            {
                Log.ErrorException("Config: Database username NOT FOUND!!!", ex);
            }
            return dbUser;
        }
    }
}