using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Nikochan.Keiba.KeibaDataAnalyzer.Util
{
    public static class CSVUtil
    {
        private static readonly Encoding SJIS = Encoding.GetEncoding("Shift_JIS");

        public static void WriteCSV<T>(IList<T> list, String csvPath)
        {
            WriteCSV<T>(list, csvPath, SJIS);
        }

        public static string GetString(object obj)
        {
            if (obj == null)
            {
                return string.Empty;
            }
            string field = obj.ToString();
            if (field.IndexOf('"') > -1 ||
                field.IndexOf(',') > -1 ||
                field.IndexOf('\r') > -1 ||
                field.IndexOf('\n') > -1 ||
                field.StartsWith(" ") || field.StartsWith("\t") ||
                field.EndsWith(" ") || field.EndsWith("\t"))
            {
                if (field.IndexOf('"') > -1)
                {
                    //"を""とする
                    field = field.Replace("\"", "\"\"");
                }
                field = "\"" + field + "\"";
            }
            return field;
        }

        public static void WriteCSV<T>(IList<T> list, String csvPath, Encoding enc)
        {
        	var columnNames = ViewUtil.GetColumnNames<T>(list);
            var colCount = columnNames.Length;
            var lastColIndex = colCount - 1;
            using (StreamWriter sr = new StreamWriter(csvPath, false, enc))
            {
                var columnInfoMap = new Dictionary<string, ViewUtil.ColumnInfo>(colCount);
                //ヘッダを書き込む
                var i = 0;
                foreach (var columnName in columnNames)
                {
                    //ヘッダの取得
                    var columnInfo = ViewUtil.GetColumnInfo(columnName);
                    columnInfoMap.Add(columnName, columnInfo);
                    //フィールドを書き込む
                    sr.Write(columnInfo.Converted);
                    //カンマを書き込む
                    if (lastColIndex > i)
                    {
                        sr.Write(',');
                    }
                    i++;
                }
                //改行する
                sr.Write("\r\n");

                //レコードを書き込む
                foreach (var item in list)
                {
                	i = 0;
                	foreach (var columnName in columnNames) {
                        //フィールドの取得
                        string val = GetString(
                        	ViewUtil.GetDisplayValue(
                        		columnInfoMap[columnName].Original,
                        		ViewUtil.GetValue(item, columnName)
                        	)
                        );
                        //フィールドを書き込む
                        sr.Write(val);
                        //カンマを書き込む
                        if (lastColIndex > i)
                        {
                            sr.Write(',');
                        }
                        i++;
                    }
                    //改行する
                    sr.Write("\r\n");
                }
            }
        }

        public static void WriteCSV(DataGridView dgv, String csvPath)
        {
            WriteCSV(dgv, csvPath, SJIS);
        }

        public static void WriteCSV(DataGridView dgv, String csvPath, Encoding enc)
        {
            int colCount = dgv.Columns.Count;
            int lastColIndex = colCount - 1;
            using (StreamWriter sr = new StreamWriter(csvPath, false, enc))
            {
                //ヘッダを書き込む
                for (int i = 0; i < colCount; i++)
                {
                    //ヘッダの取得
                    string field = GetString(dgv.Columns[i].HeaderText);
                    //フィールドを書き込む
                    sr.Write(field);
                    //カンマを書き込む
                    if (lastColIndex > i)
                    {
                        sr.Write(',');
                    }
                }
                //改行する
                sr.Write("\r\n");

                //レコードを書き込む
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    for (int i = 0; i < colCount; i++)
                    {
                        //フィールドの取得
                        string field = GetString(row.Cells[i].EditedFormattedValue);
                        //フィールドを書き込む
                        sr.Write(field);
                        //カンマを書き込む
                        if (lastColIndex > i)
                        {
                            sr.Write(',');
                        }
                    }
                    //改行する
                    sr.Write("\r\n");
                }
            }
        }

        public static void WriteCSV(IDataReader reader, String csvPath)
        {
            WriteCSV(reader, csvPath, SJIS);
        }

        public static void WriteCSV(IDataReader reader, String csvPath, Encoding enc)
        {
            int colCount = reader.FieldCount;
            int lastColIndex = colCount - 1;
            using (StreamWriter sr = new StreamWriter(csvPath, false, enc))
            {
                var columnInfoList = new List<ViewUtil.ColumnInfo>(colCount);
                //ヘッダを書き込む
                for (int i = 0; i < colCount; i++)
                {
                    //ヘッダの取得
                    var columnInfo = ViewUtil.GetColumnInfo(reader.GetName(i));
                    columnInfoList.Add(columnInfo);
                    //フィールドを書き込む
                    sr.Write(columnInfo.Converted);
                    //カンマを書き込む
                    if (lastColIndex > i)
                    {
                        sr.Write(',');
                    }
                }
                //改行する
                sr.Write("\r\n");

                //レコードを書き込む
                while (reader.Read())
                {
                    for (int i = 0; i < colCount; i++)
                    {
                        //フィールドの取得
                        string val = GetString(ViewUtil.GetDisplayValue(columnInfoList[i].Original, reader.GetValue(i)));
                        //フィールドを書き込む
                        sr.Write(val);
                        //カンマを書き込む
                        if (lastColIndex > i)
                        {
                            sr.Write(',');
                        }
                    }
                    //改行する
                    sr.Write("\r\n");
                }
            }
        }
    
    }
}
