namespace Nikochan.Keiba.KeibaDataAnalyzer.DockContents
{
    partial class ShussoubaWindow
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
        	this.dataControl = new Nikochan.Keiba.KeibaDataAnalyzer.UserControls.DataControl();
        	this.SuspendLayout();
        	// 
        	// dataControl
        	// 
        	this.dataControl.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.dataControl.Location = new System.Drawing.Point(0, 0);
        	this.dataControl.Name = "dataControl";
        	this.dataControl.Size = new System.Drawing.Size(404, 262);
        	this.dataControl.TabIndex = 0;
        	// 
        	// ShussoubaWindow
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(404, 262);
        	this.Controls.Add(this.dataControl);
        	this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft) 
        	        	        	| WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight) 
        	        	        	| WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop) 
        	        	        	| WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom)));
        	this.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
        	this.Name = "ShussoubaWindow";
        	this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockBottom;
        	this.ResumeLayout(false);
        }

        #endregion

        private Nikochan.Keiba.KeibaDataAnalyzer.UserControls.DataControl dataControl;


    }
}