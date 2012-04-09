namespace RetroMan.UI
{
    partial class GenerateForm
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
            this.CloseBtn = new System.Windows.Forms.Button();
            this.OutputText = new System.Windows.Forms.TextBox();
            this.AddBtn = new System.Windows.Forms.Button();
            this.DropFilesLabel = new System.Windows.Forms.Label();
            this.SortDataFileBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CloseBtn
            // 
            this.CloseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseBtn.Location = new System.Drawing.Point(579, 405);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(75, 23);
            this.CloseBtn.TabIndex = 0;
            this.CloseBtn.Text = "Close";
            this.CloseBtn.UseVisualStyleBackColor = true;
            // 
            // OutputText
            // 
            this.OutputText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputText.Location = new System.Drawing.Point(12, 12);
            this.OutputText.Multiline = true;
            this.OutputText.Name = "OutputText";
            this.OutputText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.OutputText.Size = new System.Drawing.Size(642, 386);
            this.OutputText.TabIndex = 1;
            // 
            // AddBtn
            // 
            this.AddBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddBtn.Location = new System.Drawing.Point(12, 405);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(75, 23);
            this.AddBtn.TabIndex = 2;
            this.AddBtn.Text = "Add";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // DropFilesLabel
            // 
            this.DropFilesLabel.AllowDrop = true;
            this.DropFilesLabel.AutoSize = true;
            this.DropFilesLabel.Location = new System.Drawing.Point(93, 410);
            this.DropFilesLabel.Name = "DropFilesLabel";
            this.DropFilesLabel.Size = new System.Drawing.Size(68, 13);
            this.DropFilesLabel.TabIndex = 3;
            this.DropFilesLabel.Text = "or Drop Here";
            this.DropFilesLabel.DragDrop += new System.Windows.Forms.DragEventHandler(this.DropFilesLabel_DragDrop);
            this.DropFilesLabel.DragEnter += new System.Windows.Forms.DragEventHandler(this.DropFilesLabel_DragEnter);
            this.DropFilesLabel.DragLeave += new System.EventHandler(this.DropFilesLabel_DragLeave);
            // 
            // SortDataFileBtn
            // 
            this.SortDataFileBtn.Location = new System.Drawing.Point(193, 405);
            this.SortDataFileBtn.Name = "SortDataFileBtn";
            this.SortDataFileBtn.Size = new System.Drawing.Size(90, 23);
            this.SortDataFileBtn.TabIndex = 4;
            this.SortDataFileBtn.Text = "Sort Data File";
            this.SortDataFileBtn.UseVisualStyleBackColor = true;
            this.SortDataFileBtn.Click += new System.EventHandler(this.SortDataFileBtn_Click);
            // 
            // GenerateForm
            // 
            this.AcceptButton = this.CloseBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseBtn;
            this.ClientSize = new System.Drawing.Size(666, 440);
            this.Controls.Add(this.SortDataFileBtn);
            this.Controls.Add(this.DropFilesLabel);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.OutputText);
            this.Controls.Add(this.CloseBtn);
            this.Name = "GenerateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GenerateForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.TextBox OutputText;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Label DropFilesLabel;
        private System.Windows.Forms.Button SortDataFileBtn;
    }
}