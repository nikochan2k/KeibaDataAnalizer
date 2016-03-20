using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel.Design;
using Soma.Core;
using Nikochan.Keiba.KeibaDataAnalyzer.Model;
using Nikochan.Keiba.KeibaDataAnalyzer.Util;

namespace Nikochan.Keiba.KeibaDataAnalyzer.DockContents
{
    public partial class EditSQLWindow : Form
    {
        private UserSQLProperty userSQLProperty;

        private ComboBox comboBox;

        public EditSQLWindow()
        {
            InitializeComponent();
        }

        public void ShowDialog(ComboBox comboBox, string domain)
        {
            userSQLProperty = new UserSQLProperty(domain);
            this.comboBox = comboBox;
            this.nameComboBox.ComboBox.DataSource = comboBox.DataSource;
            this.nameComboBox.ComboBox.DisplayMember = comboBox.DisplayMember;
            base.ShowDialog();
        }

        private void nameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        	UserSQL userSQL = (UserSQL)nameComboBox.ComboBox.SelectedItem;
            if (userSQL == null)
            {
                return;
            }
            userSQLProperty.UserSQL = userSQL;
            propertyGrid.SelectedObject = null;
            propertyGrid.SelectedObject = userSQLProperty;
        }

        private UserSQL GetUserSQL()
        {
        	var userSQL = ModelUtil.GetUserSQL(userSQLProperty.Domain, nameComboBox.Text);
            if (userSQL.Editable == 0)
            {
                return null;
            }
            return userSQL;
        }
        
        private void saveButton_Click(object sender, EventArgs e)
        {
            var userSQL = GetUserSQL();
            if (userSQL == null)
            {
                userSQLProperty.UserSQL.Name = nameComboBox.Text;
	            using(var transaction = new Transaction()){
	            	var db = transaction.DB;
	            	var con = transaction.Connection;
            		db.Insert<UserSQL>(con, userSQLProperty.UserSQL);
	            	transaction.Commit();
	            }
                UpdateComboBox();
            }
            else
            {
                if (userSQL.Editable == 0)
                {
                    MessageBox.Show("変更不可",
                        "この項目は変更できません。",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation
                        );
                    return;
                }
                if (MessageBox.Show("本当にこの項目を変更しますか？", "変更確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
		            using(var transaction = new Transaction()){
		            	var db = transaction.DB;
		            	var con = transaction.Connection;
	            		db.Update<UserSQL>(con, userSQLProperty.UserSQL);
		            	transaction.Commit();
		            }
                	UpdateComboBox();
                }
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            var userSQL = GetUserSQL();
            if (userSQL == null)
            {
                MessageBox.Show("削除不可",
                    "データベースに存在しません。",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                    );
                return;
            }
            else
            {
                if (userSQL.Editable == 0)
                {
                    MessageBox.Show("削除不可",
                        "この項目は削除できません。",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation
                        );
                    return;
                }
                else
                {
                    if (MessageBox.Show("本当にこの項目を削除しますか？", "削除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
			            using(var transaction = new Transaction()){
			            	var db = transaction.DB;
			            	var con = transaction.Connection;
		            		db.Delete<UserSQL>(con, userSQLProperty.UserSQL);
			            	transaction.Commit();
			            }
                        UpdateComboBox();
                    }
                }
            }
        }

        private void UpdateComboBox()
        {
            var dt = ModelUtil.GetUserSQLList(userSQLProperty.Domain);
            var displayMember = this.nameComboBox.ComboBox.DisplayMember;
            this.nameComboBox.ComboBox.DataSource = null;
            this.nameComboBox.ComboBox.DataSource = dt;
            this.nameComboBox.ComboBox.DisplayMember = displayMember;
            this.comboBox.DataSource = null;
            this.comboBox.DataSource = dt;
            this.comboBox.DisplayMember = displayMember;
        }

    }

    public class UserSQLProperty
    {
        private UserSQL userSQL = new UserSQL();

        public UserSQLProperty(string domain)
        {
            userSQL.Domain = domain;
            userSQL.Editable = 1;
        }

        [Browsable(false)]
        public UserSQL UserSQL
        {
            get
            {
                return userSQL;
            }
            set{
            	this.userSQL =value;
            }
        }

        [Browsable(false)]
        public string Domain
        {
            get
            {
                return userSQL.Domain;
            }
        }

        [Browsable(false)]
        public string Name
        {
            get
            {
                return userSQL.Name;
            }
            set
            {
                userSQL.Name = value;
            }
        }

        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        public string SQL
        {
            get
            {
                return userSQL.SQL;
            }
            set
            {
                userSQL.SQL = value;
            }
        }

        public string[] DetailColNames
        {
            get
            {
                return userSQL.DetailColNames.Split(',');
            }
            set
            {
                userSQL.DetailColNames = string.Join(",", value);
            }
        }

        public string[] ParamColNames
        {
            get
            {
                return userSQL.ParamColNames.Split(',');
            }
            set
            {
                userSQL.ParamColNames = string.Join(",", value);
            }
        }

        public string[] ListColNames
        {
            get
            {
                return userSQL.ListColNames.Split(',');
            }
            set
            {
                userSQL.ListColNames = string.Join(",", value);
            }
        }

        [Browsable(false)]
        public int Editable
        {
            set
            {
                userSQL.Editable = value;
            }
        }
    }
}
