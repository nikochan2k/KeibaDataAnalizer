using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace Nikochan.Keiba.KeibaDataAnalyzer.Util
{
	public static class LHAUtil
	{
        static bool IsLinux
        {
            get
            {
                int p = (int)Environment.OSVersion.Platform;
                return (p == 4) || (p == 6) || (p == 128);
            }
        }

		/// <summary>
		/// 書庫を展開する
		/// </summary>
		/// <param name="archiveFile">書庫ファイル名</param>
		/// <param name="extractDir">展開先のフォルダ名</param>
		public static void LhaExtractArchive(
			string archiveFile, string extractDir)
		{
			//指定されたファイルがあるか調べる
			if (!File.Exists(archiveFile)){
				throw new FileNotFoundException("ファイルが見つかりません:" + archiveFile);
			}

			//展開する
            ProcessStartInfo info;
            if (IsLinux)
            {
                var argument = string.Format("xqiw={0} {1}", extractDir, archiveFile);
                info = new ProcessStartInfo("lha", argument);
            }
            else
            {
                //ファイル名とフォルダ名を修正する
                if (archiveFile.IndexOf(' ') > 0)
                {
                    archiveFile = "\"" + archiveFile + "\"";
                }
                if (!extractDir.EndsWith(@"\"))
                {
                    extractDir += @"\";
                }
                if (extractDir.IndexOf(' ') > 0)
                {
                    extractDir = "\"" + extractDir + "\"";
                }

                var argument = string.Format("x -n1 {0} {1} *", archiveFile, extractDir);
                info = new ProcessStartInfo("unlha32.exe", argument);
            }
            info.UseShellExecute = false;
            info.WorkingDirectory = Path.GetDirectoryName(Application.ExecutablePath);
			info.CreateNoWindow = false;
			info.WindowStyle = ProcessWindowStyle.Hidden;
            try
            {
                var p = Process.Start(info);
                p.WaitForExit();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                Environment.Exit(1);
            }
		}
	}
}
