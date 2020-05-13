namespace PrintDemo
{
    partial class FormPrint
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrint));
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.btn_Print = new System.Windows.Forms.Button();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.pic_Print = new System.Windows.Forms.PictureBox();
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.lbl_Height = new System.Windows.Forms.Label();
            this.txt_Height = new System.Windows.Forms.TextBox();
            this.lbl_Width = new System.Windows.Forms.Label();
            this.txt_Width = new System.Windows.Forms.TextBox();
            this.lbl_Unit = new System.Windows.Forms.Label();
            this.lbl_Unit1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Print)).BeginInit();
            this.SuspendLayout();
            // 
            // printDialog
            // 
            this.printDialog.UseEXDialog = true;
            //
            // printDocument
            //
            this.printDocument.DocumentName = "快递面单";
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument_PrintPage);
            // 
            // btn_Print
            // 
            this.btn_Print.Location = new System.Drawing.Point(36, 12);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(105, 23);
            this.btn_Print.TabIndex = 0;
            this.btn_Print.Text = "快递面单打印";
            this.btn_Print.UseVisualStyleBackColor = true;
            this.btn_Print.Click += new System.EventHandler(this.btn_Print_Click);
            // 
            // pic_Print
            // 
            this.pic_Print.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic_Print.Location = new System.Drawing.Point(36, 41);
            this.pic_Print.Name = "pic_Print";
            this.pic_Print.Size = new System.Drawing.Size(535, 335);
            this.pic_Print.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_Print.TabIndex = 1;
            this.pic_Print.TabStop = false;
            // 
            // printPreviewDialog
            // 
            this.printPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog.Enabled = true;
            this.printPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog.Icon")));
            this.printPreviewDialog.Name = "printPreviewDialog";
            this.printPreviewDialog.Visible = false;
            // 
            // lbl_Height
            // 
            this.lbl_Height.Location = new System.Drawing.Point(140, 12);
            this.lbl_Height.Name = "lbl_Height";
            this.lbl_Height.Size = new System.Drawing.Size(85, 23);
            this.lbl_Height.TabIndex = 2;
            this.lbl_Height.Text = "面单打印高度:";
            this.lbl_Height.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_Height
            // 
            this.txt_Height.Location = new System.Drawing.Point(232, 14);
            this.txt_Height.Name = "txt_Height";
            this.txt_Height.Size = new System.Drawing.Size(64, 21);
            this.txt_Height.TabIndex = 3;
            // 
            // lbl_Width
            // 
            this.lbl_Width.Location = new System.Drawing.Point(340, 12);
            this.lbl_Width.Name = "lbl_Width";
            this.lbl_Width.Size = new System.Drawing.Size(85, 23);
            this.lbl_Width.TabIndex = 4;
            this.lbl_Width.Text = "面单打印宽度:";
            this.lbl_Width.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_Width
            // 
            this.txt_Width.Location = new System.Drawing.Point(431, 14);
            this.txt_Width.Name = "txt_Width";
            this.txt_Width.Size = new System.Drawing.Size(65, 21);
            this.txt_Width.TabIndex = 5;
            // 
            // lbl_Unit
            // 
            this.lbl_Unit.Location = new System.Drawing.Point(302, 12);
            this.lbl_Unit.Name = "lbl_Unit";
            this.lbl_Unit.Size = new System.Drawing.Size(32, 23);
            this.lbl_Unit.TabIndex = 6;
            this.lbl_Unit.Text = "厘米";
            this.lbl_Unit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Unit1
            // 
            this.lbl_Unit1.Location = new System.Drawing.Point(502, 12);
            this.lbl_Unit1.Name = "lbl_Unit1";
            this.lbl_Unit1.Size = new System.Drawing.Size(32, 23);
            this.lbl_Unit1.TabIndex = 7;
            this.lbl_Unit1.Text = "厘米";
            this.lbl_Unit1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.lbl_Unit1);
            this.Controls.Add(this.lbl_Unit);
            this.Controls.Add(this.txt_Width);
            this.Controls.Add(this.lbl_Width);
            this.Controls.Add(this.txt_Height);
            this.Controls.Add(this.lbl_Height);
            this.Controls.Add(this.pic_Print);
            this.Controls.Add(this.btn_Print);
            this.Name = "FormPrint";
            this.Text = "FormPrint";
            this.Load += new System.EventHandler(this.FormPrint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Print)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PrintDialog printDialog;
        private System.Windows.Forms.Button btn_Print;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.PictureBox pic_Print;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
        private System.Windows.Forms.Label lbl_Height;
        private System.Windows.Forms.TextBox txt_Height;
        private System.Windows.Forms.Label lbl_Width;
        private System.Windows.Forms.TextBox txt_Width;
        private System.Windows.Forms.Label lbl_Unit;
        private System.Windows.Forms.Label lbl_Unit1;
    }
}

