using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CAFE.CLass;
using Microsoft.Reporting.WinForms;
using CAFE.QLCafeDataSetTableAdapters;
using System.Reflection;
using System.Runtime.ExceptionServices;

namespace CAFE
{
    public partial class Baocao : Form
    {
        public Baocao()
        {
            InitializeComponent();
        }

        private void Baocao_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLCafeDataSet.BCNhap' table. You can move, or remove it, as needed.
            this.bCNhapTableAdapter.Fill(this.qLCafeDataSet.BCNhap);
            // TODO: This line of code loads data into the 'qLCafeDataSet.BCBan' table. You can move, or remove it, as needed.
            this.bCBanTableAdapter.Fill(this.qLCafeDataSet.BCBan);
            this.BaocaoNhap.Visible = false;
            this.BaocaoBan.Visible = false;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        private void load_sellReport(DateTime startDate, DateTime endDate)
        {
            QLCafeDataSet ds = new QLCafeDataSet();
            string query;
            //trường hợp chỉ muốn truy vấn hoá đơn trong 1 ngày
            if (startDate.Date == endDate.Date)
            {
                query = @"SELECT HoaDon.MaHoaDon, HoaDon.NgayBan, HoaDon.TongTien, ChiTietHDB.MaSanPham, ChiTietHDB.ThanhTien, ChiTietHDB.SoLuong, ChiTietHDB.KhuyenMai
                  FROM ChiTietHDB 
                  INNER JOIN HoaDon ON ChiTietHDB.MaHoaDon = HoaDon.MaHoaDon
                  WHERE CAST(HoaDon.NgayBan AS DATE) = @Date";
            } else
            {
                query = @"SELECT HoaDon.MaHoaDon, HoaDon.NgayBan, HoaDon.TongTien, ChiTietHDB.MaSanPham, ChiTietHDB.ThanhTien, ChiTietHDB.SoLuong, ChiTietHDB.KhuyenMai
                    FROM ChiTietHDB 
                    INNER JOIN HoaDon ON ChiTietHDB.MaHoaDon = HoaDon.MaHoaDon
                    WHERE HoaDon.NgayBan >= @StartDate AND HoaDon.NgayBan <= @EndDate";
            }
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, Functions.conn);
            if (startDate.Date == endDate.Date)
            {
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@Date", startDate.Date);
            }
            else
            {
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@StartDate", startDate.Date);
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@EndDate", endDate.Date.AddDays(1).AddTicks(-1)); // Đặt thời gian kết thúc vào cuối ngày
            }
            sqlDataAdapter.Fill(ds, "BCBan");

            ReportDataSource reportDataSource = new ReportDataSource("BCBan", ds.Tables["BCBan"]);
            this.BaocaoBan.LocalReport.DataSources.Clear();
            this.BaocaoBan.LocalReport.DataSources.Add(reportDataSource);
            this.BaocaoBan.LocalReport.Refresh();
            this.BaocaoBan.RefreshReport();
        }

        private void load_importReport(DateTime startDate, DateTime endDate)
        {
            QLCafeDataSet ds = new QLCafeDataSet();
            string query;
            //trường hợp chỉ muốn truy vấn hoá đơn trong 1 ngày
            if (startDate.Date == endDate.Date)
            {
                query = @"SELECT ChiTietHDN.MaDonNhap, ChiTietHDN.MaSanPham, ChiTietHDN.SoLuong, ChiTietHDN.DonGia, ChiTietHDN.KhuyenMai, ChiTietHDN.ThanhTien, HoaDonNhap.MaNhanVien, HoaDonNhap.MaNhaCungCap, 
                         HoaDonNhap.NgayNhap, HoaDonNhap.TongTien FROM HoaDonNhap INNER JOIN
                         ChiTietHDN ON HoaDonNhap.MaDonNhap = ChiTietHDN.MaDonNhap
                         WHERE CAST(HoaDonNhap.NgayNhap AS DATE) = @Date";
            }
            else
            {
                query = @"SELECT ChiTietHDN.MaDonNhap, ChiTietHDN.MaSanPham, ChiTietHDN.SoLuong, ChiTietHDN.DonGia, ChiTietHDN.KhuyenMai, ChiTietHDN.ThanhTien, HoaDonNhap.MaNhanVien, HoaDonNhap.MaNhaCungCap, 
                         HoaDonNhap.NgayNhap, HoaDonNhap.TongTien FROM HoaDonNhap INNER JOIN
                         ChiTietHDN ON HoaDonNhap.MaDonNhap = ChiTietHDN.MaDonNhap
                         WHERE HoaDonNhap.NgayNhap >= @StartDate AND HoaDonNhap.NgayNhap <= @EndDate";
            }
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, Functions.conn);
            if (startDate.Date == endDate.Date)
            {
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@Date", startDate.Date);
            }
            else
            {
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@StartDate", startDate.Date);
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@EndDate", endDate.Date.AddDays(1).AddTicks(-1)); // Đặt thời gian kết thúc vào cuối ngày
            }
            sqlDataAdapter.Fill(ds, "BCNhap");
            ReportDataSource reportDataSource = new ReportDataSource("BCNhap", ds.Tables["BCNhap"]);
            this.BaocaoNhap.LocalReport.DataSources.Clear();
            this.BaocaoNhap.LocalReport.DataSources.Add(reportDataSource);
            this.BaocaoNhap.LocalReport.Refresh();
            this.BaocaoNhap.RefreshReport();

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            QLCafeDataSet ds = new QLCafeDataSet();
            string query = @"SELECT HoaDon.MaHoaDon, HoaDon.NgayBan, HoaDon.TongTien, ChiTietHDB.MaSanPham, ChiTietHDB.ThanhTien, ChiTietHDB.SoLuong, ChiTietHDB.KhuyenMai, HoaDon.MaNhanVien
                            FROM ChiTietHDB INNER JOIN
                         HoaDon ON ChiTietHDB.MaHoaDon = HoaDon.MaHoaDon";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, Functions.conn);
            sqlDataAdapter.Fill(ds, ds.Tables[0].TableName);
            ReportDataSource reportDataSource = new ReportDataSource("BCBan", ds.Tables[0]);
            this.BaocaoBan.LocalReport.DataSources.Clear();
            this.BaocaoBan.LocalReport.DataSources.Add(reportDataSource);
            ReportParameter startDate = new ReportParameter("startDate", dateTimePicker1.Value.ToString("dd/MM/yyyy"));
            this.BaocaoBan.LocalReport.SetParameters(startDate);
            ReportParameter endDate = new ReportParameter("endDate", dateTimePicker2.Value.ToString("dd/MM/yyyy"));
            this.BaocaoBan.LocalReport.SetParameters(endDate);
            if (dateTimePicker1.Value.Date == dateTimePicker2.Value.Date)
            {
                ReportParameter title = new ReportParameter("title", "Báo cáo Doanh thu bán ngày " + dateTimePicker1.Value.ToString("dd/MM/yyyy"));
                ReportParameter chart_title = new ReportParameter("chart_title", "Thống kê sản phẩm bán ngày " + dateTimePicker1.Value.ToString("dd/MM/yyyy"));
                this.BaocaoBan.LocalReport.SetParameters(title);
            }
            else
            {
                ReportParameter title = new ReportParameter("title", "Báo cáo Doanh thu bán từ ngày " + dateTimePicker1.Value.ToString("dd/MM/yyyy") + " đến ngày " + dateTimePicker2.Value.ToString("dd/MM/yyyy"));
                ReportParameter chart_title = new ReportParameter("chart_title", "Thống kê sản phẩm bán từ ngày " + dateTimePicker1.Value.ToString("dd/MM/yyyy") + " đến ngày " + dateTimePicker2.Value.ToString("dd/MM/yyyy"));
                this.BaocaoBan.LocalReport.SetParameters(title);
            }
            
