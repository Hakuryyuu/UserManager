namespace gtausrmgr.Data
{
    public abstract class AccountManagement
    {
        public abstract Task LogOutAsync(string ID);

        public abstract Task GetUsernameAsync(string ID);
        public abstract Task IsAuthenticatedAndPermittedAsync(string ID);

        public abstract Task GetPermissionLevel(string ID);

        public abstract Task ValidateDataAsync(string user, string password);

    }
}
