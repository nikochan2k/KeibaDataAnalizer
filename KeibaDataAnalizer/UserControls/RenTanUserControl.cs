using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Nikochan.Keiba.KeibaDataAnalyzer.UserControls
{
    public partial class RenTanUserControl : UserControl
    {

        public RenTanUserControl()
        {
            this.ColumnName = "Umaban";
            this.Length = 2;
            InitializeComponent();
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
                return jouiUnitLabel.Text;
            }
            set
            {
                jouiUnitLabel.Text = value;
                jikuUnitLabel.Text = value;
            }
        }

        public int JouiTousuu
        {
            get
            {
                return (int)jouiNumericUpDown.Value;
            }
        }

        public int MaxJouiTousuu
        {
            get
            {
                return (int)jouiNumericUpDown.Maximum;
            }
            set
            {
                jouiNumericUpDown.Maximum = value;
                jikuNumericUpDown.Maximum = value - (jouiNumericUpDown.Minimum - 1);
            }
        }

        public int JikuTousuu
        {
            get
            {
                return (int)jikuNumericUpDown.Value;
            }
        }

        public int MaxJikuTousuu
        {
            get
            {
                return (int)jikuNumericUpDown.Maximum;
            }
        }

        public int MinJouiTousuu
        {
            get
            {
                return (int)jouiNumericUpDown.Minimum;
            }
            set
            {
                jouiNumericUpDown.Minimum = value;
            }
        }

        public bool Checked
        {
            get
            {
                return checkBox.Checked;
            }
        }

        public int Length { get; set; }

        public bool IsRen { get; set; }

        public string ColumnName { get; set; }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            jouiLabel.Enabled = checkBox.Checked;
            jouiNumericUpDown.Enabled = checkBox.Checked;
            jouiUnitLabel.Enabled = checkBox.Checked;
            jikuLabel.Enabled = checkBox.Checked;
            jikuNumericUpDown.Enabled = checkBox.Checked;
            jikuUnitLabel.Enabled = checkBox.Checked;
        }

        private void jouiNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (jouiNumericUpDown.Value < jikuNumericUpDown.Value + jouiNumericUpDown.Minimum - 1)
            {
                jikuNumericUpDown.Value = jouiNumericUpDown.Value - (jouiNumericUpDown.Minimum - 1);
            }
        }

        private void jikuNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (jouiNumericUpDown.Value < jikuNumericUpDown.Value + jouiNumericUpDown.Minimum - 1)
            {
                jikuNumericUpDown.Value = jouiNumericUpDown.Value - (jouiNumericUpDown.Minimum - 1);
            }
        }
    }
}
