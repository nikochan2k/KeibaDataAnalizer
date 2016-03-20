namespace Nikochan.Keiba.KeibaDataAnalyzer.DockContents
{
    partial class RaceWindow
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
            this.editSQLButton = new System.Windows.Forms.ToolStripButton();
            this.nameComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.showShussoubaButton = new System.Windows.Forms.ToolStripButton();
            this.dataControl = new Nikochan.Keiba.KeibaDataAnalyzer.UserControls.DataControl();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editSQLButton,
            this.nameComboBox,
            this.showShussoubaButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(270, 26);
            this.toolStrip.TabIndex = 1;
            // 
            // editSQLButton
            // 
            this.editSQLButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.editSQLButton.Image = global::Nikochan.Keiba.KeibaDataAnalyzer.Properties.Resources.icon_settings;
            this.editSQLButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editSQLButton.Name = "editSQLButton";
            this.editSQLButton.Size = new System.Drawing.Size(23, 23);
            this.editSQLButton.Text = "SQLの編集";
            this.editSQLButton.ToolTipText = "SQLの編集";
            this.editSQLButton.Click += new System.EventHandler(this.editSQLButton_Click);
            // 
            // nameComboBox
            // 
            this.nameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nameComboBox.Name = "nameComboBox";
            this.nameComboBox.Size = new System.Drawing.Size(200, 26);
            // 
            // showShussoubaButton
            // 
            this.showShussoubaButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.showShussoubaButton.Image = global::Nikochan.Keiba.KeibaDataAnalyzer.Properties.Resources.action_go;
            this.showShussoubaButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.showShussoubaButton.Name = "showShussoubaButton";
            this.showShussoubaButton.Size = new System.Drawing.Size(23, 20);
            // 
            // dataControl
            // 
            this.dataControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataControl.Location = new System.Drawing.Point(0, 26);
            this.dataControl.Name = "dataControl";
            this.dataControl.Size = new System.Drawing.Size(270, 279);
            this.dataControl.TabIndex = 2;
            // 
            // RaceWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 305);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.dataControl);
            this.Controls.Add(this.toolStrip);
            this.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.Document;
            this.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "RaceWindow";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.Document;
            this.Text = "レース結果";
            this.Load += new System.EventHandler(this.ResultWindow_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripComboBox nameComboBox;
        private Nikochan.Keiba.KeibaDataAnalyzer.UserControls.DataControl dataControl;
        private System.Windows.Forms.ToolStripButton showShussoubaButton;
        private System.Windows.Forms.ToolStripButton editSQLButton;
    }
}