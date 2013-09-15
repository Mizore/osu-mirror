using Beatmap_Mirror.Code.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Beatmap_Mirror_WPF.Code.Elements
{
    /// <summary>
    /// Interaction logic for QueueItem.xaml
    /// </summary>
    public partial class QueueItem : UserControl
    {
        public int Downloaded { get; set; }
        public Beatmap Beatmap { get; set; }
        public BitmapSource Image { get; set; }

        private Action UpdateAction;

        public QueueItem()
        {
            InitializeComponent();

            this.DataContext = this;
            this.UpdateAction = new Action(() =>
            {
                if (this.Downloaded == this.Beatmap.Size)
                    this.TProgress.Foreground = new SolidColorBrush(new Color()
                    {
                        R = 86,
                        G = 105,
                        B = 206,
                        A = 30
                    });

                if (this.Beatmap.Size != 0)
                    this.TProgress.Value = Math.Floor((double)this.Downloaded / (double)this.Beatmap.Size * 100.0);
            });
        }

        public void UpdateProgress()
        {
            this.TProgress.Dispatcher.Invoke(DispatcherPriority.Normal, this.UpdateAction);
        }

        public void SetFailed()
        {
            this.TProgress.Value = 100;
            this.TProgress.Foreground = new SolidColorBrush(new Color()
            {
                R = 255,
                G = 0,
                B = 0,
                A = 30
            });
        }

        public void UpdateImage()
        {
            this.TImage.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
            {
                this.TImage.Source = this.Image;
            }));
        }
    }
}
