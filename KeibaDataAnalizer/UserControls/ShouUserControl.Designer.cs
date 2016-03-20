namespace Nikochan.Keiba.KeibaDataAnalyzer.UserControls
{
    partial class ShouUserControl
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

        #region コンポーネント デザイナで生成されたコード

        /// <summary> 
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.jouiLabel = new System.Windows.Forms.Label();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.unitLabel = new System.Windows.Forms.Label();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.AutoSize = true;
            this.panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel.Controls.Add(this.checkBox);
            this.panel.Controls.Add(this.jouiLabel);
            this.panel.Controls.Add(this.numericUpDown);
            this.panel.Controls.Add(this.unitLabel);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(147, 25);
            this.panel.TabIndex = 22;
            // 
            // checkBox
            // 
            this.checkBox.AutoSize = true;
            this.checkBox.Checked = true;
            this.checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox.Location = new System.Drawing.Point(3, 3);
            this.checkBox.Name = "checkBox";
            this.checkBox.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.checkBox.Size = new System.Drawing.Size(48, 17);
            this.checkBox.TabIndex = 19;
            this.checkBox.Text = "単勝";
            this.checkBox.UseVisualStyleBackColor = true;
            this.checkBox.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // jouiLabel
            // 
            this.jouiLabel.AutoSize = true;
            this.jouiLabel.Location = new System.Drawing.Point(57, 3);
            this.jouiLabel.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.jouiLabel.Name = "jouiLabel";
            this.jouiLabel.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.jouiLabel.Size = new System.Drawing.Size(29, 16);
            this.jouiLabel.TabIndex = 0;
            this.jouiLabel.Text = "上位";
            // 
            // numericUpDown
            // 
            this.numericUpDown.Location = new System.Drawing.Point(89, 3);
            this.numericUpDown.Maximum = new decimal(new int[] {
            18,
            0,
            0,
            0});
            this.numericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(35, 19);
            this.numericUpDown.TabIndex = 22;
            this.numericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // unitLabel
            // 
            this.unitLabel.AutoSize = true;
            this.unitLabel.Location = new System.Drawing.Point(127, 3);
            this.unitLabel.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.unitLabel.Name = "unitLabel";
            this.unitLabel.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.unitLabel.Size = new System.Drawing.Size(17, 16);
            this.unitLabel.TabIndex = 0;
            this.unitLabel.Text = "頭";
            // 
            // TanPukuUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel);
            this.Name = "TanPukuUserControl";
            this.Size = new System.Drawing.Size(147, 25);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel panel;
        private System.Windows.Forms.CheckBox checkBox;
        private System.Windows.Forms.Label jouiLabel;
        private System.Windows.Forms.NumericUpDown numericUpDown;
        private System.Windows.Forms.Label unitLabel;
    }
}
