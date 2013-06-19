using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Beatmap_Mirror.Code.Tools
{
    public static class Tools
    {
        public static class CommandParser
        {
            private static Dictionary<string, string> Data = new Dictionary<string, string>();

            public static void Parse(string[] args)
            {
                foreach (string arg in args)
                {
                    Match match1 = Regex.Match(arg, @"\-([a-z]+)\=([a-zA-Z0-9\-_|]+)");
                    if (match1.Success)
                        Data.Add(match1.Groups[1].Value, match1.Groups[2].Value);


                    Match match2 = Regex.Match(arg, @"\-([a-z]+)");
                    if (match2.Success)
                        Data.Add(match2.Groups[1].Value, "");
                }
            }

            public static T Get<T>(string name)
            {
                if (!Data.ContainsKey(name))
                    return default(T);

                string val = Data[name];

                switch (typeof(T).Name)
                {
                    case "Int":
                        try { return (T)(object)int.Parse(val); }
                        catch { return (T)(object)default(int); }

                    case "String":
                        return (T)(object)val;

                    case "Boolean":
                        return (T)(object)Data.ContainsKey(name);

                    default: return default(T);
                }
            }
        }
    }
}
