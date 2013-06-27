namespace Beatmap_Mirror.Forms
{
    partial class BeatmapDetails
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ctlModernBlack1 = new jSkin.ctlModernBlack();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BeatmapArtist = new System.Windows.Forms.Label();
            this.BeatmapTitle = new System.Windows.Forms.Label();
            this.cButton1 = new Beatmap_Mirror.Code.Elements.CButton();
            this.BeatmapIcon = new System.Windows.Forms.PictureBox();
            this.ctlModernBlack1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BeatmapIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // ctlModernBlack1
            // 
            this.ctlModernBlack1.Controls.Add(this.panel1);
            this.ctlModernBlack1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlModernBlack1.FixedSingle = false;
            this.ctlModernBlack1.Location = new System.Drawing.Point(0, 0);
            this.ctlModernBlack1.Margin = new System.Windows.Forms.Padding(0);
            this.ctlModernBlack1.Name = "ctlModernBlack1";
            this.ctlModernBlack1.Padding = new System.Windows.Forms.Padding(10, 32, 10, 10);
            this.ctlModernBlack1.Size = new System.Drawing.Size(874, 387);
            this.ctlModernBlack1.Stretch = false;
            this.ctlModernBlack1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.BeatmapArtist);
            this.panel1.Controls.Add(this.BeatmapTitle);
            this.panel1.Controls.Add(this.cButton1);
            this.panel1.Controls.Add(this.BeatmapIcon);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(10, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(854, 345);
            this.panel1.TabIndex = 2;
            // 
            // BeatmapArtist
            // 
            this.BeatmapArtist.AutoSize = true;
            this.BeatmapArtist.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BeatmapArtist.Location = new System.Drawing.Point(15, 63);
            this.BeatmapArtist.Name = "BeatmapArtist";
            this.BeatmapArtist.Size = new System.Drawing.Size(46, 20);
            this.BeatmapArtist.TabIndex = 3;
            this.BeatmapArtist.Text = "Artist";
            // 
            // BeatmapTitle
            // 
            this.BeatmapTitle.AutoSize = true;
            this.BeatmapTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BeatmapTitle.Location = new System.Drawing.Point(13, 13);
            this.BeatmapTitle.Name = "BeatmapTitle";
            this.BeatmapTitle.Size = new System.Drawing.Size(66, 31);
            this.BeatmapTitle.TabIndex = 2;
            this.BeatmapTitle.Text = "Title";
            // 
            // cButton1
            // 
            this.cButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cButton1.Location = new System.Drawing.Point(767, 310);
            this.cButton1.Name = "cButton1";
            this.cButton1.Size = new System.Drawing.Size(75, 23);
            this.cButton1.TabIndex = 1;
            this.cButton1.Text = "cButton1";
            // 
            // BeatmapIcon
            // 
            this.BeatmapIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BeatmapIcon.Location = new System.Drawing.Point(651, 3);
            this.BeatmapIcon.Name = "BeatmapIcon";
            this.BeatmapIcon.Size = new System.Drawing.Size(200, 150);
            this.BeatmapIcon.TabIndex = 0;
            this.BeatmapIcon.TabStop = false;
            // 
            // BeatmapDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 387);
            this.Controls.Add(this.ctlModernBlack1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BeatmapDetails";
            this.Text = "BeatmapDetails";
            this.ctlModernBlack1.ResumeLayout(false);
            this.ctlModernBlack1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BeatmapIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private jSkin.ctlModernBlack ctlModernBlack1;
        private System.Windows.Forms.Panel panel1;
        private Code.Elements.CButton cButton1;
        private System.Windows.Forms.PictureBox BeatmapIcon;
        private System.Windows.Forms.Label BeatmapTitle;
        private System.Windows.Forms.Label BeatmapArtist;
    }
}