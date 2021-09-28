using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using myLibrary1;


namespace myDB
{
    public partial class Form1 : Form                   // Form1 대신 이름 부여 가능
    {
        public Form1()
        {
            InitializeComponent();
        }

        iniFile ini = new iniFile(".\\myDB.ini");
        private void Form1_Load(object sender, EventArgs e)
        {
            int x = int.Parse(ini.GetString("Position", "LocationX", "0"));
            int y = int.Parse(ini.GetString("Position", "LocationY", "0"));
            Location = new Point(x, y);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ini.WriteString("Position", "LocationX", $"{Location.X}");
            ini.WriteString("Position", "LocationY", $"{Location.Y}");
        }

        private void mnuColumnAdd_Click(object sender, EventArgs e)
        {
            string str = mylib.GetInput("컬럼명");
            dbGrid.Columns.Add(str, str);
        }

        private void pmnuColumnAdd_Click(object sender, EventArgs e)
        {
            mnuColumnAdd_Click(sender, e);                              // 기능을 복사하거나, 위의 기능을 호출하거나
            //string str = mylib.GetInput("컬럼명");                       // 같은 코드 여러번 쓰는 것보다, 호출이 나을 수 있음
            //dbGrid.Columns.Add(str, str);                             // 수정할 때 한 곳만 변경하면 됨.
        }
        private void mnuRowAdd_Click(object sender, EventArgs e)
        {
            if(dbGrid.ColumnCount > 0)
                dbGrid.Rows.Add();                                      // 1 Line 추가
        }
        private void pmnuRowAdd_Click(object sender, EventArgs e)
        {
            mnuRowAdd_Click(sender, e);
        }

        public string filePath;
        private void mnuMigration_Click(object sender, EventArgs e)
        {
            //openFileDialog.FileName = "";
            //openFileDialog.Filter = "txt files (*.txt)|*.txt|CSV files (*.csv)|*.csv|All files (*.*)|*.*";  // Dialog 하단 확장자 설정
            //openFileDialog.FilterIndex = 2;                                     // Filter 중 두 번째 것 Default로
            //if (openFileDialog.ShowDialog() == DialogResult.OK)                 // == Domdal, 종속적인 호출임    // X표로 나갔을 때 오류 막기 위해(filename에 값X) if문
            //{                                                                                                   // 아니면 DaialogResult r = saveFileDialog.ShowDialog();
            //    string rowValue;
            //    string[] cellValue;
            //    dbGrid.Rows.Clear();
            //    filePath = openFileDialog.FileName;
            //    StreamReader sr = new StreamReader(openFileDialog.FileName);    // StreamReader 객체 생성 openFileDialog에서 받아온 경로에 있는 파일

            //    rowValue = sr.ReadLine();
            //    cellValue = rowValue.Split(',');
            //    for (int i = 0; i < cellValue.Count(); i++)
            //    {
            //        DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
            //        column.Name = cellValue[i];
            //        column.HeaderText = cellValue[i];
            //        dbGrid.Columns.Add(column);
            //    }
            //    // Reading content
            //    while (sr.Peek() != -1)
            //    {
            //        rowValue = sr.ReadLine();
            //        cellValue = rowValue.Split(',');
            //        dbGrid.Rows.Add(cellValue);
            //    }
            //    sr.Close();                                                     // Stream 객체 닫아줌
            //}

            /////////////////////////////// 위가 나
            /////////////////////////////// 아래가 강사님

            if (openFileDialog.ShowDialog() == DialogResult.Cancel) return;

            filePath = openFileDialog.FileName;                                     // FileName은 full path
            dbGrid.Rows.Clear();
            dbGrid.Columns.Clear();
            StreamReader sr = new StreamReader(openFileDialog.FileName);            // 읽어야 하는 파일: .CSV -> ','로 구분되는 문자열(','로 Cell이 나뉨)
            string buf = sr.ReadLine();                                             // ReadLine(): 한 줄 읽어서 string으로 반환
            string[] sArr = buf.Split(',');
            for(int i = 0; i < sArr.Length; i++)                                    // string[]은 이것 자체가 객체, string과는 다른 property 존재
            {
                dbGrid.Columns.Add(sArr[i], sArr[i]);
            }
            while(true)
            {
                buf = sr.ReadLine();                                                // ""(빈 문자열) != null
                if (buf == null) break;
                sArr = buf.Split(',');
                dbGrid.Rows.Add(sArr);                                              // Add의 오버로드 이용 //sArr은 string, object 중 하위    // 아래 네 줄과 동일
                //int rInx = dbGrid.Rows.Add();                                       // Add() -> integer 반환(새 행 인덱스), rowIndex 저장
                //for (int i = 0; i < sArr.Length; i++) 
                //{
                //    dbGrid.Rows[rInx].Cells[i].Value = sArr[i];
                //}
            }
            sr.Close();
        }

        SqlConnection sqlConn = new SqlConnection();                                // app과 database와의 연결 담당(도로)    // SqlConnection open 해줘야
        SqlCommand sqlCmd = new SqlCommand();                                       // 거기에 올라가는 command(컨테이너, 운반용)를 통해 정보 주고 받음.

        string ConnString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\snows\source\repos\SmartSystemDevelopPracticeCodeCSharp\myDatabase.mdf;Integrated Security = True; Connect Timeout = 30";
        string CurrentTable = "";
        
