using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beatmap_Mirror.Code.Tools
{
    public static class DownloadQueueManager
    {
        private static string BeatmapDownloadLocation;
        private static string MP3DownloadLocation;

        private static List<DownloadQueueEntry> Queue = new List<DownloadQueueEntry>();

        public static void AddToQueue(int BeatmapId, DownloadType Type)
        {
            if (string.IsNullOrEmpty(BeatmapDownloadLocation) || string.IsNullOrEmpty(MP3DownloadLocation))
                return;

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
        }

        public void GatherData()
        {
            //TODO
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
