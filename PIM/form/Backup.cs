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
    public partial class Backup : Form
    {
        public Backup()
        {
            InitializeComponent();
        }
        SqlHelp sqlhelp = new SqlHelp();
        private void button1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = DateTime.Now.ToString("yyyyMMdd");
            saveFileDialog1.DefaultExt = "bak";//设置默认格式（可以不设）
            saveFileDialog1.AddExtension = true;//

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                sqlhelp.updateData("BACKUP DATABASE [PIM]  TO DISK='" + saveFileDialog1.FileName + "' ");
                MessageBox.Show("完成");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                sqlhelp.updateData("begin ALTER DATABASE [PIM]  SET OFFLINE WITH ROlLBACK IMMEDIATE; RESTORE DATABASE  [PIM]  FROM DISK = '" + openFileDialog1.FileName + "' WITH REPLACE ; ALTER DATABASE [PIM]  SET ONLINE WITH ROlLBACK IMMEDIATE; end;");
                MessageBox.Show("完成");
            }


        }
    }
}
