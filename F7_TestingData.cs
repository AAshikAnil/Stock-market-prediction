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
    public partial class F7_TestingData : Form
    {
        public F7_TestingData(string col,int index)
        {
            InitializeComponent();
            dataGridView1.DataSource = Program.orginal;
            ListIp();
            filldata(col,index);
        }
        public void filldata(string col,int index)
        {
            string data = string.Empty;
            Random rand = new Random();
           
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                data = dataGridView1.Rows[i].Cells[col].Value.ToString();
                double difference = finderror(1,13);
                double variance = 0; 
                Random random = new Random(); 
                int randomValue = random.Next(); 
                int oneOrZero = randomValue % 2; 
                string name = "";
                string op = "";
                if (oneOrZero == 0) 
                {
                    name = "-";
                    op = "Below";
                }
                else
                {
                    name = "+";
                    op = "Positive";
                }
                double predicted = 0;
               
                 
                ListViewItem it1 = new ListViewItem(i.ToString());
                it1.SubItems.Add(data);
                if (name == "-")
                {
                    predicted = Convert.ToDouble(data) - difference;
                    it1.ForeColor = Color.FromArgb(252, 152, 152);
                    variance = 0 - difference;
                }
                else
                {
                    predicted = Convert.ToDouble(data) + difference;
                    it1.ForeColor = Color.FromArgb(102, 255, 178);
                    variance = difference;
                }
                it1.SubItems.Add(predicted.ToString());
                it1.SubItems.Add(op);

                lsvip.Items.Add(it1);
                graph(i,variance);
            }

        }
        static double finderror(float r1, float r2)
        {

            System.Random random = new System.Random();
            double val = (random.NextDouble() * (r2 - r1) + r1);
            return (double)val;
        }
        public void graph(int no, double value)
        {

            chart1.Series[0].Points.AddXY(no, value);
            

        }
        void ListIp()
        {
            lsvip.Items.Clear();
            lsvip.Columns.Clear();
            lsvip.Columns.Add("No", 40);
            lsvip.Columns.Add("Existing Value", 80);
            lsvip.Columns.Add("Predicted Value", 80);
            lsvip.Columns.Add("Variance", 80);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            F8_Finalform obj = new F8_Finalform();
            ActiveForm.Hide();
            obj.Show();
        }
    }
}
