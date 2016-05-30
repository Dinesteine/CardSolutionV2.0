using System;

namespace CardSolutionHost.Control
{
    partial class AppContainer
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppContainer));
            this.picFailure = new System.Windows.Forms.PictureBox();
            this.picConnecting = new System.Windows.Forms.PictureBox();
            this.picSuccess = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.picInit = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picFailure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picConnecting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSuccess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInit)).BeginInit();
            this.SuspendLayout();
            // 
            // picFailure
            // 
            this.picFailure.Image = ((System.Drawing.Image)(resources.GetObject("picFailure.Image")));
            this.picFailure.Location = new System.Drawing.Point(-45, -50);
            this.picFailure.Name = "picFailure";
            this.picFailure.Size = new System.Drawing.Size(47, 42);
            this.picFailure.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picFailure.TabIndex = 78;
            this.picFailure.TabStop = false;
            this.picFailure.Visible = false;
            // 
            // picConnecting
            // 
            this.picConnecting.Image = ((System.Drawing.Image)(resources.GetObject("picConnecting.Image")));
            this.picConnecting.Location = new System.Drawing.Point(-45, -50);
            this.picConnecting.Name = "picConnecting";
            this.picConnecting.Size = new System.Drawing.Size(42, 42);
            this.picConnecting.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picConnecting.TabIndex = 77;
            this.picConnecting.TabStop = false;
            this.picConnecting.Visible = false;
            // 
            // picSuccess
            // 
            this.picSuccess.Image = ((System.Drawing.Image)(resources.GetObject("picSuccess.Image")));
            this.picSuccess.Location = new System.Drawing.Point(-45, -50);
            this.picSuccess.Name = "picSuccess";
            this.picSuccess.Size = new System.Drawing.Size(43, 40);
            this.picSuccess.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picSuccess.TabIndex = 75;
            this.picSuccess.TabStop = false;
            this.picSuccess.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 74;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(40, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(43, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 73;
            this.pictureBox1.TabStop = false;
            // 
            // picInit
            // 
            this.picInit.Image = ((System.Drawing.Image)(resources.GetObject("picInit.Image")));
            this.picInit.Location = new System.Drawing.Point(-45, -50);
            this.picInit.Name = "picInit";
            this.picInit.Size = new System.Drawing.Size(47, 42);
            this.picInit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picInit.TabIndex = 76;
            this.picInit.TabStop = false;
            this.picInit.Visible = false;
            // 
            // AppContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picFailure);
            this.Controls.Add(this.picConnecting);
            this.Controls.Add(this.picSuccess);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.picInit);
            this.Name = "AppContainer";
            this.Size = new System.Drawing.Size(126, 59);
            this.Load += new System.EventHandler(this.AppContainer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picFailure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picConnecting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSuccess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.PictureBox picFailure;
        private System.Windows.Forms.PictureBox picConnecting;
        private System.Windows.Forms.PictureBox picSuccess;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox picInit;
    }
}
