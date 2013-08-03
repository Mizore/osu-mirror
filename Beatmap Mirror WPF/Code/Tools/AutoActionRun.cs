using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Beatmap_Mirror_WPF.Code.Tools
{
    public class AutoActionRun
    {
        private int delay;
        private int ticks;

        private bool reset;

        private Timer timer;

        public AutoActionRun(int delay, int interval, Action d)
        {
            this.delay = delay;
            this.ticks = -1;
            this.reset = false;

            this.timer = new Timer(interval);
            this.timer.Elapsed += (object sender, ElapsedEventArgs e) =>
            {
                if ((this.ticks -= (int)this.timer.Interval) <= 0 && this.reset)
                {
                    this.reset = false;
                    d();
                }
            };
            this.timer.Start();
        }

        public void Trigger()
        {
            this.ticks = this.delay;
            this.reset = true;
        }

        public void Cancel()
        {
            this.ticks = -1;
            this.reset = false;
        }
    }
}
