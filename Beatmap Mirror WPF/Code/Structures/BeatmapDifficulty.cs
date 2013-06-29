using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beatmap_Mirror.Code.Structures
{
    public class BeatmapDifficulty
    {
        [JsonProperty(PropertyName = "id")]
        public int ID { get; set; }

        [JsonProperty(PropertyName = "map")]
        public int MapID { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "size")]
        public int Size { get; set; }

        [JsonProperty(PropertyName = "hash_md5")]
        public string HashMD5 { get; set; }

        [JsonProperty(PropertyName = "hash_sha1")]
        public string HashSha1 { get; set; }

        [JsonProperty(PropertyName = "m_title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "m_artist")]
        public string Artist { get; set; }

        [JsonProperty(PropertyName = "m_creator")]
        public string Creator { get; set; }

        [JsonProperty(PropertyName = "m_version")]
        public string DifficultyName { get; set; }

        [JsonProperty(PropertyName = "m_source")]
        public string Source { get; set; }

        [JsonProperty(PropertyName = "m_tags")]
        public string Tags { get; set; }

        [JsonProperty(PropertyName = "d_drain")]
        public double DrainRate { get; set; }

        [JsonProperty(PropertyName = "d_size")]
        public double NoteSize { get; set; }

        [JsonProperty(PropertyName = "d_diff")]
        public double Difficulty { get; set; }

        [JsonProperty(PropertyName = "d_mult")]
        public double SliderScoreMultiplier { get; set; }

        [JsonProperty(PropertyName = "d_srate")]
        public double SliterTickRate { get; set; }

        [JsonProperty(PropertyName = "version")]
        public byte Version { get; set; }
    }
}
