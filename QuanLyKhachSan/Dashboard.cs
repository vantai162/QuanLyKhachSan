using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace QuanLyKhachSan
{
    public partial class Dashboard : Form
    {
        bool admin;
        String user, chucVu,maNV;
        
        public Dashboard(String _admin,String _user,String _chucVu)
        {
            InitializeComponent();

            if (_admin.Trim() == "1")
                admin = true;
            else
                admin = false;
            user = _user;
            chucVu = _chucVu;
            String thoiGian = DateTime.Now.ToString("dd/MM/yyyy");
            hoverBox1.Text = "Xin chào!\r\n" + $"Username: {user}\r\n" + $"Chức vụ: {chucVu}\r\n" + thoiGian;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            uC_AddRoom1.Visible = false;
            uC_CustomerRes1.Visible = false;
            uC_CheckOut1.Visible = false;
            uC_CustomerDetails1.Visible = false;
            uC_Employee1.Visible = false;
            btnAddRoom.PerformClick();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void uC_AddRoom1_Load(object sender, EventArgs e)
        {

        }

        private void btnCustomerRes_Click(object sender, EventArgs e)
        {
            PanelMoving.Left = btnCustomerRes.Left+22;
            uC_CustomerRes1.Visible = true;
            uC_CustomerRes1.BringToFront();
        }

        private void btnAddRoom_Click_1(object sender, EventArgs e)
        {
            PanelMoving.Left = 15;
            uC_AddRoom1.Visible = true;
            uC_AddRoom1.BringToFront();
        }

        private void bthCheckOut_Click(object sender, EventArgs e)
        {
            PanelMoving.Left = 516;
            uC_CheckOut1.Visible = true;
            uC_CheckOut1.BringToFront();
        }

        private void btnCustomerDetail_Click(object sender, EventArgs e)
        {
            PanelMoving.Left = btnCustomerDetail.Left + 8;
            uC_CustomerDetails1.Visible = true;
            uC_CustomerDetails1.BringToFront();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            if (admin)
            {
                PanelMoving.Left = btnEmployee.Left + 8;
                uC_Employee1.Visible = true;
                uC_Employee1.BringToFront();
            }
            else
            {
                MessageBox.Show($"Bạn không có quyền truy cập vào đây!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnMinisize_Click(object sender, EventArgs e)
        {
            Form1 Login = new Form1();
            Login.Show();


            this.Close();
        }

        private void btnAddRoom_MouseEnter(object sender, EventArgs e)
        {
            btnAddRoom.Text = "Add Room";
            btnAddRoom.Image = null;
        }

        private void btnAddRoom_MouseLeave(object sender, EventArgs e)
        {
            btnAddRoom.Text = null;
            btnAddRoom.Image = QuanLyKhachSan.Properties.Resources.extra_bed;
        }

        private void btnCustomerRes_MouseEnter(object sender, EventArgs e)
        {
            btnCustomerRes.Text = "Customer Registration";
            btnCustomerRes.Image = null;
        }

        private void btnCustomerRes_MouseLeave(object sender, EventArgs e)
        {
            btnCustomerRes.Text = null;
            btnCustomerRes.Image = QuanLyKhachSan.Properties.Resources.customer;
        }

        private void bthCheckOut_MouseEnter(object sender, EventArgs e)
        {
            bthCheckOut.Text = "Checkout";
            bthCheckOut.Image = null;
        }

        private void bthCheckOut_MouseLeave(object sender, EventArgs e)
        {
            bthCheckOut.Text = null;
            bthCheckOut.Image = QuanLyKhachSan.Properties.Resources.check_out__1_;
        }

        private void btnCustomerDetail_MouseEnter(object sender, EventArgs e)
        {
            btnCustomerDetail.Text = "Customers' Details";
            btnCustomerDetail.Image = null;
        }

        private void btnCustomerDetail_MouseLeave(object sender, EventArgs e)
        {
            btnCustomerDetail.Text= null;
            btnCustomerDetail.Image = QuanLyKhachSan.Properties.Resources.applicant__1_;
        }

        private void btnEmployee_MouseEnter(object sender, EventArgs e)
        {
            btnEmployee.Text = "Employee";
            btnEmployee.Image = null;   
        }

        private void btnEmployee_MouseLeave(object sender, EventArgs e)
        {
            btnEmployee.Text = null;
            btnEmployee.Image = QuanLyKhachSan.Properties.Resources.staff;
        }

        private void userButton_MouseEnter(object sender, EventArgs e)
        {
            
            hoverBox1.Visible = true;
        }

        private void userButton_MouseLeave(object sender, EventArgs e)
        {
            hoverBox1.Visible = false;
        }
    }
}
