using System.Text.Json;
using System.Xml.Serialization;

namespace gtausrmgr.Data
{
    public class DataProvider : AccountData
    {
       

        public async Task<List<Data>> GetDashboardDataAsync()
        {  
            return Sysdba._DATA;
        }

        public async Task AddToDataAsync(Data _data)
        {
            Sysdba._DATA.Add(_data);
           await SaveSysdba.SaveData(Sysdba._DATA);
        }

        public async Task RemoveToDataAsync(Data _data)
        {
            Sysdba._DATA.Remove(_data);

            await SaveSysdba.SaveData(Sysdba._DATA);
        }
    }
}
