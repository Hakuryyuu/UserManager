using System.Timers;

namespace gtausrmgr.Data
{
    public static class ResetFees
    {
        public static async Task CheckDayAndClean()
        {
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 18000000;
            aTimer.Enabled = true;
        }

        private static async void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Monday)
            {
                await CleanAll();
            }
        }
        private static async Task CleanAll()
        {
            foreach (var mbr in Sysdba._DATA)
            {
                mbr.FEE_PAID = "FALSE";
            }
        }
    }
}
