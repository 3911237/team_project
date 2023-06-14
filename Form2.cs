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
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;
//taskkill /pid 프로세스ID /f /t

//dgv_reglist 비율 수정필요, 시간 split필요
//추가적으로 학번 성명 표기

namespace Kwangwoon_Sugang_Practice_Project
{
    public partial class Form2 : Form
    {
        int sec = 50;
        bool isStarted=false;//수강신청 시작했는지
        int selected = -1;//즐찾에서 조회버튼 누를때
        //List<bool> done = new List<bool>();//수강신청한 과목들
        //List<bool> full = new List<bool>();//여석이 다 찼는 지
        //int num=0;//몇개의 수강신청 신청했는 지
        string CsvFilePath = "2023_01_lecture_list.csv";
        DataTable dt;
        int k = 1; // 검색 순번

        int[] randNums;

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
            dt.PrimaryKey = new DataColumn[] { dt.Columns["num"], dt.Columns["seat"] };//key 설정
            cmb_favNum.SelectedIndex = 0;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_end_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("수강신청을 완료 하시겠습니까?", "수강신청", MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
                Application.Exit();
        }

        public void DataReceive(string id, string pw)
        {
            textBox3.Text = id;
            textBox2.Text = pw;
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
        } // 검색할 학부 및 학과 선택

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
                    } // 선택한 학부 및 학과만 검색 결과에 나오게 함
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
                        continue; // 검색창에 입력한 텍스트를 포함한 과목만 표시함
                    DataRow[] dr = dt.Select("num ='" + data[0] + "'");
                    if (cb_avail.Checked)
                        if (dr[0][1].ToString() == "0")
                            continue;
                    dgv_clist.Rows.Add(k, data[0], data[1], data[2], data[3], data[4], dr[0][1].ToString() == "0" ? "만석" : dr[0][1], data[6]);
                    k++;
                }
            }
        }

        private void btn_apply_Click(object sender, EventArgs e)//수강신청 버튼 눌렀을 때
        {
            if (selected == -1)
            {
                MessageBox.Show("수강신청하려는 과목을 먼저 조회해주세요!", "오류", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }else if (selected == -2)
            {
                MessageBox.Show("해당 과목은 만석입니다", "여석 없음", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;

            }
            else if (selected == -3)
            {
                MessageBox.Show("이미 수강신청이 완료된 과목입니다!", "수강신청 연습", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            */
            //dgv_reglist에 추가하는 부분
            Thread.Sleep(1000); //신청 버튼 누르면 프로그램이 1초 멈춤(실제 프로그램도 멈춤)
            dgv_reglist.Rows.Add("", tb_ccode.Text, tb_type.Text, tb_subject.Text, tb_credit.Text, tb_prof.Text, tb_day1.Text, tb_time1.Text + "교시", tb_room1.Text, tb_day2.Text, tb_time2.Text + "교시", "");
            DataRow[] dr = dt.Select("num ='" + tb_ccode.Text + "'");
            dr[0][2] = "1";//신청했으므로 1로 전환
            int currRowCount = dgv_reglist.RowCount;//행 개수
            int totalCredit = 0; //총학점

            for (int i = 0; i < currRowCount; i++)
            {
                dgv_reglist.Rows[i].Cells[0].Value = i + 1;
                totalCredit += Convert.ToInt32(dgv_reglist.Rows[i].Cells[4].Value); // 수강신청 성공한 과목에서 학점 덧셈
            }
            textBox6.Text = totalCredit + "점"; // 총학점표시

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
                Thread thread = new Thread(Randomseats);//thread로 랜덤으로 숫자 감소
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
            
            //Random random = new Random();
            for(int j = 0; j < 10; j++)//계속해서 생성해줘야 함
            {
                Thread.Sleep(3000);//3초 delay
                randNums = generatorRandomNumber(0, 20, dt.Rows.Count);//과목수 만큼 생성
                for (int i = 0; i < randNums.Length; i++)
                {
                    if (Convert.ToInt32(dt.Rows[i][1]) == 0)//0이면 안 빼줌
                        continue;
                    if (Convert.ToString(dt.Rows[i][3]) != "X")
                        dt.Rows[i][1] = (Convert.ToInt32(dt.Rows[i][1]) - randNums[i]).ToString();//빼기
                    else
                        dt.Rows[i][1] =  (Convert.ToInt32(dt.Rows[i][1]) - 3 * randNums[i]).ToString();//온라인 수업이면 3배 더 빠르게 뺌
                    if (Convert.ToInt32(dt.Rows[i][1]) <= 0)//음수면 0으로 설정 
                        dt.Rows[i][1] = "0";

                }

            }

        }

        private void btn_favadd_Click(object sender, EventArgs e)//즐찾에 추가하는 기능
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
                if (add_fav_num == null)
                {
                    MessageBox.Show("즐겨찾기 번호를 선택해 주세요", "수강신청 연습", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }
                if (dgv_clist.Rows.Count == 0)
                {
                    MessageBox.Show("즐겨찾기에 추가할 과목을 선택해 주세요", "수강신청 연습", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }

                DataGridViewRow row = dgv_clist.SelectedRows[0]; //선택된 Row 값 가져옴.

                String add_fav_ccode = row.Cells[1].Value.ToString();//학점번호
                String add_fav_type = row.Cells[2].Value.ToString();//구분
                String add_fav_subj = row.Cells[3].Value.ToString();//과목명
                String add_fav_credit = row.Cells[4].Value.ToString();//학점
                String add_fav_prof = row.Cells[5].Value.ToString();//교수
                String add_fav_seat = row.Cells[6].Value.ToString();//여석
                String add_fav_time = row.Cells[7].Value.ToString();//강의시간
                String add_fav_room = "";//강의실
                int index = Convert.ToInt32(cmb_favNum.SelectedItem) - 1;

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
        }

        private void dgv_favList_CellContentClick(object sender, DataGridViewCellEventArgs e)//조회 버튼 눌렀을 때
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgv_favList.Columns["fav_add"].Index) return;
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
                //MessageBox.Show("해당 과목은 만석입니다.", "수강신청 연습", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                selected = -2;

            }
            if(dr[0][2].ToString() == "1")//이미 신청한 과목일때
            {
                selected = -3;
            }
            for (int i = 0; i < dgv_reglist.RowCount; i++)// 같은 이름일 때
                if (dgv_reglist.Rows[i].Cells[3].Value.ToString() == dgv_favList.Rows[e.RowIndex].Cells[3].Value.ToString())
                    selected = -3;
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
                    t7 += times[i + 1].ToString();
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

            if (t7 != "")
            {
                T.Add("토");
                T.Add(t6);
            }
            if (t7 != "")
            {
                T.Add("X");
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
/*            DialogResult dr=MessageBox.Show("수강신청을 완료 하시겠습니까?","수강신청",MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(dr==DialogResult.Yes)
*/                Application.Exit();
            
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

            //dgv_reglist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            int currRowCount = dgv_reglist.RowCount;//행 개수

            for (int i = 0; i < currRowCount; i++)
            {
                dgv_reglist.Rows[i].Cells[0].Value = i + 1;
            }

        }

        public DataTable CSVtoDataTable(string strFilePath)
        {
            //List<String>x=new List<String>();
            //List<String>y=new List<String>();
            StreamReader file=new StreamReader(strFilePath);
            DataTable dt = new DataTable();
            dt.Columns.Add("num");
            dt.Columns.Add("seat");
            dt.Columns.Add("isApply");
            dt.Columns.Add("time");//신청된 과목인지

            while (!file.EndOfStream)
            {
                string line=file.ReadLine();
                string[] data = line.Split(',');
                dt.Rows.Add(data[0], data[5], 0, data[6]);
                //x.Add(data[0]);
                //y.Add(data[5]);
            }
            return dt;
        }

        private void btn_sched_Click(object sender, EventArgs e)
        {

            
            Form4 form4 = new Form4();
            //form4.ShowDataFromDataGridView(GetDataGridViewValues(dgv_reglist));
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
                values[row, 0] = dataGridView.Rows[row].Cells[3].Value?.ToString() ?? string.Empty; // Column 4
                values[row, 1] = dataGridView.Rows[row].Cells[5].Value?.ToString() ?? string.Empty; // Column 6
                values[row, 2] = dataGridView.Rows[row].Cells[6].Value?.ToString() ?? string.Empty; // Column 7
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

