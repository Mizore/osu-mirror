using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beatmap_Mirror.Code.Structures
{
    public class ApiBeatmap
    {
        [JsonProperty(PropertyName = "status")]
        public ApiStatus Status { get; set; }
        [JsonProperty(PropertyName = "beatmap")]
        public Beatmap Beatmap { get; set; }
    }
}
