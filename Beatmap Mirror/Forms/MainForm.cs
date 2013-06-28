using Beatmap_Mirror.Code.Api;
using Beatmap_Mirror.Code.Api.Requests;
using Beatmap_Mirror.Code.Structures;
using Beatmap_Mirror.Code.Tools;
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

            this.viewDetailsToolStripMenuItem.Image = global::Beatmap_Mirror.Resources.Resource.information;

        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void cButton1_Click(object sender, EventArgs e)
        {
            List<string> filters = new List<string>();
            
            if (!string.IsNullOrEmpty(this.tName.Text))
                filters.Add("maps.name.like." + this.tName.Text);

            if (!string.IsNullOrEmpty(this.tTitle.Text))
                filters.Add("maps.title.like." + this.tTitle.Text);

            if (!string.IsNullOrEmpty(this.tDifficulty.Text))
                filters.Add("metadata.m_version.like." + this.tDifficulty.Text);

            if (!string.IsNullOrEmpty(this.tArtist.Text))
                filters.Add("metadata.m_artist.like." + this.tArtist.Text);

            if (!string.IsNullOrEmpty(this.tCreator.Text))
                filters.Add("metadata.m_creator.like." + this.tCreator.Text);

            if (!string.IsNullOrEmpty(this.tSource.Text))
                filters.Add("metadata.m_source.like." + this.tSource.Text);

            if (!string.IsNullOrEmpty(this.tTags.Text))
                filters.Add("metadata.m_tags.like." + this.tTags.Text);
            
            Threaded.Add(() =>
            {
                ApiRequestSearch s = ApiBase.Create<ApiRequestSearch>(filters.ToArray());
                ApiSearch data = s.GetData<ApiSearch>();

                List<ListViewItem> items = new List<ListViewItem>();


                foreach (Beatmap b in data.Beatmaps)
                {
                    ListViewItem i = new ListViewItem(b.Ranked_ID.ToString());
                    //i.SubItems.Add(b.Ranked_ID.ToString());
                    i.SubItems.Add(b.Title);
                    i.SubItems.Add(b.Size.ToString());

                    items.Add(i);
                }

                this.Invoke((Action)(() =>
                {
                    this.cDetailView1.Items.Clear();
                    this.cDetailView1.Items.AddRange(items.ToArray());
                }));
            });
        }

        private void cDetailView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.SearchContext.Show(this.cDetailView1, e.Location);
            }
        }
    }
}
