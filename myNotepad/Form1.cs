using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using myLibrary;

namespace myNotepad
{
    public partial class Form1 : Form
    {
        string filePath = null;
        public Form1()
        {
            InitializeComponent();
        }
        //[DllImport("kernel32.dll")]                                                                                                       // IniClass 사용하지 않을 경우 필요
        //static extern int GetPrivateProfileString(string sec, string key, string def, StringBuilder buf, int bSize, string Path);

        //[DllImport("kernel32.dll")]
        //static extern bool WritePrivateProfileString(string sec, string key, string val, string Path);


        void AddLine(string str)
        {
            tbMemo.Text += str + "\r\n";
        }

        string strOrg = "";                                   // String Original
        int viewState = 0;                                    // 0: Normal(Edit 가능)  1: Lower   2: Upper   3: Hexa
        private void mnuViewLower_Click(object sender, EventArgs e)     // *********원본 보존*********
        {
            if(viewState != 1)          // 중복 방지
            {
                if(strOrg == "") strOrg = tbMemo.Text;         // 되돌리기할 원본 없으면 저장
                tbMemo.Text = strOrg.ToLower();                // 변환은 '원본'을 대상으로 // 복사본을 소문자로 바꿔서 반환     // tbMemo.Text = string
                tbMemo.ReadOnly = true;                        // 수정불가
                viewState = 1;                                 // 재차 눌리는 것 방지
            }
        }

        private void mnuViewUpper_Click(object sender, EventArgs e)
        {
            if (viewState != 2)
            {
                if (strOrg == "") strOrg = tbMemo.Text;         // 되돌리기할 원본 없으면 저장
                tbMemo.Text = strOrg.ToUpper();                 // 복사본을 대문자로 바꿔서 반환     // tbMemo.Text = string
                tbMemo.ReadOnly = true;                         // 수정불가
                viewState = 2;                                  // 재차 눌리는 것 방지
            }
        }

        private void mnuViewHexa_Click(object sender, EventArgs e)
        {
            if (viewState != 3)
            {                                                   // C#, char(문자), string을 정수로 바로 변환 불가  -> 강제 형변환 해야.
                if (strOrg == "") strOrg = tbMemo.Text;         // 되돌리기할 원본 없으면 저장
                tbMemo.Text = "";                               // 안 하면 tb 에 원본이랑 16진수 같이 나옴

                string s1;
                char[] chr = strOrg.ToCharArray();
                byte[] bArr = Encoding.Default.GetBytes(chr);   // byte가 C/C++의 char(숫자로 변환 가능)     // 통신, Encoding 필요
                for (int i = 0; i < bArr.GetLength(0); i++)
                {
                    //s1 = string.Format(" {0:X2}", bArr[i]);   // printf(" %x ", n), 왼쪽과 같이 쓰는 것 번거로움 -> 보간문자열 제공
                    s1 = $" {bArr[i]:X2}";                      // 보간 문자열(문자열 옆에 $ 사용), 출력하고자 하는 문자열, 중괄호 내에 직접 사용(포맷문자열로 기능함)
                    if (i % 16 == 15) s1 += "\r\n";
                    tbMemo.Text += s1;

                }
                //tbMemo.Text += "\r\n===================================================\r\n";


                //for (int i = 0, count = 0; i < strOrg.Length; i++, count++)   // 다른 방법 시도 중
                
                //int count = 0;
                //foreach (byte c in bArr)
                //{
                //    //s1 = string.Format(" {0:X} ", Convert.ToString(strOrg[i] - '0', 16));      // printf("%x", n); -> 16진수
                //    s1 = $" {c:X2}";
                //    if (count++ % 16 == 15) s1 += "\r\n";
                //    tbMemo.Text += s1;              // Convert.ToString(strOrg[i] - '0', 16) -> 16진수로 변환하는 함수(변환하고 싶은 10진 정수, 몇 진수로 변환?)
                //    //count++;
                //}


                tbMemo.ReadOnly = true;                         // 재차 눌리는 것 방지
                viewState = 3;
            }
        }

        private void mnuViewRefresh_Click(object sender, EventArgs e)
        {                                                               
            if(strOrg != "")                                    // 중복 감지 안 넣어놓음. 두 번 누르면 다 지워짐. // 방지 위해 해당 if문 넣음
            {
                tbMemo.Text = strOrg;
                strOrg = "";                                    // 원본 tb에 되돌린 후 저장된 것 삭제
                tbMemo.ReadOnly = false;
                viewState = 0;
            }
        }


