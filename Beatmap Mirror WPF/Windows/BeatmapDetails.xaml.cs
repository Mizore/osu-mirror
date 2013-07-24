using Beatmap_Mirror.Code;
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
using System.Windows.Threading;

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
                this.Beatmap = bm.GetData<Beatmap>();

                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(this.DisplayData));
            });
        }

        private void DisplayData()
        {
            this.BeatmapTitle.Text = this.Beatmap.Title;
            this.BeatmapSize.Text = this.Beatmap.SizeFormatted;

            this.ButtonImage.ImageSource = new BitmapImage(new Uri(string.Format("{0}beatmaps/{1}/content/image/custom/200x150/crop", Configuration.ApiLocation, this.Beatmap.Ranked_ID)));
        }

        private void ImageButton_Click(object sender, RoutedEventArgs e)
        {
            new ImageViewer(string.Format("{0}beatmaps/{1}/content/image/full", Configuration.ApiLocation, this.Beatmap.Ranked_ID)).ShowDialog();
        }
    }
}
