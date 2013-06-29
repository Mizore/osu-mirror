using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beatmap_Mirror.Code.Api.Requests
{
    public class ApiRequestBeatmapDownload : ApiRequest
    {
        public ApiRequestBeatmapDownload()
        {
            base.Request = "beatmaps/{0}/download";
            base.RequestMethod = ApiRequestMethod.Download;
        }
    }
}
