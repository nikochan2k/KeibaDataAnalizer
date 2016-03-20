using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Nikochan.Keiba.KeibaDataAnalyzer.UserControls
{
    public partial class ShouUserControl : UserControl
    {
        public ShouUserControl()
        {
            this.ColumnName = "Umaban";
            InitializeComponent();
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            jouiLabel.Enabled = checkBox.Checked;
            numericUpDown.Enabled = checkBox.Checked;
            unitLabel.Enabled = checkBox.Checked;
        }

        public string Caption
        {
            get
            {
                return checkBox.Text;
            }
            set
            {
                checkBox.Text = value;
            }
        }

        public string Unit
        {
            get
            {
                return unitLabel.Text;
            }
            set
            {
                unitLabel.Text = value;
            }
        }

        public int Tousuu
        {
            get
            {
                return (int)numericUpDown.Value;
            }
        }

        public int MaxTousuu
        {
            get
            {
                return (int)numericUpDown.Maximum;
            }
            set
            {
                numericUpDown.Maximum = value;
            }
        }

        public bool Checked
        {
            get
            {
                return checkBox.Checked;
            }
        }

        public string ColumnName { get; set; }
    }
}
