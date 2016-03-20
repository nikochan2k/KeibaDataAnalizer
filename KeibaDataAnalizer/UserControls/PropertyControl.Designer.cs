namespace Nikochan.Keiba.KeibaDataAnalyzer.UserControls
{
    partial class PropertyControl
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
            this.label = new System.Windows.Forms.Label();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.valueLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label.Location = new System.Drawing.Point(0, 0);
            this.label.Margin = new System.Windows.Forms.Padding(0);
            this.label.Name = "label";
            this.label.Padding = new System.Windows.Forms.Padding(1);
            this.label.Size = new System.Drawing.Size(45, 16);
            this.label.TabIndex = 0;
            this.label.Text = "項目名";
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoSize = true;
            this.flowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel.Controls.Add(this.label);
            this.flowLayoutPanel.Controls.Add(this.valueLabel);
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(92, 18);
            this.flowLayoutPanel.TabIndex = 1;
            // 
            // valueLabel
            // 
            this.valueLabel.AutoSize = true;
            this.valueLabel.BackColor = System.Drawing.SystemColors.Window;
            this.valueLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.valueLabel.Location = new System.Drawing.Point(45, 0);
            this.valueLabel.Margin = new System.Windows.Forms.Padding(0);
            this.valueLabel.Name = "valueLabel";
            this.valueLabel.Padding = new System.Windows.Forms.Padding(1);
            this.valueLabel.Size = new System.Drawing.Size(45, 16);
            this.valueLabel.TabIndex = 2;
            this.valueLabel.Text = "項目値";
            // 
            // PropertyControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.flowLayoutPanel);
            this.Name = "PropertyControl";
            this.Size = new System.Drawing.Size(92, 18);
            this.flowLayoutPanel.ResumeLayout(false);
            this.flowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Label valueLabel;
    }
}
