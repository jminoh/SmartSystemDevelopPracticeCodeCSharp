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


namespace myNotepad
{
    public partial class Form1 : Form
    {
        string filePath = null;
        public Form1()
        {
            InitializeComponent();
        }
        string GetTokenJM(int n, string str, char d)        // 0이 C:
        {                                                   // for문 str.Length 문제 아님. return 못타고 밖의 for문 타서 연속해서 찍힘
            int count = 0;                                  // string GetToken(int n, string str, char d)
            string re = "";                                 // n: n번째 Item, str: 문자열, d: 구분자, 
            char[] chr = str.ToCharArray();                 // 문자열 str에 있는 데이터를 구분자 d를 통해 필드 구분하여, 그 중 n번째 데이터 반환
            for(int i = 0; i < str.Length; i++)             // ex) GetToken(1, "a,b,c,d", ',') => "b"
            {
                if (d == chr[i]) count += 1;                // 구분자 만나면 구분자 카운트++, n이랑 비교할 거
                if (n == 0)                                 // 0번째 Item이면 구분자 나오기 전까지
                    for (int j = 0; j < str.Length; j++)
                    {
                        re += chr[j];                       // 구분자 만나기 전까지 돌아서
                        if (d == str[j + 1]) return re;     // 만나면 return
                    }
                if (n == count)                             // n과 구분자 만나버리면 print할 것 저장 시작
                {
                    for (int j = i + 1; j < str.Length; j++)// 구분자 다음부터 string에 저장
                    {
                        if (d == chr[j]) return re;         // 다음 문자가 구분자면 return
                        re += chr[j];                       // 다음 문자가 구분자 아니면 string에 저장
                    }
                    return re;                              // 구분자 못 만나고 끝까지 저장했으면 return
                }
            }
            return re;
        }
        string GetToken1(int n, string str, char d)         // 강사님
        {                                                   // 경계조건 잘 생각해야
            int i, j, k, n1, n2;                            //n1 = start, n2 = end
                                                            // k = 구분자 개수, 다 돌게 되어 d = k
            for (i = j = k = n1 = n2 = 0; i < str.Length; i++)
            {
                if (str[i] == d) k++;                       // 구분자 만나면 k++
                if (k == n)                                                                                 // ***********이거 계속 탐 수정 어떻게 하심??????
                    n1 = i;                                 // n번째 구분자면 n1에 반환할 첫 문자 위치                 // 아래 if문 이거 종속으로 넣고, n2 = i후에 i = str.Length 해야 함??                                
                if (k == n + 1) n2 = i;                     // n+1번째 구분자면 n2에 반환 문자열 마지막 문자 위치
            }
            if (n1 == 0) return "";                         // 구분자가 첫 자면 반환
            if (n2 == 0) n2 = str.Length + 1;
            return str.Substring(n1, (n2 - 1) - n1);
        }

        string GetToken(int n, string str, char d)          // 강사님
        {
            string[] sArr = str.Split(d);                   // 구분자로 문자열 나눠 문자열 배열에 집어 넣음
            if(n < sArr.Length) return sArr[n];             // 구분자로 구분된 string들, n이랑 index 맞음, 정보 있으면 해당 index 반환
            return "";                                      // 경로 나눠놓은 것보다 n이 크면 ""
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
                tbMemo.Text = GetToken1(4, filePath, '\\' );                    // GetToken 시험
            }
        }

        private void mnuFileSave_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = Path.GetFileName(filePath);               // 저장 누를 시, 오픈했던 파일명 나옴.
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

        int num = 0;
        private void mnuEditTest_Click(object sender, EventArgs e)              // GetToken 시험
        {
            tbMemo.Text += $"{GetToken(num++, "a,b,c,d", ',')}";        
        }
    }
}
