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
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;
//taskkill /pid 프로세스ID /f /t

namespace Kwangwoon_Sugang_Practice_Project
{
    public partial class Form2 : Form
    {
        int sec = 50;
        bool isStarted=false;//수강신청 시작했는지
        int selected = -1;//즐찾에서 조회버튼 누를때
        //int num=0;//몇개의 수강신청 신청했는 지
        string CsvFilePath = "2023_01_lecture_list.csv";
        DataTable dt;
        int k = 1; // 검색 순번
        Thread thread;
        String prevccode = ""; // 이전에 조회한 과목 코드
        int[] randNums;
        int click = 0;
        int checktime = 0;

        public delegate void LoginGetEventHandler(string id, string pw); // 로그인창 이벤트 핸들러
        public event LoginGetEventHandler DataPassEvent;

        public string[,] DataGridViewData { get; set; }


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
            //여석은 값이 줄어야 하므로 data table로 다룬다
            dt = CSVtoDataTable(CsvFilePath);
            dataGridView1.DataSource = dt;
            dt.PrimaryKey = new DataColumn[] { dt.Columns["num"] , dt.Columns["Name"] };
            cmb_favNum.SelectedIndex = 0;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_end_Click(object sender, EventArgs e) // 종료 버튼
        {
            DialogResult dr = MessageBox.Show("수강신청을 완료 하시겠습니까?", "수강신청", MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
                Application.Exit();
        }

        public void DataReceive(string id, string pw) // 로그인창의 학번과 이름을 받아옴
        {
            textBox3.Text = id;
            textBox2.Text = pw;
        }
        private void cmb_dept1_SelectedIndexChanged(object sender, EventArgs e) // 선택한 학부가 바뀌었을 때 하위 학과도 바뀌는 기능
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
            Form3 form3 = new Form3();
            DialogResult dResult = form3.ShowDialog(); // 인증번호를 입력받는 form3 실행
            if (dResult == DialogResult.No)
            {
                MessageBox.Show("인증번호를 바르게 입력하세요!", "대학 수강신청"); // form3에서 인증번호가 틀리면 검색이 되지 않음
            }
            else if (dResult == DialogResult.OK) // form3에서 인증번호가 맞으면 검색 진행
            {
                StreamReader file = new StreamReader("2023_01_lecture_list.csv");
                String firstLine=file.ReadLine();
                dgv_clist.Rows.Clear();
                dgv_clist.Refresh();
                k = 1;
                while (!file.EndOfStream)
                {
                    string line = file.ReadLine();
                    string[] data = line.Split(',');
                    if (cmb_dept1.SelectedItem.ToString() == "전자정보공과대학") // if문을 사용하여 검색 조건을 만족하는 강의만 결과에 나오게 함
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
                    DataRow[] dr = dt.Select("num ='" + data[0] + "'");
                    if (cb_avail.Checked)
                        if (dr[0][1].ToString() == "0")
                            continue;
                    dgv_clist.Rows.Add(k, data[0], data[1], data[2], data[3], data[4], dr[0][1].ToString() == "0" ? "만석" : dr[0][1], data[6]);
                    k++;
                }
            }
        }

