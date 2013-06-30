using Beatmap_Mirror.Code;
using Beatmap_Mirror.Code.Api;
using Beatmap_Mirror.Code.Api.Requests;
using Beatmap_Mirror.Code.Structures;
using Beatmap_Mirror.Code.Tools;
using Beatmap_Mirror_WPF.Code.Elements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
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
    /// Interaction logic for DownloadQueue.xaml
    /// </summary>
    public partial class DownloadQueue : Window
    {
        private Dictionary<int, QueueItem> Queue = new Dictionary<int, QueueItem>();
        private List<int> Pending = new List<int>();

        public DownloadQueue()
        {
            InitializeComponent();

            DownloadQueueManager.QueuedFile += (int BeatmapID) =>
            {
                QueueItem qi = new QueueItem();

                this.Queue.Add(BeatmapID, qi);

                this.QueuedList.Children.Add(qi);
                this.Pending.Add(BeatmapID);
            };

            this.LoadQueue();
            this.StartWorker();
        }

        private void Worker(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (this.Pending.Count != 0)
                {
                    int f = this.Pending.First();
                    this.Pending.Remove(f);

                    ApiRequestBeatmapDetail d = ApiBase.Create<ApiRequestBeatmapDetail>(f.ToString());
                    ApiBeatmap data = d.GetData<ApiBeatmap>();

                    byte[] bdata;
                    using (WebClient r = new WebClient())
                    {
                        bdata = r.DownloadData(new Uri(string.Format("{0}beatmaps/{1}/preview/image/custom/80x50/crop", Configuration.ApiLocation, data.Beatmap.Ranked_ID)));
                    }

                    BitmapImage bmp = new BitmapImage();
                    bmp.BeginInit();
                    bmp.StreamSource = new MemoryStream(bdata);
                    bmp.EndInit();

                    bmp.Freeze();

                    if (this.Queue.ContainsKey(f))
                    {
                        Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                        {
                            this.Queue[f].Title = data.Beatmap.Title;
                            this.Queue[f].Size = data.Beatmap.Size;
                            this.Queue[f].Image = bmp;
                            this.Queue[f].UpdateData();
                        }));
                    }
                    else
                    {
                        Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                        {
                            QueueItem qi = new QueueItem();
                            qi.Title = data.Beatmap.Title;
                            qi.Size = data.Beatmap.Size;
                            qi.Image = bmp;

                            this.Queue.Add(f, qi);
                            this.QueuedList.Children.Add(qi);
                        }));
                    }
                }

                Thread.Sleep(100);
            }
        }

        private void StartWorker()
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(this.Worker);

            bw.RunWorkerAsync();
        }

        private void LoadQueue()
        {
            int[] p = DownloadQueueManager.GetQueue();
            foreach(int i in p)
            {
                QueueItem qi = new QueueItem();

                this.Queue.Add(i, qi);

                this.QueuedList.Children.Add(qi);
                this.Pending.Add(i);
            }
        }
    }
}
