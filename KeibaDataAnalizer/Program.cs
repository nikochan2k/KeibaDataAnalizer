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
        	Application.ThreadException += (sender, e) =>
        	{
        		MessageBox.Show(
        			CommonUtil.FlattenException(e.Exception),
        		    "予期せぬエラー",
        		    MessageBoxButtons.OK,
        		    MessageBoxIcon.Error);
			};
        	
        	Thread.GetDomain().UnhandledException += (sender, e) =>
        	{
				Exception ex = e.ExceptionObject as Exception;
				if (ex != null)
				{
	        		MessageBox.Show(
	        			CommonUtil.FlattenException(ex),
	        		    "予期せぬエラー",
	        		    MessageBoxButtons.OK,
	        		    MessageBoxIcon.Error);
				}
			};
        	
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
            try{
				LOGGER.Info("競馬データ取り込みプログラム開始");
				Application.Run(new MainForm());
            }
            catch(Exception ex){
        		MessageBox.Show(
        			CommonUtil.FlattenException(ex),
        		    "予期せぬエラー",
        		    MessageBoxButtons.OK,
        		    MessageBoxIcon.Error);
			}
		}

	}
}
