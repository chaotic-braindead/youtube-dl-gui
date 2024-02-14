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
            txtDebug = new TextBox();
            tblQueue = new DataGridView();
            btnQueue = new Button();
            label2 = new Label();
            Link = new DataGridViewTextBoxColumn();
            Title = new DataGridViewTextBoxColumn();
            Type = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            Progress = new DataGridViewTextBoxColumn();
            Speed = new DataGridViewTextBoxColumn();
            Remove = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)tblQueue).BeginInit();
            SuspendLayout();
            // 
            // txtUrl
            // 
            txtUrl.Location = new Point(96, 64);
            txtUrl.Name = "txtUrl";
            txtUrl.PlaceholderText = "URL";
            txtUrl.Size = new Size(483, 25);
            txtUrl.TabIndex = 0;
            // 
            // btnDownload
            // 
            btnDownload.Enabled = false;
            btnDownload.Location = new Point(443, 397);
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
            chkAudio.Location = new Point(96, 95);
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
            cmbExtension.Items.AddRange(new object[] { "flv", "mp4", "webm" });
            cmbExtension.Location = new Point(599, 64);
            cmbExtension.Name = "cmbExtension";
            cmbExtension.Size = new Size(121, 25);
            cmbExtension.Sorted = true;
            cmbExtension.TabIndex = 3;
            // 
            // txtDebug
            // 
            txtDebug.Location = new Point(38, 446);
            txtDebug.Multiline = true;
            txtDebug.Name = "txtDebug";
            txtDebug.ReadOnly = true;
            txtDebug.ScrollBars = ScrollBars.Vertical;
            txtDebug.Size = new Size(873, 123);
            txtDebug.TabIndex = 6;
            // 
            // tblQueue
            // 
            tblQueue.AllowUserToAddRows = false;
            tblQueue.BackgroundColor = SystemColors.ControlLightLight;
            tblQueue.BorderStyle = BorderStyle.None;
            tblQueue.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tblQueue.Columns.AddRange(new DataGridViewColumn[] { Link, Title, Type, Status, Progress, Speed, Remove });
            tblQueue.EditMode = DataGridViewEditMode.EditOnEnter;
            tblQueue.GridColor = SystemColors.ControlLightLight;
            tblQueue.Location = new Point(38, 135);
            tblQueue.MultiSelect = false;
            tblQueue.Name = "tblQueue";
            tblQueue.ReadOnly = true;
            tblQueue.RowHeadersVisible = false;
            tblQueue.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tblQueue.Size = new Size(873, 256);
            tblQueue.TabIndex = 7;
            tblQueue.CellContentClick += tblQueue_CellContentClick;
            // 
            // btnQueue
            // 
            btnQueue.Location = new Point(740, 64);
            btnQueue.Name = "btnQueue";
            btnQueue.Size = new Size(75, 23);
            btnQueue.TabIndex = 8;
            btnQueue.Text = "Queue";
            btnQueue.UseVisualStyleBackColor = true;
            btnQueue.Click += btnQueue_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(38, 417);
            label2.Name = "label2";
            label2.Size = new Size(39, 17);
            label2.TabIndex = 9;
            label2.Text = "Logs:";
            // 
            // Link
            // 
            Link.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Link.HeaderText = "Link";
            Link.Name = "Link";
            Link.ReadOnly = true;
            // 
            // Title
            // 
            Title.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Title.HeaderText = "Title";
            Title.Name = "Title";
            Title.ReadOnly = true;
            // 
            // Type
            // 
            Type.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            Type.HeaderText = "Type";
            Type.Name = "Type";
            Type.ReadOnly = true;
            Type.Resizable = DataGridViewTriState.False;
            Type.Width = 60;
            // 
            // Status
            // 
            Status.HeaderText = "Status";
            Status.Name = "Status";
            Status.ReadOnly = true;
            // 
            // Progress
            // 
            Progress.HeaderText = "Progress";
            Progress.Name = "Progress";
            Progress.ReadOnly = true;
            // 
            // Speed
            // 
            Speed.HeaderText = "Speed";
            Speed.Name = "Speed";
            Speed.ReadOnly = true;
            // 
            // Remove
            // 
            Remove.HeaderText = "";
            Remove.Name = "Remove";
            Remove.ReadOnly = true;
            Remove.Text = "Remove";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(949, 597);
            Controls.Add(label2);
            Controls.Add(btnQueue);
            Controls.Add(tblQueue);
            Controls.Add(txtDebug);
            Controls.Add(cmbExtension);
            Controls.Add(chkAudio);
            Controls.Add(btnDownload);
            Controls.Add(txtUrl);
            Name = "Form1";
            Text = "Youtube-DL-GUI";
            ((System.ComponentModel.ISupportInitialize)tblQueue).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtUrl;
        private Button btnDownload;
        private CheckBox chkAudio;
        private ComboBox cmbExtension;
        private FolderBrowserDialog saveDirectory;
        private TextBox txtDebug;
        private DataGridView tblQueue;
        private Button btnQueue;
        private Label label2;
        private DataGridViewTextBoxColumn Link;
        private DataGridViewTextBoxColumn Title;
        private DataGridViewTextBoxColumn Type;
        private DataGridViewTextBoxColumn Status;
        private DataGridViewTextBoxColumn Progress;
        private DataGridViewTextBoxColumn Speed;
        private DataGridViewButtonColumn Remove;
    }
}
