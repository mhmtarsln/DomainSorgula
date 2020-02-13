using DomainSorgula.Settings;
using DomainSorgula.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DomainSorgula.Settings
{
    public class Setting
    {
        static Setting()
        {
            if (int.TryParse(IniHelper.Read(SettingHeader.ConcurrentCount), out int value))
            {
                ConcurrentCount = value;
            }
            else
            {
                ConcurrentCount = 3;
            }

            if (int.TryParse(IniHelper.Read(SettingHeader.DomainSaveSetting), out value))
            {
                switch (value)
                {
                    case 0:
                        Setting.SaveSetting = SaveSetting.Both;
                        break;
                    case 1:
                        Setting.SaveSetting = SaveSetting.OnlyAvailable;
                        break;
                    case 2:
                        Setting.SaveSetting = SaveSetting.OnlyTaken;
                        break;
                }
            }
            else
            {
                SaveSetting = SaveSetting.Both;
            }
            string path = IniHelper.Read(SettingHeader.SavePath);
            if (!string.IsNullOrEmpty(path))
            {
                Setting.SavePath = path;
            }
            else
            {
                SavePath = Application.StartupPath + @"\Sonuçlar.txt";
            }
        }
        private static int _concurrentCount;
        private static string _savePath;
        private static SaveSetting _saveSetting;

        public static int ConcurrentCount { get { return _concurrentCount; } 
            set {
                _concurrentCount = value;
                IniHelper.Write(SettingHeader.ConcurrentCount, _concurrentCount.ToString());
            } 
        }
        public static string SavePath { get { return _savePath; } 
            set { 
                _savePath = value;
                IniHelper.Write(SettingHeader.SavePath, _savePath);
            }
        }
        public static SaveSetting SaveSetting { get { return _saveSetting; } set { 
                _saveSetting = value;
                IniHelper.Write(SettingHeader.DomainSaveSetting, Convert.ToInt32(_saveSetting).ToString());
            }
        }

        public static readonly string SettingPath = Application.StartupPath + @"\settings.ini";
    }
}
