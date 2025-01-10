using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace QuanLyKhachSan
{
    public partial class Form1 : Form
    {
        Function fn = new Function();
        String query;
        public Form1()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            query = "Select Username, Password,Admin,Chucvu from NHANVIEN where Username = '" + txtUsername.Text + "' and Password = '" + txtPassword.Text + "'";
            DataSet ds = fn.GetData(query);
            
            if (ds.Tables[0].Rows.Count != 0)
            {
                String admin = ds.Tables[0].Rows[0][2].ToString();
                String user = ds.Tables[0].Rows[0][0].ToString();
                String chucVu = ds.Tables[0].Rows[0][3].ToString();
                labelError.Visible = false;
                Dashboard dash = new Dashboard(admin,user,chucVu);
                this.Hide();
                dash.Show();
            }
            else
            {
                labelError.Visible = true;
                txtPassword.Clear();
            }    
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
            guna2CirclePictureBox1.Visible = false;
            guna2CirclePictureBox2.Visible = true;
            
        }

        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
            guna2CirclePictureBox1.Visible = true;
            guna2CirclePictureBox2.Visible = false;
        }
    }
}
