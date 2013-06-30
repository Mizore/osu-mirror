using Beatmap_Mirror.Code;
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
            // Lets create debug console, useful for printing out data into it.
            // It will obviously be non-visible in Relese mode.
            if (AllocConsole())
                Console.WriteLine("Console creation:: OK");
            else
                MessageBox.Show("Console creation failed!!!", "OH NOES", MessageBoxButton.OK);
#endif
        }
    }
}
