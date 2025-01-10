using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheArtOfDevHtmlRenderer.Adapters;

namespace QuanLyKhachSan
{
    public partial class XuatHoaDon : Form
    {
        String maKH, tenKH, soPhong,maHD,soDV;
        int soNgayO;
        DateTime ngayNhanPhong, ngayTraPhong;
        float giaMoiDem;
        Function fn = new Function();
        float tienDV,tienPhong,tongTien;

        public XuatHoaDon(string _maKH, string _tenKH, TimeSpan _soNgayO, string _soPhong, DateTime _ngayNhanPhong, DateTime _ngayTraPhong,float _giaMoiDem)
        {
            InitializeComponent();
            maKH = _maKH;
            tenKH = _tenKH;
            soPhong = _soPhong;
            soNgayO = _soNgayO.Days;
            ngayTraPhong = _ngayTraPhong;
            ngayNhanPhong = _ngayNhanPhong;
            giaMoiDem = _giaMoiDem; 
            string query = "Select max(MaHoaDon) from HoaDon";
            DataSet ds = fn.GetData(query);
            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                int x = int.Parse(ds.Tables[0].Rows[0][0].ToString()) + 1;
                maHD = x.ToString();
            }

            label2.Text += " " + maHD;
            label10.Text += " " + soPhong;
            label4.Text += " " + tenKH;
            label6.Text += " " + giaMoiDem.ToString("N2");
            label8.Text += " " + ngayNhanPhong.ToString("dd/MM/yyyy");
            label5.Text += " " + ngayTraPhong.ToString("dd/MM/yyyy");
            label7.Text += " " + soNgayO.ToString();
            query = "SELECT DV.TenDichVu,  DV.GiaDichVu, DVKH.SoLuong FROM DICHVU_KHACHHANG DVKH INNER JOIN DICHVU DV ON DVKH.MaDichVu = DV.MaDichVu WHERE DVKH.MaKhachHang = '" + maKH+ "'";
            ds = fn.GetData(query);
            DataGridView1.DataSource = ds.Tables[0];

            query = "SELECT COUNT(*) FROM DICHVU_KHACHHANG DVKH INNER JOIN DICHVU DV ON DVKH.MaDichVu = DV.MaDichVu WHERE DVKH.MaKhachHang = '" + maKH + "'";
            ds = fn.GetData(query);
            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                soDV = ds.Tables[0].Rows[0][0].ToString();
            }
            label9.Text += " " + soDV;


            //tinh tien
            query = "Select sum(GiaDichVu) FROM DICHVU_KHACHHANG DVKH INNER JOIN DICHVU DV ON DVKH.MaDichVu = DV.MaDichVu WHERE DVKH.MaKhachHang = '" + maKH + "'";
            ds = fn.GetData(query);
            tienPhong = giaMoiDem * soNgayO;

            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                tienDV = float.Parse(ds.Tables[0].Rows[0][0].ToString());
            }
            tongTien = tienPhong + tienDV;
            label11.Text += " " + tienPhong.ToString("N2");
            label12.Text += " " + tienDV.ToString("N2");
            label13.Text += " " + tongTien.ToString("N2");
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
        private void xtButton_Click(object sender, EventArgs e)
        {
            String query = "UPDATE KHACHHANG SET Checkout = 'true' WHERE MaKhachHang = " + maKH + ";" +
                           "UPDATE PHONG SET TinhTrang = 'Trong' WHERE SoPhong = '" + soPhong + "';" +
                           "INSERT INTO HOADON(MAKHACHHANG,NGAYTHANHTOAN,TONGTIEN) VALUES ('" + maKH + " ','" + ngayTraPhong + " ', " + tongTien + ")";
            fn.SetData(query, "Thanh Toán Thành Công");
            this.Close();
        }
    }
}
