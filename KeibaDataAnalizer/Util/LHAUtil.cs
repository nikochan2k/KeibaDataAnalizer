using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace Nikochan.Keiba.KeibaDataAnalyzer.Util
{
	public static class LHAUtil
	{
		/// <summary>
		/// UNLHA32.DLLで書庫を展開する
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

			//展開する
			var filename = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "unlha32.exe");
			var argument = string.Format("x -n1 {0} {1} *", archiveFile, extractDir);
			var info = new ProcessStartInfo(filename, argument);
			info.CreateNoWindow = false;
			info.WindowStyle = ProcessWindowStyle.Hidden;
			var p = Process.Start(info);
			p.WaitForExit();
		}
	}
}
