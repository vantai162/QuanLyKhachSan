using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;
namespace QuanLyKhachSan.General
{
    public partial class UC_AddRoom : UserControl
    {
        Function fn = new Function();
        String query;
       
        public UC_AddRoom()
        {
            InitializeComponent();
        }

        private void UC_AddRoom_Load(object sender, EventArgs e)
        {
            query = "Select MaPhong,SoPhong,LoaiPhong,LoaiGiuong,GiaMoiDem,TinhTrang from PHONG";
            DataSet ds = fn.GetData(query);
            DataGridView1.DataSource = ds.Tables[0];
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            if (txtRoomNo.Text != "" && txtRoomType.Text != "" && txtBed.Text != "" && txtPrice.Text != "")
            {
                String roomno = txtRoomNo.Text;
                String type=txtRoomType.Text;
                String bed=txtBed.Text;
                Int64 price =Int64.Parse(txtPrice.Text);
                //String descript = txtDescript.Text; 
                query="Insert Into PHONG(SoPhong,LoaiPhong,LoaiGiuong,GiaMoiDem,TinhTrang) values ('"+ roomno + "','" + type +"','"+ bed+"'" +
                        ",'"+price+"','Trong')";
                fn.SetData(query, "Đã Thêm Phòng");
                UC_AddRoom_Load(this,null);
                ClearALl();
            }   
            else
            {
                MessageBox.Show("Thông tin không hợp lệ!","Lỗi!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }    
        }
        public void ClearALl() //don du lieu cua text box sau khi bam add room
        {
            txtRoomNo.Clear();
            txtRoomType.SelectedIndex=-1;
            txtBed.SelectedIndex=-1;
            txtPrice.Clear();
            txtDescript.Clear();
        }

        private void UC_AddRoom_Leave(object sender, EventArgs e)
        {
            ClearALl();
        }

        private void UC_AddRoom_Enter(object sender, EventArgs e)
        {
            UC_AddRoom_Load(this,null);
        }

        private void txtRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtRoomType.SelectedIndex == 0)
            {
                txtDescript.Text = "Phòng thường khá nhỏ, được bố trí ở các tầng thấp, không có view đẹp và chỉ gồm những vật dụng cơ bản nhất.";
            }
            else if (txtRoomType.SelectedIndex == 1)
            {
                txtDescript.Text = "Loại phòng khách sạn này tương đối chất lượng hơn phòng Standard, diện tích phòng được tăng thêm, có view nhìn và cách bày trí đẹp mắt hơn hẳn " +
                    "và thường nằm ở những tầng gần giữa của tòa nhà.";
            }
            else if (txtRoomType.SelectedIndex == 2)
            {
                txtDescript.Text = "Loại phòng khách sạn này nằm ở các tầng giữa trở lên nên sở hữu view nhìn ra quang cảnh bên ngoài khá đẹp. " +
                    "Ở vị trí này, chất lượng phòng được nâng lên mức cao cấp với các tiện nghi hiện đại và tốt nhất.";
            }
            else if (txtRoomType.SelectedIndex == 3)    
            {
                txtDescript.Text = "Đây là loại phòng cao cấp nhất trong tất cả các loại phòng khách sạn, thông thường được bố trí ở các tầng cao nhất.";
            }
        }
    }
}
