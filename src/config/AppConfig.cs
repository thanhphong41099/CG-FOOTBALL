using IniReaderUnicode;
using System.IO;
using System.Windows.Forms;

/*
 * Author Phong 
 * Version CG karisma 2.8.1.0
 * Appconfig use *.DLL (Dynamic Link Library) to read config file
 * Use Key "[]" and Get Value on config.cfg file
*/

namespace VLeague
{
    internal class AppConfig
    {
        public static IniReader ConfigReader;

        public static IniReader LogReader;
        public static void envFileConfig()
        {
            if (!File.Exists(Application.StartupPath + "\\config.cfg"))
            {
                MessageBox.Show("Không tìm thấy file config.cfg !!!");
            }
            ConfigReader = new IniReader(Application.StartupPath + "\\config.cfg");
            LogReader = new IniReader(Application.StartupPath + "\\Logs.ini");
        }
    }
}
