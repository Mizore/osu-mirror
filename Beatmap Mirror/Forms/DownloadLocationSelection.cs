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
    public partial class DownloadLocationSelection : Form
    {
        public DownloadLocationSelection()
        {
            InitializeComponent();
        }

        private void cButton1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
        }
    }
}
