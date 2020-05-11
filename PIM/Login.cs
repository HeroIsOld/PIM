using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIM
{
    public partial class Login : Form
    {
        SqlHelp sqlhelp = new SqlHelp();
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string pwd = textBox2.Text;
            string sql = "select * from T_USER where NAME='" + name + "' and PWD ='" + pwd + "'";
            DataTable dt = sqlhelp.getData(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                info.Username = name;
                this.DialogResult = DialogResult.OK;
                this.Dispose();
                this.Close();
            }
            else
            {
                MessageBox.Show("帐号密码错误");
            }
        }

    }
}
