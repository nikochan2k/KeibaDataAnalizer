using System;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Soma.Core;
using Nikochan.Keiba.KeibaDataAnalyzer.UserControls;
using Nikochan.Keiba.KeibaDataAnalyzer.Model;

namespace Nikochan.Keiba.KeibaDataAnalyzer.Util
{
    public class ViewUtil
    {

    	private static IDictionary<ScrollableControl, string> scrollableControlMap = new Dictionary<ScrollableControl, string>();
    	
        private static IDictionary<DataGridView, string> dataGridViewMap = new Dictionary<DataGridView, string>();
        
        private static IDictionary<string, Code> codeMap = new Dictionary<string, Code>();
        
        public static string[] GetColumnNames<T>(IList<T> list){
        	if(list.Count == 0){
        		return null;
        	}
            List<string> columnNameList = new List<string>();
        	var item = list[0];
        	if(item is IDictionary<string, object>){
        		var map = (IDictionary<string, object>)item;
        		foreach(var key in map.Keys){
	                columnNameList.Add(key);
        		}
        	}
        	else{
        		var type = item.GetType();
        		foreach (var property in type.GetProperties()) {
        			
        			columnNameList.Add(property.Name);
        		}
        	}
            return columnNameList.ToArray();
        }
        
        public static void Bind<T>(DataGridView dgv, IList<T> list)
        {
        	var columnNames = GetColumnNames<T>(list);
        	if(columnNames == null){
        		return;
        	}
            var displayCollumnNames = string.Join(",", columnNames);
            Bind(dgv, list, displayCollumnNames);
        }

        public class ColumnInfo
        {
            public string Original { get; set; }

            public string Converted { get; set; }

            public string Domain { get; set; }
        }
		
        private static IList<Japanize> japanizeList;
        
        public static IList<Japanize> GetJapanizeList(){
        	if(japanizeList != null){
        		return japanizeList;
        	}
            using(var transaction = new Transaction()){
            	var db = transaction.DB;
            	var con = transaction.Connection;
            	japanizeList = db.Query<Japanize>(con, "SELECT * FROM Japanize");
            	return japanizeList;
        	}
        }
        
        public static Japanize GetJapanize(string id){
        	var japanizeList = GetJapanizeList();
        	var japanize =
        		(from item in japanizeList
        		 where item.Id == id
        		 select item).FirstOrDefault<Japanize>();
        	return japanize;
        }
        
        public static IDictionary<string, ColumnInfo> columnInfoMap = new Dictionary<string, ColumnInfo>();
        
        public static ColumnInfo GetColumnInfo(string columnName)
        {
        	if(columnInfoMap.ContainsKey(columnName)){
        		return columnInfoMap[columnName];
        	}
        	var list = GetJapanizeList();
        	var ci =
        		(from i in list
        		where i.Id == columnName
        		select new ColumnInfo(){Original = columnName, Converted = i.Name, Domain = i.Domain}).FirstOrDefault();
        	if(ci == null){
        		ci = new ColumnInfo(){ Original = columnName, Converted = columnName, Domain = null};
        	}
        	columnInfoMap.Add(columnName, ci);
        	return ci;
        }
	    
        public static string GetString(object obj)
        {
            if (obj == null)
            {
                return string.Empty;
            }
            if (obj is DateTime)
            {
                var dt = (DateTime)obj;
                return dt.ToString("yy/MM/dd");
            }
            if(obj is DateTime?){
            	var dt = (DateTime?)obj;
            	return dt.Value.ToString("yy/MM/dd");
            }
            return obj.ToString();
        }

        public static string GetCodeValue(string domain, int key)
        {
            using(var transaction = new Transaction()){
            	var db = transaction.DB;
            	var con = transaction.Connection;
            	var code = db.TryFind<Code>(con, new object[]{ domain, key });
        		if(code == null){
        			return string.Empty;
        		}
        		return code.Val;
            }
        }

        public static string GetDisplayValue(string columnName, object val)
        {
            var columnInfo = GetColumnInfo(columnName);
            if (val == null || val == DBNull.Value)
            {
                return string.Empty;
            }
            if (columnInfo.Domain != null)
            {
                return GetCodeValue(columnInfo.Domain, (int)val);
            }
            return val.ToString();
        }
        
        public static object GetValue(object item, string key){
        	if(item == null){
        		return null;
        	}
        	object obj = null;
            if(item is IDictionary<string, object>){
            	var map = (IDictionary<string, object>)item;
            	if(map.ContainsKey(key)){
	            	obj = map[key];
            	}
            } else {
            	var type = item.GetType();
            	var pi = type.GetProperty(key);
            	if(pi != null){
	            	obj = pi.GetValue(item, null);
            	}
            }
        	return obj;
        }
        
