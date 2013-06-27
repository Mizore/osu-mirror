using Beatmap_Mirror.Code.Api;
using Beatmap_Mirror.Code.Api.Requests;
using Beatmap_Mirror.Code.Elements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Beatmap_Mirror.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = "Beatmap Mirror";
            this.Icon = global::Beatmap_Mirror.Resources.Resource._1371743613_104015;

        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void cButton1_Click(object sender, EventArgs e)
        {
            /*
            ApiRequestSearch s = ApiBase.Create<ApiRequestSearch>();
            s.SetParams(new List<string>()
            {
                "maps.title.like.ass"
            });
            string data = s.SendRequest();
            Console.WriteLine(data);
            */
        }
    }
}
