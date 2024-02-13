using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace youtube_dl_GUI
{
    internal class Youtube
    {
        private ProcessStartInfo process;
        string path;
        public Youtube() { 
            try
            {
                path = Environment.ExpandEnvironmentVariables("%LOCALAPPDATA%\\Programs\\Python\\");
                Regex pyVer = new Regex("Python3[0-9]+");
                List<string> res = Directory.GetDirectories(path).Where(path => pyVer.IsMatch(path)).ToList();
                if (res.Count < 1)
                {
                    throw new Exception("Python does not exist in your system. Please install.");
                }
                path = res[0] + "\\Scripts\\youtube-dl.exe";
                if (!File.Exists(path))
                {
                    throw new Exception("youtube-dl does not exist in your system. Please install.");
                }
                process = new ProcessStartInfo(path);
                process.WindowStyle = ProcessWindowStyle.Hidden;
                process.RedirectStandardOutput = true; 
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
                    "--recode-video={0} " +
                    "--audio-quality=0 " +
                    "-o \"{1}\" " +
                    "{2}",
                    options["filetype"],
                    options["dir"],
                    options["url"]);
                process.Arguments = args;
                Process? proc = Process.Start(process);
                while (!proc.StandardOutput.EndOfStream)
                    msg.Report(proc.StandardOutput.ReadLine() + "\n");
                proc.WaitForExit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
