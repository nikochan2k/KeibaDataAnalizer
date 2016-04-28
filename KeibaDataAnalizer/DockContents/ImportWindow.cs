using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

using WeifenLuo.WinFormsUI.Docking;
using NLog;

using Nikochan.Keiba.KeibaDataAnalyzer.Model;
using Nikochan.Keiba.KeibaDataAnalyzer.Util;
using Nikochan.Keiba.KeibaDataAnalyzer.Enum;
using Nikochan.Keiba.KeibaDataAnalyzer.Logic;
using Nikochan.Keiba.KeibaDataAnalyzer.Logic.Importer;
using Nikochan.Keiba.KeibaDataAnalyzer.Logic.ImporterFactory;

namespace Nikochan.Keiba.KeibaDataAnalyzer.DockContents
{

	public partial class ImportWindow : DockContent
	{
		private static readonly Logger LOGGER = LogManager.GetCurrentClassLogger();
			
        private readonly ImporterListFactory importListFactory = new ImporterListFactory();

        private readonly BindingList<ImportHistory> importHistoryList = new BindingList<ImportHistory>();

        private readonly String extractFolder;
        
        private readonly IList<UserSQL> preImportSQLList;

        private readonly IList<UserSQL> postImportSQLList;

        public ImportWindow()
		{
			InitializeComponent();
			
			preImportSQLList = ModelUtil.GetUserSQLList("PreImport");
			postImportSQLList = ModelUtil.GetUserSQLList("PostImport");
			
            extractFolder = Path.Combine(
                Environment.GetEnvironmentVariable("TEMP"),
                "KeibaDataAnalizer");
			
            importFileDataGridView.AutoGenerateColumns = false;
            var col1 = new DataGridViewTextBoxColumn();
            col1.DataPropertyName = "FileName";
            col1.HeaderText = "ファイル名";
            importFileDataGridView.Columns.Add(col1);
            var col2 = new DataGridViewTextBoxColumn();
            col2.DataPropertyName = "Progress";
            col2.HeaderText = "進捗";
            importFileDataGridView.Columns.Add(col2);
            var col3 = new DataGridViewTextBoxColumn();
            col3.DataPropertyName = "Status";
            col3.HeaderText = "状態";
            importFileDataGridView.Columns.Add(col3);
            
            importFileDataGridView.DataSource = importHistoryList;
        }

		#region メソッド

		private void addFileNames(string[] filePathes)
		{
			foreach (string filePath in filePathes)
			{
                var importHistory = ImportHistory.CreateInstance(filePath);
                if (importHistory == null)
                {
                    continue;
                }
                if (importHistoryList.Contains(importHistory))
                {
                    continue;
                }
                importHistoryList.Add(importHistory);
			}
        }
		
		#endregion

		#region イベント

		private void addToListButton_Click(object sender, EventArgs e)
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				var filePathes = openFileDialog.FileNames;
				addFileNames(filePathes);
			}
		}

        private void importFileDataGridView_DragDrop(object sender, DragEventArgs e)
        {
            var filePathes = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            addFileNames(filePathes);
        }

        private void importFileDataGridView_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
                return;
            }
            e.Effect = DragDropEffects.None;
        }

		private void removeFromListButton_Click(object sender, EventArgs e)
		{
            foreach (DataGridViewRow row in importFileDataGridView.SelectedRows)
            {
                if (!row.IsNewRow)
                {
                    importFileDataGridView.Rows.Remove(row);
                }
            }
        }

        private void importDBButton_Click(object sender, EventArgs e)
		{
        	var dockPanel = (DockPanel)this.DockPanel;
        	var parent = (MainForm)dockPanel.Parent;
            parent.EnabledExceptFor(this, false);
            toolStrip.Enabled = false;
            this.AllowDrop = false;
            backgroundWorker.RunWorkerAsync();
		}
        
        private void ClearCompletedButtonClick(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in importFileDataGridView.Rows)
            {
            	var importHistory = row.DataBoundItem as ImportHistory;
                if (importHistory.Status == ImportFileStatusEnum.成功)
                {
                    importFileDataGridView.Rows.Remove(row);
                }
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
	        using(var transaction = new Transaction()){
	        	var db = transaction.DB;
	        	var con = transaction.Connection;
	        	foreach (var userSQL in preImportSQLList) {
	        		try{
		        		db.Execute(con, userSQL.SQL);
	        		} catch(Exception ex){
	        			LOGGER.Error(CommonUtil.FlattenException(ex));
	        		}
	        	}
        	}
            foreach (var importHistory in importHistoryList)
            {
                try
                {
                    if (Directory.Exists(extractFolder))
                    {
                        Directory.Delete(extractFolder, true);
                    }
                    LHAUtil.LhaExtractArchive(importHistory.FilePath, extractFolder);
                    var filePathes = Directory.GetFiles(extractFolder);
                    foreach(string filePath in filePathes)
                    {
                        importHistory.Length += new FileInfo(filePath).Length;
                    }
                    var importerList = importListFactory.CreateImporterList(importHistory, filePathes);
                    importHistory.Status = ImportFileStatusEnum.取込中;
                    foreach (var importer in importerList)
                    {
                        importer.Import();
                    }
                    importHistory.Index = (int)importHistory.Length;

                    importHistory.Save();
                }
                catch (Exception ex)
                {
                	var message = CommonUtil.FlattenException(ex);
                	LOGGER.Error(message);
                    MessageBox.Show(message,
                        "予期せぬエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
	        using(var transaction = new Transaction()){
	        	var db = transaction.DB;
	        	var con = transaction.Connection;
	        	foreach (var userSQL in postImportSQLList) {
	        		try{
		        		db.Execute(con, userSQL.SQL);
	        		} catch(Exception ex) {
	        			LOGGER.Error(CommonUtil.FlattenException(ex));
	        		}
	        	}
        	}
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.AllowDrop = true;
            toolStrip.Enabled = true;
            var dockPanel = (DockPanel)this.DockPanel;
            var parent = (MainForm)dockPanel.Parent;
            parent.EnabledExceptFor(this, true);
            this.importFileDataGridView.Refresh();
        }

        #endregion

    }
}
