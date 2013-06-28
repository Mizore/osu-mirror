
namespace Beatmap_Mirror.Forms
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.ctlModernBlack1 = new jSkin.ctlModernBlack();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cDetailView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bSearch = new System.Windows.Forms.Button();
            this.tTags = new System.Windows.Forms.TextBox();
            this.tSource = new System.Windows.Forms.TextBox();
            this.tCreator = new System.Windows.Forms.TextBox();
            this.tArtist = new System.Windows.Forms.TextBox();
            this.lDifficulty = new System.Windows.Forms.Label();
            this.tDifficulty = new System.Windows.Forms.TextBox();
            this.tTitle = new System.Windows.Forms.TextBox();
            this.tName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lSize = new System.Windows.Forms.Label();
            this.lTags = new System.Windows.Forms.Label();
            this.lSource = new System.Windows.Forms.Label();
            this.lCreator = new System.Windows.Forms.Label();
            this.lArtist = new System.Windows.Forms.Label();
            this.lTitle = new System.Windows.Forms.Label();
            this.lFileName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SearchContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.downloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadMP3sToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctlModernBlack1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SearchContext.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctlModernBlack1
            // 
            this.ctlModernBlack1.Controls.Add(this.panel1);
            this.ctlModernBlack1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlModernBlack1.FixedSingle = false;
            this.ctlModernBlack1.Location = new System.Drawing.Point(0, 0);
            this.ctlModernBlack1.Name = "ctlModernBlack1";
            this.ctlModernBlack1.Padding = new System.Windows.Forms.Padding(10, 32, 10, 10);
            this.ctlModernBlack1.Size = new System.Drawing.Size(745, 712);
            this.ctlModernBlack1.Stretch = false;
            this.ctlModernBlack1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(10, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(725, 670);
            this.panel1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox3);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 210);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(725, 460);
            this.panel3.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cDetailView1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(725, 325);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Search results";
            // 
            // cDetailView1
            // 
            this.cDetailView1.AccessibleRole = System.Windows.Forms.AccessibleRole.List;
            this.cDetailView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cDetailView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.cDetailView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cDetailView1.FullRowSelect = true;
            this.cDetailView1.GridLines = true;
            this.cDetailView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.cDetailView1.Location = new System.Drawing.Point(3, 16);
            this.cDetailView1.Name = "cDetailView1";
            this.cDetailView1.ShowGroups = false;
            this.cDetailView1.Size = new System.Drawing.Size(719, 306);
            this.cDetailView1.TabIndex = 0;
            this.cDetailView1.Text = "cDetailView1";
            this.cDetailView1.UseCompatibleStateImageBehavior = false;
            this.cDetailView1.View = System.Windows.Forms.View.Details;
            this.cDetailView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cDetailView1_MouseClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Ranked ID";
            this.columnHeader1.Width = 81;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Title";
            this.columnHeader2.Width = 473;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Size";
            this.columnHeader3.Width = 87;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.groupBox2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 325);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(725, 135);
            this.panel4.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(725, 135);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Active downloads";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(725, 210);
            this.panel2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bSearch);
            this.groupBox1.Controls.Add(this.tTags);
            this.groupBox1.Controls.Add(this.tSource);
            this.groupBox1.Controls.Add(this.tCreator);
            this.groupBox1.Controls.Add(this.tArtist);
            this.groupBox1.Controls.Add(this.lDifficulty);
            this.groupBox1.Controls.Add(this.tDifficulty);
            this.groupBox1.Controls.Add(this.tTitle);
            this.groupBox1.Controls.Add(this.tName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lSize);
            this.groupBox1.Controls.Add(this.lTags);
            this.groupBox1.Controls.Add(this.lSource);
            this.groupBox1.Controls.Add(this.lCreator);
            this.groupBox1.Controls.Add(this.lArtist);
            this.groupBox1.Controls.Add(this.lTitle);
            this.groupBox1.Controls.Add(this.lFileName);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(725, 210);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Beatmap search";
            // 
            // bSearch
            // 
            this.bSearch.Location = new System.Drawing.Point(644, 181);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(75, 23);
            this.bSearch.TabIndex = 31;
            this.bSearch.Text = "Search...";
            this.bSearch.UseVisualStyleBackColor = true;
            // 
            // tTags
            // 
            this.tTags.Location = new System.Drawing.Point(74, 179);
            this.tTags.Name = "tTags";
            this.tTags.Size = new System.Drawing.Size(212, 20);
            this.tTags.TabIndex = 30;
            // 
            // tSource
            // 
            this.tSource.Location = new System.Drawing.Point(74, 153);
            this.tSource.Name = "tSource";
            this.tSource.Size = new System.Drawing.Size(212, 20);
            this.tSource.TabIndex = 29;
            // 
            // tCreator
            // 
            this.tCreator.Location = new System.Drawing.Point(74, 127);
            this.tCreator.Name = "tCreator";
            this.tCreator.Size = new System.Drawing.Size(212, 20);
            this.tCreator.TabIndex = 28;
            // 
            // tArtist
            // 
            this.tArtist.Location = new System.Drawing.Point(74, 101);
            this.tArtist.Name = "tArtist";
            this.tArtist.Size = new System.Drawing.Size(212, 20);
            this.tArtist.TabIndex = 27;
            // 
            // lDifficulty
            // 
            this.lDifficulty.AutoSize = true;
            this.lDifficulty.Location = new System.Drawing.Point(16, 78);
            this.lDifficulty.Name = "lDifficulty";
            this.lDifficulty.Size = new System.Drawing.Size(47, 13);
            this.lDifficulty.TabIndex = 26;
            this.lDifficulty.Text = "Difficulty";
            // 
            // tDifficulty
            // 
            this.tDifficulty.Location = new System.Drawing.Point(74, 75);
            this.tDifficulty.Name = "tDifficulty";
            this.tDifficulty.Size = new System.Drawing.Size(212, 20);
            this.tDifficulty.TabIndex = 25;
            // 
            // tTitle
            // 
            this.tTitle.Location = new System.Drawing.Point(74, 49);
            this.tTitle.Name = "tTitle";
            this.tTitle.Size = new System.Drawing.Size(212, 20);
            this.tTitle.TabIndex = 24;
            // 
            // tName
            // 
            this.tName.Location = new System.Drawing.Point(74, 23);
            this.tName.Name = "tName";
            this.tName.Size = new System.Drawing.Size(212, 20);
            this.tName.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(565, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "kilobytes";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(465, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "to";
            // 
            // lSize
            // 
            this.lSize.AutoSize = true;
            this.lSize.Location = new System.Drawing.Point(331, 26);
            this.lSize.Name = "lSize";
            this.lSize.Size = new System.Drawing.Size(50, 13);
            this.lSize.TabIndex = 12;
            this.lSize.Text = "Size from";
            // 
            // lTags
            // 
            this.lTags.AutoSize = true;
            this.lTags.Location = new System.Drawing.Point(16, 182);
            this.lTags.Name = "lTags";
            this.lTags.Size = new System.Drawing.Size(31, 13);
            this.lTags.TabIndex = 9;
            this.lTags.Text = "Tags";
            // 
            // lSource
            // 
            this.lSource.AutoSize = true;
            this.lSource.Location = new System.Drawing.Point(16, 156);
            this.lSource.Name = "lSource";
            this.lSource.Size = new System.Drawing.Size(41, 13);
            this.lSource.TabIndex = 8;
            this.lSource.Text = "Source";
            // 
            // lCreator
            // 
            this.lCreator.AutoSize = true;
            this.lCreator.Location = new System.Drawing.Point(16, 130);
            this.lCreator.Name = "lCreator";
            this.lCreator.Size = new System.Drawing.Size(41, 13);
            this.lCreator.TabIndex = 5;
            this.lCreator.Text = "Creator";
            // 
            // lArtist
            // 
            this.lArtist.AutoSize = true;
            this.lArtist.Location = new System.Drawing.Point(16, 104);
            this.lArtist.Name = "lArtist";
            this.lArtist.Size = new System.Drawing.Size(30, 13);
            this.lArtist.TabIndex = 4;
            this.lArtist.Text = "Artist";
            // 
            // lTitle
            // 
            this.lTitle.AutoSize = true;
            this.lTitle.Location = new System.Drawing.Point(16, 52);
            this.lTitle.Name = "lTitle";
            this.lTitle.Size = new System.Drawing.Size(27, 13);
            this.lTitle.TabIndex = 2;
            this.lTitle.Text = "Title";
            // 
            // lFileName
            // 
            this.lFileName.AutoSize = true;
            this.lFileName.Location = new System.Drawing.Point(16, 26);
            this.lFileName.Name = "lFileName";
            this.lFileName.Size = new System.Drawing.Size(52, 13);
            this.lFileName.TabIndex = 0;
            this.lFileName.Text = "File name";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 0;
            // 
            // SearchContext
            // 
            this.SearchContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewDetailsToolStripMenuItem,
            this.toolStripSeparator1,
            this.downloadToolStripMenuItem,
            this.downloadMP3sToolStripMenuItem});
            this.SearchContext.Name = "SearchContext";
            this.SearchContext.Size = new System.Drawing.Size(184, 76);
            // 
            // viewDetailsToolStripMenuItem
            // 
            this.viewDetailsToolStripMenuItem.Name = "viewDetailsToolStripMenuItem";
            this.viewDetailsToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.viewDetailsToolStripMenuItem.Text = "View details";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(180, 6);
            // 
            // downloadToolStripMenuItem
            // 
            this.downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
            this.downloadToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.downloadToolStripMenuItem.Text = "Download beatmaps";
            // 
            // downloadMP3sToolStripMenuItem
            // 
            this.downloadMP3sToolStripMenuItem.Name = "downloadMP3sToolStripMenuItem";
            this.downloadMP3sToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.downloadMP3sToolStripMenuItem.Text = "Download MP3s";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 712);
            this.Controls.Add(this.ctlModernBlack1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ctlModernBlack1.ResumeLayout(false);
            this.ctlModernBlack1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.SearchContext.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private jSkin.ctlModernBlack ctlModernBlack1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lTags;
        private System.Windows.Forms.Label lSource;
        private System.Windows.Forms.Label lCreator;
        private System.Windows.Forms.Label lArtist;
        private System.Windows.Forms.Label lTitle;
        private System.Windows.Forms.Label lFileName;
        private System.Windows.Forms.Label lSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView cDetailView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ContextMenuStrip SearchContext;
        private System.Windows.Forms.ToolStripMenuItem viewDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem downloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadMP3sToolStripMenuItem;
        private System.Windows.Forms.TextBox tDifficulty;
        private System.Windows.Forms.TextBox tTitle;
        private System.Windows.Forms.TextBox tName;
        private System.Windows.Forms.TextBox tTags;
        private System.Windows.Forms.TextBox tSource;
        private System.Windows.Forms.TextBox tCreator;
        private System.Windows.Forms.TextBox tArtist;
        private System.Windows.Forms.Label lDifficulty;
        private System.Windows.Forms.Button bSearch;

    }
}