using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Nikochan.Keiba.KeibaDataAnalyzer.UserControls
{
    public partial class PropertyControl : UserControl
    {
        public PropertyControl()
        {
            InitializeComponent();
        }

        public string Label
        {
            get
            {
                return label.Text;
            }
            set
            {
                label.Text = value;
            }
        }

        public string Value
        {
            get
            {
                return valueLabel.Text;
            }
            set
            {
                valueLabel.Text = value;
            }
        }
    }
}
