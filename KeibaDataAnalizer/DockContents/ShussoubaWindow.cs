using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;
using Nikochan.Keiba.KeibaDataAnalyzer.Util;
using Nikochan.Keiba.KeibaDataAnalyzer.UserControls;
using Nikochan.Keiba.KeibaDataAnalyzer.Model;

namespace Nikochan.Keiba.KeibaDataAnalyzer.DockContents
{
    public partial class ShussoubaWindow : DockContent
    {
    	private UserSQL userSQL;
    	
        public ShussoubaWindow()
        {
            InitializeComponent();
        }

        public void Show(DockPanel dockPanel, RaceWindow raceWindow)
        {
            base.Show(dockPanel);
            raceWindow.ShussoubaSelected += ShussoubaSelected;
        }

        public void ShussoubaSelected(UserSQL userSQL, IDictionary<string,object> shussouba)
        {
        	if(this.userSQL != null){
        		if(!this.userSQL.Domain.Equals(userSQL.Domain) || !this.userSQL.Name.Equals(userSQL.Name)){
        			return;
        		}
        	}
        	this.userSQL = userSQL;
            dataControl.Setup(userSQL, shussouba);
        }

        public DataControl DataControl
        {
            get
            {
                return dataControl;
            }
        }

    }
}
