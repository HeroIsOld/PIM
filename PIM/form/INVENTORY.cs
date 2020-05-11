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
    public partial class INVENTORY : Form
    {
        SqlHelp sqlhelp = new SqlHelp();

        bool isnew = true;
        string id = "";
        public INVENTORY()
        {
            InitializeComponent();
        }

        private void INVENTORY_Load(object sender, EventArgs e)
        {
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Name = "btnDelete";
            btn.HeaderText = "操作";
            btn.DefaultCellStyle.NullValue = "修改";
            dataGridView1.Columns.Add(btn);

            Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        //保存
        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "";
            if (isnew)
            {

                sql = "INSERT INTO [dbo].[T_INVENTORY] ([CODE],[NAME],[COLOR],[TYPE],[TYPE2],[NUM],[PRICE],[BARCODE])VALUES('" + textBox3.Text + "','" + textBox4.Text + "','" + textBox9.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox2.Text + "','" + textBox7.Text + "','" + textBox8.Text + "');select @@IDENTITY ";
                int nextid = (int)sqlhelp.updateOrder(sql);
                sql = "INSERT INTO  [dbo].[T_CHECK] ([INVENTORY_ID],[OLD_NUM],[NEW_NUM],[COMMENT],[CREATED_DATA],[CREATED_USER])VALUES(" + nextid.ToString() + ", 0, " + textBox2.Text + ",'" + richTextBox1.Text + "',getdate(),'" + info.Username + "' ) ";
                sqlhelp.updateData(sql);
            }
            else
            {
                sql = "INSERT INTO  [dbo].[T_CHECK] ([INVENTORY_ID],[OLD_NUM],[NEW_NUM],[COMMENT],[CREATED_DATA],[CREATED_USER])VALUES(" + id + ",(select NUM from  [T_INVENTORY] where ID=" + id + "), " + textBox2.Text + ",'" + richTextBox1.Text + "',getdate(),'" + info.Username + "' ) ";
                sqlhelp.updateData(sql);
                sql = " UPDATE[dbo].[T_INVENTORY]    SET [CODE] = '" + textBox3.Text + "'       ,[NAME] = '" + textBox4.Text + "'      ,[COLOR] = '" + textBox9.Text + "'      ,[TYPE] = '" + textBox5.Text + "'      ,[TYPE2] = '" + textBox6.Text + "'      ,[NUM] = '" + textBox2.Text + "'    ,[PRICE] = '" + textBox7.Text + "'      ,[BARCODE] = '" + textBox8.Text + "' WHERE ID =   " + id;
                sqlhelp.updateData(sql);
            }
            Refresh();
            clear();
            texxtreadonly(false);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "btnDelete" && e.RowIndex >= 0)
            {
                clear();
                texxtreadonly(true);
                isnew = false;
                string chooseid = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                string sql = " select  * from [dbo].[T_INVENTORY] where ID= " + chooseid;
                DataTable dt = sqlhelp.getData(sql);

                id = chooseid;
                textBox2.Text = dt.Rows[0]["NUM"].ToString();
                textBox8.Text = dt.Rows[0]["BARCODE"].ToString();
                textBox9.Text = dt.Rows[0]["COLOR"].ToString();
                textBox7.Text = dt.Rows[0]["PRICE"].ToString();
                textBox6.Text = dt.Rows[0]["TYPE2"].ToString();
                textBox5.Text = dt.Rows[0]["TYPE"].ToString();
                textBox4.Text = dt.Rows[0]["NAME"].ToString();
                textBox3.Text = dt.Rows[0]["CODE"].ToString();
            }
        }

        //取消
        private void button2_Click(object sender, EventArgs e)
        {
            clear();
            texxtreadonly(false);
        }

        //新增
        private void button3_Click(object sender, EventArgs e)
        {
            clear();
            texxtreadonly(true);
            isnew = true;
        }

        private void clear()
        {
            id = "";
            richTextBox1.Clear();
            textBox2.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox7.Clear();
            textBox6.Clear();
            textBox5.Clear();
            textBox4.Clear();
            textBox3.Clear();
        }

        private void texxtreadonly(bool isadd)
        {
            richTextBox1.Enabled = isadd;
            textBox2.Enabled = isadd;
            textBox8.Enabled = isadd;
            textBox9.Enabled = isadd;
            textBox7.Enabled = isadd;
            textBox6.Enabled = isadd;
            textBox5.Enabled = isadd;
            textBox4.Enabled = isadd;
            textBox3.Enabled = isadd;
            button2.Enabled = isadd;
            button1.Enabled = isadd;
            button3.Enabled = !isadd;
        }

        private void Refresh()
        {
            string sql = " select  * from [dbo].[T_INVENTORY] ";
            DataTable dt = sqlhelp.getData(sql);
            dataGridView1.DataSource = dt;
        }

    }
}
