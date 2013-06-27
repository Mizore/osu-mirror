using Beatmap_Mirror.Code.Api.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

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

        public delegate void DDownloadProgress(long Downloaded, long Total);
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
            WebClient wc = new WebClient();
            wc.Proxy = null;
            wc.Headers.Add(HttpRequestHeader.UserAgent, "Osu!Mirror");

            if (this.RequestMethod == ApiRequestMethod.Text)
            {
                return wc.DownloadString(string.Format("{0}{1}", Configuration.ApiLocation, this.BuildQuery()));
            }
            else if (this.RequestMethod == ApiRequestMethod.Download)
            {
                MemoryStream ms = new MemoryStream();

                wc.DownloadDataCompleted += (object sender, DownloadDataCompletedEventArgs e) =>
                {
                    try { EOnDownloadComplete(e.Result); }
                    catch { }
                };

                wc.DownloadProgressChanged += (object sender, DownloadProgressChangedEventArgs e) =>
                {
                    try { EOnDownloadUpdate(e.BytesReceived, e.TotalBytesToReceive); }
                    catch { }
                };

                wc.DownloadDataAsync(new Uri(string.Format("{0}{1}", Configuration.ApiLocation, string.Format(this.Request, this.Parameters))));
            }

            return null;
        }

        public T GetData<T>()
        {
            return ApiRequestParser.Parse<T>(this.SendRequest());
        }

        protected virtual string BuildQuery()
        {
            return string.Format(this.Request, string.Join("/", this.Parameters));
        }
    }
}
