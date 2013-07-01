using Beatmap_Mirror.Code.Api.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Beatmap_Mirror.Code.Api
{
    public static class ApiBase
    {
        public static T Create<T>()
            where T : ApiRequest, new()
        {
            T instance = (T)Activator.CreateInstance<T>();
            return instance;
        }

        public static T Create<T>(params string []param)
            where T : ApiRequest, new()
        {
            T instance = (T)Activator.CreateInstance<T>();
            instance.SetParams(param);

            return instance;
        }
    }

    public class ApiRequest
    {
        protected string Request { get; set; }
        protected List<string> Params { get; set; }

        protected ApiRequestMethod RequestMethod { get; set; }

        protected string[] Parameters { get; set; }

        public delegate void DDownloadProgress(long Downloaded);
        public delegate void DDownloadComplete(byte[] Buffer);

        public event DDownloadProgress EOnDownloadUpdate;
        public event DDownloadComplete EOnDownloadComplete;

        public ApiRequest()
        {
            this.Parameters = new string[] { };
        }

        public void SetParams(string[] pars)
        {
            this.Parameters = pars;
        }

        public void SetParams(List<string> pars)
        {
            this.Parameters = pars.ToArray();
        }

        public string SendRequest()
        {
            if (this.RequestMethod == ApiRequestMethod.Text)
            {
                WebClient wc = new WebClient();
                wc.Proxy = null;
                wc.Headers.Add(HttpRequestHeader.UserAgent, "Osu!Mirror");

                try
                {
                    string location = string.Format("{0}{1}", Configuration.ApiLocation, this.BuildQuery());
                    Console.WriteLine("Api: {0}", location);

                    return wc.DownloadString(location);
                }
                catch { return null; }
            }
            else if (this.RequestMethod == ApiRequestMethod.Download)
            {
                MemoryStream ms = new MemoryStream();
                string location = string.Format("{0}{1}", Configuration.ApiLocation, string.Format(this.Request, this.Parameters));
                Console.WriteLine("Api DL: {0}", location);

                HttpWebRequest r = (HttpWebRequest)WebRequest.Create(location);
                r.Method = "GET";
                using (WebResponse response = r.GetResponse())
                {
                    using (Stream s = response.GetResponseStream())
                    {
                        int total = 0;
                        int i = 0;
                        byte[] buff = new byte[1024 * 4]; // 4kb buffer

                        while ((i = s.Read(buff, 0, buff.Length)) > 0)
                        {
                            total += i;
                            ms.Write(buff, 0, i);

                            if (EOnDownloadUpdate != null)
                                EOnDownloadUpdate(total);
                        }

                        byte[] trimmed = new byte[total];
                        Array.Copy(ms.GetBuffer(), trimmed, total);

                        if (EOnDownloadComplete != null)
                            EOnDownloadComplete(trimmed);
                    }
                }
            }

            return null;
        }

        public T GetData<T>()
        {
            string data = this.SendRequest();
            if (data == null)
                return default(T);

            return ApiRequestParser.Parse<T>(data);
        }

        protected virtual string BuildQuery()
        {
            return string.Format(this.Request, string.Join("/", this.Parameters));
        }
    }
}
