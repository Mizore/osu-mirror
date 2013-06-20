using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beatmap_Mirror.Code.Api.Requests
{
    public class ApiRequestBeatmapDetail : ApiRequest
    {
        public ApiRequestBeatmapDetail()
        {
            base.Request = "beatmaps/{0}";
            base.RequestMethod = ApiRequestMethod.Text;
        }
    }
}
