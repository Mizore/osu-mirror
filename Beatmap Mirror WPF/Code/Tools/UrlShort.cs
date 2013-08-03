using Beatmap_Mirror.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Beatmap_Mirror_WPF.Code.Tools
{
    public static class UrlShort
    {
        public static string Short(string url)
        {
            WebClient wc = new WebClient();
            wc.Proxy = null;
            wc.Headers.Add("User-Agent", string.Format("Osu!Mirror {0}", Configuration.VersionString));

            return wc.DownloadString(Uri.EscapeUriString(string.Format("http://api.waa.ai/?url={0}", url)));
        }
    }
}
