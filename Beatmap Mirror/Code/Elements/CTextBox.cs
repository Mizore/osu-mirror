using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Beatmap_Mirror.Code.Elements
{
    public class CTextBox : UserControl
    {
        protected TextBox _TextBox = new TextBox();
        private Color BorderColor = Color.Silver;

        public CTextBox() :
            base()
        {
            this.InitializeComponent();
            this._TextBox.BorderStyle = BorderStyle.None;

            this._TextBox.KeyDown += (object sender, KeyEventArgs e) =>
            {
                if (e.Control && e.KeyCode == Keys.A)
                {
                    this._TextBox.Select(0, this._TextBox.Text.Length);
                    e.SuppressKeyPress = true;
                    e.Handled = true;
                }
                else
                    this.Text = this._TextBox.Text;
            };

            this._TextBox.TextChanged += (object sender, EventArgs e) =>
            {
                this.Text = this._TextBox.Text;
            };

            this._TextBox.GotFocus += (object sender, EventArgs e) =>
            {
                this.BorderColor = Color.Orange;
                this.Invalidate();
            };

            this._TextBox.LostFocus += (object sender, EventArgs e) =>
            {
                this.BorderColor = Color.Silver;
                this.Invalidate();
            };

            this.Paint += (object sender, PaintEventArgs e) => 
            {
                ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, this.BorderColor, ButtonBorderStyle.Solid);
            };

            this.Resize += (object sender, EventArgs e) =>
            {
                this.UpdateSize();
            };

            this.Controls.Add(this._TextBox);
        }

        private void UpdateSize()
        {
            this._TextBox.Location = new Point(4, 2);
            this._TextBox.Size = this.Size - new Size(6, 4);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // CTextBox
            // 
            this.Name = "CTextBox";
            this.Size = new System.Drawing.Size(160, 18);
            this.ResumeLayout(false);

        }
    }
}
