using Beatmap_Mirror.Code;
using Beatmap_Mirror_WPF.Code.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Beatmap_Mirror_WPF.Windows
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();

            BeatmapLocation.Text = RegistryHelper.GetKey("BeatmapLocation");
            MP3Location.Text = RegistryHelper.GetKey("MP3Location");

            ParrarelDownloadCount.Value = int.Parse(RegistryHelper.GetKey("ParrarelDownloads"));
            ParrarelDownloadCount.Text = ParrarelDownloadCount.Value.ToString();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void BeatmapLocation_TextChanged(object sender, TextChangedEventArgs e)
        {
            Configuration.BeatmapDownloadLocation = BeatmapLocation.Text;
            RegistryHelper.SetKey("BeatmapLocation", BeatmapLocation.Text);
        }

        private void MP3Location_TextChanged(object sender, TextChangedEventArgs e)
        {
            Configuration.Mp3DownloadLocation = MP3Location.Text;
            RegistryHelper.SetKey("MP3Location", MP3Location.Text);
        }

        private void ParrarelDownloadCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            Configuration.ParrarelDownloads = ParrarelDownloadCount.Value;
            RegistryHelper.SetKey("ParrarelDownloads", ParrarelDownloadCount.Value.ToString());
        }

        private void BeatmapBrowse_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            DialogResult result = dialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
                this.BeatmapLocation.Text = dialog.SelectedPath;
        }

        private void MP3Browse_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            DialogResult result = dialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
                this.MP3Location.Text = dialog.SelectedPath;
        }
    }
}
