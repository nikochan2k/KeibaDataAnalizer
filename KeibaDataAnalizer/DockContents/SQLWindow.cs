using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

using Soma.Core;
using WeifenLuo.WinFormsUI.Docking;
using Nikochan.Keiba.KeibaDataAnalyzer.Model;
using Nikochan.Keiba.KeibaDataAnalyzer.Util;

namespace Nikochan.Keiba.KeibaDataAnalyzer.DockContents
{
    public partial class SQLWindow : DockContent
    {
        public SQLWindow()
        {
            InitializeComponent();
        }

        private void executeButton_Click(object sender, EventArgs e)
        {
            try
            {
	            using(var transaction = new Transaction()){
	            	var db = transaction.DB;
	            	var con = transaction.Connection;
	                if (sqlTextBox.Text.Trim().ToUpper().StartsWith("SELECT"))
	                {
	            		var list = db.Query<dynamic>(con, sqlTextBox.Text);
	            		ViewUtil.Bind(dataGridView, list);
	                }
	                else
	                {
	                	db.Execute(con, sqlTextBox.Text);
		            	transaction.Commit();
	                }
	            }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(
                    "不正なSQL\n" + ex.Message,
                    "不正なSQL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                );
            }
        }

        private void exportCSVButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            try
            {
            	IList<dynamic> list;
	            using(var transaction = new Transaction()){
	            	var db = transaction.DB;
	            	var con = transaction.Connection;
            		list = db.Query<dynamic>(con, sqlTextBox.Text);
	            }
                CSVUtil.WriteCSV(list, saveFileDialog.FileName);
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(
                    "不正なSQL\n" + ex.Message,
                    "不正なSQL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                );
            }
        }

        private void saveSQLButton_Click(object sender, EventArgs e)
        {
            string name = nameComboBox.Text.Trim();
            if (name == string.Empty)
            {
                MessageBox.Show(
                    "コンボボックスに名前が設定されていません。",
                    "名前未設定",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                );
                return;
            }
            using(var transaction = new Transaction()){
            	var db = transaction.DB;
            	var con = transaction.Connection;
            	var userSQL = ModelUtil.GetUserSQL("SQL", name);
	            if (userSQL != null)
	            {
	            	userSQL.SQL = sqlTextBox.Text;
	            	db.Update(con, userSQL);
	            }
	            else
	            {
	                userSQL = new UserSQL();
	                userSQL.Domain = "SQL";
	                userSQL.Name = name;
	                userSQL.SQL = sqlTextBox.Text;
	                userSQL.Editable = 1;
	                db.Insert(con, userSQL);
	            }
            	transaction.Commit();
            }

            BindToNameComboBox();
        }

        private void SQLWindow_Load(object sender, EventArgs e)
        {
            BindToNameComboBox();
        }

        private void BindToNameComboBox()
        {
        	var list = ModelUtil.GetUserSQLList("SQL");
            nameComboBox.ComboBox.DisplayMember = "Name";
            nameComboBox.ComboBox.DataSource = list;
        }

        private void nameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        	var userSQL = (UserSQL)nameComboBox.ComboBox.SelectedItem;
            sqlTextBox.Text = userSQL.SQL;
        }
    }
}
