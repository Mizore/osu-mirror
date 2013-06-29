using Beatmap_Mirror.Code.Api;
using Beatmap_Mirror.Code.Api.Requests;
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
using System.Windows.Shapes;

namespace Beatmap_Mirror_WPF.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<string> Filters = new List<string>();

            if (!string.IsNullOrWhiteSpace(this.SearchTitle.Text))
                Filters.Add(string.Format("maps.title.like.{0}", this.SearchTitle.Text));

            if (!string.IsNullOrWhiteSpace(this.SearchCreator.Text))
                Filters.Add(string.Format("metadata.m-creator.like.{0}", this.SearchCreator.Text));

            if (!string.IsNullOrWhiteSpace(this.SearchSource.Text))
                Filters.Add(string.Format("metadata.m_source.like.{0}", this.SearchSource.Text));

            if (!string.IsNullOrWhiteSpace(this.SearchTags.Text))
                Filters.Add(string.Format("metadata.m_tags.like.{0}", this.SearchTags.Text));

            if(this.SearchSizeMin.Value > 0)
                Filters.Add(string.Format("maps.size.gteq.{0}", this.SearchSizeMin.Value));

            if(this.SearchSizeMax.Value > 0)
                Filters.Add(string.Format("maps.size.lteq.{0}", this.SearchSizeMax.Value));

            if (this.SearchVersion.Value > 0)
                Filters.Add(string.Format("metadata.version.eq.{0}", this.SearchVersion.Value));

            ApiRequestSearch search = ApiBase.Create<ApiRequestSearch>(Filters.ToArray());
            ApiSearch data = search.GetData<ApiSearch>();

            this.SearchResults.Items.Clear();

            foreach (Beatmap bm in data.Beatmaps)
            {
                this.SearchResults.Items.Add(bm);
            }
        }
    }
}
