namespace youtube_dl_GUI
{
    public partial class Form1 : Form
    {
        private Youtube yt;
        string[] audio = new string[] {
            "mp3", "flac", "opus"
        };
        string[] video = new string[] {
            "mp4", "mov", "wmv"
        };

        public Form1()
        {
            InitializeComponent();
            cmbExtension.SelectedIndex = 0;
            yt = new Youtube();
        }

        private async void btnDownload_Click(object sender, EventArgs e)
        {
            if (txtUrl.Text == "")
                return;

            DialogResult dir = saveDirectory.ShowDialog();
            if (dir == DialogResult.Cancel)
                return;

            string path = saveDirectory.SelectedPath;
            if (!path.Contains("youtube-dl-gui") && !Directory.Exists(path + "\\youtube-dl-gui"))
                Directory.CreateDirectory(path + "\\youtube-dl-gui");

            Dictionary<string, string> dict = new Dictionary<string, string>
                {
                    { "filetype", cmbExtension.Text },
                    { "url", txtUrl.Text },
                    { "dir", path + "\\youtube-dl-gui\\%(title)s.%(ext)s" }
            };
            txtDebug.Clear();
            label1.Show();
            label1.Text = "Downloading...";
            downloadBar.Show();
            var progress = new Progress<string>(s =>
            {
                txtDebug.Text += s;
                txtDebug.SelectionStart = txtDebug.Text.Length;
                txtDebug.ScrollToCaret();
            });
            if (chkAudio.Checked)
                await Task.Factory.StartNew(() => yt.DownloadAudio(dict, progress));
            else
                await Task.Factory.StartNew(() => yt.DownloadVideo(dict, progress));

            label1.Text = "Download complete.";
            downloadBar.Hide();
        }

        private void txtUrl_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbExtension_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chkAudio_CheckedChanged(object sender, EventArgs e)
        {
            cmbExtension.Items.Clear();
            if (chkAudio.Checked)
                cmbExtension.Items.AddRange(audio);
            else
                cmbExtension.Items.AddRange(video);
            cmbExtension.SelectedIndex = 0;
        }

    }
}
