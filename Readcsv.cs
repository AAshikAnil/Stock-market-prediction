using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IronXL;

namespace Stockmarketprediction
{
    public partial class Readcsv : Form
    {
        public static DataTable full = new DataTable();
        public static int rowcount = 0;
        public static int blocksize = 100;
        public static int startelement = 0;
        public static int endelement = 0;
        public Readcsv()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReadCSVData(Application.StartupPath + "\\RELIANCE.csv");
        }
        private DataTable ReadExcel(string fileName)
        {
            WorkBook workbook = WorkBook.Load(fileName);
            WorkSheet sheet = workbook.DefaultWorkSheet;
            return sheet.ToDataTable(true);
        }
        public void ReadCSVData(string csvFileName)
        {
            var csvFilereader = new DataTable();
            csvFilereader = ReadExcel(csvFileName);
            dataGridView1.DataSource = csvFilereader;
            full = csvFilereader;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for(int i=0;i<full.Rows.Count;i++)
            {
                string date = full.Rows[i][0].ToString();
                string close = full.Rows[i][8].ToString();
                string open = full.Rows[i][4].ToString();
                dataGridView2.Rows.Add();
                this.dataGridView2.Rows[i].Cells[0].Value =date;
                this.dataGridView2.Rows[i].Cells[1].Value =close;
                this.dataGridView2.Rows[i].Cells[2].Value = open;
            }
            
            startelement = 0;
            endelement = startelement + blocksize;


        }


        public void graph(int c, double time, double count,double close)
        {

            chart1.Series[c].Points.AddXY(time, count);
            chart2.Series[0].Points.AddXY(time, close);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                graph(0, Convert.ToDouble(i), Convert.ToDouble(dataGridView2.Rows[i].Cells[1].Value), Convert.ToDouble(dataGridView2.Rows[i].Cells[2].Value));
            }
        }
    }
}
