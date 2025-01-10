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
    public partial class ThemDichVu : Form
    {
        int maKH;
        Function fn = new Function();
        List<int> list;
        public ThemDichVu(int _maKH)
        {
            InitializeComponent();
            maKH = _maKH;
            label1.Text = $"Mã khách hàng đã chọn để thêm dịch vụ: {maKH}";
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            list = new List<int>(); 
            if (guna2CheckBox1.Checked)
            {
                list.Add(1);
            }
            if (guna2CheckBox2.Checked)
            {
                list.Add(2);
            }
            if (guna2CheckBox3.Checked)
            {
                list.Add(3);
            }
            if (guna2CheckBox4.Checked)
            {
                list.Add(4);
            }
            if (guna2CheckBox5.Checked)
            {
                list.Add(5);
            }
            if (guna2CheckBox6.Checked)
            {
                list.Add(6);
            }
            if (guna2CheckBox7.Checked)
            {
                list.Add(7);
            }
            if (list.Count == 0)
                MessageBox.Show("Vui lòng chọn ít nhất 1 dịch vụ", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                for (int i = 0; i < list.Count; i++)
                {
                    int maDV = list[i];
                    string query = "INSERT INTO DICHVU_KHACHHANG (MaKhachHang, MaDichVu, SoLuong) " +
                    "VALUES ('" + maKH + "', '" + maDV + "', '1')";
                    fn.SetData(query);
                }
                MessageBox.Show("Thêm dịch vụ thành công!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void ThemDichVu_Load(object sender, EventArgs e)
        {

        }
    }
}
