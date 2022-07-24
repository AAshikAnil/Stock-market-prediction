using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stockmarketprediction
{
    public partial class F6_Calculate : Form
    {
        public static string col = "";
        public static int sindex =0;
        public F6_Calculate()
        {
            InitializeComponent();
            dataGridView1.DataSource = Program.orginal;
        }
        public F6_Calculate(string columnname)
        {
            InitializeComponent();
            dataGridView1.DataSource = Program.orginal;
            col = columnname;
        }
        void ListIp(string value)
        {
            lsvip.Items.Clear();
            lsvip.Columns.Clear();
            lsvip.Columns.Add("No",40);
            lsvip.Columns.Add(value, 80);
            lsvip.Columns.Add("Current Value", 80);
            lsvip.Columns.Add("Mean Value", 80);
            lsvip.Columns.Add("Variance", 80);
        }

        public void graph(int no, double value,double avg)
        {

            chart1.Series[0].Points.AddXY(no, value);
            chart1.Series[1].Points.AddXY(no, avg);

        }
        public void graph2(int no, double value,double a)
        {
            chart2.Series[1].Points.AddXY(no, a);
            chart2.Series[0].Points.AddXY(no, value);
          

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is a time-taking process..Please wait");
            ListIp(col);
            string index = string.Empty;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
                if (column.HeaderText.Equals(col, StringComparison.InvariantCultureIgnoreCase))
                {
                    index = column.Index.ToString();
                    sindex = column.Index;
                    break;
                }
            string data = string.Empty;
            double sum = 0;
            double avg = 0;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                data = dataGridView1.Rows[i].Cells[8].Value.ToString();
                sum = sum + Convert.ToDouble(data);
            }
            avg = sum / dataGridView1.Rows.Count;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                data = dataGridView1.Rows[i].Cells[8].Value.ToString();
                ListViewItem it1 = new ListViewItem(i.ToString());
                it1.SubItems.Add(col);
                it1.SubItems.Add(data);
                it1.SubItems.Add(avg.ToString());
                double v = Convert.ToDouble(data) - Convert.ToDouble(avg);
                it1.SubItems.Add(v.ToString());
               if(v<0)
                {
                    it1.ForeColor = Color.FromArgb(252,152,152);
                }
                else
                {
                    it1.ForeColor = Color.FromArgb(102,255,178);
                }
                graph(i, Convert.ToDouble(data), avg);
                graph2(i,v,Convert.ToDouble(data));
                lsvip.Items.Add(it1);

            }
            button2.Enabled = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            F7_TestingData obj = new F7_TestingData(col,sindex);
            ActiveForm.Hide();
            obj.Show();
        }
    }
}
