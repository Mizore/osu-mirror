using Beatmap_Mirror.Code.Api;
using Beatmap_Mirror.Code.Api.Requests;
using Beatmap_Mirror.Code.Structures;
using Beatmap_Mirror_WPF.Windows;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows;

namespace Beatmap_Mirror.Code.Tools
{
    public static class DownloadQueueManager
    {
        private static BlockingCollection<Beatmap> Queue = new BlockingCollection<Beatmap>();
        private static Thread[] DownloaderThread;

        public delegate void EMap(Beatmap bm);
        public delegate void EMapP(Beatmap bm, int downlaoded);
        public static event EMap QueuedFile;
        public static event EMap DownloadFinished;
        public static event EMapP FileUpdate;

        private static DownloadQueue dqForm;

        public static void AddToQueue(Beatmap bm, DownloadType Type)
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

            Queue.Add(bm);
            if (QueuedFile != null)
                QueuedFile(bm);

            if (DownloaderThread == null)
            {
                DownloaderThread = new Thread[4];

                DownloaderThread[0] = new Thread(new ThreadStart(DownloadQueue));
                DownloaderThread[0].Start();

                DownloaderThread[1] = new Thread(new ThreadStart(DownloadQueue));
                DownloaderThread[1].Start();

                DownloaderThread[2] = new Thread(new ThreadStart(DownloadQueue));
                DownloaderThread[2].Start();

                DownloaderThread[3] = new Thread(new ThreadStart(DownloadQueue));
                DownloaderThread[3].Start();
            }
        }

        public static Beatmap[] GetQueue()
        {
            return Queue.ToArray();
        }

        private static void DownloadQueue()
        {
            Beatmap map;
            while (true)
            {
                map = Queue.Take();

                Console.WriteLine(map.Name);

                ApiRequestBeatmapDownload Download = ApiBase.Create<ApiRequestBeatmapDownload>(map.Ranked_ID.ToString());
                Download.EOnDownloadUpdate += (long Downloaded) =>
                {
                    if (FileUpdate != null)
                        FileUpdate(map, (int)Downloaded);
                };

                Download.EOnDownloadComplete += (byte[] Buffer) =>
                {
                    File.WriteAllBytes(string.Format("{0}\\{1}.{2}", Configuration.BeatmapDownloadLocation, map.Name, map.Type.ToString()), Buffer);

                    if (DownloadFinished != null)
                        DownloadFinished(map);
                };

                Download.SendRequest();
            }
        }

        public enum DownloadType
        {
            Beatmap,
            MP3
        }
    }
}
