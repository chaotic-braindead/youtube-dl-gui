using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Text.RegularExpressions;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.LinkLabel;

namespace youtube_dl_GUI
{
    public partial class Form1 : Form
    {
        private Youtube yt;
        private string ytdlPath;
        private string[] audio = new string[] {
            "mp3", "flac", "ogg", "wav"
        };
        private string[] video = new string[] {
            "mp4", "webm", "flv"
        };
        private int idx = 0;

        public Form1()
        {
            try
            {
                ytdlPath = Environment.ExpandEnvironmentVariables("%LOCALAPPDATA%\\Programs\\Python\\");
                Regex pyVer = new Regex("Python3[0-9]+");
                List<string> res = Directory.GetDirectories(ytdlPath).Where(path => pyVer.IsMatch(path)).ToList();
                if (res.Count == 0)
                {
                    MessageBox.Show("Python does not exist in your system. Please install.");
                    this.Close();
                }
                ytdlPath = res[0] + "\\Scripts\\yt-dlp.exe";

                if (!File.Exists(ytdlPath))
                {
                    MessageBox.Show("youtube-dl does not exist in your system. Please install.");
                    this.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            InitializeComponent();
            cmbExtension.SelectedIndex = 0;
            yt = new Youtube(ytdlPath);
        }

        private async void btnDownload_Click(object sender, EventArgs e)
        {
            if(tblQueue.Rows.Count == 0)
            {
                MessageBox.Show("No links in queue.");
                return;
            }   
            DialogResult dir = saveDirectory.ShowDialog();
            if (dir == DialogResult.Cancel)
                return;

            tblQueue.ClearSelection();
            btnQueue.Enabled = false;

            string path = saveDirectory.SelectedPath;
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            txtDebug.Clear();
            btnDownload.Enabled = false;

            List<Task> tasks = new List<Task>();

            foreach (DataGridViewRow row in tblQueue.Rows)
            {
                if (row.Cells["Status"].Value.Equals("Downloaded"))
                    continue;
               
                Dictionary<string, string> dict = new Dictionary<string, string>
                {
                    { "filetype", row.Cells["Type"].Value.ToString() },
                    { "url", row.Cells["Link"].Value.ToString() },
                    { "dir", path + "\\%(title)s.%(ext)s" }
                };
                var progress = new Progress<string>(s =>
                {
                    if (s.Contains("[download]") && s.Contains('%'))
                    {
                        int progress = 0;
                        for (int j = s.IndexOf(']') + 1; j < s.Length; j++)
                        {
                            if (char.IsDigit(s[j]))
                            {
                                progress = j;
                                break;
                            }
                        }
                        row.Cells["Status"].Value = "Downloading";
                        row.Cells["Progress"].Value = s.Substring(progress, s.IndexOf('%') + 1 - progress);
                        row.Cells["Speed"].Value = s.Substring(s.IndexOf("at") + 2, s.IndexOf('s') + 1 - (s.IndexOf("at") + 2)).TrimStart();
                    }
                });

                if (video.Contains(row.Cells["Type"].Value.ToString()))
                {
                    tasks.Add(Task.Factory.StartNew(() =>
                    {
                        Youtube y = new Youtube(ytdlPath);
                        y.DownloadVideo(dict, progress);
                        row.Cells["Status"].Value = "Finished";
                        row.Cells["Speed"].Value = "";
                    }));
                }
                else
                {
                    tasks.Add(Task.Factory.StartNew(() =>
                    {
                        Youtube y = new Youtube(ytdlPath);
                        y.DownloadAudio(dict, progress);
                        row.Cells["Status"].Value = "Finished";
                        row.Cells["Speed"].Value = "";
                    }));
                }
            }
            
            await Task.WhenAll(tasks);
            btnQueue.Enabled = true;
            btnDownload.Enabled = true;
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

        private async void btnQueue_Click(object sender, EventArgs e)
        {
            Regex regex = new Regex("^((?:https?:)?\\/\\/)?((?:www|m)\\.)?((?:youtube(-nocookie)?\\.com|youtu.be))(\\/(?:[\\w\\-]+\\?v=|embed\\/|live\\/|v\\/)?)([\\w\\-]+)(\\S+)?$");
            if (!regex.IsMatch(txtUrl.Text))
            {
                MessageBox.Show("Must be a valid YouTube link.");
                return;
            }
            string temp = txtUrl.Text, title = "Fetching";
            txtUrl.Clear();
            if (temp.Contains("playlist"))
            {
                Progress<string> progress = new Progress<string>(async (s) =>
                {
                    string tempTitle = "Fetching";
                    var p = new Progress<string>((s) => {
                        tempTitle = s;
                    });
                    tblQueue.Rows.Add(s, tempTitle, cmbExtension.Text, "Queued", "0%", "", "Remove");
                    await Task.Factory.StartNew(() =>
                    {
                        yt.GetTitle(s, p);
                        tblQueue.Rows[idx].Cells["Title"].Value = tempTitle;
                        ++idx;
                    });
                });
                await Task.Factory.StartNew(() => yt.GetURL(temp, progress));
                btnDownload.Enabled = true;
            }
            else
            {
                var prog = new Progress<string>((s) => {
                    title = s;
                });
                tblQueue.Rows.Add(temp, title, cmbExtension.Text, "Queued", "0%", "", "Remove");
                btnDownload.Enabled = true;
                await Task.Factory.StartNew(() =>
                {
                    yt.GetTitle(temp, prog);
                     tblQueue.Rows[idx].Cells["Title"].Value = title;
                    ++idx;
                });
            }
        }

        private void tblQueue_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                senderGrid.Rows.RemoveAt(e.RowIndex);
                --idx;
                if (tblQueue.Rows.Count == 0)
                    btnDownload.Enabled = false;
            }
        }
    }
}
