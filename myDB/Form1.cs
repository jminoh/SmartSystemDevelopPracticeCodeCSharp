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
            dbGrid.Rows[1].Cells[5].Value = "";
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
            openFileDialog.Filter = "텍스트 문서(*.txt)|*.txt|모든 파일|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel) return;

            filePath = openFileDialog.FileName;                                     // FileName은 full path
            dbGrid.Rows.Clear();
            dbGrid.Columns.Clear();
            Encoding ec = (mnuTextUtf8.Checked == true) ? Encoding.UTF8 : Encoding.Default;
            StreamReader sr = new StreamReader(openFileDialog.FileName, ec, true);            // 읽어야 하는 파일: .CSV -> ','로 구분되는 문자열(','로 Cell이 나뉨)    // Default는 Ansi, true는 BOM있으면 BOM으로 읽어라
            string buf = sr.ReadLine();                                             // ReadLine(): 한 줄 읽어서 string으로 반환
            //byte[] bb1 = Encoding.Convert(Encoding.ASCII, Encoding.Default, Encoding.Default.GetBytes(buf));
            //string bb2 = Encoding.Default.GetString(bb1);
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
                ConnString = $"{sArr[0]};{sArr[1].Replace(sArr[1].Split('=')[1], openFileDialog.FileName)};{sArr[2]};{sArr[3]}";
                // Replace: 문자, 문자열 변환  // 원본 불변의 법칙

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
            RunSql($"select * from {e.ClickedItem.Text}");
            //RunSql(s);                                              // 두 줄= RunSql($"select * from {e.ClickedItem.Text}");
        }

        char[] ca = { ' ', '\t', '\r', '\n' };        // White Space Array
        public int RunSql(string sql)  // 모든 SQL 명령어를 처리
        {  // ex)  select * from          student where code < 4 / SELECT  /Select  / selEct
            sqlCmd.CommandText = sql;

            try
            {
                string sCmd = sql.Trim().Substring(0, 6); //mylib.GetToken(0, sql.Trim(), ' ');
                if (sCmd.ToLower() == "select")
                {
                    int n1 = sql.ToLower().IndexOf("from");
                    string s1 = sql.Substring(n1 + 4).Trim();    //student  where code < 4 
                    CurrentTable = s1.Split(ca)[0];
                    sbLabel2.Text = CurrentTable;
                    //CurrentTable = sql.Substring(sql.ToLower().IndexOf("from") + 4).Trim().Split(ca)[0];

                    SqlDataReader sdr = sqlCmd.ExecuteReader();

                    dbGrid.Rows.Clear();
                    dbGrid.Columns.Clear();
                    for (int i = 0; i < sdr.FieldCount; i++)
                    {
                        string s = sdr.GetName(i);
                        dbGrid.Columns.Add(s, s);
                    }
                    for (int i = 0; sdr.Read(); i++)
                    {
                        int rIdx = dbGrid.Rows.Add();
                        for (int j = 0; j < sdr.FieldCount; j++)
                        {
                            object obj = sdr.GetValue(j);
                            dbGrid.Rows[rIdx].Cells[j].Value = obj;
                        }
                    }
                    sdr.Close();
                    return 0;
                }
                else
                {
                    return sqlCmd.ExecuteNonQuery();
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message); return -1;      // int로 함수 선언했기에
            }
        }

        public string RunSql_noEcho(string sql)  // 모든 SQL 명령어를 처리
        {  // ex)  select * from          student where code < 4 / SELECT  /Select  / selEct
            sqlCmd.CommandText = sql;

            try
            {
                string sCmd = sql.Trim().Substring(0, 6); //mylib.GetToken(0, sql.Trim(), ' ');
                if (sCmd.ToLower() == "select")
                {
                    int n1 = sql.ToLower().IndexOf("from");
                    string s1 = sql.Substring(n1 + 4).Trim();    //student  where code < 4 
                    CurrentTable = s1.Split(ca)[0];
                    sbLabel2.Text = CurrentTable;
                    //CurrentTable = sql.Substring(sql.ToLower().IndexOf("from") + 4).Trim().Split(ca)[0];

                    SqlDataReader sdr = sqlCmd.ExecuteReader();

                    string sRet = sdr.GetName(0);
                    for (int i = 0; i < sdr.FieldCount; i++)
                    {
                        sRet += $",{sdr.GetName(i)}";
                    }
                    sRet += "\r\n";                                 // 다른 데도 쓰겠다면 \r 붙여야

                    for (int i = 0; sdr.Read(); i++)
                    {
                        sRet += sdr.GetValue(0);
                        for (int j = 1; j < sdr.FieldCount; j++)
                        {
                            sRet += $",{sdr.GetValue(j)}";
                        }
                        sRet += "\r\n";                             // 한 Record 끝나면 줄바꿈
                    }
                    sdr.Close();
                    return sRet;
                }
                else
                {
                    return $"{sqlCmd.ExecuteNonQuery()}";           // 숫자(Record 개수)를 문자로 바꿔서(보간문자열)
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message); return e1.Message;      // int로 함수 선언했기에
            }
        }

        //public int RunSql(string sql)           // 모든 SQL 명령어를 처리   // sqlCmd.Execute******로 시작
        //{                                       // ex) select * from student    / SELECT    / Select  / selEct
        //    sqlCmd.CommandText = sql;          // 매개변수로 받은 sql 바로 이용

        //    string sCmd = sql.Trim().Substring(0, 6);   //mylib.GetToken(0, sql.Trim(), ' ');           // Trim(): 앞뒤의 White space 제거
        //    if(sCmd.ToLower() == "select")
        //    {
        //        int n1 = sql.ToLower().IndexOf("from");
        //        string s1 = sql.Substring(n1 + 4).Trim();                                   // student    where code < 4
        //        CurrentTable = s1.Split(ca)[0];                                             // Table 명 담김
        //        sbLabel2.Text = CurrentTable;
        //        // string s3 = sql.Substring(sql.ToLower().IndexOf("from") + 4).Trim().Split(ca)[0];       //  한줄로 합침

        //        SqlDataReader sdr = sqlCmd.ExecuteReader();                            

        //        dbGrid.Rows.Clear();
        //        dbGrid.Columns.Clear();
        //        for (int i = 0; i < sdr.FieldCount; i++)
        //        {
        //            string s = sdr.GetName(i);
        //            dbGrid.Columns.Add(s, s);
        //        }
        //        for (int i = 0; sdr.Read(); i++)                                         // sdr.Read ->  bool 값 담고 있을 뿐만 아니라, Read 포인트 이동    // sdr.Read() -> sdr에 읽을 데이터가 있으면
        //        {
        //            int rIdx = dbGrid.Rows.Add();                                       // Grid에 한 줄 추가
        //            for (int j = 0; j < sdr.FieldCount; j++)
        //            {
        //                object obj = sdr.GetValue(j);                                   // GetValue: 현재 sdr.ReadPoint의 j번째 Item을 가지고 와라 // 문제는 얘가 무슨 타입인지 모르기에 object type(최상위 type)으로 return
        //                dbGrid.Rows[rIdx].Cells[j].Value = obj;                         // Value도 object.   // 읽은 data를 Cell에 넣어라
        //            }
        //        }
        //        sdr.Close();
        //        return 0;
        //    }
        //    else
        //    {
        //        sqlCmd.ExecuteNonQuery();                               // returnX, 
        //    }
        //}

        private void mnuExecute_Click(object sender, EventArgs e)
        {
            if (mnuEchoGrid.Checked) RunSql(tbMemo.Text);
            else RunSql_noEcho(tbMemo.Text);
        }

        private void tbMemo_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Shift && e.KeyCode == Keys.Enter)
            {
                if (mnuEchoGrid.Checked) RunSql(tbMemo.Text);
                else RunSql_noEcho(tbMemo.Text);
            }
        }

        private void pmnuExecute_Click(object sender, EventArgs e)
        {
            RunSql(tbMemo.SelectedText);
        }

        private void pmnuUpdate_Click(object sender, EventArgs e)           // Cell 입력하면, 해당 내용을 DB에 Write
        {                                                                   // update [Tabel] set [Column=value,,,] where <code=rowVal>     // 조건 and나 or
            int x = dbGrid.SelectedCells[0].ColumnIndex;
            int y = dbGrid.SelectedCells[0].RowIndex;
            string s1 = dbGrid.Columns[x].HeaderText;
            object s2 = dbGrid.SelectedCells[0].Value;
            string o1 = dbGrid.Columns[0].HeaderText;
            object o2 = dbGrid.Rows[y].Cells[0].Value;
            string sql = $"update {CurrentTable} set {s1}=N'{s2}' where {o1}=N'{o2}'";    // s1에는 X(필드명), s2는 Value라서 숫자이건 문자이건 가능  // s1 nvarchar여야!
            RunSql(sql);                                                                // sql에 하나의 컬럼만 되어 있지만, 위의 주석처럼 여러 개도 가능
        }                                                                               // o2에는 N 안 붙여도 될 것(code영역)

        public void Insert_Poc(int nRow)        // Row number에 해당하는 내용 Insert
        {                                                                   // 1: insert into [Table] values (value,,,)
                                                                            // 2: insert int [Table] (field1, field2,,,) values (val1, val2,,)
                                                                            // s1은 필드명,              s2는 value
            try
            {
                string s1 = "(";                                    // 하단 주석으로 막아놓은 것, for문 합치기
                string s2 = "(";
                for (int i = 0; i < dbGrid.ColumnCount; i++)
                {
                    if (i != 0)
                    {
                        s1 += ",";
                        s2 += ",";
                    }
                    s1 += $"{dbGrid.Columns[i].HeaderText}";                // 필드명에 괄호
                    s2 += $"N'{dbGrid.Rows[nRow].Cells[i].Value}'";             // Cell Value에, N 붙이면서 모든 insert문에 한글처리
                }
                s1 += ")"; s2 += ")";

                string sql = $"insert into {CurrentTable} {s1} values {s2}";


                /*string sql = $"insert into {CurrentTable} (";       // values ("// (까지는 고정으로 초기 값
                for (int i = 0; i < dbGrid.ColumnCount; i++)      
                {
                    if (i != 0) sql += ",";
                    sql += $"{dbGrid.Columns[i].HeaderText}";     //  Column 이름(Column[i].HeaderText) // 2의 (field1, field2,,)부분    // Data 아니기에, 따옴표 필요 X
                }
                sql += ") values (";
                for (int i = 0; i < dbGrid.ColumnCount; i++)                    // 2의 values (val1, val2,,,)부분
                {
                    if (i != 0) sql += ",";                                     // , 붙임 // 두 번째부터
                    sql += $"'{dbGrid.SelectedRows[0].Cells[i].Value}'";        // 값 들어감. ,를 어느 시점에 붙일 것인가    // '' 붙이는 이유는, '' 안 붙였다고 에러나기 때문(Value라서)
                }                                                               // SelectedRows이기 때문에, Row를 클릭해야 Insert 가능
                sql += ")"; */
                RunSql(sql);
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }
        private void pmnuInsert_Click(object sender, EventArgs e)           // Insert는 새로운 Row 단위 추가
        {
            Insert_Poc(dbGrid.SelectedRows[0].Index);
        }

        private void pmnuDelete_Click(object sender, EventArgs e)       // DB 상에서 지우기
        {                                                               // DELETE student WHERE code=4 and name='사번' and kor=50
            string sql = $"DELETE {CurrentTable} WHERE ";               // 이 뒤에 컬럼과 컬럼에 해당하는 Value 넣어줘야
            try
            {
                for(int i = 0; i < dbGrid.ColumnCount; i++)
                {
                    if (dbGrid.SelectedRows[0].Cells[i].Value == null || 
                        dbGrid.SelectedRows[0].Cells[i].Value.ToString() == "") continue;  // for루프 나머지 실행 X, 다음 index
                    if (i != 0) sql += " AND ";
                    sql += $"{dbGrid.Columns[i].HeaderText}='{dbGrid.SelectedRows[0].Cells[i].Value/*.ToString()*/}'";               // HeaderText = code, name, kor  // Value 속성은 Object
                }
                RunSql(sql);
                dbGrid.Rows.Remove(dbGrid.SelectedRows[0]);
            }
            catch(Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void pmnuDeleteColumn_Click(object sender, EventArgs e)     // 현재 선택된 Cell의 ColumnIndex를 이용해 Column을 삭제 // DB가 아니라 Grid에서
        {
            try
            {
                DialogResult ret = MessageBox.Show("아 진짜요?", "컬럼 삭제", MessageBoxButtons.OKCancel);
                if (ret == DialogResult.OK)
                    dbGrid.Columns.RemoveAt(dbGrid.SelectedCells[0].ColumnIndex);
            }
            catch(Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void pmnuDeleteRow_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult ret = MessageBox.Show("아 진짜요?", "컬럼 삭제", MessageBoxButtons.OKCancel);
                if (ret == DialogResult.OK)
                dbGrid.Rows.Remove(dbGrid.SelectedRows[0]);                     // row 선택 후 지움
                    
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void mnuMigrationImport_Click(object sender, EventArgs e)
        {
            // mnuMigration_Click(sender, e);
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Encoding enc;
                if (mnuTextUtf8.Checked == true) enc = Encoding.UTF8;
                else enc = Encoding.Default;                            // ANSI

                byte[] bArrOrg = File.ReadAllBytes(openFileDialog.FileName);   // Raw data : Low level data // file을 binary로 읽을 수 있다.
                byte[] bArr = Encoding.Convert(enc, Encoding.Default, bArrOrg); // ANSI로 Conversion한 것 담음
                string str = Encoding.Default.GetString(bArr);                  // All Text
                tbMemo.Text += str;
                string[] sArr = str.Split('\n');
                string[] sa1 = sArr[0].Trim().Split(',');
                for(int i =0; i< sa1.Length;i++)
                {
                    dbGrid.Columns.Add(sa1[i], sa1[i]);
                }
                for(int k = 1; k < sArr.Length; k++)
                {
                    sa1 = sArr[k].Trim().Split(',');
                    dbGrid.Rows.Add(sa1);                                   // 아래 네 줄과 동일
                    //int n = dbGrid.Rows.Add();
                    //for (int i =0; i < sa1.Length; i++)
                    //{
                    //    dbGrid.Rows[n].Cells[i].Value = sa1[i];
                    //}
                }
            }
        }

        private void mnuMigrationExport_Click(object sender, EventArgs e)
        {
            
            SaveFileDialog sd = new SaveFileDialog();                       // Local로 선언됨, 이 이벤트 안에서만 사용 가능
            if (sd.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(sd.FileName);
                string sbuf = "";
                for(int i = 0; i < dbGrid.ColumnCount; i++)
                {
                    if (i != 0) sbuf += ",";
                    sbuf += dbGrid.Columns[i].HeaderText;
                }
                sw.WriteLine(sbuf);
                for(int k = 0; k < dbGrid.RowCount - 1; k++)                // RowCount: Grid 맨 아래에 나타나는 것이 데이터는 없어도 입력이 가능하도록 임시 번호가 들어가 있음.
                {
                    sbuf = "";                                              // sbuf 재활용
                    for(int i = 0; i < dbGrid.ColumnCount; i++)
                    {
                        if (i != 0) sbuf += ",";                            // 첫번째에는 , 안 붙임
                        string s1 = "";
                        if (dbGrid.Rows[k].Cells[i].Value != null)
                            s1 = dbGrid.Rows[k].Cells[i].Value.ToString().Trim();   // value를 string으로 바꾼 문자열을, 앞뒤 공백 제거하고 재정의
                        sbuf += s1;                                                 // value는 object, object가 string에 담김(보간문자열)  // 확실히 하기 위해 ToString()
                                                                                    // null: 윗줄의 Value가 null, 초기화가 안 됨
                    }
                    sw.WriteLine(sbuf);
                }
                sw.Close();
            }
        }

        private void mnuCreateTable_Click(object sender, EventArgs e)
        {           // create table [Table] [type] [not null] ,,,)
                    // create table Test_taable (code varchar(10) not null, Name varchar(10),,,,)    
            string s1 = mylib.GetInput("Field Name");                       
            if (s1 == "") return;

            string sql = $"CREATE TABLE {s1} (";
            for(int i = 0; i < dbGrid.ColumnCount; i++)
            {
                if (i != 0) sql += ",";
                sql += dbGrid.Columns[i].HeaderText;
                sql += " nvarchar(20) ";
                if (i == 0) sql += "not null";
            }
            sql += ")";
            RunSql(sql);
            CurrentTable = s1;

            for(int i = 0; i < dbGrid.RowCount; i++)
            {
                Insert_Poc(i);
            }
        }

        private void mnuTextUtf8_Click(object sender, EventArgs e)
        {
            mnuTextUtf8.Checked = true;
            mnuTextAnsi.Checked = false;
        }

        private void mnuTextAnsi_Click(object sender, EventArgs e)
        {
            mnuTextAnsi.Checked = true;
            mnuTextUtf8.Checked = false;
        }

        private void pmnuColumnInfo_Click(object sender, EventArgs e)
        {
            int nCol = dbGrid.SelectedCells[0].ColumnIndex;                      // 현재 Column 번호, 현재 선택된 Cell의 Column index
            string sCol = dbGrid.Columns[nCol].HeaderText;                      // 현재 선택된 Cell의 Column index의 headertext(컬럼 이름)
            string str = RunSql_noEcho("select Table_name,column_name,data_type,character_maximum_length,is_nullable "+ 
                " from information_schema.columns "+
                $" where column_name = '{sCol}' and table_name='{CurrentTable}'");
            tbMemo.Text += str;
        }

        private void mnuEchoGrid_Click(object sender, EventArgs e)
        {
            mnuEchoText.Checked = false;
        }

        private void mnuEchoText_Click(object sender, EventArgs e)
        {
            mnuEchoGrid.Checked = false;

        }
    }
}
