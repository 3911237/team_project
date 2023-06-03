﻿using System;
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
        List<bool> done = new List<bool>();//수강신청한 과목들
        List<bool> full = new List<bool>();//여석이 다 찼는 지
        int num=0;//몇개의 수강신청 신청했는 지

        public Form2()
        {
            InitializeComponent();
            dgv_favList.Rows.Add("조회", "1", "", "","","","","","","","");
            dgv_favList.Rows.Add("조회", "2", "", "", "", "", "","", "", "", "");
            dgv_favList.Rows.Add("조회", "3", "", "", "", "", "", "", "", "", "");
            dgv_favList.Rows.Add("조회", "4", "", "", "", "", "", "", "", "", "");
            dgv_favList.Rows.Add("조회", "5", "", "", "", "", "", "", "", "", "");
            dgv_favList.Rows.Add("조회", "6", "", "", "", "", "", "", "", "", "");
            dgv_favList.Rows.Add("조회", "7", "", "", "", "", "", "", "", "", "");
            dgv_favList.Rows.Add("조회", "8", "", "", "", "", "", "", "", "", "");
            dgv_favList.Rows.Add("조회", "9", "", "", "", "", "", "", "", "", "");
            dgv_favList.Rows.Add("조회", "10", "", "", "", "", "", "", "", "", "");


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
                dgv_clist.Rows.Add(k, data[0], data[1], data[2], data[3], data[4], data[5],data[6]);
                k++;
            }
        }

        private void btn_apply_Click(object sender, EventArgs e)
        {
            if (selected == -1)
            {
                MessageBox.Show("수강신청하려는 과목을 먼저 조회해주세요!", "오류", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
/*            else if (done[selected])
            {
                MessageBox.Show("이미 수강신청이 완료된 과목입니다!", "수강신청 연습", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (full[selected])
            {
                MessageBox.Show("해당 과목은 만석입니다", "여석 없음", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
*/            //dgv_reglist에 추가하는 부분
            dgv_reglist.Rows.Add((++num).ToString(),tb_ccode.Text,tb_type.Text,tb_subject.Text,tb_credit.Text,tb_prof.Text,tb_day1.Text,tb_time1.Text+"교시",tb_room1.Text,"","","");
            dgv_reglist.CurrentCell = null;
            clearing();
            //done[selected] = true;
            this.Text = "수강신청 성공 과목 수 [" + num.ToString() + "/" + "10" + "]";
            selected = -1;

        }
        void clearing()
        {
            tb_ccode = null;
            tb_type = null;
            tb_subject = null;
            tb_credit=null;
            tb_prof = null;
            tb_day1 = null;
            tb_time1 = null;
            tb_day2 = null;
            tb_time2 = null;
            tb_room1 = null;
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
                isStarted = true;
                btn_apply.Enabled = true;
                btn_apply.BackColor = Color.Yellow;
                MessageBox.Show("수강신청이 시작되었습니다.","수강신청 시작",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            curTime.Text="09:59:"+sec.ToString();//시간 update
        }

        private void btn_favadd_Click(object sender, EventArgs e)//즐찾에 추가하는 기능
        {
            DataGridViewRow row = dgv_clist.SelectedRows[0]; //선택된 Row 값 가져옴.
            String add_fav_num = cmb_favNum.SelectedItem as String;
            String add_fav_ccode = row.Cells[1].Value.ToString();//학점번호
            String add_fav_type = row.Cells[2].Value.ToString();//구분
            String add_fav_subj = row.Cells[3].Value.ToString();//과목명
            String add_fav_credit=row.Cells[4].Value.ToString();//학점
            String add_fav_prof=row.Cells[5].Value.ToString();//교수
            String add_fav_seat = row.Cells[6].Value.ToString();//여석
            String add_fav_time =row.Cells[7].Value.ToString();//강의시간
            String add_fav_room = "";//강의실
            int index = Convert.ToInt32( cmb_favNum.SelectedItem)-1;

            //MessageBox.Show(add_fav_num+ add_fav_ccode+add_fav_subj+add_fav_credit+ add_fav_prof+ add_fav_time+"\n"+ index);
            dgv_favList.Rows[index].Cells[2].Value = add_fav_ccode.ToString();
            dgv_favList.Rows[index].Cells[3].Value = add_fav_subj.ToString();
            dgv_favList.Rows[index].Cells[4].Value = add_fav_credit.ToString();
            dgv_favList.Rows[index].Cells[5].Value = add_fav_prof.ToString();
            dgv_favList.Rows[index].Cells[6].Value = add_fav_time.ToString();
            dgv_favList.Rows[index].Cells[7].Value = add_fav_room.ToString();//강의실
            dgv_favList.Rows[index].Cells[8].Value = add_fav_seat.ToString();//여석
            dgv_favList.Rows[index].Cells[9].Value = add_fav_type.ToString();//구분





        }

        private void dgv_favList_CellContentClick(object sender, DataGridViewCellEventArgs e)//조회 버튼 눌렀을 때
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgv_favList.Columns["fav_add"].Index) return;
            if (!isStarted)//수강 신청 시작하면 조회 가능
            {
                MessageBox.Show("수강신청이 시작된 이후에만 조회가 가능합니다.", "수강신청 연습", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            String[] typeList = new String[6] { "기필", "기선", "교필", "교선", "전필", "전선" };

            selected = e.RowIndex;
            tb_ccode.Text=dgv_favList.Rows[e.RowIndex].Cells[2].Value as String;
            tb_subject.Text = dgv_favList.Rows[e.RowIndex].Cells[3].Value as String;
            tb_credit.Text= dgv_favList.Rows[e.RowIndex].Cells[4].Value as String;
            tb_prof.Text= dgv_favList.Rows[e.RowIndex].Cells[5].Value as String;
            tb_day1.Text=dgv_favList.Rows[e.RowIndex].Cells[6].Value as String;//시간 splite 처리 필요
            tb_room1.Text=dgv_favList.Rows[e.RowIndex].Cells[7].Value as String;
            tb_avail.Text = (dgv_favList.Rows[e.RowIndex].Cells[8].Value as String=="0")?"만석":"여석";
            tb_type.Text= dgv_favList.Rows[e.RowIndex].Cells[9].Value as String;

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}

