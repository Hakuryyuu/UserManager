namespace gtausrmgr.Data
{
    public class ValidateLogonData : AccountManagement
    {
        public override async Task LogOutAsync(string ID)
        {
            foreach (var u in Sysdba._ACCOUNTS)
            {
                if (u.ID.ToString() == ID)
                {
                    var idx = Sysdba._ACCOUNTS.FindIndex(x => x.ID == u.ID);
                    Sysdba._ACCOUNTS[idx].IS_AUTHENTICATED = false;
                    Sysdba._ACCOUNTS[idx].AUTH_IP = null;
                }
            }
        }

        public override async Task<Permission.LEVEL> GetPermissionLevel(string ID)
        {
            foreach (var usr in Sysdba._ACCOUNTS)
            {
                if (ID == usr.ID.ToString())
                {
                    return usr.PERM_LEVEL;
                }
            }
            return Permission.LEVEL.NONE;
        }
        public override async Task<string> GetUsernameAsync(string ID)
        {
            foreach (var u in Sysdba._ACCOUNTS)
            {
                if (u.ID.ToString() == ID)
                {
                    return u.USERNAME;
                }
            }
            return "ERR_NAME_NOT_REC";
        }
        public override async Task<bool> IsAuthenticatedAndPermittedAsync(string ID)
        {
            foreach (var u in Sysdba._ACCOUNTS)
            {
                if (u.ID.ToString() == ID && u.PERM_LEVEL != Permission.LEVEL.NONE && u.IS_AUTHENTICATED)
                {
                    return true;
                }
            }
            return false;
        }
        public override async Task<string> ValidateDataAsync(string user, string password)
        {
            foreach (var usr in Sysdba._ACCOUNTS)
            {
                if (usr.USERNAME == user && usr.PASSWORD == password)
                {
                    var idx = Sysdba._ACCOUNTS.FindIndex(x => x.ID == usr.ID);
                    Sysdba._ACCOUNTS[idx].IS_AUTHENTICATED = true;
                    return usr.ID.ToString();
                }
            }
            return null;
        }
    }
}
