using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyKhachSan
{
    public partial class ThongKe : Form
    {
        Function fn = new Function();
        String query;
        public ThongKe()
        {
            InitializeComponent();

        }

        private void ThongKe_Load(object sender, EventArgs e)
        {
            LoadYears();
           
            /*DataSet ds = new DataSet(); 
            query = "SELECT MONTH(Ngaythanhtoan) AS Thang,SUM(TongTien) AS TongTien FROM  HOADON GROUP BY MONTH(Ngaythanhtoan) ORDER BY Thang;";
            ds = fn.GetDataChart(query);

            chart1.Series.Clear();
            Series series = new Series("Doanh thu theo tháng")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.SlateGray,
               
            };
            series["PointWidth"] = "1";
            if (ds.Tables.Contains("DoanhThuTheoThang") && ds.Tables["DoanhThuTheoThang"].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables["DoanhThuTheoThang"].Rows)
                {
                    series.Points.AddXY(row["Thang"], row["TongTien"]);
                }
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để hiển thị!");
            }

            chart1.Series.Add(series);
            //chart1.ChartAreas[0].AxisX.Interval = 1; // Hiển thị tất cả các tháng
            chart1.ChartAreas[0].AxisX.Title = "Tháng";
            chart1.ChartAreas[0].AxisY.Title = "Doanh Thu (VNĐ)";

            */

            //KHACHHANG
            query = "SELECT 'Tong khách hàng' AS Loai, COUNT(*) AS SoLuong FROM KHACHHANG UNION ALL SELECT  'Đã checkout' AS Loai, COUNT(*) AS SoLuong FROM KHACHHANG WHERE Checkout = 'true' UNION ALL SELECT 'Chưa checkout' AS Loai, COUNT(*) AS SoLuong FROM KHACHHANG WHERE Checkout = 'false';";

            DataSet ds = fn.GetData(query);

            chart2.Series.Clear();
            Series series2 = new Series("Tình trạng khách hàng")
            {
                ChartType = SeriesChartType.Bar, // Biểu đồ dạng cột ngang
                IsValueShownAsLabel = true,
                Color = Color.SlateGray// Hiển thị số lượng trên cột
            };
            series2["PointWidth"] = "0.5";
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    series2.Points.AddXY(row["Loai"], row["SoLuong"]);
                }
            }

            chart2.Series.Add(series2);

            // Cấu hình ChartArea (Giao diện biểu đồ)
            chart2.ChartAreas[0].AxisX.Title = "Loại khách hàng";
            chart2.ChartAreas[0].AxisY.Title = "Số lượng";
            chart2.Series[0].Font = new Font("Arial", 12, FontStyle.Regular); // Font hỗ trợ Tiếng Việt
            chart2.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 10, FontStyle.Regular); // Font cho trục X
            chart2.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Arial", 10, FontStyle.Regular); // Font cho trục Y


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void LoadYears()
        {
            string query = "SELECT DISTINCT YEAR(Ngaythanhtoan) AS Nam FROM HOADON ORDER BY Nam";

            DataSet ds = fn.GetData(query);

            if (ds.Tables[0].Rows.Count > 0)
            {
                cbYear.Items.Clear();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    cbYear.Items.Add(row["Nam"]);
                }

                // Chọn năm đầu tiên trong danh sách mặc định
                cbYear.SelectedIndex = 0;
            }
        }

        private void cbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbYear.SelectedItem == null)
            {
                return;
            }

            // Lấy năm được chọn từ ComboBox
            int selectedYear = int.Parse(cbYear.SelectedItem.ToString());

            DataSet ds = new DataSet();
            query = "SELECT MONTH(Ngaythanhtoan) AS Thang,SUM(TongTien) AS TongTien FROM  HOADON WHERE YEAR(Ngaythanhtoan) = '"+ selectedYear+"' GROUP BY MONTH(Ngaythanhtoan) ORDER BY Thang;";
            ds = fn.GetDataChart(query);

            chart1.Series.Clear();
            Series series = new Series("Doanh thu theo tháng")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.SlateGray,

            };
            series["PointWidth"] = "1";
            decimal[] doanhThuTheoThang = new decimal[12];

            if (ds.Tables.Contains("DoanhThuTheoThang") && ds.Tables["DoanhThuTheoThang"].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables["DoanhThuTheoThang"].Rows)
                {
                    int thang = Convert.ToInt32(row["Thang"]);
                    doanhThuTheoThang[thang - 1] = Convert.ToDecimal(row["TongTien"]);
                }
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để hiển thị!");
            }

            // Thêm tất cả 12 tháng vào biểu đồ, nếu không có dữ liệu cho tháng nào, giá trị sẽ là 0
            for (int i = 0; i < 12; i++)
            {
                series.Points.AddXY(i + 1, doanhThuTheoThang[i]);
            }

            chart1.Series.Add(series);
            chart1.ChartAreas[0].AxisX.Title = "Tháng";
            chart1.ChartAreas[0].AxisY.Title = "Doanh Thu (VNĐ)";
            chart1.ChartAreas[0].AxisX.Interval = 1; // Hiển thị tất cả các tháng

            decimal maxTongTien = doanhThuTheoThang.Max();
            chart1.ChartAreas[0].AxisY.Maximum = (double)(maxTongTien * 1.2M); // Ép kiểu decimal sang double
            chart1.ChartAreas[0].AxisY.LabelStyle.Format = "N2";
            chart1.ChartAreas[0].AxisY.Minimum = 0; // Đảm bảo giá trị không âm
        }
    }
}
