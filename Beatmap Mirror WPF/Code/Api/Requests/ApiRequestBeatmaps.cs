using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beatmap_Mirror.Code.Api.Requests
{
    public class ApiRequestBeatmaps : ApiRequest
    {
        public ApiRequestBeatmaps()
        {
            base.Request = "beatmaps";
            base.RequestMethod = ApiRequestMethod.Text;
        }
    }
}
