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
    public partial class F5_ParameterSelection : Form
    {
        public F5_ParameterSelection()
        {
            InitializeComponent();
        }
        public F5_ParameterSelection(string columnnames)
        {
            InitializeComponent();
            string[] c = columnnames.Split(',');
            for(int i=0;i<c.Count();i++)
            {
                if (c[i] != "Date" && c[i]!= "Symbol" && c[i] != "Series" && c[i] != "%Deliverble" && c[i] != "Deliverable Volume" && c[i] != "Trades")
                {
                    comboBox1.Items.Add(c[i].ToString());
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text!="")
            { 
            F6_Calculate obj = new F6_Calculate(comboBox1.Text);
            ActiveForm.Hide();
            obj.Show();
            }
            else
            {
                MessageBox.Show("Please select a value..");
            }
        }
    }
}
