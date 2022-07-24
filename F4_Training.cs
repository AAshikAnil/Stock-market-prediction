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
    public partial class F4_Training : Form
    {
        public static DataTable fdt = new DataTable();
        public F4_Training()
        {
            InitializeComponent();
        }
        public F4_Training(DataTable dt)
        {
            InitializeComponent();
            fdt = dt;
            loaddata(dt);


        }
        public void loaddata(DataTable dt)
        {
            dataGridView1.DataSource = dt;

            for (int i = 0; i < 3; i++)
            {
                dataGridView1.Columns.RemoveAt(dataGridView1.Columns.Count - 1);
            }
            label9.Text = dataGridView1.Rows.Count.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int total = dataGridView1.Rows.Count;
            double seventy = (total * .7);
            int s7 = (int)seventy;
            label3.Text = s7.ToString();


            for (int i = s7; i < total; i++)
            {

                dataGridView1.Rows[i].Visible = false;
            }



        }

        private void button3_Click(object sender, EventArgs e)
        {
            string columnnames = "";
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                var name = dataGridView1.Columns[i].HeaderText;
                columnnames = columnnames + name + ",";
            }

            F5_ParameterSelection obj = new F5_ParameterSelection(columnnames);
            ActiveForm.Hide();
            obj.Show();

        }

      
            }
           
        }
