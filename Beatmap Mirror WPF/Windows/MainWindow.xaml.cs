using Beatmap_Mirror.Code;
using Beatmap_Mirror.Code.Api;
using Beatmap_Mirror.Code.Api.Requests;
using Beatmap_Mirror.Code.Structures;
using Beatmap_Mirror.Code.Tools;
using Beatmap_Mirror_WPF.Code.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Beatmap_Mirror_WPF.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ListSortDirection LastSort = ListSortDirection.Ascending;
        private List<Beatmap> RawSearchResultList = new List<Beatmap>();

        private Settings SettingsWindow;
        private About AboutWindow;
        private DownloadQueue dqForm;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void PerformBeatmapSearch()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback((object ob) =>
            {
                List<string> Filters = new List<string>();

                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                {
                    this.Overlay.BeginAnimation(Grid.OpacityProperty, new DoubleAnimation()
                    {
                        Duration = new Duration(new TimeSpan(0, 0, 0, 0, 500)),
                        FillBehavior = FillBehavior.HoldEnd,
                        From = 0.0,
                        To = 1.0
                    });
                    this.Overlay.Visibility = Visibility.Visible;

                    if (!string.IsNullOrWhiteSpace(this.SearchTitle.Text))
                        Filters.Add(string.Format("maps.title.like.{0}", this.SearchTitle.Text));

                    if (!string.IsNullOrWhiteSpace(this.SearchCreator.Text))
                        Filters.Add(string.Format("metadata.m_creator.like.{0}", this.SearchCreator.Text));

                    if (!string.IsNullOrWhiteSpace(this.SearchSource.Text))
                        Filters.Add(string.Format("metadata.m_source.like.{0}", this.SearchSource.Text));

                    if (!string.IsNullOrWhiteSpace(this.SearchTags.Text))
                        Filters.Add(string.Format("metadata.m_tags.like.{0}", this.SearchTags.Text));

                    if (this.SearchSizeMin.Value > 0)
                        Filters.Add(string.Format("maps.size.gteq.{0}", (int)(this.SearchSizeMin.Value * 1024.0 * 1024.0)));

                    if (this.SearchSizeMax.Value > 0)
                        Filters.Add(string.Format("maps.size.lteq.{0}", (int)(this.SearchSizeMax.Value * 1024.0 * 1024.0)));

                    if (this.SearchVersion.Value > 0)
                        Filters.Add(string.Format("metadata.version.eq.{0}", this.SearchVersion.Value));


                    this.SearchResults.Items.Clear();
                    this.RawSearchResultList.Clear();
                }));

                ApiRequestSearch search = ApiBase.Create<ApiRequestSearch>(Filters.ToArray());
                List<Beatmap> data = search.GetData<List<Beatmap>>();


                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                {
                    DoubleAnimation anim = new DoubleAnimation()
                    {
                        Duration = new Duration(new TimeSpan(0, 0, 0, 0, 500)),
                        FillBehavior = FillBehavior.HoldEnd,
                        From = 1.0,
                        To = 0.0
                    };

                    anim.Completed += (object sender, EventArgs e) =>
                    {
                        this.Overlay.Visibility = Visibility.Hidden;
                    };

                    this.Overlay.BeginAnimation(Grid.OpacityProperty, anim);

                    if (data == null)
                        return;

                    this.RawSearchResultList.AddRange(data);

                    foreach (Beatmap bm in data)
                        this.SearchResults.Items.Add(bm);
                }));
            }));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.PerformBeatmapSearch();
        }

        private void MenuItemDetails_Click(object sender, RoutedEventArgs e)
        {
            foreach (Beatmap bm in this.SearchResults.SelectedItems)
                new BeatmapDetails(bm.Ranked_ID).Show();
        }

        private void ShowDownloadQueue()
        {
            if (this.dqForm == null)
            {
                this.dqForm = new DownloadQueue();
                this.dqForm.Show();

                this.dqForm.Closed += (object sender, EventArgs e) =>
                {
                    this.dqForm = null;
                };
            }
            else if (this.dqForm.Visibility != Visibility.Visible)
                this.dqForm.Show();

            if (!this.dqForm.IsFocused)
                this.dqForm.Focus();
        }

        private void MenuItemDownloadBeatmap_Click(object sender, RoutedEventArgs e)
        {
            this.ShowDownloadQueue();

            foreach (Beatmap bm in this.SearchResults.SelectedItems)
                DownloadQueueManager.AddToQueue(bm, DownloadQueueManager.DownloadType.Beatmap);

            this.SearchResults.SelectedItem = null;
        }

        private void MenuItemDownloadMP3_Click(object sender, RoutedEventArgs e)
        {
            this.ShowDownloadQueue();

            foreach (Beatmap bm in this.SearchResults.SelectedItems)
                DownloadQueueManager.AddToQueue(bm, DownloadQueueManager.DownloadType.MP3);

            this.SearchResults.SelectedItem = null;
        }

        private void SearchResults_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            if (this.SearchResults.SelectedItems.Count > 1)
            {
                //this.MenuItemFullDetails.IsEnabled = false;
                this.MenuItemDetails.IsEnabled = false;
                this.MenuItemDownloadLink.IsEnabled = false;
            }
            else
            {
                //this.MenuItemFullDetails.IsEnabled = true;
                this.MenuItemDetails.IsEnabled = true;
                this.MenuItemDownloadLink.IsEnabled = true;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!Configuration.AskBeforeClose)
            {
                Process.GetCurrentProcess().Kill();
                return;
            }

            if (System.Windows.MessageBox.Show("You sure you want to quit?", "Are you sure?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                e.Cancel = true;
            else
                Process.GetCurrentProcess().Kill();
        }

        private void SearchResults_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader c = e.OriginalSource as GridViewColumnHeader;

            if (c != null)
            {
                if (this.LastSort == ListSortDirection.Ascending)
                    this.LastSort = ListSortDirection.Descending;
                else
                    this.LastSort = ListSortDirection.Ascending;
              
                switch(c.Column.Header.ToString())
                {
                    case "ID":
                        this.RawSearchResultList.Sort(delegate(Beatmap a, Beatmap b)
                        {
                            int xdiff = this.LastSort == ListSortDirection.Ascending ? a.Ranked_ID.CompareTo(b.Ranked_ID) : b.Ranked_ID.CompareTo(a.Ranked_ID);
                            if (xdiff != 0) 
                                return xdiff;

                            return 0;
                        });
                        break;

                    case "Title":
                        this.RawSearchResultList.Sort(delegate(Beatmap a, Beatmap b)
                        {
                            int xdiff = this.LastSort == ListSortDirection.Ascending ? a.Title.CompareTo(b.Title) : b.Title.CompareTo(a.Title);
                            if (xdiff != 0) 
                                return xdiff;

                            return 0;
                        });
                        break;

                    case "Size":
                        this.RawSearchResultList.Sort(delegate(Beatmap a, Beatmap b)
                        {
                            int xdiff = this.LastSort == ListSortDirection.Ascending ? a.Size.CompareTo(b.Size) : b.Size.CompareTo(a.Size);
                            if (xdiff != 0)
                                return xdiff;

                            return 0;
                        });
                        break;
                }

                this.SearchResults.Items.Clear();
                foreach (Beatmap bm in this.RawSearchResultList)
                    this.SearchResults.Items.Add(bm);
            }
        }

        private void SearchTitle_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
                this.PerformBeatmapSearch();
        }

        private void SearchCreator_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                this.PerformBeatmapSearch();
        }

        private void SearchSource_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                this.PerformBeatmapSearch();
        }

        private void SearchTags_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                this.PerformBeatmapSearch();
        }

        private void SearchSizeMin_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                this.PerformBeatmapSearch();
        }

        private void SearchSizeMax_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                this.PerformBeatmapSearch();
        }

        private void SearchVersion_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                this.PerformBeatmapSearch();
        }

        private void MenuItemFullDetails_Click(object sender, RoutedEventArgs e)
        {
            if (this.SearchResults.SelectedItems.Count > 1)
                if (System.Windows.MessageBox.Show("This will open multiple browser tabs, are you sure?", "You sure?", MessageBoxButton.YesNo, MessageBoxImage.Question) != MessageBoxResult.Yes)
                    return;

            foreach(Beatmap map in this.SearchResults.SelectedItems)
                Process.Start("http://osu.ppy.sh/s/" + map.Ranked_ID);
        }

        private void Menu_ApplicationSettings_Click(object sender, RoutedEventArgs e)
        {
            if (this.SettingsWindow == null)
                this.SettingsWindow = new Settings();

            this.SettingsWindow.Show();
        }

        private void Menu_Exit_Click(object sender, RoutedEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void Menu_AboutApp_Click(object sender, RoutedEventArgs e)
        {
            if (this.AboutWindow == null)
                this.AboutWindow = new About();

            this.AboutWindow.Show();
        }

        private void Menu_OsuThread_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://osu.ppy.sh/forum/t/137156");
        }

        private void Menu_GithubRepo_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://github.com/Mizore/osu-mirror");
        }

        private void Menu_APIDoc_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(Configuration.ApiLocation);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.SearchTitle.Focus();
        }

        private void MenuItemDownloadLink_Click(object sender, RoutedEventArgs e)
        {
            if (this.SearchResults.SelectedItems.Count != 1)
                return;

            Beatmap map = (Beatmap)this.SearchResults.SelectedItems[0];

            this.ShortURLOverlay.BeginAnimation(Grid.OpacityProperty, new DoubleAnimation()
            {
                Duration = new Duration(new TimeSpan(0, 0, 0, 0, 500)),
                FillBehavior = FillBehavior.HoldEnd,
                From = 0.0,
                To = 1.0
            });
            this.ShortURLOverlay.Visibility = Visibility.Visible;


            ThreadPool.QueueUserWorkItem(new WaitCallback((object ob) =>
            {
                string url = string.Format("{0}beatmaps/{1}/download/{2}.{3}", Configuration.ApiLocation, map.Ranked_ID, Uri.EscapeUriString(Helpers.CleanFileName(map.Name)), map.Type.ToString().ToLower());
                string urlshort = UrlShort.Short(url);

                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                {
                    System.Windows.Clipboard.SetText(urlshort);

                    DoubleAnimation anim = new DoubleAnimation()
                    {
                        Duration = new Duration(new TimeSpan(0, 0, 0, 0, 500)),
                        FillBehavior = FillBehavior.HoldEnd,
                        From = 1.0,
                        To = 0.0
                    };

                    anim.Completed += (object ssender, EventArgs ee) =>
                    {
                        this.ShortURLOverlay.Visibility = Visibility.Hidden;
                    };

                    this.ShortURLOverlay.BeginAnimation(Grid.OpacityProperty, anim);
                }));
            }));
        }
    }
}
