using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Soma.Core;
using Nikochan.Keiba.KeibaDataAnalyzer.Model;

namespace Nikochan.Keiba.KeibaDataAnalyzer.Util
{
    public class ModelUtil
    {
    	private static readonly IDictionary<string, IList<UserSQL>> userSQLListMap
    		= new Dictionary<string, IList<UserSQL>>();
    	
	    public static UserSQL GetUserSQL(string domain, string name)
	    {
	        using(var transaction = new Transaction()){
	        	var db = transaction.DB;
	        	var con = transaction.Connection;
	        	var userSQL = db.TryFind<UserSQL>(con, new object[]{domain, name});
	            return userSQL;
	        }
	    }
	    
	    public static IList<UserSQL> GetUserSQLList(string domain){
	    	if(userSQLListMap.ContainsKey(domain)){
	    		return userSQLListMap[domain];
	    	}
	        using(var transaction = new Transaction()){
	        	var db = transaction.DB;
	        	var con = transaction.Connection;
        		var list = db.Query<UserSQL>(
        			con,
        			"SELECT * FROM UserSQL WHERE Domain =/* Domain */''",
        			new { Domain = domain }
        		);
	        	userSQLListMap.Add(domain, list);
	            return list;
	        }
	    }

    }
}
