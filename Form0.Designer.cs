
namespace Kwangwoon_Sugang_Practice_Project
{
    partial class Form0
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.stid_label = new System.Windows.Forms.Button();
            this.stname_label = new System.Windows.Forms.Button();
            this.stid_tbox = new System.Windows.Forms.TextBox();
            this.stname_tbox = new System.Windows.Forms.TextBox();
            this.login_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Kwangwoon_Sugang_Practice_Project.Properties.Resources.opening;
            this.pictureBox1.Location = new System.Drawing.Point(113, 47);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(513, 290);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // stid_label
            // 
            this.stid_label.Location = new System.Drawing.Point(115, 428);
            this.stid_label.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.stid_label.Name = "stid_label";
            this.stid_label.Size = new System.Drawing.Size(86, 29);
            this.stid_label.TabIndex = 5;
            this.stid_label.Text = "학번";
            this.stid_label.UseVisualStyleBackColor = true;
            // 
            // stname_label
            // 
            this.stname_label.Location = new System.Drawing.Point(115, 465);
            this.stname_label.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.stname_label.Name = "stname_label";
            this.stname_label.Size = new System.Drawing.Size(86, 29);
            this.stname_label.TabIndex = 6;
            this.stname_label.Text = "이름";
            this.stname_label.UseVisualStyleBackColor = true;
            // 
            // stid_tbox
            // 
            this.stid_tbox.Location = new System.Drawing.Point(245, 428);
            this.stid_tbox.Name = "stid_tbox";
            this.stid_tbox.Size = new System.Drawing.Size(196, 25);
            this.stid_tbox.TabIndex = 7;
            // 
            // stname_tbox
            // 
            this.stname_tbox.Location = new System.Drawing.Point(245, 465);
            this.stname_tbox.Name = "stname_tbox";
            this.stname_tbox.Size = new System.Drawing.Size(196, 25);
            this.stname_tbox.TabIndex = 8;
            // 
            // login_btn
            // 
            this.login_btn.Location = new System.Drawing.Point(501, 427);
            this.login_btn.Name = "login_btn";
            this.login_btn.Size = new System.Drawing.Size(75, 23);
            this.login_btn.TabIndex = 9;
            this.login_btn.Text = "로그인";
            this.login_btn.UseVisualStyleBackColor = true;
            this.login_btn.Click += new System.EventHandler(this.login_btn_Click);
            // 
            // Form0
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 544);
            this.Controls.Add(this.login_btn);
            this.Controls.Add(this.stname_tbox);
            this.Controls.Add(this.stid_tbox);
            this.Controls.Add(this.stname_label);
            this.Controls.Add(this.stid_label);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form0";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button stid_label;
        private System.Windows.Forms.Button stname_label;
        private System.Windows.Forms.TextBox stid_tbox;
        private System.Windows.Forms.TextBox stname_tbox;
        private System.Windows.Forms.Button login_btn;
    }
}
