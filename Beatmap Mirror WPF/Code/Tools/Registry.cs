using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beatmap_Mirror_WPF.Code.Tools
{
    public static class RegistryHelper
    {
        private static RegistryKey Key;

        public static string GetKey(string key)
        {
            if(Key == null)
                SetUp();

            return (string)Key.GetValue(key);
        }

        public static void SetKey(string key, string value)
        {
            Key.SetValue(key, value, RegistryValueKind.String);
        }

        private static void SetUp()
        {
            Key = Registry.CurrentUser.OpenSubKey("SOFTWARE", true);
            RegistryKey k = Key.OpenSubKey("OsuMirror", true);
            if (k == null)
                Key.CreateSubKey("OsuMirror");

            Key = Key.OpenSubKey("OsuMirror", true);
        }
    }
}