            this.BaocaoBan.LocalReport.Refresh();
            this.BaocaoBan.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            DateTime startDate = dateTimePicker1.Value;
            DateTime endDate = dateTimePicker2.Value;
            this.BaocaoBan.Visible = true;
            load_sellReport(startDate, endDate);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePicker3.Value;
            DateTime endDate = dateTimePicker4.Value;
            this.BaocaoNhap.Visible = true;
            load_importReport(startDate, endDate);
        }

        private void BaocaoNhap_Load(object sender, EventArgs e)
        {
            QLCafeDataSet ds = new QLCafeDataSet();
            string query = @"SELECT ChiTietHDN.MaDonNhap, ChiTietHDN.MaSanPham, ChiTietHDN.SoLuong, ChiTietHDN.DonGia, ChiTietHDN.KhuyenMai, ChiTietHDN.ThanhTien, HoaDonNhap.MaNhanVien, HoaDonNhap.MaNhaCungCap, 
                         HoaDonNhap.NgayNhap, HoaDonNhap.TongTien FROM HoaDonNhap INNER JOIN
                         ChiTietHDN ON HoaDonNhap.MaDonNhap = ChiTietHDN.MaDonNhap";

            //thêm dataset cho bảng
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, Functions.conn);
            sqlDataAdapter.Fill(ds, ds.Tables[0].TableName);
            ReportDataSource reportDataSource = new ReportDataSource("BCNhap", ds.Tables[0]);
            this.BaocaoNhap.LocalReport.DataSources.Add(reportDataSource);
            this.BaocaoNhap.LocalReport.DataSources.Clear();
            
            ReportParameter startDate = new ReportParameter("startDate", dateTimePicker3.Value.ToString("dd/MM/yyyy"));
            this.BaocaoNhap.LocalReport.SetParameters(startDate);
            ReportParameter endDate = new ReportParameter("endDate", dateTimePicker4.Value.ToString("dd/MM/yyyy"));
            this.BaocaoNhap.LocalReport.SetParameters(endDate);
            if(dateTimePicker3.Value.Date == dateTimePicker4.Value.Date)
            {
                ReportParameter title = new ReportParameter("title", "Báo cáo Chi phí nhập Nhập ngày " + dateTimePicker3.Value.ToString("dd/MM/yyyy"));
                ReportParameter chart_title = new ReportParameter("chart_title", "Thống kê sản phẩm nhập Nhập ngày " + dateTimePicker3.Value.ToString("dd/MM/yyyy"));
                this.BaocaoNhap.LocalReport.SetParameters(title);
            } else
            {
                ReportParameter title = new ReportParameter("title", "Báo cáo Chi phí nhập Nhập từ ngày " + dateTimePicker3.Value.ToString("dd/MM/yyyy") + " đến ngày " + dateTimePicker4.Value.ToString("dd/MM/yyyy"));
                ReportParameter chart_title = new ReportParameter("chart_title", "Thống kê sản phẩm nhập Nhập từ ngày " + dateTimePicker3.Value.ToString("dd/MM/yyyy") + " đến ngày " + dateTimePicker4.Value.ToString("dd/MM/yyyy"));
                this.BaocaoNhap.LocalReport.SetParameters(title);
            }
            this.BaocaoNhap.LocalReport.Refresh();
            this.BaocaoBan.RefreshReport();
        }
    }
}
