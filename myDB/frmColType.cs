using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myDB
{
    public partial class frmColType : Form
    {
        string ColName, strDT;                                           // 클래스 외부에서 참조 불가(public 붙이면 가능)
        int MaxSize;

        public frmColType(string cName, string str = "", int size = 10)     // str(DataType), Nullable은 X, cName은 초기값 X
        {
            InitializeComponent();
            ColName = cName;
            strDT = str;
            MaxSize = size;
        }

        private void frmColType_Load(object sender, EventArgs e)
        {
            this.Name = $"{ColName} - Column Type";                     // 최 상단에 Column Name나옴
            cbDataType.Items.Add("nvarchar");
            cbDataType.Items.Add("ncahr");
            cbDataType.Items.Add("varchar");
            cbDataType.Text = strDT;                   // Default(생성자에 의해)
            tbMax.Text = $"{MaxSize}";                        // int -> string으로 바꾸기 위해 보간문자열 사용
        }
    }
}
