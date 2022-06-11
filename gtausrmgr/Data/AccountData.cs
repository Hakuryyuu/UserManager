using System.Text.Json;

namespace gtausrmgr.Data
{
    public class AccountData
    {
        public async Task<List<User>> GetAccountsAsync()
        {
            return Sysdba._ACCOUNTS;
        }

        public async Task AddAccountAsync(User _acc)
        {
            Sysdba._ACCOUNTS.Add(_acc);

            await SaveSysdba.SaveAccs(Sysdba._ACCOUNTS);
        }

        public async Task RemoveAccountAsync(User _acc)
        {
            Sysdba._ACCOUNTS.Remove(_acc);

            await SaveSysdba.SaveAccs(Sysdba._ACCOUNTS);
        }
    }
}
