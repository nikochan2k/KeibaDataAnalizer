using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using NLog;

using Nikochan.Keiba.KeibaDataAnalyzer.Util;

namespace Nikochan.Keiba.KeibaDataAnalyzer
{
	static class Program
	{
		private static readonly Logger LOGGER = LogManager.GetCurrentClassLogger();
    	
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.ThreadException += (sender, e) => {
				LOGGER.Fatal(CommonUtil.FlattenException(e.Exception));
			};
        	
			Thread.GetDomain().UnhandledException += (sender, e) => {
				Exception ex = e.ExceptionObject as Exception;
				if (ex != null) {
					LOGGER.Fatal(CommonUtil.FlattenException(ex));
				}
			};
        	
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			try {
				LOGGER.Info("競馬データ取り込みプログラム開始");
				Application.Run(new MainForm());
			} catch (Exception ex) {
				LOGGER.Fatal(CommonUtil.FlattenException(ex));
			}
		}

	}
}
