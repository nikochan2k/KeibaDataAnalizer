using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using Soma.Core;
using Nikochan.Keiba.KeibaDataAnalyzer.Model;
using Nikochan.Keiba.KeibaDataAnalyzer.Util;


namespace Nikochan.Keiba.KeibaDataAnalyzer.DockContents
{
    public partial class DateWindow : DockContent
    {
        private int currentYear;

        private int currentMonth;

        private IDictionary<string, ResultWindow> resultWindowMap = new Dictionary<string, ResultWindow>();

        public DateWindow()
        {
            InitializeComponent();
            dataControl.DataGridView.MouseDoubleClick += dataGridView_MouseDoubleClick;
        }

        private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (!this.Enabled)
            {
                return;
            }
            if (currentYear != e.Start.Year || currentMonth != e.Start.Month)
            {
                currentYear = e.Start.Year;
                currentMonth = e.Start.Month;
                String month = e.Start.ToString("MM");
                using(var transaction = new Transaction()){
                	var db = transaction.DB;
                	var con = transaction.Connection;
            		var raceDateList = db.Query<DateTime>(
            			con,
            			"SELECT DISTINCT Nengappi FROM Race WHERE KaisaiNen = /* KaisaiNen */'' AND STRFTIME(\"%m\", Nengappi) = /* Tsuki */''",
            			new { KaisaiNen = currentYear, Tsuki = month }
            		);
	            	transaction.Commit();
	            	if (raceDateList.Count > 0)
	                {
	                	this.monthCalendar.BoldedDates = raceDateList.ToArray<DateTime>();
	                    this.monthCalendar.SelectionStart = raceDateList[0];
	                }
                }
            }
        }

        private void monthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
        	IList<dynamic> list;
            using(var transaction = new Transaction()){
            	var db = transaction.DB;
            	var con = transaction.Connection;
        		list = db.Query<dynamic>(
        			con,
        			"SELECT * FROM Race WHERE Nengappi = /* Nengappi */'' ORDER BY KaisaiBasho, RaceBangou",
        			new { Nengappi = e.Start }
        		);
            	transaction.Commit();
            }
            ViewUtil.Bind(dataControl.DataGridView, list, "KaisaiBasho,RaceBangou,Jouken1,TokubetsuMei,Kyori,DirtShiba");
        }

        private void DateWindow_Load(object sender, EventArgs e)
        {
            nameComboBox.ComboBox.DisplayMember = "Name";
            nameComboBox.ComboBox.DataSource = ModelUtil.GetUserSQLList("Race");
            
			DateTime start = DateTime.Now;
            using(var transaction = new Transaction()){
            	var db = transaction.DB;
            	var con = transaction.Connection;
        		var list = db.Query<DateTime?>(
        			con,
        			"SELECT MAX(Nengappi) FROM Race"
        		);
            	if(list[0] != null){
        			start = list[0].Value;
        		}
            }
            monthCalendar.SelectionStart = start;
        }

        private void DateWindowActivated(object sender, EventArgs e)
        {
        }
        
        private void ResultWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            var resultWindow = (ResultWindow)sender;
            var key = resultWindow.Text;
            resultWindowMap.Remove(key);
        }

        private void dataGridView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowRaceResult();
        }

        private void showRaceButton_Click(object sender, EventArgs e)
        {
            ShowRaceResult();
        }

        private void ShowRaceResult()
        {
            if (dataControl.DataGridView.SelectedRows.Count == 0)
            {
                return;
            }

            var dgvr = dataControl.DataGridView.SelectedRows[0];
            var race = (IDictionary<string, object>)dgvr.DataBoundItem;

            var kaisaiBasho = dgvr.Cells["KaisaiBasho"].EditedFormattedValue.ToString();
            var nengappi = (DateTime)race["Nengappi"];
            var yyMMdd = nengappi.ToString("yy/MM/dd");
            var key = yyMMdd + " " + kaisaiBasho
            	+ " " + race["RaceBangou"].ToString() + "R";

            ResultWindow resultWindow;
            if (resultWindowMap.ContainsKey(key))
            {
                resultWindow = resultWindowMap[key];
                resultWindow.Focus();
                return;
            }

            resultWindow = new ResultWindow();
            resultWindowMap.Add(key, resultWindow);
            resultWindow.FormClosed += ResultWindow_FormClosed;
            resultWindow.Text = key;

            var userSQL = (UserSQL)nameComboBox.ComboBox.SelectedItem;

            resultWindow.Show(this.DockPanel, userSQL, race);
        }

        private void editSQLButton_Click(object sender, EventArgs e)
        {
            var editSQLLWindow = new EditSQLWindow();
            editSQLLWindow.ShowDialog(nameComboBox.ComboBox, "Race");
        }
        
    }
}
