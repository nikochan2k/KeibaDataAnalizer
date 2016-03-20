namespace Nikochan.Keiba.KeibaDataAnalyzer.UserControls
{
    partial class DataControl
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
        	System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
        	System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
        	System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
        	this.dataGridView = new System.Windows.Forms.DataGridView();
        	this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
        	((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// dataGridView
        	// 
        	this.dataGridView.AllowUserToAddRows = false;
        	this.dataGridView.AllowUserToDeleteRows = false;
        	this.dataGridView.AllowUserToResizeRows = false;
        	this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
        	dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        	dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
        	dataGridViewCellStyle1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
        	dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
        	dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
        	dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        	dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        	this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        	this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        	dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
        	dataGridViewCellStyle2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
        	dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        	dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
        	dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        	dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        	this.dataGridView.DefaultCellStyle = dataGridViewCellStyle2;
        	this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.dataGridView.Location = new System.Drawing.Point(0, 0);
        	this.dataGridView.MultiSelect = false;
        	this.dataGridView.Name = "dataGridView";
        	this.dataGridView.ReadOnly = true;
        	dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
        	dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
        	dataGridViewCellStyle3.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
        	dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
        	dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
        	dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        	dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        	this.dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
        	this.dataGridView.RowHeadersVisible = false;
        	this.dataGridView.RowTemplate.Height = 21;
        	this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        	this.dataGridView.Size = new System.Drawing.Size(219, 229);
        	this.dataGridView.TabIndex = 6;
        	// 
        	// flowLayoutPanel
        	// 
        	this.flowLayoutPanel.AutoSize = true;
        	this.flowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        	this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
        	this.flowLayoutPanel.Location = new System.Drawing.Point(0, 0);
        	this.flowLayoutPanel.Name = "flowLayoutPanel";
        	this.flowLayoutPanel.Size = new System.Drawing.Size(219, 0);
        	this.flowLayoutPanel.TabIndex = 5;
        	// 
        	// DataControl
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.Controls.Add(this.dataGridView);
        	this.Controls.Add(this.flowLayoutPanel);
        	this.Name = "DataControl";
        	this.Size = new System.Drawing.Size(219, 229);
        	((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
    }
}