        private void mnuOpen_Click(object sender, EventArgs e)
        {
            bool vn = openFileDialog.ValidateNames;
            try
            {
                openFileDialog.ValidateNames = false;
                if (openFileDialog.ShowDialog() != DialogResult.OK) return;

                string[] sArr = ConnString.Split(';');
                ConnString = $"{sArr[0]};{sArr[1].Replace(sArr[1].Split('=')[1], openFileDialog.FileName)};{sArr[2]};{sArr[3]}";     // Replace: 문자, 문자열 변환  // 원본 불변의 법칙

                //string s1 = ConnString.Split(',')[1];   // AttachDbFilename=C:\Users\snows\source\repos\SmartSystemDevelopPracticeCodeCSharp\myDatabase.mdf
                //string s2 = s1.Split('=')[1];           // C:\Users\snows\source\repos\SmartSystemDevelopPracticeCodeCSharp\myDatabase.mdf
                //string s3 = s1.Replace(s2, openFileDialog.FileName);

                sqlConn.ConnectionString = ConnString;
                sqlConn.Open();
                sqlCmd.Connection = sqlConn;                                            // 3줄이 db open 준비

                sbLabel1.Text = openFileDialog.SafeFileName;                            // file name only
                sbLabel1.BackColor = Color.Green;                                       // color -> enum

                DataTable dt = sqlConn.GetSchema("Tables");                             // Table 정보 알려줌
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sbLabel2.DropDownItems.Add(dt.Rows[i].ItemArray[2].ToString());
                }
                sbLabel2.Text = "dbTables";

            }
            catch(Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            finally 
            {
                openFileDialog.ValidateNames = vn;
            }
        }

        private void sbLabel2_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            sbLabel2.Text = e.ClickedItem.Text;
            string s = $"select * from {e.ClickedItem.Text}";
            RunSql(s);
        }

        char[] ca = { ' ', '\t', '\r', '\n' };        // White Space
        public int RunSql(string sql)           // 모든 SQL 명령어를 처리   // sqlCmd.Execute******로 시작
        {                                       // ex) select * from student    / SELECT    / Select  / selEct
            try
            {
                sqlCmd.CommandText = sql;          // 매개변수로 받은 sql 바로 이용

                string sCmd = sql.Trim().Substring(0, 6);   //mylib.GetToken(0, sql.Trim(), ' ');           // Trim(): 앞뒤의 White space 제거
                if(sCmd.ToLower() == "select")
                {
                    int n1 = sql.ToLower().IndexOf("from");
                    string s1 = sql.Substring(n1 + 4).Trim();                                   // student    where code < 4
                    CurrentTable = s1.Split(ca)[0];                                             // Table 명 담김
                    sbLabel2.Text = CurrentTable;
                    // string s3 = sql.Substring(sql.ToLower().IndexOf("from") + 4).Trim().Split(ca)[0];       //  한줄로 합침

                    SqlDataReader sdr = sqlCmd.ExecuteReader();                            

                    dbGrid.Rows.Clear();
                    dbGrid.Columns.Clear();
                    for (int i = 0; i < sdr.FieldCount; i++)
                    {
                        string s = sdr.GetName(i);
                        dbGrid.Columns.Add(s, s);
                    }
                    for (int i = 0; sdr.Read(); i++)                                         // sdr.Read ->  bool 값 담고 있을 뿐만 아니라, Read 포인트 이동    // sdr.Read() -> sdr에 읽을 데이터가 있으면
                    {
                        int rIdx = dbGrid.Rows.Add();                                       // Grid에 한 줄 추가
                        for (int j = 0; j < sdr.FieldCount; j++)
                        {
                            object obj = sdr.GetValue(j);                                   // GetValue: 현재 sdr.ReadPoint의 j번째 Item을 가지고 와라 // 문제는 얘가 무슨 타입인지 모르기에 object type(최상위 type)으로 return
                            dbGrid.Rows[rIdx].Cells[j].Value = obj;                         // Value도 object.   // 읽은 data를 Cell에 넣어라
                        }
                    }
                    sdr.Close();
                    return 0;
                }
                else
                {
                    sqlCmd.ExecuteNonQuery();                               // returnX, 
                }

            }
            catch(Exception e2)
            {  }
            return 1;
        }

        private void executeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunSql(tbMemo.Text);
            
        }

        private void tbMemo_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Shift && e.KeyCode == Keys.Enter)
                RunSql(tbMemo.Text);
        }

        private void pmnuExecute_Click(object sender, EventArgs e)
        {
            RunSql(tbMemo.SelectedText);
        }

        private void pmnuUpdate_Click(object sender, EventArgs e)           // Cell 입력하면, 해당 내용을 DB에 Write
        {                                                                   // update [Tabel] set [Column=value,,,] where <code=rowVal>
            int x = dbGrid.SelectedCells[0].ColumnIndex;
            int y = dbGrid.SelectedCells[0].RowIndex;
            string s1 = dbGrid.Columns[x].HeaderText;
            object s2 = dbGrid.SelectedCells[0].Value;
            string o1 = dbGrid.Columns[0].HeaderText;
            object o2 = dbGrid.Rows[y].Cells[0].Value;
            string sql = $"update {CurrentTable} set {s1}={s2} where {o1}={o2}";
            RunSql(sql);
        }
    }
}
