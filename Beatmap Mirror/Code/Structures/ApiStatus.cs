using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beatmap_Mirror.Code.Structures
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ApiStatus
    {
        ok,
        fail
    }
}
