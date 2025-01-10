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
    public partial class UC_CheckOut : UserControl
    {
        float sum = 0;
        DateTime ngayNhanPhong;
        DateTime ngayTraPhong;
        float giaMoiDem;
        string maHoaDon;
        string tenKH;
        string soPhong;
        string maKH;
        TimeSpan soNgayO;
        Function fn=new Function();
       
        
        String query;
        public UC_CheckOut()
        {
            InitializeComponent();
            
        }

        private void UC_CheckOut_Load(object sender, EventArgs e) //load bang
        {
            query = "Select KHACHHANG.MaKhachHang, KHACHHANG.HoTen,KHACHHANG.SoDienThoai, KHACHHANG.QuocTich,KHACHHANG.GioiTinh, KHACHHANG.NgaySinh,KHACHHANG.CCCD,KHACHHANG.DiaChi,KHACHHANG.NgayNhanPhong,PHONG.SoPhong,PHONG.LoaiPhong,PHONG.LoaiGiuong,PHONG.GiaMoiDem from KHACHHANG inner join PHONG on KHACHHANG.MaPhong=PHONG.MaPhong where KHACHHANG.Checkout = 'false'";
            DataSet ds = fn.GetData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void txtName_TextChanged(object sender, EventArgs e) //thanh tim kiem
        {
            query = "Select KHACHHANG.MaKhachHang, KHACHHANG.HoTen,KHACHHANG.SoDienThoai, KHACHHANG.QuocTich,KHACHHANG.GioiTinh, KHACHHANG.NgaySinh,KHACHHANG.CCCD,KHACHHANG.DiaChi,KHACHHANG.NgayNhanPhong,PHONG.SoPhong,PHONG.LoaiPhong,PHONG.LoaiGiuong,PHONG.GiaMoiDem from KHACHHANG inner join PHONG on KHACHHANG.MaPhong=PHONG.MaPhong where HoTen like'" + txtName.Text+ "%' AND KHACHHANG.Checkout = 'false'"; 
            DataSet ds = fn.GetData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value != null)
            {
                // Lấy giá trị từ DataGridView
                maKH = guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtCName.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtRoom.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                giaMoiDem = float.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString());
                ngayNhanPhong = DateTime.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString()); // Lấy từ DataGridView hoặc DateTimePicker
                ngayTraPhong = DateTime.Parse(txtCheckOutDate.Text);  
                soNgayO = ngayTraPhong - ngayNhanPhong;
                tenKH = txtCName.Text;
                soPhong = txtRoom.Text;

            }
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            
            if (txtCName.Text != "")
            {
                if (ngayTraPhong < ngayNhanPhong)
                    MessageBox.Show("Vui lòng chọn ngày trả phòng lớn hơn ngày nhận phòng!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    XuatHoaDon xuatHoaDon = new XuatHoaDon(maKH, tenKH, soNgayO, soPhong, ngayNhanPhong, ngayTraPhong, giaMoiDem);
                    xuatHoaDon.ShowDialog();
                    UC_CheckOut_Load(this, null);
                    ClearAll();
                }
            }    
            else
            {
                MessageBox.Show("Không tìm thấy thông tin khách hàng", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }    
        }
        public void ClearAll()
        {
            txtCName.Clear();
            txtName.Clear();
            txtRoom.Clear();
            txtCheckOutDate.ResetText();
        }

        private void UC_CheckOut_Leave(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void txtCheckOutDate_ValueChanged(object sender, EventArgs e)
        {
            ngayTraPhong = DateTime.Parse(txtCheckOutDate.Text);
            txtCName.Clear();
            txtName.Clear();
            txtRoom.Clear();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            ThongKe thongKe = new ThongKe();
            thongKe.ShowDialog();   

        }
    }
}
