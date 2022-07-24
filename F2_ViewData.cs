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
    public partial class F2_ViewData : Form
    {
        public F2_ViewData()
        {
            InitializeComponent();

        }
        public F2_ViewData(DataTable dt)
        {
            InitializeComponent();
            dataGridView1.DataSource = dt;
            Program.orginal = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            F3_Cleaning obj = new F3_Cleaning();
            ActiveForm.Hide();
            obj.Show();
        }
    }
}
