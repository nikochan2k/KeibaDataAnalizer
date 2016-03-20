namespace Nikochan.Keiba.KeibaDataAnalyzer.DockContents
{
    partial class DateWindow
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
        	this.monthCalendar = new System.Windows.Forms.MonthCalendar();
        	this.panel = new System.Windows.Forms.Panel();
        	this.dataControl = new Nikochan.Keiba.KeibaDataAnalyzer.UserControls.DataControl();
        	this.toolStrip = new System.Windows.Forms.ToolStrip();
        	this.editSQLButton = new System.Windows.Forms.ToolStripButton();
        	this.nameComboBox = new System.Windows.Forms.ToolStripComboBox();
        	this.showRaceButton = new System.Windows.Forms.ToolStripButton();
        	this.panel.SuspendLayout();
        	this.toolStrip.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// monthCalendar
        	// 
        	this.monthCalendar.Dock = System.Windows.Forms.DockStyle.Top;
        	this.monthCalendar.Location = new System.Drawing.Point(0, 0);
        	this.monthCalendar.MaxSelectionCount = 1;
        	this.monthCalendar.Name = "monthCalendar";
        	this.monthCalendar.ShowToday = false;
        	this.monthCalendar.ShowTodayCircle = false;
        	this.monthCalendar.TabIndex = 0;
        	this.monthCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_DateChanged);
        	this.monthCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_DateSelected);
        	// 
        	// panel
        	// 
        	this.panel.Controls.Add(this.dataControl);
        	this.panel.Controls.Add(this.toolStrip);
        	this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.panel.Location = new System.Drawing.Point(0, 185);
        	this.panel.Name = "panel";
        	this.panel.Size = new System.Drawing.Size(220, 246);
        	this.panel.TabIndex = 2;
        	// 
        	// dataControl
        	// 
        	this.dataControl.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.dataControl.Location = new System.Drawing.Point(0, 26);
        	this.dataControl.Name = "dataControl";
        	this.dataControl.Size = new System.Drawing.Size(220, 220);
        	this.dataControl.TabIndex = 1;
        	// 
        	// toolStrip
        	// 
        	this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
        	this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.editSQLButton,
        	        	        	this.nameComboBox,
        	        	        	this.showRaceButton});
        	this.toolStrip.Location = new System.Drawing.Point(0, 0);
        	this.toolStrip.Name = "toolStrip";
        	this.toolStrip.Size = new System.Drawing.Size(220, 26);
        	this.toolStrip.TabIndex = 0;
        	// 
        	// editSQLButton
        	// 
        	this.editSQLButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.editSQLButton.Image = global::Nikochan.Keiba.KeibaDataAnalyzer.Properties.Resources.icon_settings;
        	this.editSQLButton.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.editSQLButton.Name = "editSQLButton";
        	this.editSQLButton.Size = new System.Drawing.Size(23, 23);
        	this.editSQLButton.Text = "SQLの編集";
        	this.editSQLButton.Click += new System.EventHandler(this.editSQLButton_Click);
        	// 
        	// nameComboBox
        	// 
        	this.nameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        	this.nameComboBox.Name = "nameComboBox";
        	this.nameComboBox.Size = new System.Drawing.Size(140, 26);
        	// 
        	// showRaceButton
        	// 
        	this.showRaceButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.showRaceButton.Image = global::Nikochan.Keiba.KeibaDataAnalyzer.Properties.Resources.action_go;
        	this.showRaceButton.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.showRaceButton.Name = "showRaceButton";
        	this.showRaceButton.Size = new System.Drawing.Size(23, 23);
        	this.showRaceButton.Text = "レース結果表示";
        	this.showRaceButton.Click += new System.EventHandler(this.showRaceButton_Click);
        	// 
        	// DateWindow
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(220, 431);
        	this.CloseButton = false;
        	this.CloseButtonVisible = false;
        	this.Controls.Add(this.panel);
        	this.Controls.Add(this.monthCalendar);
        	this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft) 
        	        	        	| WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight)));
        	this.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
        	this.Name = "DateWindow";
        	this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockLeft;
        	this.Text = "レース検索";
        	this.Activated += new System.EventHandler(this.DateWindowActivated);
        	this.Load += new System.EventHandler(this.DateWindow_Load);
        	this.panel.ResumeLayout(false);
        	this.panel.PerformLayout();
        	this.toolStrip.ResumeLayout(false);
        	this.toolStrip.PerformLayout();
        	this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton showRaceButton;
        private System.Windows.Forms.ToolStripComboBox nameComboBox;
        private System.Windows.Forms.ToolStripButton editSQLButton;
        private Nikochan.Keiba.KeibaDataAnalyzer.UserControls.DataControl dataControl;
    }
}