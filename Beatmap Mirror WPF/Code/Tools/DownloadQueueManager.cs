using Beatmap_Mirror.Code.Api;
using Beatmap_Mirror.Code.Api.Requests;
using Beatmap_Mirror.Code.Structures;
using Beatmap_Mirror_WPF.Code.Api.Requests;
using Beatmap_Mirror_WPF.Code.Tools;
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
        private static BlockingCollection<QueueDownload> Queue = new BlockingCollection<QueueDownload>();
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

                dqForm.Closed += (object sender, EventArgs e) =>
                {
                    dqForm = null;
                };
            }
            else if (dqForm.Visibility != Visibility.Visible)
                dqForm.Show();

            if ((Type == DownloadType.Beatmap && string.IsNullOrEmpty(Configuration.BeatmapDownloadLocation)) || (Type == DownloadType.MP3 && string.IsNullOrEmpty(Configuration.Mp3DownloadLocation)))
            {
                MessageBox.Show("Please first select download locations in settings pannel at the bottom of the window.\n\n Goto: File -> Settings", "Welp", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            Queue.Add(new QueueDownload()
            {
                Beatmap = bm,
                DownloadType = Type
            });

            if (QueuedFile != null)
                QueuedFile(bm);

            if (DownloaderThread == null)
            {
                DownloaderThread = new Thread[Configuration.ParrarelDownloads];

                for (int i = 0; i < DownloaderThread.Length; i++)
                {
                    DownloaderThread[i] = new Thread(new ThreadStart(DownloadQueue));
                    DownloaderThread[i].Start();
                }
            }
        }

        public static Beatmap[] GetQueue()
        {
            return Queue.Select(e => e.Beatmap).ToArray();
        }

        private static void DownloadQueue()
        {
            QueueDownload qitem;
            while (true)
            {
                qitem = Queue.Take();

                if (qitem.DownloadType == DownloadType.Beatmap)
                {
                    ApiRequestBeatmapDownload Download = ApiBase.Create<ApiRequestBeatmapDownload>(qitem.Beatmap.Ranked_ID.ToString());
                    Download.EOnDownloadUpdate += (long Downloaded) =>
                    {
                        if (FileUpdate != null)
                            FileUpdate(qitem.Beatmap, (int)Downloaded);
                    };

                    Download.EOnDownloadComplete += (byte[] Buffer) =>
                    {
                        File.WriteAllBytes(string.Format("{0}\\{1}.{2}", Configuration.BeatmapDownloadLocation, qitem.Beatmap.Name, qitem.Beatmap.Type.ToString().ToLower()), Buffer);

                        if (DownloadFinished != null)
                            DownloadFinished(qitem.Beatmap);
                    };

                    Download.SendRequest();
                }
                else if (qitem.DownloadType == DownloadType.MP3)
                {
                    ApiRequestBeatmapDownloadMP3 MP3Download = ApiBase.Create<ApiRequestBeatmapDownloadMP3>(qitem.Beatmap.Ranked_ID.ToString());

                    MP3Download.EOnDownloadUpdate += (long Downloaded) =>
                    {
                        if (FileUpdate != null)
                            FileUpdate(qitem.Beatmap, (int)Downloaded);
                    };

                    MP3Download.EOnDownloadComplete += (byte[] Buffer) =>
                    {
                        File.WriteAllBytes(string.Format("{0}\\{1}.mp3", Configuration.Mp3DownloadLocation, Helpers.CleanFileName(qitem.Beatmap.Title)), Buffer);

                        if (DownloadFinished != null)
                            DownloadFinished(qitem.Beatmap);
                    };

                    MP3Download.SendRequest();
                }
            }
        }

        public enum DownloadType
        {
            Beatmap,
            MP3
        }

        public class QueueDownload
        {
            public Beatmap Beatmap { get; set; }
            public DownloadType DownloadType { get; set; }
        }
    }
}
