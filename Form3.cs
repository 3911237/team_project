using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kwangwoon_Sugang_Practice_Project
{
    public partial class Form3 : Form
    {
        string PIN; // 인증번호를 담는 string
        public Form3()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e) // 확인 버튼
        {
            if (tb_PIN.Text == PIN)
                this.DialogResult = DialogResult.OK; 
            else
                this.DialogResult = DialogResult.No; 
        }

        private void btnCancel_Click(object sender, EventArgs e) // 취소 버튼
        {
            Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Random rand = new Random();
            int pin = rand.Next(9999); // int형 변수 pin을 0부터 9999까지의 랜덤 숫자로 설정
            PIN = pin.ToString("D4"); // pin을 4글자 string PIN으로 변환(ex: pin이 3295면 PIN은 3295, pin이 71이면 PIN은 0071)
            lb_PIN.Text = ("인증번호 [" + pin.ToString("D4") + "]를 입력하세요!");
        }

        private void tb_PIN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnOK_Click(sender, e); // 엔터 키를 누르면 확인 버튼을 누른 것과 동일하게 작동함
            }
        }
    }
}
