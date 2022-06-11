/*
 *  AUTHOR: Hakuryuu
 *  DATE: 09/06/2022
 *  info@hakuryuu.net
 *  
 */

namespace gtausrmgr.Data
{
    public class Permission
    {
        /* PERMISSION LEVELS/GROUPS
         * 
         *      ADMIN: READ ENTRIES, ADD ENTRIES, ADD USERS
         *      WRITE: READ ENTRIES, ADD ENTRIES
         *      READ: READ ENTRIES
         *      NONE (default): No Permissions
         */
        public enum LEVEL
        {
            ADMIN,
            WRITE,
            READ,
            NONE
        }
    }
}
