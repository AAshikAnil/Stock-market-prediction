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
    public partial class F8_Finalform : Form
    {
        public static int maxrowindex = 0;
        public static int rowindex = 0;
        public static double prevvalue = 0;
        public F8_Finalform()
        {
            InitializeComponent();
            dataGridView1.DataSource = Program.orginal;
            maxrowindex = dataGridView1.RowCount;
            timer2.Enabled = true;
        }

       

        public void graph(int no, double value,double diff1,double diff2,double vol,double vwap,double pre,double op)
        {

            chart1.Series[0].Points.AddXY(no, value);
            chart1.Series[1].Points.AddXY(no, op);
            chart2.Series[0].Points.AddXY(no, diff1);
            chart2.Series[1].Points.AddXY(no, pre);
            chart3.Series[0].Points.AddXY(no, diff2);
            chart4.Series[0].Points.AddXY(no, vol);
            chart5.Series[0].Points.AddXY(no,vwap);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            double d1 = Convert.ToDouble(dataGridView1.Rows[rowindex].Cells[8].Value.ToString()) - Convert.ToDouble(dataGridView1.Rows[rowindex].Cells[4].Value.ToString());
            double d2 = Convert.ToDouble(dataGridView1.Rows[rowindex].Cells[5].Value.ToString()) - Convert.ToDouble(dataGridView1.Rows[rowindex].Cells[6].Value.ToString());
            double d3 = Convert.ToDouble(dataGridView1.Rows[rowindex].Cells[10].Value.ToString());
            double d4 = Convert.ToDouble(dataGridView1.Rows[rowindex].Cells[9].Value.ToString());
            double d5 = Convert.ToDouble(dataGridView1.Rows[rowindex].Cells[4].Value.ToString()) - Convert.ToDouble(dataGridView1.Rows[rowindex].Cells[3].Value.ToString());
            double d6 = Convert.ToDouble(dataGridView1.Rows[rowindex].Cells[4].Value.ToString());
            graph(rowindex, Convert.ToDouble(dataGridView1.Rows[rowindex].Cells[8].Value.ToString()),d1,d2,d3,d4,d5,d6);
            if(d1<0)
            {

                label1.Text = Convert.ToString(Math.Round(d1,3));
                label1.ForeColor = Color.Salmon;
            }
            else
            {
                label1.Text = "+"+Convert.ToString(Math.Round(d1,3));
                label1.ForeColor = Color.LightGreen; ;
            }
           
            if(rowindex<maxrowindex)
            {
                rowindex = rowindex + 1;
            }
            else
            {
                timer1.Enabled = false;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer2.Enabled = false;
        }
    }
}
