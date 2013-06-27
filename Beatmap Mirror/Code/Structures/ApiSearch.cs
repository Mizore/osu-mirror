using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beatmap_Mirror.Code.Structures
{
    public class ApiSearch
    {
        [JsonProperty(PropertyName = "status")]
        public ApiStatus Status { get; set; }
        [JsonProperty(PropertyName = "beatmaps")]
        public List<ApiBeatmap> Beatmaps { get; set; }
    }
}
