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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int i = 0;
        private void btnTest_Click(object sender, EventArgs e)
        {
            string str = "안녕하세요. 반갑습니다. 날씨 참 좋네요.";

            //tbTest.Text += a + "\r\n";
            tbTest.Text += str + "[" + i++ + "]" + "\r\n";
        }

        private void btnTrans_Click(object sender, EventArgs e)
        {
            string s1 = tbInput.Text;
            string s2 = cbbType.Text;       // string은 문자열 == 문자 배열
            //string a = cbbType.SelectedIndex.ToString();
            //if (a == "0")
            //    int.Parse(tbInput.Text);
            //else if (a == "1")
            //    double.Parse(tbInput.Text);
            //else if (a == "2")
            //    (tbInput.Text).ToString();
            int a = 1000;

            try
            {
                if (s2[0] == '1')
                {
                    int n = int.Parse(s1);
                    tbTest.Text += "Int.Parse() 결과: " + " [" + (n + a) + " ]\r\n";
                }
                else if (s2[0] == '2')
                {
                    double d = double.Parse(s1);
                    tbTest.Text += "Double.Parse() 결과: " + " [" + (d + a) + " ]\r\n";
                }
                else if (s2[0] == '3')
                {
                    tbTest.Text += "입력 String 결과: " + " [" + (s1 + a) + " ]\r\n";
                }
            }
            catch (Exception exception)      // exception이 에러 정보 갖고 있음
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void cbbType_SelectedIndexChanged(object sender, EventArgs e)
        {           // 버튼 안 누르고 콤보박스 수정만으로도 같은 결과
            int n = cbbType.SelectedIndex;
            int a = 1000;
            string s1 = tbInput.Text;
            try
            {
                if (n == 0)
                {
                    int m = int.Parse(s1);
                    //tbTest.Text += "Int.Parse() 결과: " + " [" + (m + a) + " ]\r\n";
                    tbTest.Text += string.Format("Int.Parse() 결과: [{0}] {1}\r\n", m + a, n);
                    // printf("Int.Parse() 결과: [%d]\r\n", m + a);
                }
                else if (n == 1)
                {
                    double d = double.Parse(s1);
                    tbTest.Text += "Double.Parse() 결과: " + " [" + (d + a) + " ]\r\n";
                }
                else if (n == 2)
                {
                    tbTest.Text += "입력 String 결과: " + " [" + (s1 + a) + " ]\r\n";
                }
            }
            catch (Exception exception)      // exception이 에러 정보 갖고 있음
            {
                MessageBox.Show(exception.Message);
            }
        }

        string filePath = string.Empty;         // 파일 경로
        private void cbbMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            int n = cbbMenu.SelectedIndex;
            var fileContent = string.Empty;
            string line;
            string result = "";

            if (n == 0)    //new
            {
                tbTest.Text = null;
            }
            else if (n == 1)    // open     // 얘 UTF-16 LE열면 1글자 나옴
            {
                using (OpenFileDialog openFileDlg = new OpenFileDialog())
                {
                    openFileDlg.InitialDirectory = "C:\\Users\\snows\\Desktop";
                    openFileDlg.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                    openFileDlg.FilterIndex = 2;                                            // filter에서 몇 번째 것을 default로 사용할까 // 2라서 All files
                    openFileDlg.RestoreDirectory = true;
                    if (openFileDlg.ShowDialog() == DialogResult.OK)
                    {
                        filePath = openFileDlg.FileName;

                        var fileStream = openFileDlg.OpenFile();

                        using (StreamReader reader = new StreamReader(fileStream, Encoding.Default))
                        {
                            //fileContent = reader.ReadToEnd();
                            while ((line = reader.ReadLine()) != null)   // 왜 null들어감?
                            {
                                result += line;
                                result += "\r\n";
                            }
                            reader.Close();
                        }
                        tbTest.Text = result;


                        //using (StreamWriter writer = new StreamWriter(fileContent))
                        //{
                        //    writer.WriteLine(tbInput);
                        //}
                    }
                }
            }
            else if (n == 2)    // save
            {
                if (filePath != null)
                {
                    string change = tbTest.Text;
                    File.WriteAllText(filePath, change, Encoding.Default);
                }
                else
                {
                    SaveFileDialog saveFileDlg = new SaveFileDialog();
                    saveFileDlg.InitialDirectory = "C:\\Users\\snows\\Desktop";
                    saveFileDlg.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                    saveFileDlg.Title = "다른 이름으로 저장";
                    if (saveFileDlg.ShowDialog() == DialogResult.OK)
                    {
                        filePath = saveFileDlg.FileName;
                        string change = tbTest.Text;
                        File.WriteAllText(filePath, change, Encoding.Default);

                    }
                }
            }
            else if (n == 3)    // save as
            {
                SaveFileDialog saveFileDlg = new SaveFileDialog();
                saveFileDlg.InitialDirectory = "C:\\Users\\snows\\Desktop";
                saveFileDlg.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDlg.Title = "다른 이름으로 저장";
                if (saveFileDlg.ShowDialog() == DialogResult.OK)
                {
                    filePath = saveFileDlg.FileName;
                    string change = tbTest.Text;
                    File.WriteAllText(filePath, change, Encoding.Default);

                }
            }
            else if (n == 4)    // exit
            {
                Application.Exit();
            }

        }

        string strOrg = "";              // String Original
        int viewState = 0;          //  0: Normal(Edit 가능)  1: Lower  2: Upper  3: Hexa
        private void cbbDiv_SelectedIndexChanged(object sender, EventArgs e)
        {
            int n = cbbDiv.SelectedIndex;
            if (n == 0)    // 대문자로
            {
                if(viewState != 1)
                {
                    if (strOrg == "") 
                        strOrg = tbTest.Text;         // 되돌리기 할 원본 없으면 저장
                    tbTest.Text = strOrg.ToUpper();                 // 변환은 '원본' 대상 // 복사본을 소문자로 바꿔 반환 // tbTest.Text = string
                    tbTest.ReadOnly = true;                         // 수정불가
                    viewState = 1;                                  // 재차 늘리는 것 방지
                }
            }
            else if (n == 1)    // 소문자로
            {
                if (viewState != 2)
                {
                    if (strOrg == "") strOrg = tbTest.Text;         // 되돌리기 할 원본 없으면 저장
                    tbTest.Text = strOrg.ToLower();                 // 변환은 '원본' 대상 //
                    tbTest.ReadOnly = true;                         // 수정불가
                    viewState = 1;                                  // 재차 늘리는 것 방지
                }
            }
            else if (n == 2)    // 16진수
            {
                if (viewState != 3)
                {                                                   // C#, char(문자), string을 정수로 바로 변환 불가  -> 강제 형변환 해야.
                    if (strOrg == "") strOrg = tbTest.Text;         // 되돌리기할 원본 없으면 저장
                    tbTest.Text = "";                               // 안 하면 tb 에 원본이랑 16진수 같이 나옴

                    string s1;
                    char[] chr = strOrg.ToCharArray();
                    byte[] bArr = Encoding.Default.GetBytes(chr);   // byte가 C/C++의 char(숫자로 변환 가능)     // 통신, Encoding 필요
                    for (int i = 0; i < bArr.GetLength(0); i++)
                    {
                        //s1 = string.Format(" {0:X2}", bArr[i]);   // printf(" %x ", n), 왼쪽과 같이 쓰는 것 번거로움 -> 보간문자열 제공
                        s1 = $" {bArr[i]:X2}";                      // 보간 문자열(문자열 옆에 $ 사용), 출력하고자 하는 문자열, 중괄호 내에 직접 사용(포맷문자열로 기능함)
                        if (i % 16 == 15) s1 += "\r\n";
                        tbTest.Text += s1;

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


                    tbTest.ReadOnly = true;                         // 재차 눌리는 것 방지
                    viewState = 3;
                }

            }
            else if (n == 3)    // Return
            {
               if(strOrg != "")                         // 중복 감지 X, 두 번 누르면 삭제되는 것 방지 위해 if문 삽입
                {
                    tbTest.Text = strOrg;
                    strOrg = "";                        // 원본 tb에 되돌린 후 저장된 것 삭제
                    tbTest.ReadOnly = false;
                    viewState = 0;
                }
            }
        }

        private void cbbDiv_KeyDown(object sender, KeyEventArgs e)              // 완성. 콤보박스에서 이벤트 되돌리기 ESC로 
        {
            if (e.KeyCode == Keys.Escape) cbbDiv.SelectedIndex = 3;

        }
        // 콤보박스 내에서 키 다운 만들면 n만 바꿔주면 가능함. 제어권 현재 콤보박스 내에 있음
    }
}
