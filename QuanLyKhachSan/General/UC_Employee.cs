using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan.General
{
    public partial class UC_Employee : UserControl
    {
        Function fn = new Function();
        String query;
        public UC_Employee()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;
        }

        private void UC_Employee_Load(object sender, EventArgs e)
        {
            getMaxID();
        }
        public void getMaxID()
        {
            query = "Select max(MaNhanVien) from NHANVIEN";
            DataSet ds=fn.GetData(query);

            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                Int64 num = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                labelToSET.Text = (num + 1).ToString();
            }    
        }

        private void btnRegistation_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtMobile.Text != "" && txtGender.Text != "" && txtEmail.Text != "" && txtUserName.Text != "" && txtPassword.Text != "" && txtPosition.Text != "")
            {
                String name = txtName.Text;
                Int64 mobile = Int64.Parse(txtMobile.Text);
                String gender = txtGender.Text;
                String position = txtPosition.Text;
                String email = txtEmail.Text;
                String username = txtUserName.Text;
                String password = txtPassword.Text;
                String salary = txtSalary.Text;
                String admin;
                if (txtPosition.Text == "Quan ly nhan su")
                    admin = "1";
                else
                    admin = "0";
                query = "Insert into NHANVIEN (HoTen,SoDienThoai,Email,ChucVu,Luong,GioiTinh,Username,Password,Admin) values ('" + name + "', '" + mobile + "','" + email + "','" + position + "','" + salary + "','" + gender + "','" + username + "','" + password + "','" + admin+ "')";
                fn.SetData(query, "Đăng Ký Nhân Viên Thành Công!!!");
                ClearAll();
                getMaxID();
            }
            else
                MessageBox.Show("Xin vui lòng nhập đầy đủ thông tin!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ClearAll()
        {
            txtName.Clear();
            txtMobile.Clear();
            txtGender.SelectedIndex = -1;
            txtEmail.Clear();
            txtUserName.Clear();
            txtPassword.Clear();
            txtPosition.SelectedIndex = -1;
            txtSalary.Clear();
        }

        private void txtPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtPosition.Text == "Nhan vien le tan")
            {
                txtSalary.Text = "12000000";
            }
            else if (txtPosition.Text == "Nhan vien phuc vu")
            {
                txtSalary.Text = "7000000";
            }
            else if (txtPosition.Text == "Nhan vien buong phong")
            {
                txtSalary.Text = "7000000";
            }
            else if (txtPosition.Text == "Dau bep")
            {
                txtSalary.Text = "15000000";
            }
            else if (txtPosition.Text == "Bao ve")
            {
                txtSalary.Text = "7000000";
            }
            else if (txtPosition.Text == "Quan ly nha hang")
            {
                txtSalary.Text = "20000000";
            }
            else if (txtPosition.Text == "Quan ly phong")
            {
                txtSalary.Text = "25000000";
            }
            else if (txtPosition.Text == "Quan ly nhan su")
            {
                txtSalary.Text = "25000000";
            }
        }

        private void tabEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabEmployee.SelectedIndex == 1)
            {
                SetEmployee(guna2DataGridView1);
            } else if (tabEmployee.SelectedIndex == 2) 
            {
                SetEmployee(guna2DataGridView2);
            }
        }
        public void SetEmployee(DataGridView dgv)
        {
            query = "Select * from NHANVIEN";
            DataSet ds = fn.GetData(query);
            dgv.DataSource = ds.Tables[0];
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtEID.Text != "")
            {
                if (MessageBox.Show("Bạn có chắc chắn không?", "Xác nhận!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    query = "Delete from NHANVIEN where MaNhanVien = " + txtEID.Text + "";
                    fn.SetData(query, "Xóa thông tin thành công!!!");
                    tabEmployee_SelectedIndexChanged(this, null);
                }
            }
           
        }

        private void UC_Employee_Leave(object sender, EventArgs e)
        {
            ClearAll();
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
