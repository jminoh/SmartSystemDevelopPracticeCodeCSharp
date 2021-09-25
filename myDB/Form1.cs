using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private void btnCmd_Click(object sender, EventArgs e)
        {
            dbGrid.Columns.Add(tbInput.Text, tbInput.Text);
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
        }
    }
}
