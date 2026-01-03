using EOM.TSHotelManagement.Shared;
using System.Reflection;

namespace EOM.TSHotelManagement.FormUI
{
    public static class Initialize
    {
        public static void CustomizeInitialize()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
        }
    }
}
