using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beatmap_Mirror.Code.Api
{
    public class ApiRequestParser
    {
        public static T Parse<T>(string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        }
    }
}
