using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PIM
{
    public class SqlHelp
    {
        string StrConnection = System.Configuration.ConfigurationManager.ConnectionStrings["PIMConnectionString"].ToString();

        public DataTable getData(string sql)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(StrConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }
            return dt;
        }

        public int updateData(string sql)
        {
            using (SqlConnection conn = new SqlConnection(StrConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                 int rownum =  cmd.ExecuteNonQuery();
                return rownum;
            }
        }

        public Decimal updateOrder (string sql)
        {
            using (SqlConnection conn = new SqlConnection(StrConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                var id= cmd.ExecuteScalar();
                return Convert.ToDecimal(id);
            }
        }
       
    }
}
