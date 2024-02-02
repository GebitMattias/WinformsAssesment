namespace IOLib
{
    partial class frmMain
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
            lblFolder = new System.Windows.Forms.Label();
            tbFolder = new System.Windows.Forms.TextBox();
            btnSelectFolder = new System.Windows.Forms.Button();
            btnStartIOWorker = new System.Windows.Forms.Button();
            btnCancelIOWorker = new System.Windows.Forms.Button();
            tbResult = new System.Windows.Forms.TextBox();
            lblResult = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            tbStatus = new System.Windows.Forms.TextBox();
            SuspendLayout();
            // 
            // lblFolder
            // 
            lblFolder.AutoSize = true;
            lblFolder.Location = new System.Drawing.Point(12, 9);
            lblFolder.Name = "lblFolder";
            lblFolder.Size = new System.Drawing.Size(40, 15);
            lblFolder.TabIndex = 0;
            lblFolder.Text = "Folder";
            // 
            // tbFolder
            // 
            tbFolder.Location = new System.Drawing.Point(58, 6);
            tbFolder.Name = "tbFolder";
            tbFolder.ReadOnly = true;
            tbFolder.Size = new System.Drawing.Size(282, 23);
            tbFolder.TabIndex = 1;
            // 
            // btnSelectFolder
            // 
            btnSelectFolder.Location = new System.Drawing.Point(346, 5);
            btnSelectFolder.Name = "btnSelectFolder";
            btnSelectFolder.Size = new System.Drawing.Size(59, 23);
            btnSelectFolder.TabIndex = 2;
            btnSelectFolder.Text = "Select";
            btnSelectFolder.UseVisualStyleBackColor = true;
            btnSelectFolder.Click += btnSelectFolder_Click;
            // 
            // btnStartIOWorker
            // 
            btnStartIOWorker.Location = new System.Drawing.Point(12, 35);
            btnStartIOWorker.Name = "btnStartIOWorker";
            btnStartIOWorker.Size = new System.Drawing.Size(189, 23);
            btnStartIOWorker.TabIndex = 3;
            btnStartIOWorker.Text = "Start IO Worker";
            btnStartIOWorker.UseVisualStyleBackColor = true;
            btnStartIOWorker.Click += btnStartIOWorker_Click;
            // 
            // btnCancelIOWorker
            // 
            btnCancelIOWorker.Enabled = false;
            btnCancelIOWorker.Location = new System.Drawing.Point(216, 35);
            btnCancelIOWorker.Name = "btnCancelIOWorker";
            btnCancelIOWorker.Size = new System.Drawing.Size(189, 23);
            btnCancelIOWorker.TabIndex = 5;
            btnCancelIOWorker.Text = "Cancel IO Worker";
            btnCancelIOWorker.UseVisualStyleBackColor = true;
            btnCancelIOWorker.Click += btnCancelIOWorker_Click;
            // 
            // tbResult
            // 
            tbResult.Location = new System.Drawing.Point(12, 98);
            tbResult.Multiline = true;
            tbResult.Name = "tbResult";
            tbResult.ReadOnly = true;
            tbResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            tbResult.Size = new System.Drawing.Size(393, 236);
            tbResult.TabIndex = 6;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Location = new System.Drawing.Point(12, 80);
            lblResult.Name = "lblResult";
            lblResult.Size = new System.Drawing.Size(39, 15);
            lblResult.TabIndex = 7;
            lblResult.Text = "Result";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(13, 358);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(39, 15);
            label1.TabIndex = 8;
            label1.Text = "Status";
            // 
            // tbStatus
            // 
            tbStatus.Location = new System.Drawing.Point(12, 376);
            tbStatus.Multiline = true;
            tbStatus.Name = "tbStatus";
            tbStatus.ReadOnly = true;
            tbStatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            tbStatus.Size = new System.Drawing.Size(393, 101);
            tbStatus.TabIndex = 9;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(425, 489);
            Controls.Add(tbStatus);
            Controls.Add(label1);
            Controls.Add(lblResult);
            Controls.Add(tbResult);
            Controls.Add(btnCancelIOWorker);
            Controls.Add(btnStartIOWorker);
            Controls.Add(btnSelectFolder);
            Controls.Add(tbFolder);
            Controls.Add(lblFolder);
            MaximizeBox = false;
            MaximumSize = new System.Drawing.Size(441, 528);
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size(441, 528);
            Name = "frmMain";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Main";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblFolder;
        private System.Windows.Forms.TextBox tbFolder;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.Button btnStartIOWorker;
        private System.Windows.Forms.Button btnCancelIOWorker;
        private System.Windows.Forms.TextBox tbResult;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbStatus;
    }
}