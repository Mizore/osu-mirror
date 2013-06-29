using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Beatmap_Mirror.Code
{
    public static class Configuration
    {
        public const string ApiHost = "api.osu.miz.hexide.com";
        public const string ApiLocation = "http://api.osu.miz.hexide.com/";
        public const int ApiPort = 80;

        public static string BeatmapDownloadLocation = null;
        public static string Mp3DownloadLocation = null;

        public static void Innit()
        {
            ServicePointManager.DefaultConnectionLimit = int.MaxValue;
        }
    }
}
