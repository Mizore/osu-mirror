using Beatmap_Mirror.Code;
using Beatmap_Mirror.Code.Api;
using Beatmap_Mirror.Code.Api.Requests;
using Beatmap_Mirror.Code.Tools;
using Beatmap_Mirror.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beatmap_Mirror
{
    public class Program
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        static void Main(string[] args)
        {
            Configuration.Innit();

#if DEBUG
            AllocConsole();
#endif
            AppContext AC = new AppContext(args);
            Application.Run(AC);
        }
    }

    public class AppContext : ApplicationContext
    {
        private MainForm Form;

        public AppContext(string[] arguments)
        {
            Tools.CommandParser.Parse(arguments);

            if (Tools.CommandParser.Get<int>("download") != default(int))
            {
                ApiRequestBeatmapDetail a = ApiBase.Create<ApiRequestBeatmapDetail>();
                a.SetParams(new string[] { "666" });
                string aasd = a.SendRequest();
            }
            else
            {
                Console.Write("Opening up MainForm... ");
                this.Form = new MainForm();
                this.Form.Show();
                Console.WriteLine("Done");
            }
        }
    }
}
