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
    public partial class Form0 : Form
    {
        User_Info userinfo = new User_Info();

        public Form0()
        {
            InitializeComponent();
        }
        private void Login(string id, string pw)
        {
            userinfo.SetId(id);
            userinfo.SetPw(pw);

        }
        private void login_btn_Click(object sender, EventArgs e)
        {
            this.Login(stid_tbox.Text, stname_tbox.Text);
            string id = userinfo.GetId();
            string pw = userinfo.GetPw();
            Form2 form2 = new Form2();
            form2.DataPassEvent += new Form2.LoginGetEventHandler(form2.DataReceive);
            form2.DataReceive(id, pw);
            form2.Show();
            MessageBox.Show("로그인 되었습니다.", "알림");
            this.Close();
        }


        private void Form0_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();
        }

        private void Form0_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();

        }
    }
}