        private void cCheck(string new_t1,string new_t2) // 겹치는 시간 있는지 체크 하는 함수
        {
            checktime = 0; //체크용 전역변수
            int currRowCount = dgv_reglist.RowCount;
            //string[] lecArray = new string [20];
            List<string> lecList = new List<string>(); //문자열 담을 리스트
            for (int i = 0; i < currRowCount; i++)
            {
                string day1 = Convert.ToString(dgv_reglist.Rows[i].Cells[6].Value);
                string time1 = Convert.ToString(dgv_reglist.Rows[i].Cells[7].Value);
                string day2 = Convert.ToString(dgv_reglist.Rows[i].Cells[9].Value);
                string time2 = Convert.ToString(dgv_reglist.Rows[i].Cells[10].Value);

                string t1 = day1 + time1;
                string t2 = day2 + time2;

                lecList.Add(t1);
                lecList.Add(t2);
                //lecArray.Append(t1);
                //lecArray.Append(t2);
            }
            /*
            int index = Array.IndexOf(lecArray, new_t1);
            int index2 = Array.IndexOf(lecArray, new_t2);

            if (index > -1)
            {
                checktime = -1;
                return;
            }
            else if (index2 > -1)
            {
                checktime = -1;
                return;
            }
            else
                checktime = 0;
                return;
            */
            /*
            foreach(string nn in lecList)
            {
                if (nn == new_t1)
                {
                    checktime = -1;
                    return;
                }
                else if (nn == new_t2)
                {
                    checktime = -1;
                    break;
                }
                    
            }
            */
            var Check = lecList.Contains(new_t1);
            var Check2 = lecList.Contains(new_t2);
            //var Check = Array.Exists(lecArray, x => x == new_t1);
            //var Check2 = Array.Exists(lecArray, x => x == new_t2);
            if (Check || Check2 == true)
                checktime = -1;
                return;
            
            
        }
        private void btn_apply_Click(object sender, EventArgs e)//수강신청 버튼 눌렀을 때
        {
            cCheck(tb_day1.Text + tb_time1.Text+"교시", tb_day2.Text + tb_time2.Text+"교시");
            if (selected == -1) // 조회한 과목이 없는 경우
            {
                MessageBox.Show("수강신청하려는 과목을 먼저 조회해주세요!", "오류", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }else if (selected == -2) // 만석인 과목을 신청하려는 경우
            {
                MessageBox.Show("해당 과목은 만석입니다", "여석 없음", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;

            }
            else if (selected == -3) // 이미 신청한 과목을 신청한 경우
            {
                MessageBox.Show("이미 수강신청이 완료된 과목입니다!", "수강신청 연습", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;

            }
            else if (checktime == -1)
            {
                MessageBox.Show("시간이 겹치는 강의가 있습니다!", "경고", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (Convert.ToInt32(textBox6.Text) > 22) //22학점 초과시 신청불가 기능
            {
                MessageBox.Show("수강학점이 22점을 초과 할 수 없습니다.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            
            
            //dgv_reglist에 추가하는 부분
            Thread.Sleep(1000); //신청 버튼 누르면 프로그램이 1초 멈춤(실제 프로그램도 딜레이 있음)
            if(tb_time1.Text=="비대면")
                dgv_reglist.Rows.Add("", tb_ccode.Text, tb_type.Text, tb_subject.Text, tb_credit.Text, tb_prof.Text, tb_day1.Text, tb_time1.Text, tb_room1.Text, tb_day2.Text, tb_time2.Text , "");
            else
                dgv_reglist.Rows.Add("", tb_ccode.Text, tb_type.Text, tb_subject.Text, tb_credit.Text, tb_prof.Text, tb_day1.Text, tb_time1.Text + "교시", tb_room1.Text, tb_day2.Text, tb_time2.Text + "교시", "");
            DataRow[] dr = dt.Select("num ='" + tb_ccode.Text + "'");
            dr[0][2] = "1";//신청했으므로 1로 전환
            int currRowCount = dgv_reglist.RowCount;//행 개수
            int totalCredit = 0; //총학점

            for (int i = 0; i < currRowCount; i++)
            {
                dgv_reglist.Rows[i].Cells[0].Value = i + 1;
                totalCredit += Convert.ToInt32(dgv_reglist.Rows[i].Cells[4].Value); // 수강신청 성공한 과목에서 학점 더함
            }
            textBox6.Text = Convert.ToString(totalCredit);// 총 학점 표시

            dgv_reglist.CurrentCell = null;
            clearing();
            //done[selected] = true;
            this.Text = "수강신청 성공 과목 수 [" + currRowCount + "/" + "10" + "]";
            selected = -1;

        }

        void clearing()
        {
            tb_ccode.Text = null;
            tb_type.Text = null;
            tb_subject.Text = null;
            tb_credit.Text = null;
            tb_prof.Text = null;
            tb_day1.Text = null;
            tb_time1.Text = null;
            tb_day2.Text = null;
            tb_time2.Text = null;
            tb_day3.Text = null;
            tb_time3.Text = null;
            tb_day4.Text = null;
            tb_time4.Text = null;

            tb_room1.Text = null;
        }

        private void btn_start_Click(object sender, EventArgs e)//수강 신청시작 버튼 눌렀을 때
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
                thread= new Thread(Randomseats);//thread로 랜덤으로 숫자 감소
                thread.IsBackground = true;
                thread.Start();

                return;
            }
            curTime.Text="09:59:"+sec.ToString();//시간 update
        }

        public static int[] generatorRandomNumber(int min, int max, int count)//범위 내 랜덤 숫자 반환
        {
            int[] intArray = new int[count];
            Random rand = new Random();

            for (int loop = 0; loop < count; loop++)
            {
                intArray[loop] = rand.Next(min, max);
            }

            return intArray;
        }

        private void Randomseats()//랜덤 여석줄어들기 구현
        {
            for(int j = 0; j < 10; j++) // 10번 실행
            {
                Thread.Sleep(3000);//3초 delay
                randNums = generatorRandomNumber(0, 20, dt.Rows.Count);//과목수 만큼 생성
                for (int i = 0; i < randNums.Length; i++)
                {
                    if (dt.Rows[i][1].ToString() == "0")//0이면 안 빼줌
                        continue;
                    if (dt.Rows[i][3].ToString() != "X")
                        dt.Rows[i][1] =(Convert.ToInt32(dt.Rows[i][1].ToString()) - randNums[i]).ToString();//여석 감소
                    else
                        dt.Rows[i][1] = (Convert.ToInt32(dt.Rows[i][1].ToString()) - 3 * randNums[i]).ToString();//온라인 수업이면 3배 빠르게 감소
                    if (Convert.ToInt32(dt.Rows[i][1].ToString()) <= 0)//음수면 0으로 설정 
                        dt.Rows[i][1] = "0";

                }

            }

        }

        private void btn_favadd_Click(object sender, EventArgs e)//즐겨찾기에 추가하는 기능
        {
            Form3 form3 = new Form3();
            DialogResult dResult = form3.ShowDialog(); // 인증번호를 입력받는 form3 실행
            if (dResult == DialogResult.No)
            {
                MessageBox.Show("인증번호를 바르게 입력하세요!", "대학 수강신청"); // form3에서 인증번호가 틀리면 추가가 되지 않음
            }
            else if (dResult == DialogResult.OK) // form3에서 인증번호가 맞으면 즐겨찾기 목록에 추가
            {
                String add_fav_num = cmb_favNum.SelectedItem as String;
                if (add_fav_num == null) // 즐겨찾기 목록이 비어있는 경우
                {
                    MessageBox.Show("즐겨찾기 번호를 선택해 주세요", "수강신청 연습", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }
                if (dgv_clist.Rows.Count == 0) // 즐겨찾기에 추가할 과목이 없는 경우
                {
                    MessageBox.Show("즐겨찾기에 추가할 과목을 선택해 주세요", "수강신청 연습", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }

                DataGridViewRow row = dgv_clist.SelectedRows[0]; //선택된 Row 값 가져옴.

                String add_fav_ccode = row.Cells[1].Value.ToString();//학정번호
                String add_fav_type = row.Cells[2].Value.ToString();//구분
                String add_fav_subj = row.Cells[3].Value.ToString();//과목명
                String add_fav_credit = row.Cells[4].Value.ToString();//학점
                String add_fav_prof = row.Cells[5].Value.ToString();//교수
                String add_fav_seat = row.Cells[6].Value.ToString();//여석
                String add_fav_time = row.Cells[7].Value.ToString();//강의시간
                String add_fav_room = "";//강의실
                int index = Convert.ToInt32(cmb_favNum.SelectedItem) - 1;

                dgv_favList.Rows[index].Cells[2].Value = add_fav_ccode.ToString();//학정번호
                dgv_favList.Rows[index].Cells[3].Value = add_fav_subj.ToString();//과목명
                dgv_favList.Rows[index].Cells[4].Value = add_fav_credit.ToString();//학점
                dgv_favList.Rows[index].Cells[5].Value = add_fav_prof.ToString();//교수
                dgv_favList.Rows[index].Cells[6].Value = add_fav_time.ToString();//시간
                dgv_favList.Rows[index].Cells[7].Value = add_fav_room.ToString();//강의실
                dgv_favList.Rows[index].Cells[8].Value = add_fav_seat.ToString();//여석
                dgv_favList.Rows[index].Cells[9].Value = add_fav_type.ToString();//구분
            }
        }

        private void dgv_favList_CellContentClick(object sender, DataGridViewCellEventArgs e)//조회 버튼 눌렀을 때
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgv_favList.Columns["fav_add"].Index) return;//index가 0 이하로 떨어지면 리턴
            if (!isStarted)//수강 신청 시작하면 조회 가능
            {
                MessageBox.Show("수강신청이 시작된 이후에만 조회가 가능합니다.", "수강신청 연습", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (dgv_favList.Rows[e.RowIndex].Cells[2].Value.ToString() == "")//빈칸 조회했을 때
            {
                MessageBox.Show("즐겨찾기에 과목을 추가해야 조회가 가능합니다.", "수강신청 연습", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;

            }
            DataRow[] dr = dt.Select("num ='" + dgv_favList.Rows[e.RowIndex].Cells[2].Value.ToString() + "'");
            selected = e.RowIndex;
            
            if (dr[0][1].ToString() =="0")//여석이 없을 때
            {
                selected = -2;

            }
            if(dr[0][2].ToString() == "1")//이미 신청한 과목일때
            {
                selected = -3;
            }
            for (int i = 0; i < dgv_reglist.RowCount; i++)// 같은 이름일 때
                if (dgv_reglist.Rows[i].Cells[3].Value.ToString() == dgv_favList.Rows[e.RowIndex].Cells[3].Value.ToString())
                    selected = -3;
            if (prevccode == dgv_favList.Rows[e.RowIndex].Cells[2].Value as String) // 같은 과목 신청 시 click 1 증가
                click++;
            else
                click = 0; // 같은 과목이 아니면 다시 0으로 설정
            if(click > 3) // 같은 과목을 5번 이상 조회 시
            {
                Form3 form3 = new Form3();
                DialogResult dResult = form3.ShowDialog(); // 인증번호를 입력받는 form3 실행
                if (dResult == DialogResult.No)
                {
                    MessageBox.Show("인증번호를 바르게 입력하세요!", "대학 수강신청"); // form3에서 인증번호가 틀리면 검색이 되지 않음
                    clearing();
                    selected = -1;
                    return;
                }
            }
            prevccode = dgv_favList.Rows[e.RowIndex].Cells[2].Value as String; // prevccode를 현재 조회한 과목으로 설정
            tb_ccode.Text=dgv_favList.Rows[e.RowIndex].Cells[2].Value as String;
            tb_subject.Text = dgv_favList.Rows[e.RowIndex].Cells[3].Value as String;
            tb_credit.Text= dgv_favList.Rows[e.RowIndex].Cells[4].Value as String;
            tb_prof.Text= dgv_favList.Rows[e.RowIndex].Cells[5].Value as String;
            String times = dgv_favList.Rows[e.RowIndex].Cells[6].Value as String;//시간 split 처리 필요


            times = times.Trim();
            String t1 = ""; String d1 = ""; String t2 = ""; String d2 = ""; String t3 = ""; String d3 = ""; String t4 = ""; String d4 = "";
            String t5 = ""; String d5 = ""; String t6 = ""; String d6 = ""; String t7 = ""; String d7 = "";
            for (int i = 0; i < times.Length; i += 2)
            {
                if (times[i].ToString() == "월")
                {
                    t1 += times[i + 1].ToString();
                }
                if (times[i].ToString() == "화")
                {
                    t2 += times[i + 1].ToString();
                }

                if (times[i].ToString() == "수")
                {
                    t3 += times[i + 1].ToString();
                }

                if (times[i].ToString() == "목")
                {
                    t4 += times[i + 1].ToString();
                }

                if (times[i].ToString() == "금")
                {
                    t5 += times[i + 1].ToString();
                }

                if (times[i].ToString() == "토")
                {
                    t6 += times[i + 1].ToString();
                }
                if (times[i].ToString() == "X")
                {
                    t7 = "비대면";
                }
            }
            List<String> T = new List<String>();
            if (t1 != "")
            {
                T.Add("월");
                T.Add(t1);
            }
            if (t2 != "")
            {
                T.Add("화");
                T.Add(t2);
            }
            if (t3 != "")
            {
                T.Add("수");
                T.Add(t3);
            }
            if (t4 != "")
            {
                T.Add("목");
                T.Add(t4);
            }
            if (t5 != "")
            {
                T.Add("금");
                T.Add(t5);
            }

            if (t6 != "")
            {
                T.Add("토");
                T.Add(t6);
            }
            if (t7 != "")
            {
                //T.Add(" ");
                T.Add(t7);
            }
            T.Add(" ");
            T.Add(" ");
            T.Add(" ");
            T.Add(" ");
            T.Add(" ");
            T.Add(" ");
            T.Add(" ");
            T.Add(" ");
            T.Add(" ");




            tb_day1.Text = T[0];
            tb_time1.Text = T[1];
            tb_day2.Text = T[2];
            tb_time2.Text = T[3];
            tb_day3.Text = T[4];
            tb_time3.Text = T[5];
            tb_day4.Text = T[6];
            tb_time4.Text = T[7];
            tb_day4.Text = T[8];
            tb_time4.Text = T[9];
            tb_room1.Text=dgv_favList.Rows[e.RowIndex].Cells[7].Value as String;
            tb_avail.Text = (dr[0][1].ToString() == "0") ?"만석":"여석";
            tb_type.Text= dgv_favList.Rows[e.RowIndex].Cells[9].Value as String;

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btn_favclear_Click(object sender, EventArgs e)//즐찾에서 삭제 버튼 눌렀을 떄
        {
            DataGridViewRow row = dgv_favList.SelectedRows[0]; //선택된 Row 값 가져옴.
            row.SetValues("조회", row.Cells[1].Value.ToString(), "", "", "", "", "", "", "", "", "");
        }

        private void btn_del_Click(object sender, EventArgs e)//수강삭제 버튼 눌렀을 때
        {
            DataGridViewRow row = dgv_reglist.SelectedRows[0]; //선택된 Row 값 가져옴.
            DataRow[] dr = dt.Select("num ='" + row.Cells[1].Value.ToString() + "'");
            selected = -1;//삭제했므로 selected=-1로 재설정
            dr[0][2] = "0";//삭제했으므로 0으로 재설정
            dgv_reglist.Rows.Remove(row);

            int currRowCount = dgv_reglist.RowCount;//행 개수

            for (int i = 0; i < currRowCount; i++)
            {
                dgv_reglist.Rows[i].Cells[0].Value = i + 1;
            }

        }

        public DataTable CSVtoDataTable(string strFilePath)
        {
            StreamReader file=new StreamReader(strFilePath);
            DataTable dt = new DataTable();
            dt.Columns.Add("num");
            dt.Columns.Add("seat");
            dt.Columns.Add("isApply");
            dt.Columns.Add("time");//신청된 과목인지
            dt.Columns.Add("Name");
            String firstLine=file.ReadLine();
            while (!file.EndOfStream)
            {
                string line=file.ReadLine();
                string[] data = line.Split(',');
                dt.Rows.Add(data[0], data[5], 0, data[6],data[2]);
            }
            return dt;
        }

        private void btn_sched_Click(object sender, EventArgs e)
        {

            
            Form4 form4 = new Form4();
            // Get the data from DataGridView
            // Get the data from dgv_reglist
            DataGridViewData = GetDataFromDataGridView(dgv_reglist);

            // Pass the data to Form2
            form4.DataGridViewData = DataGridViewData;
            form4.Show();
        }

        private string[,] GetDataFromDataGridView(DataGridView dataGridView)
        {
            int rowCount = dataGridView.Rows.Count;
            string[,] values = new string[rowCount, 3]; // Modify the size based on the number of columns

            // Iterate over the rows in the DataGridView and extract the data
            for (int row = 0; row < rowCount; row++)
            {
                values[row, 0] = dataGridView.Rows[row].Cells[3].Value?.ToString() ?? string.Empty; // 과목명
                values[row, 1] = dataGridView.Rows[row].Cells[5].Value?.ToString() ?? string.Empty; // 교수
                DataRow[] dr = dt.Select("Num = '" + dataGridView.Rows[row].Cells[1].Value?.ToString() + "'");
                values[row, 2] = dr[0][3].ToString() ?? string.Empty;
            }

            return values;
        }


        private void btn_restart_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void github_link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/3911237/team_project");
        }
    }
}

