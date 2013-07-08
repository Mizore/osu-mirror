using Beatmap_Mirror_WPF.Code.Tools;
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
        public static string OsuLocation = null;

        public static int ParrarelDownloads = 2;

        public static void Innit()
        {
            ServicePointManager.DefaultConnectionLimit = int.MaxValue;


            string temp = RegistryHelper.GetKey("ParrarelDownloads");
            if (temp != null)
                Configuration.ParrarelDownloads = int.Parse(temp);
            else
                RegistryHelper.SetKey("ParrarelDownloads", "2");


            temp = RegistryHelper.GetKey("BeatmapLocation");
            if (temp != null)
                Configuration.BeatmapDownloadLocation = temp;

            temp = RegistryHelper.GetKey("MP3Location");
            if (temp != null)
                Configuration.Mp3DownloadLocation = temp;

            temp = RegistryHelper.GetKey("OsuLocation");
            if (temp != null)
                Configuration.OsuLocation = temp;
        }
    }
}
