

using System.Text.Json;
using System.Xml.Serialization;

namespace gtausrmgr.Data
{
    public static class Sysdba
    {
        static Sysdba(){
            SaveSysdba.ReadAccs();
            SaveSysdba.ReadData();
        }
        public static List<Data> _DATA = new List<Data>();
        public static List<User> _ACCOUNTS = new List<User>();
    }
}
