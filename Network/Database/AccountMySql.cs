using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Structures.Account;
using Utils;
using MySql.Data.MySqlClient;

namespace Network.Database
{
    class AccountMySql
    {
        //I think, that account is verified at GS side
        static public Account GetAccount(string name)
        {
            Account account = null;
            MySqlCommand myCommand = new MySqlCommand("SELECT * FROM `game_accounts` WHERE name = '" + name + "'");
            try
            {
                MySqlDataReader dataReader = myCommand.ExecuteReader();
                dataReader.Read();
                //creating new account structure
                account = new Account();
                /*
                account.SetAccountId(dataReader.GetInt32(0));
                account.SetAccountName(dataReader.GetString(1));
                account.SetAccountPassword(dataReader.GetString(2));
                account.SetIsActive(dataReader.GetInt32(3));
                account.SetAdminLevel(dataReader.GetInt32(4));
                account.SetMemberLevel(dataReader.GetInt32(5));
                account.SetLastIp(dataReader.GetString(6));
                account.SetLastServer(dataReader.GetInt32(7));
                account.SetSecureIp(dataReader.GetString(8));
                 */
            }
            catch (Exception e)
            {
                Log.ErrorException("MySQL ERROR!!! Can't initialize account",  e);
            }
            return account;
        }
    }
}