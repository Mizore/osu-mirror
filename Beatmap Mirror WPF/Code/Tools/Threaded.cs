using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Beatmap_Mirror.Code.Tools
{
    public static class Threaded
    {
        public static void Add(Action Act)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback((object StatusObject) =>
            {
                Act();
            }));
        }
    }
}
