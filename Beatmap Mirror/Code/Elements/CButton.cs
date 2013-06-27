using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Beatmap_Mirror.Code.Elements
{
    public class CButton : Control
    {
        private Button _Button = new Button();
        private Color BorderColor = Color.Silver;

        public CButton()
            : base()
        {
            this._Button.FlatStyle = FlatStyle.Flat;
            this._Button.TabStop = false;
            this._Button.FlatAppearance.BorderSize = 0;
            this._Button.FlatAppearance.MouseOverBackColor = Color.Transparent;

            this.TextChanged += (object sender, EventArgs e) =>
            {
                this._Button.Text = this.Text;
            };

            this.Paint += (object sender, PaintEventArgs e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, this.BorderColor, ButtonBorderStyle.Solid);
            };

            this.Resize += (object sender, EventArgs e) =>
            {
                this.UpdateSize();
            };

            this._Button.MouseEnter += (object sender, EventArgs e) =>
            {
                this.BorderColor = Color.Orange;
                this.Invalidate();
            };

            this._Button.MouseLeave += (object sender, EventArgs e) =>
            {
                this.BorderColor = Color.Silver;
                this.Invalidate();
            };

            this._Button.Click += (object sender, EventArgs e) =>
            {
                base.OnClick(e);
            };

            this.Controls.Add(this._Button);
            this.UpdateSize();
        }

        private void UpdateSize()
        {
            this._Button.Location = new Point(1, 1);
            this._Button.Size = this.Size - new Size(2, 2);
        }
    }
}
