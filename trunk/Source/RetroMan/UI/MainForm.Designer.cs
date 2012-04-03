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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainerEx1 = new RomWorks.Controls.SplitContainerEx();
            this.treeListView1 = new BrightIdeasSoftware.TreeListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.objectListView1 = new BrightIdeasSoftware.ObjectListView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerEx1)).BeginInit();
            this.splitContainerEx1.Panel1.SuspendLayout();
            this.splitContainerEx1.Panel2.SuspendLayout();
            this.splitContainerEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(692, 24);
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
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 448);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(692, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.settingsToolStripMenuItem.Text = "&Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
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
            this.splitContainerEx1.Location = new System.Drawing.Point(0, 24);
            this.splitContainerEx1.Name = "splitContainerEx1";
            // 
            // splitContainerEx1.Panel1
            // 
            this.splitContainerEx1.Panel1.Controls.Add(this.treeListView1);
            this.splitContainerEx1.Panel1MaxSize = 0;
            // 
            // splitContainerEx1.Panel2
            // 
            this.splitContainerEx1.Panel2.Controls.Add(this.objectListView1);
            this.splitContainerEx1.Panel2MaxSize = 0;
            this.splitContainerEx1.Size = new System.Drawing.Size(692, 424);
            this.splitContainerEx1.SplitterDistance = 304;
            this.splitContainerEx1.SplitterWidth = 20;
            this.splitContainerEx1.TabIndex = 3;
            this.splitContainerEx1.TopLeftLine = RomWorks.Controls.SplitContainerEx.LineMode.Normal;
            // 
            // treeListView1
            // 
            this.treeListView1.AllColumns.Add(this.olvColumn1);
            this.treeListView1.CheckBoxes = false;
            this.treeListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1});
            this.treeListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListView1.Location = new System.Drawing.Point(0, 0);
            this.treeListView1.Name = "treeListView1";
            this.treeListView1.OwnerDraw = true;
            this.treeListView1.ShowGroups = false;
            this.treeListView1.Size = new System.Drawing.Size(304, 424);
            this.treeListView1.TabIndex = 2;
            this.treeListView1.UseCompatibleStateImageBehavior = false;
            this.treeListView1.View = System.Windows.Forms.View.Details;
            this.treeListView1.VirtualMode = true;
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "Label";
            this.olvColumn1.FillsFreeSpace = true;
            this.olvColumn1.Text = "Label";
            this.olvColumn1.Width = 150;
            // 
            // objectListView1
            // 
            this.objectListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectListView1.Location = new System.Drawing.Point(0, 0);
            this.objectListView1.Name = "objectListView1";
            this.objectListView1.Size = new System.Drawing.Size(368, 424);
            this.objectListView1.TabIndex = 1;
            this.objectListView1.UseCompatibleStateImageBehavior = false;
            this.objectListView1.View = System.Windows.Forms.View.Details;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 470);
            this.Controls.Add(this.splitContainerEx1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "RetroMan";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainerEx1.Panel1.ResumeLayout(false);
            this.splitContainerEx1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerEx1)).EndInit();
            this.splitContainerEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private BrightIdeasSoftware.ObjectListView objectListView1;
        private BrightIdeasSoftware.TreeListView treeListView1;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private RomWorks.Controls.SplitContainerEx splitContainerEx1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
    }
}

