using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Beatmap_Mirror.Code.Elements
{
    public class CDetailView : ListView
    {
        public ColumnHeaderCollection Columns { get; set; }

        public CDetailView()
            : base()
        {
            this.View = View.Details;
            this.LabelEdit = false;
            this.AllowColumnReorder = false;
            this.CheckBoxes = false;
            this.FullRowSelect = true;
            this.GridLines = true;
            this.BorderStyle = BorderStyle.None;
            this.HeaderStyle = ColumnHeaderStyle.Clickable;

            //this

            this.Paint += (object sender, PaintEventArgs e) =>
            {
            };

            this.Columns = new ColumnHeaderCollection(this);
        }
    }
}
