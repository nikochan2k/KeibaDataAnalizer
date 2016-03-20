namespace Nikochan.Keiba.KeibaDataAnalyzer.DockContents
{
    partial class TekichuuWindow
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
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.raceSelectLabel = new System.Windows.Forms.ToolStripLabel();
            this.editRaceSelectionSQLButton = new System.Windows.Forms.ToolStripButton();
            this.raceSelectionComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.separator1 = new System.Windows.Forms.ToolStripSeparator();
            this.shussoubaSelectionLabel = new System.Windows.Forms.ToolStripLabel();
            this.editShussoubaSelectionSQLButton = new System.Windows.Forms.ToolStripButton();
            this.shussoubaSelectionComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.executeButton = new System.Windows.Forms.ToolStripButton();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.tanshouUserControl = new Nikochan.Keiba.KeibaDataAnalyzer.UserControls.ShouUserControl();
            this.fukushouUserControl = new Nikochan.Keiba.KeibaDataAnalyzer.UserControls.ShouUserControl();
            this.wakurenUserControl = new Nikochan.Keiba.KeibaDataAnalyzer.UserControls.RenTanUserControl();
            this.umarenUserControl = new Nikochan.Keiba.KeibaDataAnalyzer.UserControls.RenTanUserControl();
            this.umatanUserControl = new Nikochan.Keiba.KeibaDataAnalyzer.UserControls.RenTanUserControl();
            this.wideUserControl = new Nikochan.Keiba.KeibaDataAnalyzer.UserControls.RenTanUserControl();
            this.sanrenpukuUserControl = new Nikochan.Keiba.KeibaDataAnalyzer.UserControls.RenTanUserControl();
            this.sanrentanUserControl = new Nikochan.Keiba.KeibaDataAnalyzer.UserControls.RenTanUserControl();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.toolStrip.SuspendLayout();
            this.flowLayoutPanel.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.raceSelectLabel,
            this.editRaceSelectionSQLButton,
            this.raceSelectionComboBox,
            this.separator1,
            this.shussoubaSelectionLabel,
            this.editShussoubaSelectionSQLButton,
            this.shussoubaSelectionComboBox,
            this.toolStripSeparator1,
            this.executeButton});
            this.toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(646, 26);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // raceSelectLabel
            // 
            this.raceSelectLabel.Name = "raceSelectLabel";
            this.raceSelectLabel.Size = new System.Drawing.Size(92, 18);
            this.raceSelectLabel.Text = "レース選択SQL";
            // 
            // editRaceSelectionSQLButton
            // 
            this.editRaceSelectionSQLButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.editRaceSelectionSQLButton.Image = global::Nikochan.Keiba.KeibaDataAnalyzer.Properties.Resources.icon_settings;
            this.editRaceSelectionSQLButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editRaceSelectionSQLButton.Name = "editRaceSelectionSQLButton";
            this.editRaceSelectionSQLButton.Size = new System.Drawing.Size(23, 20);
            this.editRaceSelectionSQLButton.Text = "レース選択SQLの編集";
            this.editRaceSelectionSQLButton.Click += new System.EventHandler(this.editRaceSQLButton_Click);
            // 
            // raceSelectionComboBox
            // 
            this.raceSelectionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.raceSelectionComboBox.Name = "raceSelectionComboBox";
            this.raceSelectionComboBox.Size = new System.Drawing.Size(160, 26);
            // 
            // separator1
            // 
            this.separator1.Name = "separator1";
            this.separator1.Size = new System.Drawing.Size(6, 23);
            // 
            // shussoubaSelectionLabel
            // 
            this.shussoubaSelectionLabel.Name = "shussoubaSelectionLabel";
            this.shussoubaSelectionLabel.Size = new System.Drawing.Size(92, 18);
            this.shussoubaSelectionLabel.Text = "競走馬選択SQL";
            // 
            // editShussoubaSelectionSQLButton
            // 
            this.editShussoubaSelectionSQLButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.editShussoubaSelectionSQLButton.Image = global::Nikochan.Keiba.KeibaDataAnalyzer.Properties.Resources.icon_settings;
            this.editShussoubaSelectionSQLButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editShussoubaSelectionSQLButton.Name = "editShussoubaSelectionSQLButton";
            this.editShussoubaSelectionSQLButton.Size = new System.Drawing.Size(23, 20);
            this.editShussoubaSelectionSQLButton.Text = "競走馬指数SQLの編集";
            this.editShussoubaSelectionSQLButton.Click += new System.EventHandler(this.editHorseSQLButton_Click);
            // 
            // shussoubaSelectionComboBox
            // 
            this.shussoubaSelectionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shussoubaSelectionComboBox.Name = "shussoubaSelectionComboBox";
            this.shussoubaSelectionComboBox.Size = new System.Drawing.Size(160, 26);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // executeButton
            // 
            this.executeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.executeButton.Image = global::Nikochan.Keiba.KeibaDataAnalyzer.Properties.Resources.action_go;
            this.executeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.executeButton.Name = "executeButton";
            this.executeButton.Size = new System.Drawing.Size(23, 20);
            this.executeButton.Text = "実行";
            this.executeButton.Click += new System.EventHandler(this.executeButton_Click);
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoSize = true;
            this.flowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel.Controls.Add(this.tanshouUserControl);
            this.flowLayoutPanel.Controls.Add(this.fukushouUserControl);
            this.flowLayoutPanel.Controls.Add(this.wakurenUserControl);
            this.flowLayoutPanel.Controls.Add(this.umarenUserControl);
            this.flowLayoutPanel.Controls.Add(this.umatanUserControl);
            this.flowLayoutPanel.Controls.Add(this.wideUserControl);
            this.flowLayoutPanel.Controls.Add(this.sanrenpukuUserControl);
            this.flowLayoutPanel.Controls.Add(this.sanrentanUserControl);
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 26);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(646, 132);
            this.flowLayoutPanel.TabIndex = 20;
            // 
            // tanshouUserControl
            // 
            this.tanshouUserControl.AutoSize = true;
            this.tanshouUserControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tanshouUserControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tanshouUserControl.Caption = "単勝";
            this.tanshouUserControl.ColumnName = "Umaban";
            this.tanshouUserControl.Location = new System.Drawing.Point(3, 3);
            this.tanshouUserControl.MaxTousuu = 18;
            this.tanshouUserControl.Name = "tanshouUserControl";
            this.tanshouUserControl.Size = new System.Drawing.Size(149, 27);
            this.tanshouUserControl.TabIndex = 21;
            this.tanshouUserControl.Unit = "頭";
            // 
            // fukushouUserControl
            // 
            this.fukushouUserControl.AutoSize = true;
            this.fukushouUserControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.fukushouUserControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fukushouUserControl.Caption = "複勝";
            this.fukushouUserControl.ColumnName = "Umaban";
            this.fukushouUserControl.Location = new System.Drawing.Point(158, 3);
            this.fukushouUserControl.MaxTousuu = 18;
            this.fukushouUserControl.Name = "fukushouUserControl";
            this.fukushouUserControl.Size = new System.Drawing.Size(149, 27);
            this.fukushouUserControl.TabIndex = 22;
            this.fukushouUserControl.Unit = "頭";
            // 
            // wakurenUserControl
            // 
            this.wakurenUserControl.AutoSize = true;
            this.wakurenUserControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.wakurenUserControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.wakurenUserControl.Caption = "枠連";
            this.wakurenUserControl.ColumnName = "Wakuban";
            this.wakurenUserControl.IsRen = true;
            this.wakurenUserControl.Length = 2;
            this.wakurenUserControl.Location = new System.Drawing.Point(313, 3);
            this.wakurenUserControl.MaxJouiTousuu = 8;
            this.wakurenUserControl.MinJouiTousuu = 2;
            this.wakurenUserControl.Name = "wakurenUserControl";
            this.wakurenUserControl.Size = new System.Drawing.Size(230, 27);
            this.wakurenUserControl.TabIndex = 21;
            this.wakurenUserControl.Unit = "枠";
            // 
            // umarenUserControl
            // 
            this.umarenUserControl.AutoSize = true;
            this.umarenUserControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.umarenUserControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.umarenUserControl.Caption = "馬連";
            this.umarenUserControl.ColumnName = "Umaban";
            this.umarenUserControl.IsRen = true;
            this.umarenUserControl.Length = 2;
            this.umarenUserControl.Location = new System.Drawing.Point(3, 36);
            this.umarenUserControl.MaxJouiTousuu = 18;
            this.umarenUserControl.MinJouiTousuu = 2;
            this.umarenUserControl.Name = "umarenUserControl";
            this.umarenUserControl.Size = new System.Drawing.Size(230, 27);
            this.umarenUserControl.TabIndex = 21;
            this.umarenUserControl.Unit = "頭";
            // 
            // umatanUserControl
            // 
            this.umatanUserControl.AutoSize = true;
            this.umatanUserControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.umatanUserControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.umatanUserControl.Caption = "馬単";
            this.umatanUserControl.ColumnName = "Umaban";
            this.umatanUserControl.IsRen = false;
            this.umatanUserControl.Length = 2;
            this.umatanUserControl.Location = new System.Drawing.Point(239, 36);
            this.umatanUserControl.MaxJouiTousuu = 18;
            this.umatanUserControl.MinJouiTousuu = 2;
            this.umatanUserControl.Name = "umatanUserControl";
            this.umatanUserControl.Size = new System.Drawing.Size(230, 27);
            this.umatanUserControl.TabIndex = 21;
            this.umatanUserControl.Unit = "頭";
            // 
            // wideUserControl
            // 
            this.wideUserControl.AutoSize = true;
            this.wideUserControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.wideUserControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.wideUserControl.Caption = "ワイド";
            this.wideUserControl.ColumnName = "Umaban";
            this.wideUserControl.IsRen = true;
            this.wideUserControl.Length = 2;
            this.wideUserControl.Location = new System.Drawing.Point(3, 69);
            this.wideUserControl.MaxJouiTousuu = 18;
            this.wideUserControl.MinJouiTousuu = 2;
            this.wideUserControl.Name = "wideUserControl";
            this.wideUserControl.Size = new System.Drawing.Size(233, 27);
            this.wideUserControl.TabIndex = 21;
            this.wideUserControl.Unit = "頭";
            // 
            // sanrenpukuUserControl
            // 
            this.sanrenpukuUserControl.AutoSize = true;
            this.sanrenpukuUserControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.sanrenpukuUserControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sanrenpukuUserControl.Caption = "3連複";
            this.sanrenpukuUserControl.ColumnName = "Umaban";
            this.sanrenpukuUserControl.IsRen = true;
            this.sanrenpukuUserControl.Length = 3;
            this.sanrenpukuUserControl.Location = new System.Drawing.Point(242, 69);
            this.sanrenpukuUserControl.MaxJouiTousuu = 18;
            this.sanrenpukuUserControl.MinJouiTousuu = 3;
            this.sanrenpukuUserControl.Name = "sanrenpukuUserControl";
            this.sanrenpukuUserControl.Size = new System.Drawing.Size(236, 27);
            this.sanrenpukuUserControl.TabIndex = 21;
            this.sanrenpukuUserControl.Unit = "頭";
            // 
            // sanrentanUserControl
            // 
            this.sanrentanUserControl.AutoSize = true;
            this.sanrentanUserControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.sanrentanUserControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sanrentanUserControl.Caption = "3連単";
            this.sanrentanUserControl.ColumnName = "Umaban";
            this.sanrentanUserControl.IsRen = false;
            this.sanrentanUserControl.Length = 3;
            this.sanrentanUserControl.Location = new System.Drawing.Point(3, 102);
            this.sanrentanUserControl.MaxJouiTousuu = 18;
            this.sanrentanUserControl.MinJouiTousuu = 3;
            this.sanrentanUserControl.Name = "sanrentanUserControl";
            this.sanrentanUserControl.Size = new System.Drawing.Size(236, 27);
            this.sanrentanUserControl.TabIndex = 21;
            this.sanrentanUserControl.Unit = "頭";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 302);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(646, 22);
            this.statusStrip.TabIndex = 22;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(200, 16);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 158);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowTemplate.Height = 21;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(646, 144);
            this.dataGridView.TabIndex = 23;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            // 
            // TekichuuWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 324);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.toolStrip);
            this.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.Document;
            this.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "TekichuuWindow";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.Document;
            this.Text = "的中率・回収率算出";
            this.Load += new System.EventHandler(this.TekichuuWindow_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.flowLayoutPanel.ResumeLayout(false);
            this.flowLayoutPanel.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton editRaceSelectionSQLButton;
        private System.Windows.Forms.ToolStripComboBox raceSelectionComboBox;
        private System.Windows.Forms.ToolStripSeparator separator1;
        private System.Windows.Forms.ToolStripButton editShussoubaSelectionSQLButton;
        private System.Windows.Forms.ToolStripLabel raceSelectLabel;
        private System.Windows.Forms.ToolStripComboBox shussoubaSelectionComboBox;
        private System.Windows.Forms.ToolStripLabel shussoubaSelectionLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton executeButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private Nikochan.Keiba.KeibaDataAnalyzer.UserControls.ShouUserControl tanshouUserControl;
        private Nikochan.Keiba.KeibaDataAnalyzer.UserControls.ShouUserControl fukushouUserControl;
        private Nikochan.Keiba.KeibaDataAnalyzer.UserControls.RenTanUserControl wakurenUserControl;
        private Nikochan.Keiba.KeibaDataAnalyzer.UserControls.RenTanUserControl umarenUserControl;
        private Nikochan.Keiba.KeibaDataAnalyzer.UserControls.RenTanUserControl umatanUserControl;
        private Nikochan.Keiba.KeibaDataAnalyzer.UserControls.RenTanUserControl wideUserControl;
        private Nikochan.Keiba.KeibaDataAnalyzer.UserControls.RenTanUserControl sanrenpukuUserControl;
        private Nikochan.Keiba.KeibaDataAnalyzer.UserControls.RenTanUserControl sanrentanUserControl;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
    }
}