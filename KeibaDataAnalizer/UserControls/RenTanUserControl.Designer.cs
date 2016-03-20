namespace Nikochan.Keiba.KeibaDataAnalyzer.UserControls
{
    partial class RenTanUserControl
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
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.jouiLabel = new System.Windows.Forms.Label();
            this.jouiNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.jouiUnitLabel = new System.Windows.Forms.Label();
            this.jikuLabel = new System.Windows.Forms.Label();
            this.jikuNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.jikuUnitLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jouiNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jikuNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoSize = true;
            this.flowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel.Controls.Add(this.checkBox);
            this.flowLayoutPanel.Controls.Add(this.jikuLabel);
            this.flowLayoutPanel.Controls.Add(this.jikuNumericUpDown);
            this.flowLayoutPanel.Controls.Add(this.jikuUnitLabel);
            this.flowLayoutPanel.Controls.Add(this.jouiLabel);
            this.flowLayoutPanel.Controls.Add(this.jouiNumericUpDown);
            this.flowLayoutPanel.Controls.Add(this.jouiUnitLabel);
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(228, 25);
            this.flowLayoutPanel.TabIndex = 25;
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
            this.checkBox.Text = "馬連";
            this.checkBox.UseVisualStyleBackColor = true;
            this.checkBox.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // jouiLabel
            // 
            this.jouiLabel.AutoSize = true;
            this.jouiLabel.Location = new System.Drawing.Point(138, 3);
            this.jouiLabel.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.jouiLabel.Name = "jouiLabel";
            this.jouiLabel.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.jouiLabel.Size = new System.Drawing.Size(29, 16);
            this.jouiLabel.TabIndex = 24;
            this.jouiLabel.Text = "上位";
            // 
            // jouiNumericUpDown
            // 
            this.jouiNumericUpDown.Location = new System.Drawing.Point(170, 3);
            this.jouiNumericUpDown.Maximum = new decimal(new int[] {
            18,
            0,
            0,
            0});
            this.jouiNumericUpDown.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.jouiNumericUpDown.Name = "jouiNumericUpDown";
            this.jouiNumericUpDown.Size = new System.Drawing.Size(35, 19);
            this.jouiNumericUpDown.TabIndex = 25;
            this.jouiNumericUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.jouiNumericUpDown.ValueChanged += new System.EventHandler(this.jouiNumericUpDown_ValueChanged);
            // 
            // jouiUnitLabel
            // 
            this.jouiUnitLabel.AutoSize = true;
            this.jouiUnitLabel.Location = new System.Drawing.Point(208, 3);
            this.jouiUnitLabel.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.jouiUnitLabel.Name = "jouiUnitLabel";
            this.jouiUnitLabel.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.jouiUnitLabel.Size = new System.Drawing.Size(17, 16);
            this.jouiUnitLabel.TabIndex = 23;
            this.jouiUnitLabel.Text = "頭";
            // 
            // jikuLabel
            // 
            this.jikuLabel.AutoSize = true;
            this.jikuLabel.Location = new System.Drawing.Point(57, 3);
            this.jikuLabel.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.jikuLabel.Name = "jikuLabel";
            this.jikuLabel.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.jikuLabel.Size = new System.Drawing.Size(17, 16);
            this.jikuLabel.TabIndex = 0;
            this.jikuLabel.Text = "軸";
            // 
            // jikuNumericUpDown
            // 
            this.jikuNumericUpDown.Location = new System.Drawing.Point(77, 3);
            this.jikuNumericUpDown.Maximum = new decimal(new int[] {
            17,
            0,
            0,
            0});
            this.jikuNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.jikuNumericUpDown.Name = "jikuNumericUpDown";
            this.jikuNumericUpDown.Size = new System.Drawing.Size(35, 19);
            this.jikuNumericUpDown.TabIndex = 22;
            this.jikuNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.jikuNumericUpDown.ValueChanged += new System.EventHandler(this.jikuNumericUpDown_ValueChanged);
            // 
            // jikuUnitLabel
            // 
            this.jikuUnitLabel.AutoSize = true;
            this.jikuUnitLabel.Location = new System.Drawing.Point(115, 3);
            this.jikuUnitLabel.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.jikuUnitLabel.Name = "jikuUnitLabel";
            this.jikuUnitLabel.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.jikuUnitLabel.Size = new System.Drawing.Size(17, 16);
            this.jikuUnitLabel.TabIndex = 0;
            this.jikuUnitLabel.Text = "頭";
            // 
            // RenTanUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.flowLayoutPanel);
            this.Name = "RenTanUserControl";
            this.Size = new System.Drawing.Size(228, 25);
            this.flowLayoutPanel.ResumeLayout(false);
            this.flowLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jouiNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jikuNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.CheckBox checkBox;
        private System.Windows.Forms.Label jouiLabel;
        private System.Windows.Forms.NumericUpDown jouiNumericUpDown;
        private System.Windows.Forms.Label jouiUnitLabel;
        private System.Windows.Forms.Label jikuLabel;
        private System.Windows.Forms.NumericUpDown jikuNumericUpDown;
        private System.Windows.Forms.Label jikuUnitLabel;
    }
}