        public static void Bind<T>(DataGridView dataGridView, IList<T> list, string displayColNames)
        {
        	dataGridView.DataSource = null;
        	var count = list.Count;
        	if(count == 0){
        		return;
        	}
        	if(string.IsNullOrEmpty(displayColNames)){
        		return;
        	}
            try
            {
                dataGridView.SuspendLayout();

                if (!dataGridViewMap.ContainsKey(dataGridView))
                {
                    dataGridViewMap.Add(dataGridView, string.Empty);
                    dataGridView.AutoGenerateColumns = false;
                    dataGridView.DataError += DataGridView_DataError;
                    dataGridView.CellFormatting += DataGridView_CellFormatting;
                }
                if (dataGridViewMap[dataGridView] != displayColNames)
                {
                    dataGridViewMap[dataGridView] = displayColNames;
                    dataGridView.Columns.Clear();
                    var columnNames = displayColNames.Split(',');
                    foreach (var columnName in columnNames)
                    {
                        var columnInfo = GetColumnInfo(columnName);
                        var header = columnInfo.Converted;
                        var col = new DataGridViewTextBoxColumn();
                        col.Name = columnName;
                        col.DataPropertyName = columnName;
                        col.HeaderText = header;
                        if (columnInfo.Domain != null)
                        {
                        	var codes = GetCodes(columnInfo.Domain);
                        	col.Tag = codes;
                        }
                        dataGridView.Columns.Add(col);
                    }
                }
                dataGridView.DataSource = list;
            }
            finally
            {
                dataGridView.ResumeLayout();
            }
        }

        protected static IList<Code> GetCodes(string domain)
        {
            using(var transaction = new Transaction()){
            	var db = transaction.DB;
            	var con = transaction.Connection;
        		var list = db.Query<Code>(
        			con,
        			"SELECT * FROM Code WHERE Domain = /* Domain */''",
        			new { Domain = domain }
        		);
            	transaction.Commit();
        		return list;
            }
        }

        public static void Bind(ScrollableControl container, object item, string detailColNamesString)
        {
        	if(string.IsNullOrEmpty(detailColNamesString)){
        		return;
        	}
            try
            {
                container.SuspendLayout();

                var columnNames = detailColNamesString.Split(',');
                if(!scrollableControlMap.ContainsKey(container)){
                    scrollableControlMap.Add(container, detailColNamesString);
	                foreach (var columnName in columnNames)
	                {
                        var columnInfo = GetColumnInfo(columnName);
                        var label = columnInfo.Converted;
	                    var property = new PropertyControl();
	                    property.Name = columnName;
	                    property.Label = label;
                        if (columnInfo.Domain != null)
                        {
                        	var codes = GetCodes(columnInfo.Domain);
                        	property.Tag = codes;
                        }
	                    container.Controls.Add(property);
	                }
                }
                foreach (var columnName in columnNames)
                {
					foreach (PropertyControl property in container.Controls) {
                		if(property.Name == columnName){
                			var val = GetValue(item, columnName);
                			if(val != null){
                				property.Visible = true;
	                			property.Value = GetValueWithCode(val, property.Tag as IList<Code>);
                			}
                			else {
                				property.Visible = false;
                			}
                		}
					}
                }
            }
            finally
            {
                container.ResumeLayout();
            }
        }

        private static void DataGridView_DataError(object sender,
            DataGridViewDataErrorEventArgs e)
        {
            Console.WriteLine(CommonUtil.FlattenException(e.Exception));
            e.ThrowException = false;
        }

        private static void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e){
        	var dgv = (DataGridView)sender;
        	var codes = dgv.Columns[e.ColumnIndex].Tag as IList<Code>;
        	var cellValue = dgv[e.ColumnIndex, e.RowIndex].Value;
        	var valueWithCode = GetValueWithCode(cellValue, codes);
        	e.Value = valueWithCode;
        	e.FormattingApplied = true;
        }
        
        private static string GetValueWithCode(object original, IList<Code> codes){
        	if(original == null || DBNull.Value.Equals(original)){
        		return string.Empty;
        	}
        	if(codes == null){
        		return GetString(original);
        	}
        	int key;
        	if(!int.TryParse(original.ToString(), out key)){
        		return GetString(original);
        	}
        	var val =
        		(from i in codes
        		where i.Key == key
        		select i.Val).FirstOrDefault();
        	if(val == null){
        		return GetString(original);
        	}
        	var valueWithCode = val + "[" + key + "]";
        	return valueWithCode;
        }
    }
}
