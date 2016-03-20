using System;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

using Nikochan.Keiba.KeibaDataAnalyzer.DockContents;
using Nikochan.Keiba.KeibaDataAnalyzer.SQLite;
using Nikochan.Keiba.KeibaDataAnalyzer.Util;
using Nikochan.Keiba.KeibaDataAnalyzer.Model;

using System.Data.SQLite;
using NLog;
using Soma.Core;

namespace Nikochan.Keiba.KeibaDataAnalyzer
{
	public partial class MainForm : Form
	{
		private static readonly Logger LOGGER = LogManager.GetCurrentClassLogger();
		
		private ImportWindow importWindow = new ImportWindow();

        private DateWindow dateWindow = new DateWindow();

        private TekichuuWindow tekichuuWindow = new TekichuuWindow();

        private SQLWindow sqlWindow = new SQLWindow();

		public MainForm()
		{
			InitializeComponent();
		}

        public void EnabledExceptFor(DockContent dockContent, bool enabled)
        {
            if (importWindow != dockContent)
            {
                importWindow.Enabled = enabled;
            }
            if (dateWindow != dockContent)
            {
                dateWindow.Enabled = enabled;
            }
            if (tekichuuWindow != dockContent)
            {
                tekichuuWindow.Enabled = enabled;
            }
            if (sqlWindow != dockContent)
            {
                sqlWindow.Enabled = enabled;
            }
        }

		private void importMenuItem_Click(object sender, EventArgs e)
		{
            if (importWindow == null || importWindow.Disposing || importWindow.IsDisposed)
            {
                importWindow = new ImportWindow();
            }
			importWindow.Show(dockPanel);
		}

        private void searchMenuItem_Click(object sender, EventArgs e)
        {
            if (dateWindow == null || dateWindow.Disposing || dateWindow.IsDisposed)
            {
                dateWindow = new DateWindow();
            }
            dateWindow.Show(dockPanel);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            importWindow.Show(dockPanel);
            dateWindow.Show(dockPanel);
        }

        private void sqlMenuItem_Click(object sender, EventArgs e)
        {
            if (sqlWindow == null || sqlWindow.Disposing || sqlWindow.IsDisposed)
            {
                sqlWindow = new SQLWindow();
            }
            sqlWindow.Show(dockPanel);
        }

        private void tekichuuMenuItem_Click(object sender, EventArgs e)
        {
            if (tekichuuWindow == null || tekichuuWindow.Disposing || tekichuuWindow.IsDisposed)
            {
                tekichuuWindow = new TekichuuWindow();
            }
            tekichuuWindow.Show(dockPanel);
        }
    
        private const string RACE_SQL = "SELECT * FROM Race";
        
        private void RaceOnlyMenuItemClick(object sender, EventArgs e)
        {
        	using(var t = new Transaction()){
        		var db = t.DB;
        		var con = t.Connection;
        		var raceEnu = db.QueryOnDemand<Race>(con, RACE_SQL);
        		foreach (var race in raceEnu) {
        			foreach (var userSQL in ModelUtil.GetUserSQLList("PostShutsubahyouRaceImport")) {
		        		db.Execute(con, userSQL.SQL, race);
        			}
        			foreach (var userSQL in ModelUtil.GetUserSQLList("PostSeisekiRaceImport")) {
		        		db.Execute(con, userSQL.SQL, race);
        			}
        		}
        		
        		t.Commit();
        	}
        }
        
        private const string SHUSSOUBA_SQL = "SELECT * FROM Shussouba WHERE RaceId = /* Id */0";
        
        private void RaceAndShussoubaMenuItemClick(object sender, EventArgs e)
        {
        	using(var t = new Transaction()){
        		var db = t.DB;
        		var con = t.Connection;
        		var raceEnu = db.QueryOnDemand<Race>(con, RACE_SQL);
        		foreach (var race in raceEnu) {
        			// 出走馬データのカスタムクエリ実行
        			var shussoubaEnu = db.QueryOnDemand<Shussouba>(con, SHUSSOUBA_SQL, race);
        			foreach (var shussouba in shussoubaEnu) {
	        			foreach (var userSQL in ModelUtil.GetUserSQLList("PostShutsubahyouShussoubaImport")) {
			        		db.Execute(con, userSQL.SQL, race);
	        			}
	        			foreach (var userSQL in ModelUtil.GetUserSQLList("PostSeisekiShussoubaImport")) {
			        		db.Execute(con, userSQL.SQL, race);
	        			}
        			}
        			// レースデータのカスタムクエリ実行
        			foreach (var userSQL in ModelUtil.GetUserSQLList("PostShutsubahyouRaceImport")) {
		        		db.Execute(con, userSQL.SQL, race);
        			}
        			foreach (var userSQL in ModelUtil.GetUserSQLList("PostSeisekiRaceImport")) {
		        		db.Execute(con, userSQL.SQL, race);
        			}
        		}
        		
        		t.Commit();
        	}
        }
	}
}
