using Beatmap_Mirror.Code.Api.Requests;
using HttpMachine;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }

    public class ApiRequest
    {
        protected string Request { get; set; }
        protected List<string> Params { get; set; }

        protected HttpTrafficData TrafficData;
        protected HttpParser HttpParser;

        public ApiRequest()
        {
            this.TrafficData = new HttpTrafficData();
            this.HttpParser = new HttpParser(this.TrafficData);
        }

        public void SendRequest()
        {
            Socket sock = KeepAliveSocketManager.GetSocket();

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("GET /{0} HTTP/1.1\r\n", this.Request);
            sb.AppendFormat("Host: {0}\r\n", Configuration.ApiHost);
            sb.AppendFormat("User-Agent: {0}\r\n", "Osu!Mirror~");
            sb.AppendFormat("Accept: {0}\r\n", "*/*");
            sb.AppendFormat("\r\n");

            byte[] rheaders = Encoding.ASCII.GetBytes(sb.ToString());

            sock.Send(rheaders);

            int i = 0;
            byte[] recbuff = new byte[1024];
            while((i = sock.Receive(recbuff, recbuff.Length, SocketFlags.None)) > 0)
            {
                this.HttpParser.Execute(new ArraySegment<byte>(recbuff, 0, i));
            }
        }
    }
}
