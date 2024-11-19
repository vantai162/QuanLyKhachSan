using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    internal class Function
    {
        protected SqlConnection GetConnection() 
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source = TAI\\SQLEXPRESS; Initial Catalog = QuanLyKhachSan; Integrated Security = True";
            return con;
        }
        public DataSet GetData(String query)
        {
            SqlConnection con = GetConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = query;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public void SetData(String query,String message) 
        { 
            SqlConnection con = GetConnection();
            SqlCommand cmd =new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(message,"Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        public SqlDataReader GetForComBo(String query) 
        {
            SqlConnection con = GetConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd=new SqlCommand(query,con);
            SqlDataReader sdr=cmd.ExecuteReader();
            return sdr;
        }
    }
}
