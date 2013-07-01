using Beatmap_Mirror.Code.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beatmap_Mirror_WPF.Code.Api.Requests
{
    public class ApiRequestBeatmapDownloadMP3 : ApiRequest
    {
        public ApiRequestBeatmapDownloadMP3()
        {
            base.Request = "beatmaps/{0}/preview/mp3/full";
            base.RequestMethod = ApiRequestMethod.Download;
        }
    }
}
