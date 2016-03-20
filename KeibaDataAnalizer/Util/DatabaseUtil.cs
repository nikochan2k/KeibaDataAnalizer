using System;
using System.Data.Common;
using Soma.Core;

using Nikochan.Keiba.KeibaDataAnalyzer.Model;

namespace Nikochan.Keiba.KeibaDataAnalyzer.Util
{
	/// <summary>
	/// Description of DatabaseUtil.
	/// </summary>
	public static class DatabaseUtil
	{
		public static void SetForeignKey(ILocalDb db, DbConnection con, bool flag){
			var onOff = flag ? "ON" : "OFF";
			db.Execute(con, "PRAGMA foreign_keys = " + onOff);
		}		
	}
}
