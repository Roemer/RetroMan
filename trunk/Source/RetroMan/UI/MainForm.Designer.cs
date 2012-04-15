namespace RetroMan.UI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.DeviceCtx = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.setRomPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainerEx2 = new RomWorks.Controls.SplitContainerEx();
            this.splitContainerEx1 = new RomWorks.Controls.SplitContainerEx();
            this.OverviewList = new BrightIdeasSoftware.TreeListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.AddDataFileBtn = new System.Windows.Forms.ToolStripButton();
            this.DetailList = new BrightIdeasSoftware.ObjectListView();
            this.LogList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1.SuspendLayout();
            this.DeviceCtx.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerEx2)).BeginInit();
            this.splitContainerEx2.Panel1.SuspendLayout();
            this.splitContainerEx2.Panel2.SuspendLayout();
            this.splitContainerEx2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerEx1)).BeginInit();
            this.splitContainerEx1.Panel1.SuspendLayout();
            this.splitContainerEx1.Panel2.SuspendLayout();
            this.splitContainerEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OverviewList)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DetailList)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(923, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.settingsToolStripMenuItem.Text = "&Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(113, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // generateToolStripMenuItem
            // 
            this.generateToolStripMenuItem.Name = "generateToolStripMenuItem";
            this.generateToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.generateToolStripMenuItem.Text = "Generate";
            this.generateToolStripMenuItem.Click += new System.EventHandler(this.generateToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 517);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(923, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // DeviceCtx
            // 
            this.DeviceCtx.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setRomPathToolStripMenuItem,
            this.removeToolStripMenuItem,
            this.checkToolStripMenuItem});
            this.DeviceCtx.Name = "DeviceCtx";
            this.DeviceCtx.Size = new System.Drawing.Size(146, 70);
            // 
            // setRomPathToolStripMenuItem
            // 
            this.setRomPathToolStripMenuItem.Name = "setRomPathToolStripMenuItem";
            this.setRomPathToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.setRomPathToolStripMenuItem.Text = "Set &Rom Path";
            this.setRomPathToolStripMenuItem.Click += new System.EventHandler(this.setRomPathToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.removeToolStripMenuItem.Text = "&Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // checkToolStripMenuItem
            // 
            this.checkToolStripMenuItem.Name = "checkToolStripMenuItem";
            this.checkToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.checkToolStripMenuItem.Text = "&Check Roms";
            this.checkToolStripMenuItem.Click += new System.EventHandler(this.checkToolStripMenuItem_Click);
            // 
            // splitContainerEx2
            // 
            this.splitContainerEx2.AlternativeCollapseDefault = false;
            this.splitContainerEx2.AlternativeCollapsePanel = RomWorks.Controls.SplitContainerEx.Panels.None;
            this.splitContainerEx2.BottomRightLine = RomWorks.Controls.SplitContainerEx.LineMode.Normal;
            this.splitContainerEx2.CenterLine = RomWorks.Controls.SplitContainerEx.LineMode.Hidden;
            this.splitContainerEx2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerEx2.DragLineOffset = 0;
            this.splitContainerEx2.DragLines = RomWorks.Controls.SplitContainerEx.LineMode.Normal;
            this.splitContainerEx2.DragLineWidth = 40;
            this.splitContainerEx2.Location = new System.Drawing.Point(0, 24);
            this.splitContainerEx2.Name = "splitContainerEx2";
            this.splitContainerEx2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerEx2.Panel1
            // 
            this.splitContainerEx2.Panel1.Controls.Add(this.splitContainerEx1);
            this.splitContainerEx2.Panel1MaxSize = 0;
            // 
            // splitContainerEx2.Panel2
            // 
            this.splitContainerEx2.Panel2.Controls.Add(this.LogList);
            this.splitContainerEx2.Panel2MaxSize = 0;
            this.splitContainerEx2.Size = new System.Drawing.Size(923, 493);
            this.splitContainerEx2.SplitterDistance = 286;
            this.splitContainerEx2.SplitterWidth = 20;
            this.splitContainerEx2.TabIndex = 5;
            this.splitContainerEx2.TopLeftLine = RomWorks.Controls.SplitContainerEx.LineMode.Normal;
            // 
            // splitContainerEx1
            // 
            this.splitContainerEx1.AlternativeCollapseDefault = false;
            this.splitContainerEx1.AlternativeCollapsePanel = RomWorks.Controls.SplitContainerEx.Panels.None;
            this.splitContainerEx1.BottomRightLine = RomWorks.Controls.SplitContainerEx.LineMode.Normal;
            this.splitContainerEx1.CenterLine = RomWorks.Controls.SplitContainerEx.LineMode.Hidden;
            this.splitContainerEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerEx1.DragLineOffset = 0;
            this.splitContainerEx1.DragLines = RomWorks.Controls.SplitContainerEx.LineMode.Normal;
            this.splitContainerEx1.DragLineWidth = 40;
            this.splitContainerEx1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerEx1.Name = "splitContainerEx1";
            // 
            // splitContainerEx1.Panel1
            // 
            this.splitContainerEx1.Panel1.Controls.Add(this.OverviewList);
            this.splitContainerEx1.Panel1.Controls.Add(this.toolStrip1);
            this.splitContainerEx1.Panel1MaxSize = 0;
            // 
            // splitContainerEx1.Panel2
            // 
            this.splitContainerEx1.Panel2.Controls.Add(this.DetailList);
            this.splitContainerEx1.Panel2MaxSize = 0;
            this.splitContainerEx1.Size = new System.Drawing.Size(923, 286);
            this.splitContainerEx1.SplitterDistance = 450;
            this.splitContainerEx1.SplitterWidth = 20;
            this.splitContainerEx1.TabIndex = 3;
            this.splitContainerEx1.TopLeftLine = RomWorks.Controls.SplitContainerEx.LineMode.Normal;
            // 
            // OverviewList
            // 
            this.OverviewList.AllColumns.Add(this.olvColumn1);
            this.OverviewList.AllColumns.Add(this.olvColumn2);
            this.OverviewList.CheckBoxes = false;
            this.OverviewList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.olvColumn2});
            this.OverviewList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OverviewList.Location = new System.Drawing.Point(0, 25);
            this.OverviewList.Name = "OverviewList";
            this.OverviewList.OwnerDraw = true;
            this.OverviewList.ShowGroups = false;
            this.OverviewList.Size = new System.Drawing.Size(450, 261);
            this.OverviewList.TabIndex = 2;
            this.OverviewList.UseCompatibleStateImageBehavior = false;
            this.OverviewList.View = System.Windows.Forms.View.Details;
            this.OverviewList.VirtualMode = true;
            this.OverviewList.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.treeListView1_FormatRow);
            this.OverviewList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeListView1_MouseClick);
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "Name";
            this.olvColumn1.FillsFreeSpace = true;
            this.olvColumn1.Text = "Name";
            this.olvColumn1.Width = 150;
            // 
            // olvColumn2
            // 
            this.olvColumn2.Text = "Status";
            this.olvColumn2.Width = 91;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddDataFileBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(450, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // AddDataFileBtn
            // 
            this.AddDataFileBtn.Image = ((System.Drawing.Image)(resources.GetObject("AddDataFileBtn.Image")));
            this.AddDataFileBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddDataFileBtn.Name = "AddDataFileBtn";
            this.AddDataFileBtn.Size = new System.Drawing.Size(94, 22);
            this.AddDataFileBtn.Text = "Add DataFile";
            this.AddDataFileBtn.Click += new System.EventHandler(this.AddDataFileBtn_Click);
            // 
            // DetailList
            // 
            this.DetailList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DetailList.Location = new System.Drawing.Point(0, 0);
            this.DetailList.Name = "DetailList";
            this.DetailList.Size = new System.Drawing.Size(453, 286);
            this.DetailList.TabIndex = 1;
            this.DetailList.UseCompatibleStateImageBehavior = false;
            this.DetailList.View = System.Windows.Forms.View.Details;
            // 
            // LogList
            // 
            this.LogList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader2});
            this.LogList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogList.Location = new System.Drawing.Point(0, 0);
            this.LogList.Name = "LogList";
            this.LogList.Size = new System.Drawing.Size(923, 187);
            this.LogList.TabIndex = 0;
            this.LogList.UseCompatibleStateImageBehavior = false;
            this.LogList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Time";
            this.columnHeader1.Width = 127;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Type";
            this.columnHeader3.Width = 93;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Message";
            this.columnHeader2.Width = 320;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 539);
            this.Controls.Add(this.splitContainerEx2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "RetroMan";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.DeviceCtx.ResumeLayout(false);
            this.splitContainerEx2.Panel1.ResumeLayout(false);
            this.splitContainerEx2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerEx2)).EndInit();
            this.splitContainerEx2.ResumeLayout(false);
            this.splitContainerEx1.Panel1.ResumeLayout(false);
            this.splitContainerEx1.Panel1.PerformLayout();
            this.splitContainerEx1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerEx1)).EndInit();
            this.splitContainerEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OverviewList)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DetailList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private BrightIdeasSoftware.ObjectListView DetailList;
        private BrightIdeasSoftware.TreeListView OverviewList;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private RomWorks.Controls.SplitContainerEx splitContainerEx1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton AddDataFileBtn;
        private System.Windows.Forms.ContextMenuStrip DeviceCtx;
        private System.Windows.Forms.ToolStripMenuItem setRomPathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private RomWorks.Controls.SplitContainerEx splitContainerEx2;
        private System.Windows.Forms.ListView LogList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}

