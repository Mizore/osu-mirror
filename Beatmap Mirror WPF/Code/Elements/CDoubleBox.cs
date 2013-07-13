using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Beatmap_Mirror_WPF.Code.Elements
{
    public class CDoubleBox : TextBox
    {
        static CDoubleBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(CDoubleBox),
                new FrameworkPropertyMetadata(typeof(CDoubleBox)));
        }

        public double Value { get; set; }

        public CDoubleBox()
        {
            this.DataContext = this;
            this.Text = string.Empty;
            this.IsTabStop = false;

            Regex numberOnlyRegex = new Regex(@"^[0-9]+\.?([0-9]+)?$");

            this.PreviewTextInput += (object sender, TextCompositionEventArgs e) =>
            {
                if (!numberOnlyRegex.IsMatch((e.OriginalSource as TextBox).Text + e.Text))
                    e.Handled = true;
            };

            this.GotFocus += (object sender, RoutedEventArgs e) =>
            {
                base.Text = base.Text.Replace(",", "");
            };

            this.TextChanged += (object sender, TextChangedEventArgs e) =>
            {
                try { this.Value = double.Parse((e.OriginalSource as TextBox).Text); }
                catch { this.Value = 0; }
            };

            this.LostFocus += (object sender, RoutedEventArgs e) =>
            {
                try { this.Value = double.Parse(base.Text); }
                catch { this.Value = 0; }

                base.Text = string.Format("{0:#,##0}", this.Value);
            };
        }
    }
}
