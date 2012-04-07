namespace RetroMan.UI
{
    partial class SettingsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.OkBtn = new System.Windows.Forms.Button();
            this.SevenZipPathText = new System.Windows.Forms.TextBox();
            this.SevenZipBrowseBtn = new System.Windows.Forms.Button();
            this.DataFilesListBox = new System.Windows.Forms.ListBox();
            this.RomFoldersListBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "7-Zip Path";
            // 
            // CancelBtn
            // 
            this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(601, 351);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 4;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // OkBtn
            // 
            this.OkBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkBtn.Location = new System.Drawing.Point(520, 351);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(75, 23);
            this.OkBtn.TabIndex = 3;
            this.OkBtn.Text = "Ok";
            this.OkBtn.UseVisualStyleBackColor = true;
            // 
            // SevenZipPathText
            // 
            this.SevenZipPathText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SevenZipPathText.Location = new System.Drawing.Point(84, 14);
            this.SevenZipPathText.Name = "SevenZipPathText";
            this.SevenZipPathText.Size = new System.Drawing.Size(511, 20);
            this.SevenZipPathText.TabIndex = 1;
            // 
            // SevenZipBrowseBtn
            // 
            this.SevenZipBrowseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SevenZipBrowseBtn.Location = new System.Drawing.Point(601, 12);
            this.SevenZipBrowseBtn.Name = "SevenZipBrowseBtn";
            this.SevenZipBrowseBtn.Size = new System.Drawing.Size(75, 23);
            this.SevenZipBrowseBtn.TabIndex = 2;
            this.SevenZipBrowseBtn.Text = "Browse";
            this.SevenZipBrowseBtn.UseVisualStyleBackColor = true;
            this.SevenZipBrowseBtn.Click += new System.EventHandler(this.SevenZipBrowseBtn_Click);
            // 
            // DataFilesListBox
            // 
            this.DataFilesListBox.AllowDrop = true;
            this.tableLayoutPanel1.SetColumnSpan(this.DataFilesListBox, 2);
            this.DataFilesListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataFilesListBox.FormattingEnabled = true;
            this.DataFilesListBox.Location = new System.Drawing.Point(75, 156);
            this.DataFilesListBox.Name = "DataFilesListBox";
            this.DataFilesListBox.Size = new System.Drawing.Size(589, 148);
            this.DataFilesListBox.TabIndex = 5;
            this.DataFilesListBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.DataFilesListBox_DragDrop);
            this.DataFilesListBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.DataFilesListBox_DragEnter);
            this.DataFilesListBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DataFilesListBox_KeyUp);
            // 
            // RomFoldersListBox
            // 
            this.RomFoldersListBox.AllowDrop = true;
            this.tableLayoutPanel1.SetColumnSpan(this.RomFoldersListBox, 2);
            this.RomFoldersListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RomFoldersListBox.FormattingEnabled = true;
            this.RomFoldersListBox.Location = new System.Drawing.Point(75, 3);
            this.RomFoldersListBox.Name = "RomFoldersListBox";
            this.RomFoldersListBox.Size = new System.Drawing.Size(589, 147);
            this.RomFoldersListBox.TabIndex = 6;
            this.RomFoldersListBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.RomFoldersListBox_DragDrop);
            this.RomFoldersListBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.RomFoldersListBox_DragEnter);
            this.RomFoldersListBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.RomFoldersListBox_KeyUp);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Rom Folders";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.DataFilesListBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.RomFoldersListBox, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 41);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(667, 307);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 223);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Data Files";
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.OkBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(688, 386);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.SevenZipBrowseBtn);
            this.Controls.Add(this.OkBtn);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SevenZipPathText);
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SettingsForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button OkBtn;
        private System.Windows.Forms.TextBox SevenZipPathText;
        private System.Windows.Forms.Button SevenZipBrowseBtn;
        private System.Windows.Forms.ListBox DataFilesListBox;
        private System.Windows.Forms.ListBox RomFoldersListBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}