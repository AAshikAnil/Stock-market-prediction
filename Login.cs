using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace Stockmarketprediction
{
    public partial class Login : Form
    {
         BaseConnection con = new BaseConnection();
        public Login()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "select * from login where username='" + name.Text  + "'";
                SqlDataReader sd = con.ret_dr(query);
                if (sd.Read())
                {
                    if ((name.Text == sd[0].ToString()) && pwd.Text == sd[1].ToString())
                    {


                        BasePage obj = new BasePage();
                        ActiveForm.Hide();
                        obj.Show();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect username or password");
                        name.Text = "";
                        pwd.Text = "";
                    }
            }
            else
            {
                MessageBox.Show("Incorrect username or password");
                name.Text = "";
                pwd.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
        }
    }
}
