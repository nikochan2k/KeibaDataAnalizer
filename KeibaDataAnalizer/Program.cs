using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

using Nikochan.Keiba.KeibaDataAnalyzer.Util;
using Nikochan.Keiba.KeibaDataAnalyzer.Logic;
using Nikochan.Keiba.KeibaDataAnalyzer.Logic.ImporterFactory;

namespace Nikochan.Keiba.KeibaDataAnalyzer
{
	static class Program
	{
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
        static int Main(string[] args)
		{
            if (args.Length == 0)
            {
                Console.Error.WriteLine("使い方: KeibaDataAnalyzer.exe <LZHファイルまたはフォルダ> [エラーログ出力先]");
                return 1;
            }

            var factory = new ImporterListFactory();
            var path = args[0];
            if (File.Exists(path))
            {
                var extension = Path.GetExtension(path);
                if (!".lzh".Equals(extension, StringComparison.OrdinalIgnoreCase))
                {
                    Console.Error.WriteLine("LZHファイルではありません: " + path);
                }
                Import(factory, path);
            }
            else if (Directory.Exists(path))
            {
                foreach (var lzhFilePath in Directory.EnumerateFiles(path, "*.lzh", SearchOption.AllDirectories))
                {
                    Import(factory, lzhFilePath);
                }
            }
            else
            {
                Console.Error.WriteLine("LZHファイルまたはフォルダが存在しません: " + path);
                return 1;
            }
           

            return 0;
		}

        static void Import(ImporterListFactory factory, string lzhFilePath)
        {
            Console.WriteLine(String.Format("{0} を取り込んでいます", lzhFilePath));
            var history = ImportHistory.CreateInstance(lzhFilePath);
            String tempDirectory = GetTemporaryDirectory();
            try
            {
                LHAUtil.LhaExtractArchive(lzhFilePath, tempDirectory);
                var files = Directory.GetFiles(tempDirectory);
                var importers = factory.CreateImporterList(history, files);
                foreach(var importer in importers){
                    importer.Import();
                }
            }
            finally
            {
                try
                {
                    history.Save();
                    Directory.Delete(tempDirectory, true);
                }
                catch
                {
                    // 何もしない
                }
            }
        }

        static string GetTemporaryDirectory()
        {
            string tempDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(tempDirectory);
            return tempDirectory;
        }
	}
}
