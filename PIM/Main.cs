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
    public partial class Main : Form
    {
        public string username = "";
        SqlHelp sqlhelp = new SqlHelp();
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            label2.Text = info.Username;
            string sql = "select m.NAME from  [dbo].[T_ROLE] r left join  [dbo].[T_MENU] m on r.MENU_ID=M.ID left join  [dbo].[T_USER] u on r.USER_ID=u.ID where u.NAME='" + info.Username + "'";
           DataTable dt= sqlhelp.getData(sql);
            foreach (ToolStripMenuItem item in menuStrip1.Items)
            {
                if (dt.Select("NAME='" + item.Text + "'").Count() > 0)
                {
                    item.Visible = true;
                }
            }
        }

        private void 销售ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sell fm=new Sell();
            fm.Show();
        }

        private void 入库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buy fm = new buy();
            fm.Show();
        }

        private void 产品信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            INVENTORY fm = new INVENTORY();
            fm.Show();
        }

        private void 员工ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            People fm = new People();
            fm.Show();
        }

        private void 备份ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Backup  fm = new Backup();
            fm.Show();
        }
    }
}
