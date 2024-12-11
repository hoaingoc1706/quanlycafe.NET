using CAFE.CLass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAFE
{
    public partial class Timkiem : Form
    {
        public Timkiem()
        {
            InitializeComponent();
            this.Load += new EventHandler(Timkiem_Load);
            toolTip = new ToolTip();
        }
        private void Timkiem_Load(object sender, EventArgs e)
        {
            CLass.Functions.connect();
            CLass.Functions.FillCombo("select MaLoai, TenLoai from Loai", cboMaloai, "MaLoai", "TenLoai");
            cboMaloai.SelectedIndex = -1;
            CLass.Functions.FillCombo("select MaCongDung, TenCongDung from CongDung", cboMacongdung, "MaCongDung", "TenCongDung");
            cboMaloai.SelectedIndex = -1;
            txtSoluong.Enabled = false;
            ResetValues();
            dgridSanpham.DataSource = null;
            /*Load_dgridSanpham();*/
            //// Gắn các hàm xử lý sự kiện cho ToolStripMenuItem
            tabPage1.Click += tabPage1_Click;
            tabPage3.Click += tabPage3_Click;
            tabPage2.Click += tabPage2_Click;
            cboMaloai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMacongdung.DropDownStyle = ComboBoxStyle.DropDownList;
            // Tạo một đối tượng ToolTip
            ToolTip toolTip = new ToolTip();

            // Đặt nội dung tooltip cho các ComboBox
            toolTip1.SetToolTip(cboMaloai, "Hãy chọn trong danh sách");
            toolTip2.SetToolTip(cboMacongdung, "Hãy chọn trong danh sách");

        }
        private void dgridSanpham_Click(object sender, EventArgs e)
        {
            if (dgridSanpham.CurrentRow != null)
            {
                txtMasanpham.Text = dgridSanpham.CurrentRow.Cells["maSanPham"]?.Value.ToString();
                txtTensanpham.Text = dgridSanpham.CurrentRow.Cells["tenSanPham"]?.Value.ToString();
                string maLoai = dgridSanpham.CurrentRow.Cells["maLoai"]?.Value?.ToString();
                if (!string.IsNullOrEmpty(maLoai))
                {
                    cboMaloai.Text = CLass.Functions.GetFieldValues("select TenLoai from Loai where MaLoai=N'" + maLoai + "'");
                }

                txtSoluong.Text = dgridSanpham.CurrentRow.Cells["soLuong"]?.Value.ToString();
                string maCongDung = dgridSanpham.CurrentRow.Cells["soluong"]?.Value?.ToString();
                if (!string.IsNullOrEmpty(maCongDung))
                {
                    cboMacongdung.Text = CLass.Functions.GetFieldValues("select TenCongDung from CongDung where MaCongDung=N'" + maCongDung + "'");
                }
            }
            string imagePath = Functions.GetFieldValues($"select HinhAnh from SanPham where MaSanPham=N'{txtMasanpham.Text}'");
            txtAnh.Text = imagePath;

            if (!string.IsNullOrEmpty(imagePath))
            {
                try
                {
                    picAnh.SizeMode = PictureBoxSizeMode.Zoom;
                    picAnh.Image = Image.FromFile(imagePath);
                }
                catch
                {
                    picAnh.Image = null;
                    MessageBox.Show("Không thể tải ảnh từ đường dẫn được cung cấp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                picAnh.Image = null;
            }
        }
        private void ResetValues()
        {
            txtMasanpham.Text = "";
            txtTensanpham.Text = "";
            txtSoluong.Text = "";
            cboMaloai.SelectedIndex = -1;
            cboMacongdung.SelectedIndex = -1;
            txtAnh.Text = "";
            picAnh.Image = null;
            txtMasanpham.Focus();

            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtDiachi.Text = "";
            mskSDT.Text = "";
            txtMaKH.Focus();

            txtMahoadonnhap.Text = "";
            txtManhanvien.Text = "";
            txtManhacungcap.Text = "";
            txtNgay.Text = "";
            txtThang.Text = "";
            txtNam.Text = "";
            txtMahoadonnhap.Focus();

            txtMaHDB.Text = "";
            txtMaKHB.Text = "";
            txtMaNV.Text = "";
            txtNgayb.Text = "";
            txtThangb.Text = "";
            txtNamb.Text = "";
            txtTongtien.Text = "";
            txtMaHDB.Focus();

        }
        private DataTable Sanpham;
        private void btnTimkiem1_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtMasanpham.Text == "") && (txtTensanpham.Text == "") && (cboMaloai.Text == "") && (cboMacongdung.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM SanPham WHERE 1=1";
            if (txtMasanpham.Text != "")
                sql = sql + " AND MaSanPham Like N'%" + txtMasanpham.Text + "%'";
            if (txtTensanpham.Text != "")
                sql = sql + " AND TenSanPham Like N'%" + txtTensanpham.Text + "%'";
            if (cboMaloai.Text != "")
                sql = sql + " AND MaLoai Like N'%" + cboMaloai.SelectedValue + "%'";
            if (cboMacongdung.Text != "")
                sql = sql + " AND MaCongDung Like N'%" + cboMacongdung.SelectedValue + "%'";
            Sanpham = Functions.GetDataToTable(sql);
            if (Sanpham.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Có " + Sanpham.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dgridSanpham.DataSource = Sanpham;
            txtSoluong.Enabled = false;
            ResetValues();
        }
        DataTable QLCafe;
        private void Load_dgridSanpham()
        {
            string sql;
            sql = "select * from SanPham WHERE 1=1 ";
            QLCafe = CLass.Functions.GetDataToTable(sql);
            dgridSanpham.DataSource = QLCafe;
            dgridSanpham.Columns[0].HeaderText = "Mã sản phẩm";
            dgridSanpham.Columns[1].HeaderText = "Tên sản phẩm";
            dgridSanpham.Columns[2].HeaderText = "Mã loại";
            dgridSanpham.Columns[3].HeaderText = "Số lượng";
            dgridSanpham.AllowUserToAddRows = false;
            dgridSanpham.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnTimlai1_Click(object sender, EventArgs e)
        {
            ResetValues();
            dgridSanpham.DataSource = null;
        }

        private void btnDong1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        DataTable HDN;
        private void btnTimkiem3_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtMahoadonnhap.Text == "") && (txtNgay.Text == "") && (txtThang.Text == "") && (txtNam.Text == "") &&
               (txtManhanvien.Text == "") && (txtManhacungcap.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yeu cau ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM HoaDonNhap WHERE 1=1";
            if (txtMahoadonnhap.Text != "")
                sql = sql + " AND MaDonNhap Like N'%" + txtMahoadonnhap.Text + "%'";
            if (txtNgay.Text != "")
                sql = sql + " AND DAY(NgayNhap) =" + txtNgay.Text;
            if (txtThang.Text != "")
                sql = sql + " AND MONTH(NgayNhap) =" + txtThang.Text;
            if (txtNam.Text != "")
                sql = sql + " AND YEAR(NgayNhap) =" + txtNam.Text;
            if (txtManhanvien.Text != "")
                sql = sql + " AND MaNhanVien Like N'%" + txtManhanvien.Text + "%'";
            if (txtManhacungcap.Text != "")
                sql = sql + " AND MaNhaCungCap Like N'%" + txtManhacungcap.Text + "%'";
            if (txtNgay.Text != "" && (txtThang.Text == "" || txtNam.Text == ""))
            {
                MessageBox.Show("Phải nhập cả Tháng và Năm khi đã nhập Ngày", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtThang.Focus();
                return;
            }
            int ngay, thang, nam;
            if (txtNgay.Text != "" && (!int.TryParse(txtNgay.Text, out ngay) || ngay < 1 || ngay > 31))
            {
                MessageBox.Show("Ngày phải là số và nằm trong khoảng từ 1 đến 31", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNgay.Focus();
                return;
            }
            if (txtThang.Text != "" && (!int.TryParse(txtThang.Text, out thang) || thang < 1 || thang > 12))
            {
                MessageBox.Show("Tháng phải là số và nằm trong khoảng từ 1 đến 12", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtThang.Focus();
                return;
            }
            if (txtNam.Text != "" && (!int.TryParse(txtNam.Text, out nam) || txtNam.Text.Length != 4))
            {
                MessageBox.Show("Năm phải là số và có 4 chữ số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNam.Focus();
                return;
            }
            HDN = Functions.GetDataToTable(sql);
            if (HDN.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetValues();
            }
            else
                MessageBox.Show("Có " + HDN.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dgridTimhoadonnhap.DataSource = HDN;
            Load_DataGridView();
        }
        private void txtNgay_TextChanged(object sender, EventArgs e)
        {

            if (txtNgay.Text != "" && (txtThang.Text == "" || txtNam.Text == ""))
            {

                toolTip.Show("Vui lòng nhập cả tháng và năm", txtNgay, 0, -20, 2000);
            }
            else
            {

                toolTip.Hide(txtNgay);
            }
        }
        private void Load_DataGridView()
        {
            dgridTimhoadonnhap.Columns[0].HeaderText = "Mã hóa đơn nhập";
            dgridTimhoadonnhap.Columns[1].HeaderText = "Mã nhân viên";
            dgridTimhoadonnhap.Columns[2].HeaderText = "Mã nhà cung cấp";
            dgridTimhoadonnhap.Columns[3].HeaderText = "Ngày nhập";
            dgridTimhoadonnhap.Columns[4].HeaderText = "Tổng tiền";
            dgridTimhoadonnhap.AllowUserToAddRows = false;
            dgridTimhoadonnhap.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void btnTimlai3_Click(object sender, EventArgs e)
        {
            ResetValues();
            dgridTimhoadonnhap.DataSource = null;
        }

        private void btnDong3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dgridTimhoadonnhap_DoubleClick(object sender, EventArgs e)
        {
            string mahd;
            if (MessageBox.Show("Bạn có muốn hiển thị thông tin chi tiết?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                mahd = dgridTimhoadonnhap.CurrentRow.Cells["SoHDN"].Value.ToString();
                //frmHoadonnhap frm = new frmHoadonnhap();
                txtMahoadonnhap.Text = mahd;
                //frm.StartPosition = FormStartPosition.CenterScreen;
                //frm.ShowDialog();
            }

        }
        DataTable KhachHang;

        private void Load_daGridTKKH()
        {
            string sql;
            sql = "select * from KhachHang WHERE 1=1";
            KhachHang = CLass.Functions.GetDataToTable(sql);
            daGridTKKH.DataSource = KhachHang;
            daGridTKKH.Columns[0].HeaderText = "Mã khách hàng";
            daGridTKKH.Columns[1].HeaderText = "Tên khách hàng";
            daGridTKKH.Columns[2].HeaderText = "Địa chỉ";
            daGridTKKH.Columns[3].HeaderText = "Số điện thoại";

            daGridTKKH.AllowUserToAddRows = true;
            daGridTKKH.EditMode = DataGridViewEditMode.EditProgrammatically;
                
            
        }
        private void dGridTKKH_Click(object sender, EventArgs e)
        {

            if (daGridTKKH.CurrentRow != null)
            {
                txtMaKH.Text = daGridTKKH.CurrentRow.Cells["MaKH"]?.Value.ToString();
                txtTenKH.Text = daGridTKKH.CurrentRow.Cells["TenKH"]?.Value.ToString();
                mskSDT.Text = daGridTKKH.CurrentRow.Cells["Sodt"]?.Value.ToString();
                txtDiachi.Text = daGridTKKH.CurrentRow.Cells["Dia"]?.Value.ToString();
            }
        }

        private void btnTimkiem2_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtMaKH.Text == "") && (txtTenKH.Text == "") && (txtDiachi.Text == "") && (mskSDT.Text == "(   )    -"))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            sql = "SELECT * FROM KhachHang WHERE 1=1";
            if (txtMaKH.Text != "")
                sql = sql + " AND MaKhachHang Like N'%" + txtMaKH.Text.Trim().ToString() + "%'";
            if (txtTenKH.Text != "")
                sql = sql + " AND TenKhachHang Like N'%" + txtTenKH.Text.Trim().ToString() + "%'";
            if (txtDiachi.Text != "")
                sql = sql + " AND DiaChi Like N'%" + txtDiachi.Text.Trim().ToString() + "%'";
            if (mskSDT.Text != "(   )    -")
                sql = sql + " AND SoDienThoai Like N'%" + mskSDT.Text + "%'";

            KhachHang = Functions.GetDataToTable(sql);
            daGridTKKH.DataSource = KhachHang;

            if (KhachHang.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetValues();
            }
            else
                MessageBox.Show("Có " + KhachHang.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            txtMaKH.Enabled = false;
            txtTenKH.Enabled = false;
            txtDiachi.Enabled = false;
            mskSDT.Enabled = false;
            ResetValues();
        }

        private void btnTimlai2_Click(object sender, EventArgs e)
        {
            txtMaKH.Enabled = true;
            txtTenKH.Enabled = true;
            txtDiachi.Enabled = true;
            mskSDT.Enabled = true;
            ResetValues();
            Load_daGridTKKH();
        }

        private void btnDong2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        DataTable HoaDon;

        private void btnTimkiem4_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtMaHDB.Text == "") && (txtNgayb.Text == "") && (txtThangb.Text == "") && (txtNamb.Text == "") && (txtMaNV.Text == "") && (txtMaKHB.Text == "") && (txtTongtien.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yeu cau ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM HoaDon WHERE 1=1";
            if (txtMaHDB.Text != "")
                sql = sql + " AND MaHoaDon Like N'%" + txtMaHDB.Text + "%'";
            if (txtNgayb.Text != "")
                sql = sql + " AND DAY(NgayBan) =" + txtNgayb.Text;
            if (txtThangb.Text != "")
                sql = sql + " AND MONTH(NgayBan) =" + txtThangb.Text;
            if (txtNamb.Text != "")
                sql = sql + " AND YEAR(NgayBan) =" + txtNamb.Text;
            if (txtMaNV.Text != "")
                sql = sql + " AND MaNhanVien Like N'%" + txtMaNV.Text + "%'";
            if (txtMaKHB.Text != "")
                sql = sql + " AND MaKhachHang Like N'%" + txtMaKHB.Text + "%'";
            if (txtTongtien.Text != "")
                sql = sql + " AND Tongtien <=" + txtTongtien.Text;
            if (txtNgayb.Text != "" && (txtThangb.Text == "" || txtNamb.Text == ""))
            {
                MessageBox.Show("Phải nhập cả Tháng và Năm khi đã nhập Ngày", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtThangb.Focus();
                return;
            }
            int ngayb, thangb, namb;
            if (txtNgayb.Text != "" && (!int.TryParse(txtNgayb.Text, out ngayb) || ngayb < 1 || ngayb > 31))
            {
                MessageBox.Show("Ngày phải là số và nằm trong khoảng từ 1 đến 31", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNgayb.Focus();
                return;
            }
            if (txtThangb.Text != "" && (!int.TryParse(txtThangb.Text, out thangb) || thangb < 1 || thangb > 12))
            {
                MessageBox.Show("Tháng phải là số và nằm trong khoảng từ 1 đến 12", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtThang.Focus();
                return;
            }
            if (txtNamb.Text != "" && (!int.TryParse(txtNamb.Text, out namb) || txtNamb.Text.Length != 4))
            {
                MessageBox.Show("Năm phải là số và có 4 chữ số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNamb.Focus();
                return;
            }
            HoaDon = Functions.GetDataToTable(sql);
            if (HoaDon.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetValues();
            }
            else
                MessageBox.Show("Có " + HoaDon.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            daGridTKHDB.DataSource = HoaDon;
            txtTongtien.Enabled = false;
            Load_daGridTKHDB();
        }

        private void Load_daGridTKHDB()
        {
            daGridTKHDB.Columns[0].HeaderText = "Mã hoá đơn";
            daGridTKHDB.Columns[1].HeaderText = "Mã khách hàng";
            daGridTKHDB.Columns[2].HeaderText = "Mã nhân viên";
            daGridTKHDB.Columns[3].HeaderText = "Ngày bán";
            daGridTKHDB.Columns[4].HeaderText = "Tổng tiền";
            daGridTKHDB.AllowUserToAddRows = false;
            daGridTKHDB.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void btnTimlai4_Click(object sender, EventArgs e)
        {
            ResetValues();
            daGridTKHDB.DataSource = null;
        }
        private void daGridTKHDB_DoubleClick(object sender, EventArgs e)
        {
            string mahdb;
            if (MessageBox.Show("Bạn có muốn hiển thị thông tin chi tiết?", "Xác nhận",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                mahdb = daGridTKHDB.CurrentRow.Cells["MaHoaDon"].Value.ToString();
                Timkiem frm = new Timkiem();//Sau cái này thay bằng frmSanpham frm = new frmSanpham(); 
                frm.txtMaHDB.Text = mahdb;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
            }
        }
        private void btnDong4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
    }
}
