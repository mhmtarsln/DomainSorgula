using DomainSorgula.Settings; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DomainSorgula.Helpers
{
    class IniHelper
    {

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool WritePrivateProfileString(string kategori, string anahtar, string deger, string dosyaAdi);

        [DllImport("kernel32.dll")]
        static extern uint GetPrivateProfileString(string kategori, string anahtar, string lpDefault, StringBuilder sb, int sbKapasite, string dosyaAdi);

        private static string GetHeader(SettingHeader setting)
        {
            string settingHeader = "";
            switch (setting)
            {
                case SettingHeader.ConcurrentCount:
                    settingHeader = "COUNCURRENT_COUNT";
                    break;
                case SettingHeader.DomainSaveSetting:
                    settingHeader = "DOMAIN_SAVE_SETTING";
                    break;
                case SettingHeader.SavePath:
                    settingHeader = "DOMAIN_SAVE_PATH";
                    break;
            }
            return settingHeader;
        }

        public static string Read(SettingHeader setting)
        {
            StringBuilder sb = new StringBuilder(2048);
            GetPrivateProfileString(GetHeader(setting), "VALUE", "", sb, 2048, Setting.SettingPath);
            return sb.ToString();
        }

        public static void Write(SettingHeader setting, string value)
        {
            WritePrivateProfileString(GetHeader(setting), "VALUE", value, Setting.SettingPath);
        }
    }
}
