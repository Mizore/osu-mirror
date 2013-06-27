using Beatmap_Mirror.Code;
using Beatmap_Mirror.Code.Api;
using Beatmap_Mirror.Code.Api.Requests;
using Beatmap_Mirror.Code.Structures;
using Beatmap_Mirror.Code.Tools;
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
    public partial class BeatmapDetails : Form
    {
        private Beatmap BeatMap { get; set; }


        public BeatmapDetails(int bmid)
        {
            InitializeComponent();
            this.LoadData(bmid);
        }

        public BeatmapDetails(Beatmap data)
        {
            InitializeComponent();

            this.BeatMap = data;
            this.ShowData();
        }

        private void LoadData(int beatmap)
        {
            Threaded.Add(() =>
            {
                ApiRequestBeatmapDetail details = ApiBase.Create<ApiRequestBeatmapDetail>(beatmap.ToString());
                this.BeatMap = details.GetData<ApiBeatmap>().Beatmap;

                this.Invoke((Action)(() =>
                {
                    this.ShowData();
                }));
            });
        }

        private void ShowData()
        {

            this.BeatmapTitle.Text = this.BeatMap.Title;
            this.BeatmapIcon.Load(string.Format("{0}beatmaps/{1}/preview/image/custom/200x150", Configuration.ApiLocation, this.BeatMap.Ranked_ID));
        }
    }
}
