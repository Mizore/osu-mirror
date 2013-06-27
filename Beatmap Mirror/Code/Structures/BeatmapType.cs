using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Beatmap_Mirror.Code.Structures
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum BeatmapType
    {
        [EnumMember(Value = "osz2")]
        Osz2,
        [EnumMember(Value = "osz")]
        Osz,
        [EnumMember(Value = "rar")]
        Rar,
        [EnumMember(Value = "zip")]
        Zip
    }
}
