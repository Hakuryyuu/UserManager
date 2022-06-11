using System.Data;

namespace gtausrmgr.Data
{
    public class SaveSysdba
    {
        public static async Task SaveData(List<Data> dat)
        {
            File.Delete("sysdba.dat");
            string file = null;
            foreach (var itm in dat)
            {
                file += $"{itm.NAME},{itm.ID},{itm.RANK},{itm.INTRODUCED_BY},{itm.RECRUITED_BY},{itm.FEE_PAID}\n";
            }
            File.WriteAllText("sysdba.dat", file);
        }

        public static async Task SaveAccs(List<User> dat)
        {
            File.Delete("sysdba.acc");
            string file = null;
            foreach (var itm in dat)
            {
                file += $"{itm.ID},{itm.USERNAME},{itm.PASSWORD},{itm.PERM_LEVEL}\n";
            }
            File.WriteAllText("sysdba.acc", file);
        }

        public static async Task ReadData()
        {
            if (!File.Exists("sysdba.dat"))
            {
                File.Create("sysdba.dat");
            }
            string[] file = File.ReadAllLinesAsync("sysdba.dat").Result;

            foreach (var r in file)
            {
                string[] rd = r.Split(',');
                Sysdba._DATA.Add(new Data { NAME = rd[0], ID = Convert.ToInt32(rd[1]), RANK = rd[2], INTRODUCED_BY = rd[3], RECRUITED_BY = rd[4], FEE_PAID = rd[5] });
            }
        }

        public static async Task ReadAccs()
        {
            if (!File.Exists("sysdba.acc"))
            {
                File.Create("sysdba.acc");
            }
            string[] file = File.ReadAllLinesAsync("sysdba.acc").Result;

            foreach (var r in file)
            {
                string[] rd = r.Split(',');
                Sysdba._ACCOUNTS.Add(new User { ID = Convert.ToInt32(rd[0]), USERNAME = rd[1], PASSWORD = rd[2], PERM_LEVEL = ConvertPerm(rd[3]) });
            }
        }

        private static Permission.LEVEL ConvertPerm(string lvl)
        {
            Permission.LEVEL PERM;

            switch (lvl.ToUpper())
            {
                case "ADMIN":
                    PERM = Permission.LEVEL.ADMIN;
                    break;
                case "WRITE":
                    PERM = Permission.LEVEL.WRITE;
                    break;
                case "READ":
                    PERM = Permission.LEVEL.READ;
                    break;
                default:
                    PERM = Permission.LEVEL.NONE;
                    break;
            }
            return PERM;
        }
    }
}
