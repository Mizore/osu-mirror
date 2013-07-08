using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Beatmap_Mirror_WPF.Code.Elements
{
    public class CNumBox : TextBox
    {
        static CNumBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(CNumBox),
                new FrameworkPropertyMetadata(typeof(CNumBox)));
        }

        public int Value { get; set; }

        public CNumBox()
        {
            this.DataContext = this;
            this.Text = string.Empty;
            this.IsTabStop = false;

            Regex numberOnlyRegex = new Regex("^[0-9]+$");

            this.PreviewTextInput += (object sender, TextCompositionEventArgs e) =>
            {
                if (!numberOnlyRegex.IsMatch(e.Text))
                    e.Handled = true;
            };

            this.GotFocus += (object sender, RoutedEventArgs e) =>
            {
                base.Text = base.Text.Replace(",", "");
            };

            this.TextChanged += (object sender, TextChangedEventArgs e) =>
            {
                try { this.Value = int.Parse((e.OriginalSource as TextBox).Text); }
                catch { this.Value = 0; }
            };

            this.LostFocus += (object sender, RoutedEventArgs e) =>
            {
                try { this.Value = int.Parse(base.Text); }
                catch { this.Value = 0; }

                base.Text = string.Format("{0:#,##0}", this.Value);
            };
        }
    }
}
