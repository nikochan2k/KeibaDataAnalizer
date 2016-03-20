using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

using Nikochan.Keiba.KeibaDataAnalyzer.Model;
using Nikochan.Keiba.KeibaDataAnalyzer.Util;

namespace Nikochan.Keiba.KeibaDataAnalyzer.DockContents
{
    public partial class RaceWindow : DockContent
    {
        public RaceWindow()
        {
            InitializeComponent();
            dataControl.DataGridView.MouseDoubleClick += dataGridView_MouseDoubleClick;
            dataControl.DataGridView.MouseClick += dataGridView_MouseClick;
            dataControl.DataGridView.KeyDown += DataGridViewKeyDown;
        }

        public delegate void ShussoubaSelectedHandler(UserSQL userSQL, IDictionary<string,object> shussouba);

        public event ShussoubaSelectedHandler ShussoubaSelected;

        private void ResultWindow_Load(object sender, EventArgs e)
        {
            nameComboBox.ComboBox.DisplayMember = "Name";
            nameComboBox.ComboBox.DataSource = ModelUtil.GetUserSQLList("Shussouba");
        }

        private IDictionary<string, ShussoubaWindow> shussoubaWindowMap = new Dictionary<string, ShussoubaWindow>();

        public void Show(DockPanel dockPanel, UserSQL userSQL, dynamic drv)
        {
            base.Show(dockPanel);
            dataControl.Setup(userSQL, drv);
        }

        private void OnShussoubaSelected()
        {
            if (ShussoubaSelected == null)
            {
                return;
            }
            if (dataControl.DataGridView.SelectedRows.Count == 0)
            {
                return;
            }
        	var userSQL = (UserSQL)nameComboBox.ComboBox.SelectedItem;
            OnShussoubaSelected(userSQL);
        }

        private void OnShussoubaSelected(UserSQL userSQL)
        {
        	var shussouba = (IDictionary<string,object>)dataControl.DataGridView.SelectedRows[0].DataBoundItem;
            ShussoubaSelected(userSQL, shussouba);
        }

        private void DataGridViewKeyDown(object sender, KeyEventArgs e)
        {
        	if(e.KeyData == Keys.Up || e.KeyData == Keys.Down){
        		OnShussoubaSelected();
        	}
        }
        
        private void dataGridView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        	var userSQL = (UserSQL)nameComboBox.ComboBox.SelectedItem;
            var name = userSQL.Name;
            if (!shussoubaWindowMap.ContainsKey(name))
            {
                var shussoubaWindow = new ShussoubaWindow();
                shussoubaWindow.Text = name;
                shussoubaWindow.Show(this.DockPanel, this);
                OnShussoubaSelected(userSQL);
                shussoubaWindowMap.Add(name, shussoubaWindow);
            }
        }

        private void dataGridView_MouseClick(object sender, MouseEventArgs e)
        {
            OnShussoubaSelected();
        }
        
        private void editSQLButton_Click(object sender, EventArgs e)
        {
            var editSQLLWindow = new EditSQLWindow();
            editSQLLWindow.ShowDialog(nameComboBox.ComboBox, "Shussouba");
        }
    }
}
