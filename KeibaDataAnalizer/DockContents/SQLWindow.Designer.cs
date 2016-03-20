namespace Nikochan.Keiba.KeibaDataAnalyzer.DockContents
{
    partial class SQLWindow
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
        	System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
        	this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
        	this.toolStrip1 = new System.Windows.Forms.ToolStrip();
        	this.saveSQLButton = new System.Windows.Forms.ToolStripButton();
        	this.nameComboBox = new System.Windows.Forms.ToolStripComboBox();
        	this.executeButton = new System.Windows.Forms.ToolStripButton();
        	this.exportCSVButton = new System.Windows.Forms.ToolStripButton();
        	this.splitContainer = new System.Windows.Forms.SplitContainer();
        	this.sqlTextBox = new System.Windows.Forms.TextBox();
        	this.dataGridView = new System.Windows.Forms.DataGridView();
        	this.toolStrip1.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
        	this.splitContainer.Panel1.SuspendLayout();
        	this.splitContainer.Panel2.SuspendLayout();
        	this.splitContainer.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// saveFileDialog
        	// 
        	this.saveFileDialog.DefaultExt = "csv";
        	this.saveFileDialog.FileName = "export.csv";
        	this.saveFileDialog.Filter = "CSVファイル|*.csv";
        	this.saveFileDialog.RestoreDirectory = true;
        	this.saveFileDialog.Title = "CSVファイルを保存";
        	// 
        	// toolStrip1
        	// 
        	this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.saveSQLButton,
        	        	        	this.nameComboBox,
        	        	        	this.executeButton,
        	        	        	this.exportCSVButton});
        	this.toolStrip1.Location = new System.Drawing.Point(0, 0);
        	this.toolStrip1.Name = "toolStrip1";
        	this.toolStrip1.Size = new System.Drawing.Size(284, 26);
        	this.toolStrip1.TabIndex = 0;
        	this.toolStrip1.Text = "toolStrip";
        	// 
        	// saveSQLButton
        	// 
        	this.saveSQLButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.saveSQLButton.Image = global::Nikochan.Keiba.KeibaDataAnalyzer.Properties.Resources.action_save;
        	this.saveSQLButton.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.saveSQLButton.Name = "saveSQLButton";
        	this.saveSQLButton.Size = new System.Drawing.Size(23, 23);
        	this.saveSQLButton.Text = "SQL保存";
        	this.saveSQLButton.Click += new System.EventHandler(this.saveSQLButton_Click);
        	// 
        	// nameComboBox
        	// 
        	this.nameComboBox.Name = "nameComboBox";
        	this.nameComboBox.Size = new System.Drawing.Size(200, 26);
        	this.nameComboBox.SelectedIndexChanged += new System.EventHandler(this.nameComboBox_SelectedIndexChanged);
        	// 
        	// executeButton
        	// 
        	this.executeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.executeButton.Image = global::Nikochan.Keiba.KeibaDataAnalyzer.Properties.Resources.action_go;
        	this.executeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.executeButton.Name = "executeButton";
        	this.executeButton.Size = new System.Drawing.Size(23, 23);
        	this.executeButton.Text = "SQL実行";
        	this.executeButton.Click += new System.EventHandler(this.executeButton_Click);
        	// 
        	// exportCSVButton
        	// 
        	this.exportCSVButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.exportCSVButton.Image = global::Nikochan.Keiba.KeibaDataAnalyzer.Properties.Resources.Icon_csv;
        	this.exportCSVButton.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.exportCSVButton.Name = "exportCSVButton";
        	this.exportCSVButton.Size = new System.Drawing.Size(23, 23);
        	this.exportCSVButton.Text = "CSV出力";
        	this.exportCSVButton.Click += new System.EventHandler(this.exportCSVButton_Click);
        	// 
        	// splitContainer
        	// 
        	this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.splitContainer.Location = new System.Drawing.Point(0, 26);
        	this.splitContainer.Name = "splitContainer";
        	this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
        	// 
        	// splitContainer.Panel1
        	// 
        	this.splitContainer.Panel1.Controls.Add(this.sqlTextBox);
        	// 
        	// splitContainer.Panel2
        	// 
        	this.splitContainer.Panel2.Controls.Add(this.dataGridView);
        	this.splitContainer.Size = new System.Drawing.Size(284, 236);
        	this.splitContainer.SplitterDistance = 94;
        	this.splitContainer.TabIndex = 1;
        	// 
        	// sqlTextBox
        	// 
        	this.sqlTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.sqlTextBox.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
        	this.sqlTextBox.Location = new System.Drawing.Point(0, 0);
        	this.sqlTextBox.Multiline = true;
        	this.sqlTextBox.Name = "sqlTextBox";
        	this.sqlTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        	this.sqlTextBox.Size = new System.Drawing.Size(284, 94);
        	this.sqlTextBox.TabIndex = 0;
        	// 
        	// dataGridView
        	// 
        	this.dataGridView.AllowUserToAddRows = false;
        	this.dataGridView.AllowUserToDeleteRows = false;
        	this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
        	this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.dataGridView.Location = new System.Drawing.Point(0, 0);
        	this.dataGridView.MultiSelect = false;
        	this.dataGridView.Name = "dataGridView";
        	this.dataGridView.ReadOnly = true;
        	dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
        	dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
        	dataGridViewCellStyle1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
        	dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
        	dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
        	dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        	dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        	this.dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
        	this.dataGridView.RowHeadersVisible = false;
        	this.dataGridView.RowTemplate.Height = 21;
        	this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        	this.dataGridView.Size = new System.Drawing.Size(284, 138);
        	this.dataGridView.TabIndex = 0;
        	// 
        	// SQLWindow
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(284, 262);
        	this.Controls.Add(this.splitContainer);
        	this.Controls.Add(this.toolStrip1);
        	this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.Document)));
        	this.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
        	this.Name = "SQLWindow";
        	this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.Document;
        	this.Text = "SQL発行";
        	this.Load += new System.EventHandler(this.SQLWindow_Load);
        	this.toolStrip1.ResumeLayout(false);
        	this.toolStrip1.PerformLayout();
        	this.splitContainer.Panel1.ResumeLayout(false);
        	this.splitContainer.Panel1.PerformLayout();
        	this.splitContainer.Panel2.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
        	this.splitContainer.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox nameComboBox;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TextBox sqlTextBox;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ToolStripButton executeButton;
        private System.Windows.Forms.ToolStripButton saveSQLButton;
        private System.Windows.Forms.ToolStripButton exportCSVButton;
    }
}