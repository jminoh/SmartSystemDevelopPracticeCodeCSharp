using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace myLibrary1
{
    public partial class frmInput: Form
    {
        public frmInput()
        {
            InitializeComponent();
        }
        public frmInput(string str)
        {
            InitializeComponent();
            Prompt.Text = str;
            Prompt.Visible = true;
        }

        public string retStr = "";                                 // return String
        private void tbInput_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                DialogResult = DialogResult.OK;
                retStr = tbInput.Text;
                Close();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                retStr = "";
                Close();
            }
        }
    }

    public class iniFile
    {
        [DllImport("kernel32.dll")]
        static extern int GetPrivateProfileString(string s, string k, string df, StringBuilder b, int n, string p);      // 외부 dll -> extern

        [DllImport("kernel32.dll")]
        static extern int WritePrivateProfileString(string s, string k, string df, string p);

        public string fPath;
        public iniFile(string str)
        {
            fPath = str;
        }
        public string GetString(string sec, string key, string def = "")                         // OverLoad or 인수 초기값 설정
        {
            StringBuilder buf = new StringBuilder(512);
            GetPrivateProfileString(sec, key, "", buf, 512, fPath);             // 가져온 값, buf에 담김
            return buf.ToString();
        }
        public int WriteString(string sec, string key, string val)                      
        {
            return WritePrivateProfileString(sec, key, val, fPath);                    // int 값 반환

        }
    }
    public static class mylib                             // 만들 것이기 때문에 Form 상속 필요 X, 순수 클래스    // static: 
    {
        public static string GetTokenJM(int n, string str, char d) // 0이 C:
        {                                                   // for문 str.Length 문제 아님. return 못타고 밖의 for문 타서 연속해서 찍힘
            int count = 0;                                  // string GetToken(int n, string str, char d)
            string re = "";                                 // n: n번째 Item, str: 문자열, d: 구분자, 
            char[] chr = str.ToCharArray();                 // 문자열 str에 있는 데이터를 구분자 d를 통해 필드 구분하여, 그 중 n번째 데이터 반환
            for (int i = 0; i < str.Length; i++)             // ex) GetToken(1, "a,b,c,d", ',') => "b"
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
        public static string GetToken1(int n, string str, char d)         // 강사님
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

        public static string GetToken(int n, string str, char d)          // 강사님
        {
            string[] sArr = str.Split(d);                   // 구분자로 문자열 나눠 문자열 배열에 집어 넣음
            if (n < sArr.Length) return sArr[n];             // 구분자로 구분된 string들, n이랑 index 맞음, 정보 있으면 해당 index 반환
            return "";                                      // 경로 나눠놓은 것보다 n이 크면 ""
        }

        public static string GetInput(string str)
        {
            frmInput dlg = new frmInput(str);
            //dlg.ShowDialog();
            //return dlg.retStr;                            // 보호수준 때문에 안 된다면, retStr를 public으로
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                return dlg.retStr;
            }
            return "";
        }
    }
}
