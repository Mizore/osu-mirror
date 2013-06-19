using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Beatmap_Mirror.Code.Api
{
    public static class KeepAliveSocketManager
    {
        private static Socket _sock;

        public static Socket GetSocket()
        {
            if (_sock != null)
            {
                if (_sock.Connected)
                    return _sock;
                else
                {
                    try
                    {
                        _sock.Disconnect(false);
                        _sock.Close();
                    }
                    catch { }
                }
            }
            
            if (_sock == null)
            {
                _sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _sock.Connect(Dns.GetHostAddresses(Configuration.ApiHost), Configuration.ApiPort);
            }

            return _sock;
        }
    }
}