        private void tbMemo_KeyDown(object sender, KeyEventArgs e)  // ESC 이용해 되돌리기     // form이 아니라 textbox로 하는 이유는 제어권이 tb에 있음.
        {                                                           //e.KeyData 이용해보기     // c/c++의 enum -> 요일, 정수값으로 바로 비교 가능
            if (e.KeyCode == Keys.Escape)                           // Keys라는 enum 정의 사용해야 비교 가능.
                mnuViewRefresh_Click(sender, e);
        }


        
        private void mnuFileNew_Click(object sender, EventArgs e)
        {
            tbMemo.Text = "";
            filePath = null;
            this.Text = "NotePad v1.0  " + $"{filePath:s}";                     // 프로그램 title bar, 파일 경로 달라졌으니 반영
        }

        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            openFileDialog.FileName = "";
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";  // Dialog 하단 확장자 설정
            openFileDialog.FilterIndex = 2;                                     // Filter 중 두 번째 것 Default로
            if (openFileDialog.ShowDialog() == DialogResult.OK)                 // == Domdal, 종속적인 호출임    // X표로 나갔을 때 오류 막기 위해(filename에 값X) if문
            {                                                                                                   // 아니면 DaialogResult r = saveFileDialog.ShowDialog();
                //tbMemo.Text += openFileDialog.FileName + "\r\n";              // FileName은 string, fullpath로 나옴
                filePath = openFileDialog.FileName;
                StreamReader sr = new StreamReader(openFileDialog.FileName);    // StreamReader 객체 생성 openFileDialog에서 받아온 경로에 있는 파일
                tbMemo.Text = sr.ReadToEnd();                                   // ReadToEnd() -> file 끝까지 읽어서 string으로 되돌려 줌. // tbMemo에 바로 출력
                sr.Close();                                                     // Stream 객체 닫아줌
                this.Text = "NotePad v1.0  " + $"{filePath:s}";                 // 프로그램 title bar, 파일 경로 달라졌으니 반영
                //tbMemo.Text = filePath;
                //tbMemo.Text = GetToken1(4, filePath, '\\' );                    // GetToken 시험
            }
        }

