using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace youtube_dl_GUI
{
    internal class Youtube
    {
        private ProcessStartInfo process;
        public Youtube(string ytdlPath) { 
            try
            {
                process = new ProcessStartInfo(ytdlPath);
                process.WindowStyle = ProcessWindowStyle.Hidden;
                process.RedirectStandardOutput = true; 
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void GetURL(string playlist, IProgress<string> urls) {
            try
            {
                string args = String.Format(" --no-download " +
                    "--print \"%(webpage_url)s\" \"" +
                    playlist + "\"");
                process.Arguments = args;
                Process? proc = Process.Start(process);
                while (!proc.StandardOutput.EndOfStream)
                    urls.Report(proc.StandardOutput.ReadLine());

                proc.WaitForExit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void GetTitle(string url, IProgress<string> msg)
        {
            try
            {
                string args = String.Format(" --print \"%(title)s\" \"" +
                    url + "\"");
                process.Arguments = args;
                Process? proc = Process.Start(process);
                msg.Report(proc.StandardOutput.ReadLine());
                proc.WaitForExit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    
        public void DownloadAudio(Dictionary<string, string> options, IProgress<string> msg)
        {
            try
            {
                string args = String.Format("--verbose " +
                    "-x " +
                    "--audio-format={0} " +
                    "--audio-quality=0 " +
                    "-o \"{1}\" " +
                    "{2}",
                    options["filetype"],
                    options["dir"],
                    options["url"]);
                process.Arguments = args;
                Process? proc = Process.Start(process);

                while (!proc.StandardOutput.EndOfStream)
                    msg.Report(proc.StandardOutput.ReadLine() + Environment.NewLine);

                proc.WaitForExit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void DownloadVideo(Dictionary<string, string> options, IProgress<string> msg)
        {
            try
            {
                string args = String.Format("--verbose " +
                    "-f \"bestvideo[ext={0}]+bestaudio[ext=m4a]/best[ext=mp4]/best\" "+
                    "--audio-quality=0 " +
                    "-o \"{1}\" " +
                    "{2}",
                    options["filetype"],
                    options["dir"],
                    options["url"]);
                process.Arguments = args;
                Process? proc = Process.Start(process);
                while (!proc.StandardOutput.EndOfStream)
                    msg.Report(proc.StandardOutput.ReadLine() + Environment.NewLine);
                proc.WaitForExit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
