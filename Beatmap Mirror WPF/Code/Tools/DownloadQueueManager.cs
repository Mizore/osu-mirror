using Beatmap_Mirror.Code.Api;
using Beatmap_Mirror.Code.Api.Requests;
using Beatmap_Mirror.Code.Structures;
using Beatmap_Mirror_WPF.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;

namespace Beatmap_Mirror.Code.Tools
{
    public static class DownloadQueueManager
    {
        private static List<DownloadQueueEntry> Queue = new List<DownloadQueueEntry>();
        private static Thread DownloaderThread;

        public delegate void EInt(int BeatmapID);
        public delegate void EMap(int BeatmapID, int downloaded);
        public static event EInt QueuedFile;
        public static event EMap FileUpdate;

        private static DownloadQueue dqForm;

        public static void AddToQueue(int BeatmapId, DownloadType Type)
        {
            if (dqForm == null)
            {
                dqForm = new DownloadQueue();
                dqForm.Show();
            }

            if (string.IsNullOrEmpty(Configuration.BeatmapDownloadLocation) || string.IsNullOrEmpty(Configuration.Mp3DownloadLocation))
            {
                MessageBox.Show("Please first select download locations in settings pannel at the bottom of the window.", "Welp", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            Queue.Add(new DownloadQueueEntry(BeatmapId));

            try { QueuedFile(BeatmapId); }
            catch { }

            if (DownloaderThread == null)
            {
                DownloaderThread = new Thread(new ThreadStart(DownloadQueue));
                DownloaderThread.Start();
            }
        }

        public static int[] GetQueue()
        {
            return Queue.Select(item => item.RankedBeatmapID).ToArray();
        }

        private static void DownloadQueue()
        {
            while (true)
            {
                if (Queue.Count > 0)
                {
                    DownloadQueueEntry ent = Queue.First();
                    Queue.Remove(ent);

                    //try { FileUpdate(ent.RankedBeatmapID, r.Next(0, ent.Size)); }
                    //catch { }

                }

                Thread.Sleep(10);
            }
        }

        public enum DownloadType
        {
            Beatmap,
            MP3
        }
    }

    public class DownloadQueueEntry
    {
        public int RankedBeatmapID { get; private set; }
        public int Size { get; private set; }
        public int Downloaded { get; private set; }
        public DownloadStatus Status { get; private set; }

        public DownloadQueueEntry(int Beatmap)
        {
            this.RankedBeatmapID = Beatmap;

            this.GatherData();
        }

        public void GatherData()
        {
            ApiRequestBeatmapDetail d = ApiBase.Create<ApiRequestBeatmapDetail>(this.RankedBeatmapID.ToString());
            ApiBeatmap Detail = d.GetData<ApiBeatmap>();

            this.Size = Detail.Beatmap.Size;
        }

        public void UpdateStatus()
        {
            //TODO
        }

        public enum DownloadStatus
        {
            Queued,
            Downloading,
            Finished
        }
    }
}
