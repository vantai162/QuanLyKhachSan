using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;


namespace QuanLyKhachSan.General
{
    public partial class UC_CustomerRes : UserControl
    {
        Function fn = new Function();
        String query;
        int rid;
        public UC_CustomerRes()
        {
            InitializeComponent();
        }

        public void setComboBox(String query,ComboBox combo)
        {
            SqlDataReader sdr = fn.GetForComBo(query);
            while (sdr.Read())
            {
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    combo.Items.Add(sdr.GetString(i));
                }
                   
            }
            sdr.Close();
        }

        private void UC_CustomerRes_Load(object sender, EventArgs e)
        {

        }

        private void txtBed_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRoomType.SelectedIndex = -1;
            txtRoomNo.Items.Clear();
            txtPrice.Clear();
        }

        private void txtRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Khi loai phong thay doi thi gia tri du lieu cua so phong xuat hien
            txtRoomNo.Items.Clear();
            query = "Select SoPhong FROM PHONG WHERE LoaiGiuong = '" + txtBed.Text + "' and LoaiPhong = '" + txtRoomType.Text + "' " +
                "and TinhTrang = 'Trong'"; //Lay du lieu so phong
            setComboBox(query, txtRoomNo);
        }

        private void txtRoomNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Khi so phong doi thi gia tri du lieu cua gia tien xuat hien
            query = "SELECT GiaMoiDem, MaPhong FROM PHONG WHERE SoPhong = '" + txtRoomNo.Text + "'"; //Lay du lieu gia tien
            DataSet ds = fn.GetData(query);
            txtPrice.Text = ds.Tables[0].Rows[0][0].ToString();
            rid = int.Parse(ds.Tables[0].Rows[0][1].ToString());
        }

        private void btnAllotCustomer_Click(object sender, EventArgs e)
        {
            //ktra dieu kien nhap day du cac o trong
            if (txtName.Text != "" && txtGender.Text != "" && txtContact.Text != "" && txtNationality.Text != "" && txtDob.Text != "" &&
                txtAddress.Text != "" && txtIDProof.Text != "" && txtCheckIn.Text != "" && txtPrice.Text != "")
            {
                //Tao cac bien trung gian
                string name = txtName.Text;
                string mobile = txtContact.Text;
                string nation = txtNationality.Text;
                string gender = txtGender.Text;
                string dob = txtDob.Text;
                string cccd = txtIDProof.Text;
                string address = txtAddress.Text;
                string checkin = txtCheckIn.Text;

                //them thong tin vao bang khach hang da dat phong tuong ung
                query = "INSERT INTO KHACHHANG (HoTen, SoDienThoai, CCCD, GioiTinh, QuocTich, DiaChi, NgaySinh, NgayNhanPhong,MaPhong) " +
                        "VALUES ('" + name + "', '" + mobile + "', '" + cccd + "', '" + gender + "', '" + nation + "', '" + address + "', '" + dob + "', '" + checkin + "','"+rid+"') UPDATE PHONG SET TinhTrang = 'Da Dat' " +
                        "WHERE SoPhong = '"+txtRoomNo.Text+"' ";
                fn.SetData(query, $"Số phòng {txtRoomNo.Text}: Đăng ký khách hàng thành công!");
                ClearAll();
                
            }
            else
            {
                MessageBox.Show("Xin vui lòng nhập đầy đủ thông tin!","Thông báo!", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        public void ClearAll()
        {
            txtName.Clear();
            txtContact.Clear();
            txtNationality.Clear();
            txtAddress.Clear();
            txtIDProof.Clear();
            txtGender.SelectedIndex = -1;
            txtRoomNo.Items.Clear();
            txtDob.ResetText();
            txtCheckIn.ResetText();
            txtRoomType.SelectedIndex = -1;
            txtBed.SelectedIndex = -1;
            txtPrice.Clear();
        }

        private void UC_CustomerRes_Leave(object sender, EventArgs e)
        {
            ClearAll();
        }
    }
}