        private void mnuFileSave_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = Path.GetFileName(filePath);               // 저장 누를 시, 오픈했던 파일명 나옴. // saveFileDialog는
            saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 2;
            if(filePath != null)
            {
                StreamWriter sw = new StreamWriter(filePath);                   // MsDocs에서 좌측에 생성자 -> 오버로드
                sw.Write(tbMemo.Text);                                          // StreamWriter 객체에 tbMemo에 출력되고 있는 text 입력함
                sw.Close();
            } 
            else
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = saveFileDialog.FileName;
                    StreamWriter sw = new StreamWriter(saveFileDialog.FileName);// MsDocs에서 좌측에 생성자 -> 오버로드
                    sw.Write(tbMemo.Text);
                    sw.Close();
                    this.Text = "NotePad v1.0  " + $"{filePath:s}";             // 프로그램 title bar, 파일 경로 달라졌으니 반영
                }
            }
            
        }

        private void mnuFileSaveAs_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = Path.GetFileName(filePath);               // 저장 누를 시, 오픈했던 파일명 나옴.
            saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 2;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = saveFileDialog.FileName;
                StreamWriter sw = new StreamWriter(saveFileDialog.FileName);    // MsDocs에서 좌측에 생성자 -> 오버로드
                sw.Write(tbMemo.Text);
                sw.Close();
                this.Text = "NotePad v1.0  " + $"{filePath:s}";                 // 프로그램 title bar, 파일 경로 달라졌으니 반영
            }
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // mylib ml = new mylib();
        int num = 0;
        private void mnuEditTest_Click(object sender, EventArgs e)              // GetToken 시험
        {
            AddLine($"{mylib.GetToken(num++, "a,b,c,d", ',')}");
            //tbMemo.Text += $"{GetToken(num++, "a,b,c,d", ',')}";
            tbMemo.Text = mylib.GetTokenJM(4, filePath, '\\');
        }


        Point p;
        private void mnuEditCallTest_Click(object sender, EventArgs e)
        {
            Form2 dlg = new Form2();                                            // dlg의 유효범위는 CallTest 메서드 안
            dlg.Location = p;                                                   // 최초의 위치 p(전역변수)
            //if(sbLabel1.Text != "")                                           // 직전의 CallTest 내용 다시  // speed, parity, databit에 "," 더해야 함
            //{
            //    if (sbLabel1.Text.Substring(0, 4) == dlg.rbCOM1.Text) dlg.rbCOM1.Checked = true;
            //    else dlg.rbCOM2.Checked = true;
            //    string str1 = sbLabel1.Text.Substring(5, sbLabel1.Text.Length - 5);
            //    dlg.cbbSpeed.Text = GetTokenJM(0, str1, ',');
            //    dlg.cbbParity.Text = GetTokenJM(1, str1, ',');
            //    dlg.cbbDatabit.Text = GetTokenJM(2, str1, ',');
            //    dlg.cbbStopbit.Text = GetTokenJM(3, str1, ',');
            //}

            if(sbLabel1.Text != "")                                             // 직전의 CallTest 내용 다시  // "," 없이
            {
                string str1 = mylib.GetTokenJM(0, sbLabel1.Text, ':');
                string str2 = mylib.GetTokenJM(1, sbLabel1.Text, ':');
                if (str1 == dlg.rbCOM1.Text) dlg.rbCOM1.Checked = true;
                else dlg.rbCOM2.Checked = true;
                dlg.cbbSpeed.Text = str2.Substring(0, str2.Length - 3);
                dlg.cbbParity.Text = str2.Substring(str2.Length - 3, 1);
                dlg.cbbDatabit.Text = str2.Substring(str2.Length - 2, 1);
                dlg.cbbStopbit.Text = str2.Substring(str2.Length - 1, 1);       
            }

            //if (sbLabel1.Text != "")                                              // 강사님. , 하나만 넣고  // 아직 쳐야할 거 남음
            //{
            //    string s1, s2, s3;
            //    s1 = GetToken(0, sbLabel1.Text, ':');
            //    if (s1 == "com1") dlg.rbCOM1.Checked = true;
            //    else if (s1 == "com2") dlg.rbCOM2.Checked = true;

            //    //s3 = gettoken(1, sblabel1.text, ':'); // com1:9600:,n81 ==> 9600,n81
            //    //s2 = gettoken(0, s3, ','); // 9600,n81 ==> 9600
            //    s2 = GetToken(0, GetToken(1, sbLabel1.Text, ':'), ',');
            //    dlg.cbbSpeed.Text = s2;

            //    s3 = GetToken(1, sbLabel1.Text, ',');   // N81

            //    //dlg.cbbParity.Text = (s3[0] == 'N') ? "  none" : // 8
            //    //                    (s3[0] == 'O') ? "  odd" :
            //    //                    (s3[0] == 'E') ? "  Even" : "";

            //}


                if (dlg.ShowDialog() == DialogResult.OK)                             // COM1:9600N81 문자열 만들기
            {
                //string str;
                //if (dlg.rbCOM1.Checked) str = "COM1:";                        // 삼항연산자와 동일
                //else if (dlg.rbCOM2.Checked) str = "COM2:";
                //else str = "XXX:";

                // 3개라면, 오른쪽을 또 다른 삼항연산자로 만듦
                // string str = (dlg.rbCOM1.Checked)? "COM1:":
                //  (dlg.rbCOM2.Checked)? "COM2:":"XXXX";
                string str = (dlg.rbCOM1.Checked)? "COM1:":"COM2:" ;            // 삼항연산자 사용     
                str += dlg.cbbSpeed.Text;                                       
                str += dlg.cbbParity.Text.Trim().ToUpper()[0];                  // None, Odd, Even: 한글자씩만 // 소문자인데 대문자로 바꿔서 출력 원하면 // Substring(0, 1)   
                str += dlg.cbbDatabit.Text;
                str += dlg.cbbStopbit.Text;
                
                //AddLine(str);
                sbLabel1.Text = str;
            }
            p = dlg.Location;                                                   // 다음 호출땐 변화된 위치로
        }

        string iniPath = ".\\myNotepad.ini";                                    // '.ini' 파일 전체 경로 // 실행파일과 같은 곳에 있을 땐, 파일이름만 써도 됨
        IniClass ini = new IniClass(".\\myNotepad.ini");                        // 절대경로로            // 선언, 사전 준비 필요 X
        IniClass ini2 = new IniClass(".\\myNotepadEx.ini");                                             // 위와 전혀 다름         // GetToken과 비교
        private void Form1_Load(object sender, EventArgs e)
        {
            //StringBuilder buf = new StringBuilder(500);                         // ini 파일 데이터('='우측의 value의 최대 사이즈) // IniClass 이용 X 방법

            //GetPrivateProfileString(string sec, string key, string def, StringBuilder buf, int bSize, string Path);       // IniClass 이용 X 방법
            //GetPrivateProfileString("Form1", "LocationX", "0", buf, 500, iniPath); int x = int.Parse(buf.ToString());     // IniClass 이용 X 방법
            //GetPrivateProfileString("Form1", "LocationY", "0", buf, 500, iniPath); int y = int.Parse(buf.ToString());     // IniClass 이용 X 방법
            int x = int.Parse(ini.GetString("Form1", "LocationX", "0"));             // 에러 가능성 존재. 한번이라도 Write되면 문제 없으나, null 문자열 입력 시(ini file 없을 시) 에러.(int.parse에서) => 예외처리 필요
            int y = int.Parse(ini.GetString("Form1", "LocationY", "0"));
            Location = new Point(x, y);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //WritePrivateProfileString("Form1", "LocationX", $"{Location.X}", iniPath);
            //WritePrivateProfileString("Form1", "LocationY", $"{Location.Y}", iniPath);
            ini.WriteString("Form1", "LocationX", $"{Location.X}");
            ini.WriteString("Form1", "LocationY", $"{Location.Y}");
        }

        private void callTest2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddLine(mylib.GetInput("문자열 입력 테스트"));
            //frmInput frm = new frmInput("문자열 입력 테스트");
            //if(frm.ShowDialog() == DialogResult.OK)
            //{
            //    AddLine(frm.retStr);
            //}
        }
    }
}
