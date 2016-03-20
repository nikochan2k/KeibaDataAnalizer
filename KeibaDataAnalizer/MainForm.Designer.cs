namespace Nikochan.Keiba.KeibaDataAnalyzer
{
    partial class MainForm
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
        	WeifenLuo.WinFormsUI.Docking.DockPanelSkin dockPanelSkin1 = new WeifenLuo.WinFormsUI.Docking.DockPanelSkin();
        	WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin autoHideStripSkin1 = new WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin();
        	WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
        	WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient1 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
        	WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin dockPaneStripSkin1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin();
        	WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient dockPaneStripGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient();
        	WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient2 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
        	WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient2 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
        	WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient3 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
        	WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient dockPaneStripToolWindowGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient();
        	WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient4 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
        	WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient5 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
        	WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient3 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
        	WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient6 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
        	WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient7 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
        	this.menuStrip = new System.Windows.Forms.MenuStrip();
        	this.viewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.importMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.searchMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.sqlMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.tekichuuMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.executeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.executeCustomQueryMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.raceOnlyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.raceAndShussoubaMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.dockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
        	this.menuStrip.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// menuStrip
        	// 
        	this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.viewMenuItem,
        	        	        	this.executeMenuItem});
        	this.menuStrip.Location = new System.Drawing.Point(0, 0);
        	this.menuStrip.Name = "menuStrip";
        	this.menuStrip.Size = new System.Drawing.Size(784, 26);
        	this.menuStrip.TabIndex = 1;
        	this.menuStrip.Text = "menuStrip1";
        	// 
        	// viewMenuItem
        	// 
        	this.viewMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.importMenuItem,
        	        	        	this.searchMenuItem,
        	        	        	this.sqlMenuItem,
        	        	        	this.tekichuuMenuItem});
        	this.viewMenuItem.Name = "viewMenuItem";
        	this.viewMenuItem.Size = new System.Drawing.Size(62, 22);
        	this.viewMenuItem.Text = "表示(&V)";
        	// 
        	// importMenuItem
        	// 
        	this.importMenuItem.Name = "importMenuItem";
        	this.importMenuItem.Size = new System.Drawing.Size(184, 22);
        	this.importMenuItem.Text = "データ取り込み";
        	this.importMenuItem.Click += new System.EventHandler(this.importMenuItem_Click);
        	// 
        	// searchMenuItem
        	// 
        	this.searchMenuItem.Name = "searchMenuItem";
        	this.searchMenuItem.Size = new System.Drawing.Size(184, 22);
        	this.searchMenuItem.Text = "データ検索";
        	this.searchMenuItem.Click += new System.EventHandler(this.searchMenuItem_Click);
        	// 
        	// sqlMenuItem
        	// 
        	this.sqlMenuItem.Name = "sqlMenuItem";
        	this.sqlMenuItem.Size = new System.Drawing.Size(184, 22);
        	this.sqlMenuItem.Text = "SQL発行";
        	this.sqlMenuItem.Click += new System.EventHandler(this.sqlMenuItem_Click);
        	// 
        	// tekichuuMenuItem
        	// 
        	this.tekichuuMenuItem.Name = "tekichuuMenuItem";
        	this.tekichuuMenuItem.Size = new System.Drawing.Size(184, 22);
        	this.tekichuuMenuItem.Text = "的中率・回収率算出";
        	this.tekichuuMenuItem.Click += new System.EventHandler(this.tekichuuMenuItem_Click);
        	// 
        	// executeMenuItem
        	// 
        	this.executeMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.executeCustomQueryMenuItem});
        	this.executeMenuItem.Name = "executeMenuItem";
        	this.executeMenuItem.Size = new System.Drawing.Size(62, 22);
        	this.executeMenuItem.Text = "実行(&X)";
        	// 
        	// executeCustomQueryMenuItem
        	// 
        	this.executeCustomQueryMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.raceOnlyMenuItem,
        	        	        	this.raceAndShussoubaMenuItem});
        	this.executeCustomQueryMenuItem.Name = "executeCustomQueryMenuItem";
        	this.executeCustomQueryMenuItem.Size = new System.Drawing.Size(196, 22);
        	this.executeCustomQueryMenuItem.Text = "カスタムクエリの実行";
        	// 
        	// raceOnlyMenuItem
        	// 
        	this.raceOnlyMenuItem.Name = "raceOnlyMenuItem";
        	this.raceOnlyMenuItem.Size = new System.Drawing.Size(172, 22);
        	this.raceOnlyMenuItem.Text = "レースのみ";
        	this.raceOnlyMenuItem.Click += new System.EventHandler(this.RaceOnlyMenuItemClick);
        	// 
        	// raceAndShussoubaMenuItem
        	// 
        	this.raceAndShussoubaMenuItem.Name = "raceAndShussoubaMenuItem";
        	this.raceAndShussoubaMenuItem.Size = new System.Drawing.Size(172, 22);
        	this.raceAndShussoubaMenuItem.Text = "レース及び出走馬";
        	this.raceAndShussoubaMenuItem.Click += new System.EventHandler(this.RaceAndShussoubaMenuItemClick);
        	// 
        	// dockPanel
        	// 
        	this.dockPanel.ActiveAutoHideContent = null;
        	this.dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.dockPanel.DockBackColor = System.Drawing.SystemColors.AppWorkspace;
        	this.dockPanel.DockLeftPortion = 236D;
        	this.dockPanel.DockRightPortion = 236D;
        	this.dockPanel.Location = new System.Drawing.Point(0, 26);
        	this.dockPanel.Name = "dockPanel";
        	this.dockPanel.Size = new System.Drawing.Size(784, 536);
        	dockPanelGradient1.EndColor = System.Drawing.SystemColors.ControlLight;
        	dockPanelGradient1.StartColor = System.Drawing.SystemColors.ControlLight;
        	autoHideStripSkin1.DockStripGradient = dockPanelGradient1;
        	tabGradient1.EndColor = System.Drawing.SystemColors.Control;
        	tabGradient1.StartColor = System.Drawing.SystemColors.Control;
        	tabGradient1.TextColor = System.Drawing.SystemColors.ControlDarkDark;
        	autoHideStripSkin1.TabGradient = tabGradient1;
        	autoHideStripSkin1.TextFont = new System.Drawing.Font("メイリオ", 9F);
        	dockPanelSkin1.AutoHideStripSkin = autoHideStripSkin1;
        	tabGradient2.EndColor = System.Drawing.SystemColors.ControlLightLight;
        	tabGradient2.StartColor = System.Drawing.SystemColors.ControlLightLight;
        	tabGradient2.TextColor = System.Drawing.SystemColors.ControlText;
        	dockPaneStripGradient1.ActiveTabGradient = tabGradient2;
        	dockPanelGradient2.EndColor = System.Drawing.SystemColors.Control;
        	dockPanelGradient2.StartColor = System.Drawing.SystemColors.Control;
        	dockPaneStripGradient1.DockStripGradient = dockPanelGradient2;
        	tabGradient3.EndColor = System.Drawing.SystemColors.ControlLight;
        	tabGradient3.StartColor = System.Drawing.SystemColors.ControlLight;
        	tabGradient3.TextColor = System.Drawing.SystemColors.ControlText;
        	dockPaneStripGradient1.InactiveTabGradient = tabGradient3;
        	dockPaneStripSkin1.DocumentGradient = dockPaneStripGradient1;
        	dockPaneStripSkin1.TextFont = new System.Drawing.Font("メイリオ", 9F);
        	tabGradient4.EndColor = System.Drawing.SystemColors.ActiveCaption;
        	tabGradient4.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
        	tabGradient4.StartColor = System.Drawing.SystemColors.GradientActiveCaption;
        	tabGradient4.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
        	dockPaneStripToolWindowGradient1.ActiveCaptionGradient = tabGradient4;
        	tabGradient5.EndColor = System.Drawing.SystemColors.Control;
        	tabGradient5.StartColor = System.Drawing.SystemColors.Control;
        	tabGradient5.TextColor = System.Drawing.SystemColors.ControlText;
        	dockPaneStripToolWindowGradient1.ActiveTabGradient = tabGradient5;
        	dockPanelGradient3.EndColor = System.Drawing.SystemColors.ControlLight;
        	dockPanelGradient3.StartColor = System.Drawing.SystemColors.ControlLight;
        	dockPaneStripToolWindowGradient1.DockStripGradient = dockPanelGradient3;
        	tabGradient6.EndColor = System.Drawing.SystemColors.GradientInactiveCaption;
        	tabGradient6.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
        	tabGradient6.StartColor = System.Drawing.SystemColors.GradientInactiveCaption;
        	tabGradient6.TextColor = System.Drawing.SystemColors.ControlText;
        	dockPaneStripToolWindowGradient1.InactiveCaptionGradient = tabGradient6;
        	tabGradient7.EndColor = System.Drawing.Color.Transparent;
        	tabGradient7.StartColor = System.Drawing.Color.Transparent;
        	tabGradient7.TextColor = System.Drawing.SystemColors.ControlDarkDark;
        	dockPaneStripToolWindowGradient1.InactiveTabGradient = tabGradient7;
        	dockPaneStripSkin1.ToolWindowGradient = dockPaneStripToolWindowGradient1;
        	dockPanelSkin1.DockPaneStripSkin = dockPaneStripSkin1;
        	this.dockPanel.Skin = dockPanelSkin1;
        	this.dockPanel.TabIndex = 3;
        	// 
        	// MainForm
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(784, 562);
        	this.Controls.Add(this.dockPanel);
        	this.Controls.Add(this.menuStrip);
        	this.IsMdiContainer = true;
        	this.MainMenuStrip = this.menuStrip;
        	this.Name = "MainForm";
        	this.Text = "KeibaDataAnalyzer";
        	this.Load += new System.EventHandler(this.MainForm_Load);
        	this.menuStrip.ResumeLayout(false);
        	this.menuStrip.PerformLayout();
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.ToolStripMenuItem executeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem raceAndShussoubaMenuItem;
        private System.Windows.Forms.ToolStripMenuItem raceOnlyMenuItem;
        private System.Windows.Forms.ToolStripMenuItem executeCustomQueryMenuItem;

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel;
        private System.Windows.Forms.ToolStripMenuItem viewMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sqlMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tekichuuMenuItem;

    }
}