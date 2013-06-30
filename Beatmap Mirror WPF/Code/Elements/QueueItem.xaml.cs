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
        public int Size { get; set; }
        public int Downloaded { get; set; }
        public string Title { get; set; }
        public BitmapSource Image { get; set; }
        public string BottomString { get; set; }

        public QueueItem()
        {
            InitializeComponent();

            this.Image = new BitmapImage();
            this.DataContext = this;
        }

        public void UpdateData()
        {
            this.TTitle.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() => { this.TTitle.Text = this.Title; }));
            this.TDetails.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() => {  }));
            this.TImage.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() => { this.TImage.Source = this.Image; }));
        }
    }
}
