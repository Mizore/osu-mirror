using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Beatmap_Mirror.Code.Elements
{
    public class CNumberBox : CTextBox
    {
        public int Value { get; private set; }

        public CNumberBox() :
            base()
        {
            this._TextBox.Text = "0";
            this._TextBox.KeyPress += (object sender, KeyPressEventArgs e) =>
            {
                switch (e.KeyChar)
                {
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        /* All good :p, it was a number */
                        break;

                    default:
                        e.Handled = true;
                        break;
                }
            };

            this._TextBox.GotFocus += (object sender, EventArgs e) =>
            {
                this._TextBox.Text = this._TextBox.Text.Replace(",", "");
            };

            this._TextBox.LostFocus += (object sender, EventArgs e) =>
            {
                try
                {
                    this.Value = int.Parse(this._TextBox.Text);
                }
                catch
                {
                    this.Value = 0;
                }
                this._TextBox.Text = string.Format("{0:#,##0}", this.Value);
            };
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // _TextBox
            // 
            this._TextBox.Location = new System.Drawing.Point(4, 2);
            this._TextBox.Size = new System.Drawing.Size(154, 13);
            // 
            // CNumberBox
            // 
            this.Name = "CNumberBox";
            this.Size = new System.Drawing.Size(160, 18);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
