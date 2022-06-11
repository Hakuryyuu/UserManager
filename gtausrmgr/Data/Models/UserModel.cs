

namespace gtausrmgr.Data
{
    public class User : Permission
    {
        public int ID { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        // PERMISSION LEVEL
        public LEVEL PERM_LEVEL { get; set; }
        public bool IS_AUTHENTICATED { get; set; }
        public string AUTH_IP { get; set; }
    }
}
