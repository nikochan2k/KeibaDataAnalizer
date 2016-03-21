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
            AddEventsToDockContent(importWindow, importMenuItem);
            AddEventsToDockContent(dateWindow, searchMenuItem);
            AddEventsToDockContent(tekichuuWindow, tekichuuMenuItem);
            AddEventsToDockContent(sqlWindow, sqlMenuItem);
		}

        private void AddEventsToDockContent(DockContent content, ToolStripMenuItem menuItem)
        {
            content.Load += (sender, e) =>
            {
                menuItem.Checked = true;
            };
            content.FormClosed += (sender, e) =>
            {
                menuItem.Checked = false;
            };
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
            dateWindow.Show(dockPanel);
            importWindow.Show(dockPanel);
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
    
	}
}
