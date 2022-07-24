using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Stockmarketprediction
{
    public partial class F3_Cleaning : Form
    {
        public F3_Cleaning()
        {
            InitializeComponent();
            dataGridView1.DataSource = Program.orginal;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < Program.orginal.Rows.Count; i++)
            {
                label5.Text = i.ToString() + " Rows";
                dataGridView1.Rows[i].Selected = true;
            }
            int c = dataGridView1.Rows.Count * 3;
            int d = dataGridView1.Rows.Count * dataGridView1.Columns.Count;
            label2.Text = c.ToString() + " Blank cells";
            label3.Text = d.ToString() + " Valid cells";
            label4.Visible = true;
            label4.ForeColor = Color.IndianRed;
            label4.Text = "Has to Remove " + c.ToString() + " Cells";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                dataGridView1.Columns.RemoveAt(dataGridView1.Columns.Count - 1);
            }
            label2.Text = "0 Blank cells";
            label4.Text = "Dataset good for Data Analysis";
            label4.ForeColor = Color.LightGreen;
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)dataGridView1.DataSource;

            F4_Training obj = new F4_Training(dt);
            ActiveForm.Hide();
            obj.Show();
        }
    }
}
