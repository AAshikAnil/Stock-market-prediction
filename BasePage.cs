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
    public partial class BasePage : Form
    {
        public BasePage()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            F1_LoadData obj = new F1_LoadData();
            obj.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
