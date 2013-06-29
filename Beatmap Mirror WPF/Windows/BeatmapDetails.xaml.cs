using Beatmap_Mirror.Code.Api;
using Beatmap_Mirror.Code.Api.Requests;
using Beatmap_Mirror.Code.Structures;
using Beatmap_Mirror.Code.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Beatmap_Mirror_WPF.Windows
{
    /// <summary>
    /// Interaction logic for BeatmapDetails.xaml
    /// </summary>
    public partial class BeatmapDetails : Window
    {
        private Beatmap Beatmap { get; set; }

        public BeatmapDetails(int BeatmapID)
        {
            InitializeComponent();

            this.LoadBeatmapData(BeatmapID);
        }

        private void LoadBeatmapData(int Beatmap)
        {
            Threaded.Add(() =>
            {
                ApiRequestBeatmapDetail bm = ApiBase.Create<ApiRequestBeatmapDetail>(Beatmap.ToString());
                this.Beatmap = bm.GetData<ApiBeatmap>().Beatmap;


            });
        }

        private void DisplayData()
        {

        }
    }
}
