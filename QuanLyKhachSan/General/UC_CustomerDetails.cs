using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.Design;
using System.Windows.Forms;
using System.Xml.Linq;

namespace QuanLyKhachSan.General
{
    public partial class UC_CustomerDetails : UserControl
    {
        Function fn = new Function();
        String query;
        int maKH;
        public UC_CustomerDetails()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LoadAgain()
        {
            if (txtSearchBy.SelectedIndex == 0) //tat ca khach hang
            {
                query = "Select KHACHHANG.MaKhachHang, KHACHHANG.HoTen,KHACHHANG.SoDienThoai, KHACHHANG.QuocTich,KHACHHANG.GioiTinh, KHACHHANG.NgaySinh,KHACHHANG.CCCD,KHACHHANG.DiaChi,KHACHHANG.NgayNhanPhong,PHONG.SoPhong,PHONG.LoaiPhong,PHONG.LoaiGiuong,PHONG.GiaMoiDem from KHACHHANG inner join PHONG on KHACHHANG.MaPhong=PHONG.MaPhong";
                GetRecord(query);
            }
            else if (txtSearchBy.SelectedIndex == 1)
            {
                query = "Select KHACHHANG.MaKhachHang, KHACHHANG.HoTen,KHACHHANG.SoDienThoai, KHACHHANG.QuocTich,KHACHHANG.GioiTinh, KHACHHANG.NgaySinh,KHACHHANG.CCCD,KHACHHANG.DiaChi,KHACHHANG.NgayNhanPhong,PHONG.SoPhong,PHONG.LoaiPhong,PHONG.LoaiGiuong,PHONG.GiaMoiDem from KHACHHANG inner join PHONG on KHACHHANG.MaPhong=PHONG.MaPhong where KHACHHANG.Checkout = 'false'";
                GetRecord(query);
            }
            else if (txtSearchBy.SelectedIndex == 2)
            {
                query = "Select KHACHHANG.MaKhachHang, KHACHHANG.HoTen,KHACHHANG.SoDienThoai, KHACHHANG.QuocTich,KHACHHANG.GioiTinh, KHACHHANG.NgaySinh,KHACHHANG.CCCD,KHACHHANG.DiaChi,KHACHHANG.NgayNhanPhong,PHONG.SoPhong,PHONG.LoaiPhong,PHONG.LoaiGiuong,PHONG.GiaMoiDem from KHACHHANG inner join PHONG on KHACHHANG.MaPhong=PHONG.MaPhong where KHACHHANG.Checkout = 'true'";
                GetRecord(query);
            }
        }
        private void UC_CustomerDetails_Load(object sender, EventArgs e)
        {
           
        }

        private void txtSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtSearchBy.SelectedIndex == 0) //tat ca khach hang
            {
                query = "Select KHACHHANG.MaKhachHang, KHACHHANG.HoTen,KHACHHANG.SoDienThoai, KHACHHANG.QuocTich,KHACHHANG.GioiTinh, KHACHHANG.NgaySinh,KHACHHANG.CCCD,KHACHHANG.DiaChi,KHACHHANG.NgayNhanPhong,PHONG.SoPhong,PHONG.LoaiPhong,PHONG.LoaiGiuong,PHONG.GiaMoiDem from KHACHHANG inner join PHONG on KHACHHANG.MaPhong=PHONG.MaPhong";
                GetRecord(query);
                addDichVu.Visible = false;
            }
            else if (txtSearchBy.SelectedIndex == 1)
            {
                query = "Select KHACHHANG.MaKhachHang, KHACHHANG.HoTen,KHACHHANG.SoDienThoai, KHACHHANG.QuocTich,KHACHHANG.GioiTinh, KHACHHANG.NgaySinh,KHACHHANG.CCCD,KHACHHANG.DiaChi,KHACHHANG.NgayNhanPhong,PHONG.SoPhong,PHONG.LoaiPhong,PHONG.LoaiGiuong,PHONG.GiaMoiDem from KHACHHANG inner join PHONG on KHACHHANG.MaPhong=PHONG.MaPhong where KHACHHANG.Checkout = 'false'";
                GetRecord(query);
                addDichVu.Visible = true;
            }
            else if (txtSearchBy.SelectedIndex == 2)
            {
                query = "Select KHACHHANG.MaKhachHang, KHACHHANG.HoTen,KHACHHANG.SoDienThoai, KHACHHANG.QuocTich,KHACHHANG.GioiTinh, KHACHHANG.NgaySinh,KHACHHANG.CCCD,KHACHHANG.DiaChi,KHACHHANG.NgayNhanPhong,PHONG.SoPhong,PHONG.LoaiPhong,PHONG.LoaiGiuong,PHONG.GiaMoiDem from KHACHHANG inner join PHONG on KHACHHANG.MaPhong=PHONG.MaPhong where KHACHHANG.Checkout = 'true'";
                GetRecord(query);
                addDichVu.Visible = false;
            }
        }

        private void GetRecord(string query) //lay data de hien thi
        {
            DataSet ds = fn.GetData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void btnRegistation_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.CurrentRow != null)
            {
                DataGridViewRow row = guna2DataGridView1.CurrentRow;

                // Lấy dữ liệu từ DataGridView
                string name = row.Cells["HoTen"].Value.ToString();
                string phone = row.Cells["SoDienThoai"].Value.ToString();
                string nationality = row.Cells["QuocTich"].Value.ToString();
                string gender = row.Cells["GioiTinh"].Value.ToString();
                string id = row.Cells["CCCD"].Value.ToString();
                string address = row.Cells["DiaChi"].Value.ToString();
                DateTime birthDate = DateTime.Parse(row.Cells["NgaySinh"].Value.ToString());
                string code = row.Cells["MaKhachHang"].Value.ToString();

                // Mở Form2 và truyền dữ liệu
                Sua editForm = new Sua(name, phone, nationality, gender, id, address, birthDate,code);
                editForm.ShowDialog();
                LoadAgain();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khách hàng!","Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void addDichVu_Click(object sender, EventArgs e)
        {
            if (maKH == 0)
                MessageBox.Show("Vui lòng chọn khách hàng!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                ThemDichVu themDichVu = new ThemDichVu(maKH);
                themDichVu.ShowDialog();
            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value != null)
            {
                // Lấy giá trị từ DataGridView
                maKH = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

            }
        }
    }
}
