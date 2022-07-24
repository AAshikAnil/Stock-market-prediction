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
    public partial class F1_LoadData : Form
    {
        public F1_LoadData()
        {
            InitializeComponent();
        }
        public static DataTable full = new DataTable();
        public static int rowcount = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is a time-taking process..Please wait");
            ReadCSVData(Application.StartupPath + "\\RELIANCE.csv");
            label5.Text = "Reliance.csv";
            button1.Enabled = true;
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
            full = csvFilereader;
            label6.Text = full.Rows.Count.ToString() + " rows";
            label7.Text = full.Columns.Count.ToString() + " columns";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            F2_ViewData obj = new F2_ViewData(full);
            ActiveForm.Hide();
            obj.Show();
        }
    }
}
