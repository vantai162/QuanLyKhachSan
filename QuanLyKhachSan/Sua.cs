using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class Sua : Form
    {
        Function fn = new Function();
        string query;
        string maKH;
        public Sua(string name, string phone, string nationality, string gender, string id, string address, DateTime birthDate,string ma)
        {
            InitializeComponent();
            txtName.Text = name;
            txtContact.Text = phone;
            txtNationality.Text = nationality;
            txtGender.Text = gender;
            txtIDProof.Text = id;
            txtAddress.Text = address;
            txtDob.Value = birthDate;
            maKH = ma;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string mobile = txtContact.Text;
            string nation = txtNationality.Text;
            string gender = txtGender.Text;
            string dob = txtDob.Text;
            string cccd = txtIDProof.Text;
            string address = txtAddress.Text;
            query = "UPDATE KHACHHANG SET " +
            "HoTen = N'" + name + "', " +
            "SoDienThoai = '" + mobile + "', " +
            "QuocTich = N'" + nation + "', " +
            "GioiTinh = N'" + gender + "', " +
            "NgaySinh = '" + dob + "', " +
            "CCCD = '" + cccd + "', " +
            "DiaChi = N'" + address + "' " +
            "WHERE MaKhachHang = '"+ maKH +"'";

            fn.SetData(query, "Sua thanh cong");
            this.Close();
        }

       
    }
}
