namespace youtube_dl_GUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtUrl = new TextBox();
            btnDownload = new Button();
            chkAudio = new CheckBox();
            cmbExtension = new ComboBox();
            saveDirectory = new FolderBrowserDialog();
            downloadBar = new ProgressBar();
            label1 = new Label();
            txtDebug = new TextBox();
            SuspendLayout();
            // 
            // txtUrl
            // 
            txtUrl.Location = new Point(128, 222);
            txtUrl.Name = "txtUrl";
            txtUrl.PlaceholderText = "URL";
            txtUrl.Size = new Size(346, 25);
            txtUrl.TabIndex = 0;
            txtUrl.TextChanged += txtUrl_TextChanged;
            // 
            // btnDownload
            // 
            btnDownload.Location = new Point(607, 222);
            btnDownload.Name = "btnDownload";
            btnDownload.Size = new Size(75, 25);
            btnDownload.TabIndex = 1;
            btnDownload.Text = "Download";
            btnDownload.UseVisualStyleBackColor = true;
            btnDownload.Click += btnDownload_Click;
            // 
            // chkAudio
            // 
            chkAudio.AutoSize = true;
            chkAudio.Location = new Point(128, 253);
            chkAudio.Name = "chkAudio";
            chkAudio.Size = new Size(91, 21);
            chkAudio.TabIndex = 2;
            chkAudio.Text = "Audio Only";
            chkAudio.UseVisualStyleBackColor = true;
            chkAudio.CheckedChanged += chkAudio_CheckedChanged;
            // 
            // cmbExtension
            // 
            cmbExtension.FormattingEnabled = true;
            cmbExtension.Items.AddRange(new object[] { "mov", "mp4", "wmv" });
            cmbExtension.Location = new Point(480, 222);
            cmbExtension.Name = "cmbExtension";
            cmbExtension.Size = new Size(121, 25);
            cmbExtension.Sorted = true;
            cmbExtension.TabIndex = 3;
            cmbExtension.SelectedIndexChanged += cmbExtension_SelectedIndexChanged;
            // 
            // downloadBar
            // 
            downloadBar.Location = new Point(128, 435);
            downloadBar.MarqueeAnimationSpeed = 5;
            downloadBar.Name = "downloadBar";
            downloadBar.Size = new Size(554, 23);
            downloadBar.Step = 2;
            downloadBar.Style = ProgressBarStyle.Marquee;
            downloadBar.TabIndex = 4;
            downloadBar.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(376, 475);
            label1.Name = "label1";
            label1.Size = new Size(43, 17);
            label1.TabIndex = 5;
            label1.Text = "label1";
            label1.Visible = false;
            // 
            // txtDebug
            // 
            txtDebug.Location = new Point(128, 280);
            txtDebug.Multiline = true;
            txtDebug.Name = "txtDebug";
            txtDebug.ReadOnly = true;
            txtDebug.ScrollBars = ScrollBars.Vertical;
            txtDebug.Size = new Size(554, 137);
            txtDebug.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 591);
            Controls.Add(txtDebug);
            Controls.Add(label1);
            Controls.Add(downloadBar);
            Controls.Add(cmbExtension);
            Controls.Add(chkAudio);
            Controls.Add(btnDownload);
            Controls.Add(txtUrl);
            Name = "Form1";
            Text = "Youtube-DL-GUI";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtUrl;
        private Button btnDownload;
        private CheckBox chkAudio;
        private ComboBox cmbExtension;
        private FolderBrowserDialog saveDirectory;
        private ProgressBar downloadBar;
        private Label label1;
        private TextBox txtDebug;
    }
}
