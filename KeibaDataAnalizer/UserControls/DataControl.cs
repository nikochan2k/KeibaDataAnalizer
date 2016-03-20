using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Soma.Core;
using Nikochan.Keiba.KeibaDataAnalyzer.Model;
using Nikochan.Keiba.KeibaDataAnalyzer.Util;

namespace Nikochan.Keiba.KeibaDataAnalyzer.UserControls
{
    public partial class DataControl : UserControl
    {
        public DataControl()
        {
            InitializeComponent();
        }

        public DataGridView DataGridView
        {
            get
            {
                return dataGridView;
            }
        }

        public void Setup(UserSQL userSQL, object detail)
        {
            ViewUtil.Bind(flowLayoutPanel, detail, userSQL.DetailColNames);

            var paramColNamesString = userSQL.ParamColNames;
            var paramColNames = paramColNamesString.Split(',');
            var paramMap = new Dictionary<string, object>();
            foreach (var paramColName in paramColNames)
            {
            	paramMap.Add(paramColName, ViewUtil.GetValue(detail, paramColName));
            }
            using(var transaction = new Transaction()){
            	var db = transaction.DB;
            	var con = transaction.Connection;
        		var list = db.Query<dynamic>(con, userSQL.SQL, paramMap);
	            ViewUtil.Bind(dataGridView, list, userSQL.ListColNames);
            	transaction.Commit();
	        }
        }

    }
}
