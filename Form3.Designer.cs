namespace Kwangwoon_Sugang_Practice_Project
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tb_PIN = new System.Windows.Forms.TextBox();
            this.lb_PIN = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(358, 16);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(86, 31);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "확인";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(358, 55);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 31);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tb_PIN
            // 
            this.tb_PIN.Location = new System.Drawing.Point(14, 143);
            this.tb_PIN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_PIN.Name = "tb_PIN";
            this.tb_PIN.Size = new System.Drawing.Size(430, 22);
            this.tb_PIN.TabIndex = 1;
            this.tb_PIN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_PIN_KeyDown);
            // 
            // lb_PIN
            // 
            this.lb_PIN.AutoSize = true;
            this.lb_PIN.Location = new System.Drawing.Point(11, 16);
            this.lb_PIN.Name = "lb_PIN";
            this.lb_PIN.Size = new System.Drawing.Size(162, 16);
            this.lb_PIN.TabIndex = 6;
            this.lb_PIN.Text = "인증번호 [0000]를 입력하세요!";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 184);
            this.Controls.Add(this.lb_PIN);
            this.Controls.Add(this.tb_PIN);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form3";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "대학 수강신청(과부하 방지)";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tb_PIN;
        private System.Windows.Forms.Label lb_PIN;
    }
}