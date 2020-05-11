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
    public partial class Sell : Form
    {

        SqlHelp sqlhelp = new SqlHelp();
        string id = "";
        DataTable dtChat = new DataTable();

        public Sell()
        {
            InitializeComponent();
        }

        private void Sell_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            numericUpDown1.Enabled = false;

            string sql = "select BARCODE,  CODE+'-'+NAME as QUERY from [dbo].[T_INVENTORY]";
            DataTable dt = sqlhelp.getData(sql);
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "QUERY";
            comboBox2.ValueMember = "BARCODE";

            string sql1 = "select ID,NAME from  [dbo].[T_SELLER]";
            DataTable dt2 = sqlhelp.getData(sql1);
            comboBox1.DataSource = dt2;
            comboBox1.DisplayMember = "NAME";
            comboBox1.ValueMember = "ID";

            dtChat.Columns.Add("ID", Type.GetType("System.String"));
            dtChat.Columns.Add("名称", Type.GetType("System.String"));
            dtChat.Columns.Add("数量", Type.GetType("System.Int32"));
            dtChat.Columns.Add("单价", Type.GetType("System.String"));
            dataGridView1.DataSource = dtChat;

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Name = "btnDelete";
            btn.HeaderText = "操作";
            btn.DefaultCellStyle.NullValue = "删除";
            dataGridView1.Columns.Add(btn);

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                selectInventory(false, textBox2.Text);
                textBox2.Clear();
                if (id != "")
                {
                    addtochat(1);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            selectInventory(true, comboBox2.SelectedValue.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addtochat(Convert.ToInt32(numericUpDown1.Value));
            clearText(false);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "btnDelete" && e.RowIndex >= 0)
            {

                for (int i = 0; i < dtChat.Rows.Count; i++)
                {
                    if (dtChat.Rows[i]["ID"].ToString() == dataGridView1.CurrentRow.Cells[0].Value.ToString())
                    {
                        dtChat.Rows[i].Delete();
                    }
                }
            }

            caltotal();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox11.Text == "" || textBox10.Text == "")
            {
                MessageBox.Show("请填2客户信息");
                return;
            }
            
            string sql1 = "insert into dbo.T_ORDER (TYPE,SELLER_ID,CREATED_DATA,COMMENT,CREATED_USER,CLIENT_NAME,CLIENT_TEL) values ('SELL',"+comboBox1.SelectedValue.ToString()+ ",getdate(),'"+richTextBox1.Text+"','"+info.Username+"','"+textBox11.Text+"','"+textBox10.Text+"' ); select @@IDENTITY";
            int nextid=(int)sqlhelp.updateOrder(sql1);

            string sql2="";
            string sql3= "";
            for (int i = 0; i < dtChat.Rows.Count; i++)
            {
                sql2 = "insert into dbo.T_ORDER_LIST (ORDER_ID,INVENTORY_ID,NUM,PRICE) values ("+ nextid + ","+ dtChat.Rows[i]["ID"].ToString()+ ","+ dtChat.Rows[i]["数量"].ToString() + "," + dtChat.Rows[i]["单价"].ToString() + ")";
                sqlhelp.updateData(sql2);
                sql3 = "Update [dbo].[T_INVENTORY] set NUM=NUM - " + dtChat.Rows[i]["数量"].ToString() + " where ID = " + dtChat.Rows[i]["ID"].ToString();
                sqlhelp.updateData(sql3);
            }

            MessageBox.Show("完成");
            clearText(true);
        }


        private void selectInventory(bool isnotAdd, string BARCODE)
        {
            numericUpDown1.Enabled = isnotAdd;
            button1.Enabled = isnotAdd;

            string sql = " select  * from [dbo].[T_INVENTORY] where BARCODE='" + BARCODE + "'";
            DataTable dt = sqlhelp.getData(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                id = dt.Rows[0]["ID"].ToString();
                textBox3.Text = dt.Rows[0]["CODE"].ToString();
                textBox4.Text = dt.Rows[0]["NAME"].ToString();
                textBox9.Text = dt.Rows[0]["COLOR"].ToString();
                textBox5.Text = dt.Rows[0]["TYPE"].ToString();
                textBox6.Text = dt.Rows[0]["TYPE2"].ToString();
                textBox1.Text = dt.Rows[0]["NUM"].ToString();
                textBox7.Text = dt.Rows[0]["PRICE"].ToString();
                textBox8.Text = dt.Rows[0]["BARCODE"].ToString();
            }
            else
            {
                clearText(false);
            }
        }

        private void addtochat(Int32 num)
        {
            bool isE = false;
            for (int i = 0; i < dtChat.Rows.Count; i++)
            {
                if (dtChat.Rows[i]["ID"].ToString() == id)
                {
                    dtChat.Rows[i]["数量"] = Convert.ToInt32(dtChat.Rows[i]["数量"]) + num;
                    isE = true;
                }
            }
            if (!isE)
            {
                DataRow dr = dtChat.NewRow();
                dr[0] = id;
                dr[1] = textBox4.Text;
                dr[2] = num;
                dr[3] = textBox7.Text;
                dtChat.Rows.Add(dr);
            }
            caltotal();
        }

        private void caltotal( )
        {
            Decimal _total = 0;
            for (int i = 0; i < dtChat.Rows.Count; i++)
            {
                _total += Convert.ToDecimal(dtChat.Rows[i]["数量"]) * Convert.ToDecimal(dtChat.Rows[i]["单价"]);
            }
            total.Text = _total.ToString();
        }

        private void clearText(bool isAll)
        {
            button1.Enabled = false;
            numericUpDown1.Enabled = false;
            id = "";
            numericUpDown1.Value = 1;
            textBox3.Clear();
            textBox4.Clear();
            textBox9.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox1.Clear();
            textBox7.Clear();
            textBox8.Clear();
            if (isAll)
            {
                dtChat.Rows.Clear();
                textBox11.Clear();
                textBox10.Clear();
                richTextBox1.Clear();
            }
        }

    }
}
