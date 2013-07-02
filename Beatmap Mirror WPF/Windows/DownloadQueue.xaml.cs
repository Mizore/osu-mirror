using Beatmap_Mirror.Code;
using Beatmap_Mirror.Code.Api;
using Beatmap_Mirror.Code.Api.Requests;
using Beatmap_Mirror.Code.Structures;
using Beatmap_Mirror.Code.Tools;
using Beatmap_Mirror_WPF.Code.Elements;
using System;
using System.Collections.Concurrent;
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
        private BlockingCollection<int> Pending = new BlockingCollection<int>();

        private object Lock = new object();

        public DownloadQueue()
        {
            InitializeComponent();
            
            DownloadQueueManager.QueuedFile += (Beatmap map) =>
            {
                QueueItem qi = new QueueItem();
                qi.Beatmap = map;

                this.Queue.Add(map.Ranked_ID, qi);

                this.QueuedList.Children.Add(qi);
                this.Pending.Add(map.Ranked_ID);
            };

            DownloadQueueManager.FileUpdate += (Beatmap map, int downloaded) =>
            {
                this.Queue[map.Ranked_ID].Downloaded = downloaded;
                this.Queue[map.Ranked_ID].UpdateProgress();
            };

            DownloadQueueManager.DownloadFinished += (Beatmap map) =>
            {
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                {
                    this.QueuedList.Children.Remove(this.Queue[map.Ranked_ID]);
                    this.Queue.Remove(map.Ranked_ID);
                }));
            };
            
            new Thread(new ThreadStart(Worker)).Start();
        }

        private void Worker()
        {
            while (true)
            {
                int tgrab = this.Pending.Take();


                byte[] bdata;
                using (WebClient r = new WebClient())
                    bdata = r.DownloadData(new Uri(string.Format("{0}beatmaps/{1}/content/image/custom/80x50/crop", Configuration.ApiLocation, tgrab)));

                BitmapImage bmp = new BitmapImage();
                bmp.BeginInit();
                bmp.StreamSource = new MemoryStream(bdata);
                bmp.EndInit();

                bmp.Freeze();

                if (this.Queue.ContainsKey(tgrab))
                {
                    Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                    {
                        this.Queue[tgrab].Image = bmp;
                        this.Queue[tgrab].UpdateImage();
                    }));
                }
            }
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (this.Queue.Count == 0)
                this.Hide();

            e.Cancel = true;
        }
    }
}
