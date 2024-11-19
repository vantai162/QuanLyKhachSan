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
        Function fn=new Function();
        String query;
        public UC_CheckOut()
        {
            InitializeComponent();
        }

        private void UC_CheckOut_Load(object sender, EventArgs e)
        {
            query = "Select KHACHHANG.MaKhachHang, KHACHHANG.HoTen,KHACHHANG.SoDienThoai, KHACHHANG.QuocTich,KHACHHANG.GioiTinh, KHACHHANG.NgaySinh,KHACHHANG.CCCD,KHACHHANG.DiaChi,KHACHHANG.NgayNhanPhong,PHONG.SoPhong,PHONG.LoaiPhong,PHONG.LoaiGiuong,PHONG.GiaMoiDem from KHACHHANG inner join PHONG on KHACHHANG.MaPhong=PHONG.MaPhong";
            DataSet ds = fn.GetData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            query = "Select KHACHHANG.MaKhachHang, KHACHHANG.HoTen,KHACHHANG.SoDienThoai, KHACHHANG.QuocTich,KHACHHANG.GioiTinh, KHACHHANG.NgaySinh,KHACHHANG.CCCD,KHACHHANG.DiaChi,KHACHHANG.NgayNhanPhong,PHONG.SoPhong,PHONG.LoaiPhong,PHONG.LoaiGiuong,PHONG.GiaMoiDem from KHACHHANG inner join PHONG on KHACHHANG.MaPhong=PHONG.MaPhong where HoTen like'" + txtName.Text+ "%'" ; 
            DataSet ds = fn.GetData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];

        }

        int id;
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.Rows[e.RowIndex].Cells[e.RowIndex].Value != null)
            {
                id = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtCName.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtRoom.Text= guna2DataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (txtCName.Text != "")
            {
                if(MessageBox.Show("Bạn có đồng ý thanh toán không?","Xác nhận!",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning)==DialogResult.OK)
                {
                    String cdate=txtCheckOutDate.Text;
                    query = " delete from KHACHHANG where MaKhachHang=" + id + " update PHONG set TinhTrang='Trong' where SoPhong='" + txtRoom.Text + "update HOADON set NgayTraPhong= " + cdate + "'";
                    fn.SetData(query, "Thanh Toán Thành Công");
                    UC_CheckOut_Load(this, null);
                    ClearAll();

                }    
            }    else
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
    }
}
