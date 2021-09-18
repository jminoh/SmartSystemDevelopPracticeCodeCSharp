using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myNotepad
{
    public partial class Form2 : Form
    {
        public Form2()                      // 생성자(클래스명과 동일한 함수명, public은 반환형이 아니라 참조에 대한 것
        {
            InitializeComponent();

            cbbStopbit.Items.Add("1");
            cbbStopbit.Items.Add("2");
        }
        [DllImport("kernel32.dll")]
        static extern int GetPrivateProfileString(string sec, string key, string def, StringBuilder buf, int bSize, string Path);

        [DllImport("kernel32.dll")]
        static extern bool WritePrivateProfileString(string sec, string key, string val, string Path);

        string iniPath = ".\\myNotepad.ini";  // '.ini' 파일 전체 경로 // 실행파일과 같은 곳에 있을 땐, 파일이름만 써도 됨
     
        private void Form2_Load_1(object sender, EventArgs e)
        {
            StringBuilder buf = new StringBuilder(500);  // ini 파일 데이터('='우측의 value의 최대 사이즈)

            //GetPrivateProfileString(string sec, string key, string def, StringBuilder buf, int bSize, string Path);
            GetPrivateProfileString("Form2", "LocationX2", "0", buf, 500, iniPath); int x = int.Parse(buf.ToString());
            GetPrivateProfileString("Form2", "LocationY2", "0", buf, 500, iniPath); int y = int.Parse(buf.ToString());
            Location = new Point(x, y);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            WritePrivateProfileString("Form2", "LocationX2", $"{Location.X}", iniPath);
            WritePrivateProfileString("Form2", "LocationX2", $"{Location.Y}", iniPath);
        }
    }
}
