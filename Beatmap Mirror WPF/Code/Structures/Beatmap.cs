using Beatmap_Mirror_WPF.Code.Tools;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beatmap_Mirror.Code.Structures
{
    public class Beatmap
    {
        [JsonProperty(PropertyName = "id")]
        public int ID { get; set; }

        [JsonProperty(PropertyName = "ranked_id")]
        public int Ranked_ID { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "type")]
        public BeatmapType Type { get; set; }

        [JsonProperty(PropertyName = "size")]
        public int Size { get; set; }

        [JsonProperty(PropertyName = "hash_md5")]
        public string HashMD5 { get; set; }

        [JsonProperty(PropertyName = "hash_sha1")]
        public string HashSha1 { get; set; }

        [JsonProperty(PropertyName = "versions")]
        public List<BeatmapDifficulty> Difficulties { get; set; }

        [JsonIgnore]
        public string SizeFormatted
        {
            get
            {
                return string.Format(new FileSizeFormatProvider(), "{0:fs3}", this.Size);
            }
        }
    }
}
