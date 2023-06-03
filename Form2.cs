using System;
using System.IO;
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
    public partial class Form2 : Form
    {
        int sec = 50;
        bool isStarted=false;//수강신청 시작했는지
        int selected = -1;//즐찾에서 조회버튼 누를때
        public Form2()
        {
            InitializeComponent();
        }
        int k = 1;

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btn_end_Click(object sender, EventArgs e)
        {
            //this.Close();
            Application.Exit();
        }

        private void cmb_dept1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_dept1.SelectedItem.ToString() == "전체검색")
            {
                cmb_dept2.Items.Clear();
                cmb_dept2.Items.Add("전체검색");
                cmb_dept2.SelectedIndex = 0;
            }
            if (cmb_dept1.SelectedItem.ToString() == "전자정보공과대학")
            {
                cmb_dept2.Items.Clear();
                cmb_dept2.Items.Add("전체검색");
                cmb_dept2.Items.Add("공통");
                cmb_dept2.Items.Add("전자공학과");
                cmb_dept2.Items.Add("전자통신공학과");
                cmb_dept2.Items.Add("전자융합공학과");
                cmb_dept2.Items.Add("전기공학과");
                cmb_dept2.Items.Add("전자재료공학과");
                cmb_dept2.Items.Add("로봇학부");
                cmb_dept2.Items.Add("지능형로봇학과");
                cmb_dept2.SelectedIndex = 0;
            }
            else if (cmb_dept1.SelectedItem.ToString() == "소프트웨어융합대학")
            {
                cmb_dept2.Items.Clear();
                cmb_dept2.Items.Add("전체검색");
                cmb_dept2.Items.Add("공통");
                cmb_dept2.Items.Add("컴퓨터정보공학부");
                cmb_dept2.Items.Add("소프트웨어학부");
                cmb_dept2.Items.Add("정보융합학부");
                cmb_dept2.SelectedIndex = 0;
            }
            else if (cmb_dept1.SelectedItem.ToString() == "공과대학")
            {
                cmb_dept2.Items.Clear();
                cmb_dept2.Items.Add("전체검색");
                cmb_dept2.Items.Add("공통");
                cmb_dept2.Items.Add("건축공학과");
                cmb_dept2.Items.Add("화학공학과");
                cmb_dept2.Items.Add("환경공학과");
                cmb_dept2.Items.Add("건축학과");
                cmb_dept2.SelectedIndex = 0;
            }
            else if (cmb_dept1.SelectedItem.ToString() == "자연과학대학")
            {
                cmb_dept2.Items.Clear();
                cmb_dept2.Items.Add("전체검색");
                cmb_dept2.Items.Add("공통");
                cmb_dept2.Items.Add("수학과");
                cmb_dept2.Items.Add("화학과");
                cmb_dept2.Items.Add("전자바이오물리학과");
                cmb_dept2.Items.Add("스포츠융합과학과");
                cmb_dept2.Items.Add("정보콘텐츠학과");
                cmb_dept2.SelectedIndex = 0;
            }
            else if (cmb_dept1.SelectedItem.ToString() == "인문사회과학대학")
            {
                cmb_dept2.Items.Clear();
                cmb_dept2.Items.Add("전체검색");
                cmb_dept2.Items.Add("공통");
                cmb_dept2.Items.Add("국어국문학과");
                cmb_dept2.Items.Add("영어산업학과");
                cmb_dept2.Items.Add("미디어커뮤니케이션학부");
                cmb_dept2.Items.Add("산업심리학과");
                cmb_dept2.Items.Add("동북아문화산업학부");
                cmb_dept2.SelectedIndex = 0;
            }
            else if (cmb_dept1.SelectedItem.ToString() == "정책법학대학")
            {
                cmb_dept2.Items.Clear();
                cmb_dept2.Items.Add("전체검색");
                cmb_dept2.Items.Add("공통");
                cmb_dept2.Items.Add("행정학과");
                cmb_dept2.Items.Add("법학부");
                cmb_dept2.Items.Add("국제학부");
                cmb_dept2.Items.Add("자산관리학과");
                cmb_dept2.SelectedIndex = 0;
            }
            else if (cmb_dept1.SelectedItem.ToString() == "경영대학")
            {
                cmb_dept2.Items.Clear();
                cmb_dept2.Items.Add("전체검색");
                cmb_dept2.Items.Add("공통");
                cmb_dept2.Items.Add("경영학부");
                cmb_dept2.Items.Add("국제통상학부");
                cmb_dept2.SelectedIndex = 0;
            }
            else if (cmb_dept1.SelectedItem.ToString() == "교양")
            {
                cmb_dept2.Items.Clear();
                cmb_dept2.Items.Add("전체검색");
                cmb_dept2.SelectedIndex = 0;
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            StreamReader file = new StreamReader("2023_01_lecture_list.csv");
            dgv_clist.Rows.Clear();
            dgv_clist.Refresh();
            k = 1;
            while (!file.EndOfStream)
            {
                string line = file.ReadLine();
                string[] data = line.Split(',');
                if (cmb_dept1.SelectedItem.ToString() == "전자정보공과대학")
                {
                    if (data[7] != "전자정보공과대학")
                        continue;
                    if (cmb_dept2.SelectedItem.ToString() == "공통")
                    {
                        if (data[8] != "공통")
                            continue;
                    }
                    if (cmb_dept2.SelectedItem.ToString() == "전자공학과")
                    {
                        if (data[8] != "전자공학과")
                            continue;
                    }
                    if (cmb_dept2.SelectedItem.ToString() == "전자통신공학과")
                    {
                        if (data[8] != "전자통신공학과")
                            continue;
                    }
                    if (cmb_dept2.SelectedItem.ToString() == "전자융합공학과")
                    {
                        if (data[8] != "전자융합공학과")
                            continue;
                    }
                    if (cmb_dept2.SelectedItem.ToString() == "전기공학과")
                    {
                        if (data[8] != "전기공학과")
                            continue;
                    }
                    if (cmb_dept2.SelectedItem.ToString() == "전자재료공학과")
                    {
                        if (data[8] != "전자재료공학과")
                            continue;
                    }
                    if (cmb_dept2.SelectedItem.ToString() == "로봇학부")
                    {
                        if (data[8] != "로봇학부")
                            continue;
                    }
                    if (cmb_dept2.SelectedItem.ToString() == "지능형로봇학과")
                    {
                        if (data[8] != "지능형로봇학과")
                            continue;
                    }
                }
                if (cmb_dept1.SelectedItem.ToString() == "소프트웨어융합대학")
                {
                    if (data[7] != "소프트웨어융합대학")
                        continue;
                    if (cmb_dept2.SelectedItem.ToString() == "공통")
                    {
                        if (data[8] != "공통")
                            continue;
                    }
                    if (cmb_dept2.SelectedItem.ToString() == "컴퓨터정보공학부")
                    {
                        if (data[8] != "컴퓨터정보공학부")
                            continue;
                    }
                    if (cmb_dept2.SelectedItem.ToString() == "소프트웨어학부")
                    {
                        if (data[8] != "소프트웨어학부")
                            continue;
                    }
                    if (cmb_dept2.SelectedItem.ToString() == "정보융합학부")
                    {
                        if (data[8] != "정보융합학부")
                            continue;
                    }
                }
                if (cmb_dept1.SelectedItem.ToString() == "공과대학")
                {
                    if (data[7] != "공과대학")
                        continue;
                    if (cmb_dept2.SelectedItem.ToString() == "공통")
                    {
                        if (data[8] != "공통")
                            continue;
                    }
                    if (cmb_dept2.SelectedItem.ToString() == "건축공학과")
                    {
                        if (data[8] != "건축공학과")
                            continue;
                    }
                    if (cmb_dept2.SelectedItem.ToString() == "화학공학과")
                    {
                        if (data[8] != "화학공학과")
                            continue;
                    }
                    if (cmb_dept2.SelectedItem.ToString() == "환경공학과")
                    {
                        if (data[8] != "환경공학과")
                            continue;
                    }
                    if (cmb_dept2.SelectedItem.ToString() == "건축학과")
                    {
                        if (data[8] != "건축학과")
                            continue;
                    }
                }
                if (cmb_dept1.SelectedItem.ToString() == "자연과학대학")
                {
                    if (data[7] != "자연과학대학")
                        continue;
                    if (cmb_dept2.SelectedItem.ToString() == "공통")
                    {
                        if (data[8] != "공통")
                            continue;
                    }
                    if (cmb_dept2.SelectedItem.ToString() == "수학과")
                    {
                        if (data[8] != "수학과")
                            continue;
                    }
                    if (cmb_dept2.SelectedItem.ToString() == "화학과")
                    {
                        if (data[8] != "화학과")
                            continue;
                    }
                    if (cmb_dept2.SelectedItem.ToString() == "전자바이오물리학과")
                    {
                        if (data[8] != "전자바이오물리학과")
                            continue;
                    }
                    if (cmb_dept2.SelectedItem.ToString() == "스포츠융합과학과")
                    {
                        if (data[8] != "스포츠융합과학과")
                            continue;
                    }
                    if (cmb_dept2.SelectedItem.ToString() == "정보콘텐츠학과")
                    {
                        if (data[8] != "정보콘텐츠학과")
                            continue;
                    }
                }
                if (cmb_dept1.SelectedItem.ToString() == "인문사회과학대학")
                {
                    if (data[7] != "인문사회과학대학")
                        continue;
                    if (cmb_dept2.SelectedItem.ToString() == "공통")
                    {
                        if (data[8] != "공통")
                            continue;
                    }
                    if (cmb_dept2.SelectedItem.ToString() == "국어국문학과")
                    {
                        if (data[8] != "국어국문학과")
                            continue;
                    }
                    if (cmb_dept2.SelectedItem.ToString() == "영어산업학과")
                    {
                        if (data[8] != "영어산업학과")
                            continue;
                    }
                    if (cmb_dept2.SelectedItem.ToString() == "미디어커뮤니케이션학부")
                    {
                        if (data[8] != "미디어커뮤니케이션학부")
                            continue;
                    }
                    if (cmb_dept2.SelectedItem.ToString() == "산업심리학과")
                    {
                        if (data[8] != "산업심리학과")
                            continue;
                    }
                    if (cmb_dept2.SelectedItem.ToString() == "동북아문화산업학부")
                    {
                        if (data[8] != "동북아문화산업학부")
                            continue;
                    }
                }
                if (cmb_dept1.SelectedItem.ToString() == "정책법학대학")
                {
                    if (data[7] != "정책법학대학")
                        continue;
                    if (cmb_dept2.SelectedItem.ToString() == "공통")
                    {
                        if (data[8] != "공통")
                            continue;
                    }
                    if (cmb_dept2.SelectedItem.ToString() == "행정학과")
                    {
                        if (data[8] != "행정학과")
                            continue;
                    }
                    if (cmb_dept2.SelectedItem.ToString() == "법학부")
                    {
                        if (data[8] != "법학부")
                            continue;
                    }
                    if (cmb_dept2.SelectedItem.ToString() == "국제학부")
                    {
                        if (data[8] != "국제학부")
                            continue;
                    }
                    if (cmb_dept2.SelectedItem.ToString() == "자산관리학과")
                    {
                        if (data[8] != "자산관리학과")
                            continue;
                    }
                }
                if (cmb_dept1.SelectedItem.ToString() == "경영대학")
                {
                    if (data[7] != "경영대학")
                        continue;
                    if (cmb_dept2.SelectedItem.ToString() == "공통")
                    {
                        if (data[8] != "공통")
                            continue;
                    }
                    if (cmb_dept2.SelectedItem.ToString() == "경영학부")
                    {
                        if (data[8] != "경영학부")
                            continue;
                    }
                    if (cmb_dept2.SelectedItem.ToString() == "국제통상학부")
                    {
                        if (data[8] != "국제통상학부")
                            continue;
                    }
                }
                if (cmb_dept1.SelectedItem.ToString() == "교양")
                    if (data[7] != "교양")
                        continue;
                if (cmb_isu.SelectedItem.ToString() == "교필")
                    if (data[1] != "교필")
                        continue;
                if (cmb_isu.SelectedItem.ToString() == "전필")
                    if (data[1] != "전필")
                        continue;
                if (cmb_isu.SelectedItem.ToString() == "기필")
                    if (data[1] != "기필")
                        continue;
                if (cmb_isu.SelectedItem.ToString() == "교선")
                    if (data[1] != "교선")
                        continue;
                if (cmb_isu.SelectedItem.ToString() == "전선")
                    if (data[1] != "전선")
                        continue;
                if (cmb_isu.SelectedItem.ToString() == "기선")
                    if (data[1] != "기선")
                        continue;
                if (!(data[2].Contains(tb_csearch.Text)))
                    continue;
                dgv_clist.Rows.Add(k, data[0], data[1], data[2], data[3], data[4], data[6]);
                k++;
            }
        }

        private void btn_apply_Click(object sender, EventArgs e)
        {

        }

        private void btn_start_Click(object sender, EventArgs e)//수강 신청 버튼 눌렀을 때
        {
            btn_start.Enabled = false;
            MessageBox.Show("10초 후 수강신청이 시작됩니다.\n서버 시간을 확인해주세요!","수강신청 시작",MessageBoxButtons.OK,MessageBoxIcon.Information);
            timer_start.Enabled = true;
        }

        private void timer_start_Tick(object sender, EventArgs e)
        {
            sec++;
            if(sec==55)curTime.ForeColor=Color.Red;
            else if (sec == 60)
            {
                timer_start.Enabled=false;
                curTime.Text = "10:00:00";
                //랜덤 여석 차기 구현 필요
                //practiceStart()
                MessageBox.Show("수강신청이 시작되었습니다.","수강신청 시작",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            curTime.Text="09:59:"+sec.ToString();//시간 update
        }
    }
}

