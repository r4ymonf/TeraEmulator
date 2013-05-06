using Communication.Interfaces;
using Data;
using Data.Interfaces;

namespace Tera.Services
{
    class AccountService : IAccountService
    {
        public void Authorized(IConnection connection, string accountName)
        {
            connection.Account = Cache.GetAccount(accountName);
        }

        public void AbortExitAction(IConnection connection)
        {
            if (connection.Account.ExitAction != null)
            {
                connection.Account.ExitAction.Abort();
                connection.Account.ExitAction = null;
            }
        }

        public void Action()
        {
            
        }
    }
}
