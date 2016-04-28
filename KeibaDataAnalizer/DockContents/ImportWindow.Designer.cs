namespace Nikochan.Keiba.KeibaDataAnalyzer.DockContents
{
    partial class ImportWindow
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
        	this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
        	this.toolStrip = new System.Windows.Forms.ToolStrip();
        	this.addToListButton = new System.Windows.Forms.ToolStripButton();
        	this.removeFromListButton = new System.Windows.Forms.ToolStripButton();
        	this.importDBButton = new System.Windows.Forms.ToolStripButton();
        	this.clearCompletedButton = new System.Windows.Forms.ToolStripButton();
        	this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
        	this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
        	this.importFileDataGridView = new System.Windows.Forms.DataGridView();
        	this.toolStrip.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.importFileDataGridView)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// openFileDialog
        	// 
        	this.openFileDialog.Filter = "LZHファイル|*.lzh";
        	this.openFileDialog.Multiselect = true;
        	this.openFileDialog.RestoreDirectory = true;
        	this.openFileDialog.Title = "ファイルを開く";
        	// 
        	// toolStrip
        	// 
        	this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.addToListButton,
			this.removeFromListButton,
			this.importDBButton,
			this.clearCompletedButton});
        	this.toolStrip.Location = new System.Drawing.Point(0, 0);
        	this.toolStrip.Name = "toolStrip";
        	this.toolStrip.Size = new System.Drawing.Size(292, 25);
        	this.toolStrip.TabIndex = 0;
        	// 
        	// addToListButton
        	// 
        	this.addToListButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.addToListButton.Image = global::Nikochan.Keiba.KeibaDataAnalyzer.Properties.Resources.table_row_insert;
        	this.addToListButton.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.addToListButton.Name = "addToListButton";
        	this.addToListButton.Size = new System.Drawing.Size(23, 22);
        	this.addToListButton.Text = "リストに追加(&A)";
        	this.addToListButton.ToolTipText = "リストに追加";
        	this.addToListButton.Click += new System.EventHandler(this.addToListButton_Click);
        	// 
        	// removeFromListButton
        	// 
        	this.removeFromListButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.removeFromListButton.Image = global::Nikochan.Keiba.KeibaDataAnalyzer.Properties.Resources.table_row_delete;
        	this.removeFromListButton.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.removeFromListButton.Name = "removeFromListButton";
        	this.removeFromListButton.Size = new System.Drawing.Size(23, 22);
        	this.removeFromListButton.Text = "リストから削除(&R)";
        	this.removeFromListButton.ToolTipText = "リストから削除";
        	this.removeFromListButton.Click += new System.EventHandler(this.removeFromListButton_Click);
        	// 
        	// importDBButton
        	// 
        	this.importDBButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.importDBButton.Image = global::Nikochan.Keiba.KeibaDataAnalyzer.Properties.Resources.table_save;
        	this.importDBButton.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.importDBButton.Name = "importDBButton";
        	this.importDBButton.Size = new System.Drawing.Size(23, 22);
        	this.importDBButton.Text = "データベースに登録(&I)";
        	this.importDBButton.ToolTipText = "データベースに登録";
        	this.importDBButton.Click += new System.EventHandler(this.importDBButton_Click);
        	// 
        	// clearCompletedButton
        	// 
        	this.clearCompletedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.clearCompletedButton.Image = global::Nikochan.Keiba.KeibaDataAnalyzer.Properties.Resources.table_delete;
        	this.clearCompletedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.clearCompletedButton.Name = "clearCompletedButton";
        	this.clearCompletedButton.Size = new System.Drawing.Size(23, 22);
        	this.clearCompletedButton.Text = "成功したものをクリア(&C)";
        	this.clearCompletedButton.ToolTipText = "成功したものをクリア";
        	this.clearCompletedButton.Click += new System.EventHandler(this.ClearCompletedButtonClick);
        	// 
        	// toolStripButton1
        	// 
        	this.toolStripButton1.Name = "toolStripButton1";
        	this.toolStripButton1.Size = new System.Drawing.Size(23, 23);
        	// 
        	// backgroundWorker
        	// 
        	this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
        	this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
        	// 
        	// importFileDataGridView
        	// 
        	this.importFileDataGridView.AllowDrop = true;
        	this.importFileDataGridView.AllowUserToAddRows = false;
        	this.importFileDataGridView.AllowUserToResizeRows = false;
        	this.importFileDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
        	this.importFileDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.importFileDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.importFileDataGridView.Location = new System.Drawing.Point(0, 25);
        	this.importFileDataGridView.Name = "importFileDataGridView";
        	this.importFileDataGridView.ReadOnly = true;
        	this.importFileDataGridView.RowHeadersVisible = false;
        	this.importFileDataGridView.RowTemplate.Height = 21;
        	this.importFileDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        	this.importFileDataGridView.Size = new System.Drawing.Size(292, 241);
        	this.importFileDataGridView.TabIndex = 1;
        	this.importFileDataGridView.DragDrop += new System.Windows.Forms.DragEventHandler(this.importFileDataGridView_DragDrop);
        	this.importFileDataGridView.DragEnter += new System.Windows.Forms.DragEventHandler(this.importFileDataGridView_DragEnter);
        	// 
        	// ImportWindow
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(292, 266);
        	this.CloseButton = false;
        	this.CloseButtonVisible = false;
        	this.Controls.Add(this.importFileDataGridView);
        	this.Controls.Add(this.toolStrip);
        	this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft) 
			| WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight)));
        	this.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
        	this.Name = "ImportWindow";
        	this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockLeft;
        	this.Text = "データ取り込み";
        	this.toolStrip.ResumeLayout(false);
        	this.toolStrip.PerformLayout();
        	((System.ComponentModel.ISupportInitialize)(this.importFileDataGridView)).EndInit();
        	this.ResumeLayout(false);
        	this.PerformLayout();

        }
        private System.Windows.Forms.ToolStripButton clearCompletedButton;

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton addToListButton;
        private System.Windows.Forms.ToolStripButton removeFromListButton;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton importDBButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.DataGridView importFileDataGridView;
    }
}