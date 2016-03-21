using System;
using System.Collections.Generic;
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


        public static void ExecuteSQLs(string sqls, object condition, params string[] args)
        {
            using (var t = new Transaction())
            {
                ExecuteSQLs(sqls, t);
            }
            
        }

        public static void ExecuteSQLs(Transaction t, string sqls, object condition, params string[] args)
        {
            if (string.IsNullOrWhiteSpace(sqls))
            {
                return;
            }

            var sqlList = new List<string>();
            foreach (var sql in sqls.Split(';'))
            {
                if (string.IsNullOrWhiteSpace(sql))
                {
                    continue;
                }
                var adding = sql;
                if (args != null && args.Length > 0)
                {
                    adding = string.Format(sql, args);
                }
                sqlList.Add(adding);
            }

            var con = t.Connection;
            var db = t.DB;
            foreach (var sql in sqlList)
            {
                if (condition != null)
                {
                    db.Execute(con, sql, condition);
                }
                else
                {
                    db.Execute(con, sql);
                }
            }
        }
	}
}
