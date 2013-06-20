using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Beatmap_Mirror.Forms
{
    public partial class Information : Form
    {
        public Information()
        {
            InitializeComponent();
        }

        private void Information_Load(object sender, EventArgs e)
        {
            this.Text = "Beatmap Mirror - Information";
            this.Icon = global::Beatmap_Mirror.Resources.Resource._1371743613_104015;

            this.panel1.BackgroundImage = global::Beatmap_Mirror.Resources.Resource.information_banner;
        }
    }
}
