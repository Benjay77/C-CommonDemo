namespace ComboxFilterDemo
{
    partial class FormComboxFilter
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
            this.cmb_Filter = new System.Windows.Forms.ComboBox();
            this.txt_InnerIP = new System.Windows.Forms.TextBox();
            this.txt_OuterIP = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmb_Filter
            // 
            this.cmb_Filter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmb_Filter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmb_Filter.FormattingEnabled = true;
            this.cmb_Filter.Location = new System.Drawing.Point(37, 55);
            this.cmb_Filter.Name = "cmb_Filter";
            this.cmb_Filter.Size = new System.Drawing.Size(121, 20);
            this.cmb_Filter.Sorted = true;
            this.cmb_Filter.TabIndex = 0;
            this.cmb_Filter.TextUpdate += new System.EventHandler(this.cmb_Filter_TextUpdate);
            // 
            // txt_InnerIP
            // 
            this.txt_InnerIP.Location = new System.Drawing.Point(37, 115);
            this.txt_InnerIP.Name = "txt_InnerIP";
            this.txt_InnerIP.ReadOnly = true;
            this.txt_InnerIP.Size = new System.Drawing.Size(121, 21);
            this.txt_InnerIP.TabIndex = 1;
            // 
            // txt_OuterIP
            // 
            this.txt_OuterIP.Location = new System.Drawing.Point(37, 176);
            this.txt_OuterIP.Name = "txt_OuterIP";
            this.txt_OuterIP.ReadOnly = true;
            this.txt_OuterIP.Size = new System.Drawing.Size(121, 21);
            this.txt_OuterIP.TabIndex = 2;
            // 
            // FormComboxFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.txt_OuterIP);
            this.Controls.Add(this.txt_InnerIP);
            this.Controls.Add(this.cmb_Filter);
            this.Name = "FormComboxFilter";
            this.Text = "FormComboxFilter";
            this.Load += new System.EventHandler(this.FormComboxFilter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_Filter;
        private System.Windows.Forms.TextBox txt_InnerIP;
        private System.Windows.Forms.TextBox txt_OuterIP;
    }
}

