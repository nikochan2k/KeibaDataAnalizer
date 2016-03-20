using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Nikochan.Keiba.KeibaDataAnalyzer.Model;
using Nikochan.Keiba.KeibaDataAnalyzer.Util;
using WeifenLuo.WinFormsUI.Docking;

namespace Nikochan.Keiba.KeibaDataAnalyzer.DockContents
{
    public partial class ResultWindow : DockContent
    {
        public ResultWindow()
        {
            InitializeComponent();
        }

        private void ResultWindow_Load(object sender, EventArgs e)
        {
        }

        public void Show(DockPanel dockPanel, UserSQL userSQL, dynamic race)
        {
            base.Show(dockPanel);
            var raceWindow = new RaceWindow();
            raceWindow.Show(this.dockPanel, userSQL, race);
        }
    }
}
