using Beatmap_Mirror.Code;
using Beatmap_Mirror.Code.Api;
using Beatmap_Mirror.Code.Api.Requests;
using Beatmap_Mirror_WPF.Code.Tools;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;

namespace Beatmap_Mirror_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        public App()
        {
            Configuration.Innit();

#if DEBUG
            if (AllocConsole())
                Console.WriteLine("Console creation:: OK");
            else
                MessageBox.Show("Console creation failed!!!", "OH NOES", MessageBoxButton.OK);
#endif
            return;
        }
    }
}
