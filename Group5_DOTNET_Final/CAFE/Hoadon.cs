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
using COMExcel = Microsoft.Office.Interop.Excel;
using CAFE.CLass;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System.Data.SqlTypes;
using static System.Net.Mime.MediaTypeNames;
//using Quanlybanhang.Class;


namespace CAFE
{
    public partial class Hoadon : Form
    {
        public Hoadon()
        {
            InitializeComponent();
        }
        DataTable tblCTHDB;

        private void Hoadon_Load(object sender, EventArgs e)
        {

            CLass.Functions.connect();
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnIn.Enabled = false;
            txtMahoadonban.ReadOnly = true;
            txtTennhanvien.ReadOnly = true;
            txtTenkhach.ReadOnly = true;
            txtDiachi.ReadOnly = true;
            txtDienthoai.ReadOnly = true;
            txtTenhang.ReadOnly = true;
            txtDongiaban.ReadOnly = true;
            txtThanhtien.ReadOnly = true;
            txtTongtien.ReadOnly = true;
            txtGiamgia.Text = "0";
            txtTongtien.Text = "0";
            Functions.FillCombo("SELECT Makhachhang, Tenkhachhang FROM Khachhang", cboMakhach,
"Makhachhang", "Makhachhang");
            cboMakhach.SelectedIndex = -1;
            Functions.FillCombo("SELECT Manhanvien, Tennhanvien FROM Nhanvien",
cboManhanvien, "Manhanvien", "Manhanvien");
            cboManhanvien.SelectedIndex = -1;
            Functions.FillCombo("SELECT Masanpham, Tensanpham FROM sanpham", cboMahang,
"Masanpham", "Masanpham");
            cboMahang.SelectedIndex = -1;
            Functions.FillCombo("SELECT mahoadon FROM Chitiethdb", cboMaHDB, "Mahoadon", "Mahoadon");
            cboMaHDB.SelectedIndex = -1;
            //Hiển thị thông tin của một hóa đơn được gọi từ form tìm kiếm
            if (txtMahoadonban.Text != "")
            {
                Load_ThongtinHD();
                btnIn.Enabled = true;
            }
            Load_DataGridViewChitiet();
            btnthemhdn.Enabled = true;
            btnluuhdn.Enabled = false;
            btnxoahdn.Enabled = false;
            btninhdn.Enabled = false;
            btnsuahdn.Enabled = false;
            btnboquahdn.Enabled = false;
            txtmahoadonnhap.ReadOnly = true;
            txttennv.ReadOnly = true;
            txtngaynhap.ReadOnly = true;
            txttenncc.ReadOnly = true;
            txtdiachincc.ReadOnly = true;
            mskdienthoai.ReadOnly = true;
            txttenhanghdn.ReadOnly = true;
            txtthanhtienhdn.ReadOnly = true;
            txttongtienhdn.ReadOnly = true;
            txtgiamgiahdn.Text = "0";
            txttongtienhdn.Text = "0";
            Load_DataGridView();
            Functions.FillCombo("SELECT manhacungcap FROM nhacungcap", cbbmancc, "manhacungcap", "manhacungcap");
            Functions.FillCombo("SELECT manhanvien FROM nhanvien", cbbmanv, "manhanvien", "manhanvien");
            Functions.FillCombo("SELECT masanpham FROM sanpham", cbbmahang, "masanpham", "masanpham");
            Functions.FillCombo("SELECT madonnhap FROM chitiethdn", cbbmahdn, "madonnhap", "madonnhap");
            cbbmahang.SelectedIndex = -1;
            cbbmancc.SelectedIndex = -1;
            cbbmanv.SelectedIndex = -1;
            cbbmahdn.SelectedIndex = -1;
            ResetValue();
            if (txtmahoadonnhap.Text != "")
            {
                Load_Thongtinhdn();
                btnxoahdn.Enabled = true;
                btninhdn.Enabled = true;
                btnsuahdn.Enabled = true;
            }
        }
        private void Load_DataGridViewChitiet()
        {
            string sql;
            sql = "SELECT a.Masanpham, b.Tensanpham, a.Soluong, b.Giaban, a.Khuyenmai, a.Thanhtien FROM ChitietHDB AS a, Sanpham AS b WHERE " +
                "a.Mahoadon = N'" + txtMahoadonban.Text + "' AND a.Masanpham=b.Masanpham";
            tblCTHDB = Functions.GetDataToTable(sql);
            DataGridViewChitiet.DataSource = tblCTHDB;
            DataGridViewChitiet.Columns[0].HeaderText = "Mã hàng";
            DataGridViewChitiet.Columns[1].HeaderText = "Tên hàng";
            DataGridViewChitiet.Columns[2].HeaderText = "Số lượng";
            DataGridViewChitiet.Columns[3].HeaderText = "Đơn giá";
            DataGridViewChitiet.Columns[4].HeaderText = "Khuyến mãi %";
            DataGridViewChitiet.Columns[5].HeaderText = "Thành tiền";
            DataGridViewChitiet.Columns[0].Width = 80;
            DataGridViewChitiet.Columns[1].Width = 100;
            DataGridViewChitiet.Columns[2].Width = 80;
            DataGridViewChitiet.Columns[3].Width = 90;
            DataGridViewChitiet.Columns[4].Width = 90;
            DataGridViewChitiet.Columns[5].Width = 90;
            DataGridViewChitiet.AllowUserToAddRows = false;
            DataGridViewChitiet.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void Load_ThongtinHD()
        {
            string str;
            str = "SELECT Ngayban FROM Hoadon WHERE MaHoadon = N'" + txtMahoadonban.Text + "'";
            txtNgayban.Text = Functions.ConvertDateTime(Functions.GetFieldValues(str));
            str = "SELECT Manhanvien FROM hoadon WHERE Mahoadon = N'" + txtMahoadonban.Text + "'";
            cboManhanvien.Text = Functions.GetFieldValues(str);
            str = "SELECT Makhachhang FROM hoadon WHERE Mahoadon = N'" + txtMahoadonban.Text + "'";
            cboMakhach.Text = Functions.GetFieldValues(str);
            str = "SELECT Tongtien FROM hoadon WHERE Mahoadon = N'" + txtMahoadonban.Text + "'";
            txtTongtien.Text = Functions.GetFieldValues(str);
            txtBangchu.Text = Functions.ChuyenSoSangChu(txtTongtien.Text);
        }
        private void DataGridViewChitiet_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào được chọn không
            if (DataGridViewChitiet.CurrentRow != null)
            {
                // Lấy dữ liệu từ dòng được chọn
                DataGridViewRow selectedRow = DataGridViewChitiet.CurrentRow;
                // Gán dữ liệu từ các cột của dòng được chọn vào các điều khiển tương ứng
                cboMahang.Text = selectedRow.Cells["Masanpham"].Value.ToString();
                txtTenhang.Text = selectedRow.Cells["Tensanpham"].Value.ToString();
                txtSoluong.Text = selectedRow.Cells["Soluong"].Value.ToString();
                txtDongiaban.Text = selectedRow.Cells["giaban"].Value.ToString();
                txtGiamgia.Text = selectedRow.Cells["Khuyenmai"].Value.ToString();
                txtThanhtien.Text = selectedRow.Cells["Thanhtien"].Value.ToString();
                dataGridViewChitietClicked = true;
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            //btnXoaHD.Enabled = false;
            btnLuu.Enabled = true;
            btnIn.Enabled = false;
            btnThem.Enabled = false;
            ResetValues();
            cboMaHDB.Text = "";
            if (cboManhanvien.Text == "")
                txtTennhanvien.Text = "";
            if (cboMahang.Text == "")
                txtTenhang.Text = "";
            txtDongiaban.Text = "";
            if (cboMakhach.Text == "")
            {
                txtTenkhach.Text = "";
                txtDiachi.Text = "";
                txtDienthoai.Text = "";
            }
            txtDongiaban.Text = "";
            txtMahoadonban.Text = Functions.CreateHDBKey();
            Load_DataGridViewChitiet();
        }
        private void ResetValues()
        {
            txtMahoadonban.Text = "";
            txtNgayban.Text = DateTime.Now.ToShortDateString();
            cboManhanvien.Text = "";
            cboMakhach.Text = "";
            txtTongtien.Text = "0";
            txtBangchu.Text = "";
            cboMahang.Text = "";
            txtSoluong.Text = "";
            txtGiamgia.Text = "0";
            txtThanhtien.Text = "0";
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            double sl, SLcon, tong, Tongmoi;
            sql = "SELECT Mahoadon FROM hoadon WHERE MaHoadon=N'" + txtMahoadonban.Text + "'";
            if (!Functions.CheckKey(sql))
            {
                // Mã hóa đơn chưa có, tiến hành lưu các thông tin chung
                // Mã HDBan được sinh tự động do đó không có trường hợp trùng khóa
                if (txtNgayban.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập ngày bán", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNgayban.Focus();
                    return;
                }
                if (cboManhanvien.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập nhân viên", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboManhanvien.Focus();
                    return;
                }
                if (cboMakhach.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập khách hàng", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboMakhach.Focus();
                    return;
                }
                //lưu thông tin chung vào bảng hdban    
                sql = "INSERT INTO Hoadon(Mahoadon, Ngayban, Manhanvien, Makhachhang, Tongtien) VALUES(N'" + txtMahoadonban.Text.Trim() + "', '" +
                        Functions.ConvertDateTime(txtNgayban.Text.Trim()) + "',N'" + cboManhanvien.SelectedValue + "',N'" +
                        cboMakhach.SelectedValue + "'," + txtTongtien.Text + ")";
                Functions.RunSQL(sql);
            }

            // Lưu thông tin của các mặt hàng
            if (cboMahang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK,
MessageBoxIcon.Warning);
                cboMahang.Focus();
                return;
            }
            if ((txtSoluong.Text.Trim().Length == 0) || (txtSoluong.Text == "0"))
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK,
MessageBoxIcon.Warning);
                txtSoluong.Text = "";
                txtSoluong.Focus();
                return;
            }
            if (txtGiamgia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giảm giá", "Thông báo", MessageBoxButtons.OK,
MessageBoxIcon.Warning);
                txtGiamgia.Focus();
                return;
            }
            sql = "SELECT Masanpham FROM ChitietHDB WHERE Masanpham=N'" +
cboMahang.SelectedValue + "' AND Mahoadon = N'" + txtMahoadonban.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã hàng này đã có, bạn phải nhập mã khác", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetValuesHang();
                cboMahang.Focus();
                return;
            }
            // Kiểm tra xem số lượng hàng trong kho còn đủ để cung cấp không?
            sl = Convert.ToDouble(Functions.GetFieldValues("SELECT Soluong FROM sanpham WHERE masanpham = N'" + cboMahang.SelectedValue + "'"));
            if (Convert.ToDouble(txtSoluong.Text) > sl)
            {
                MessageBox.Show("Số lượng mặt hàng này chỉ còn " + sl, "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoluong.Text = "";
                txtSoluong.Focus();
                return;
            }
            sql = "INSERT INTO ChitietHDB(MaHoadon,Masanpham,Soluong,khuyenmai, Thanhtien)  VALUES(N'" + txtMahoadonban.Text.Trim() + "', N'" + cboMahang.SelectedValue +
"'," + txtSoluong.Text + "," + txtGiamgia.Text + "," + txtThanhtien.Text + ")";
            Functions.RunSQL(sql);
            Load_DataGridViewChitiet();
            // Cập nhật lại số lượng của mặt hàng vào bảng tblHang
            SLcon = sl - Convert.ToDouble(txtSoluong.Text);
            sql = "UPDATE sanpham SET Soluong =" + SLcon + " WHERE Masanpham= N'" + cboMahang.SelectedValue + "'";
            Functions.RunSQL(sql);
            // Cập nhật lại tổng tiền cho hóa đơn bán
            tong = Convert.ToDouble(Functions.GetFieldValues("SELECT Tongtien FROM Hoadon WHERE Mahoadon = N'" + txtMahoadonban.Text + "'"));
            Tongmoi = tong + Convert.ToDouble(Functions.GetFieldValues("SELECT sum(thanhtien) FROM chitietHDB WHERE Mahoadon = N'" + txtMahoadonban.Text + "'"));
            sql = "UPDATE hoadon SET Tongtien =" + Tongmoi + " WHERE Mahoadon = N'" + txtMahoadonban.Text + "'";
            Functions.RunSQL(sql);
            txtTongtien.Text = Tongmoi.ToString();
            txtBangchu.Text = Functions.ChuyenSoSangChu(Tongmoi.ToString());
            ResetValuesHang();
            //btnXoaHD.Enabled = true;
            btnThem.Enabled = true;
            btnIn.Enabled = true;
        }
        private void ResetValuesHang()
        {
            cboMahang.Text = "";
            txtSoluong.Text = "";
            txtGiamgia.Text = "0";
            txtThanhtien.Text = "0";
        }
        private void DataGridViewChitiet_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string mahang;
            Double Thanhtien;
            if (tblCTHDB.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK,
MessageBoxIcon.Information);
                return;
            }
            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo",
MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                //Xóa hàng và cập nhật lại số lượng hàng 
                mahang = DataGridViewChitiet.CurrentRow.Cells["Masanpham"].Value.ToString();
                DelHang(txtMahoadonban.Text, mahang);
                // Cập nhật lại tổng tiền cho hóa đơn bán
                Thanhtien = Convert.ToDouble(DataGridViewChitiet.CurrentRow.
Cells["Thanhtien"].Value.ToString());
                DelUpdateTongtien(txtMahoadonban.Text, Thanhtien);
                Load_DataGridViewChitiet();
            }
        }
        private void DelHang(string Mahoadon, string Mahang)
        {
            Double s, sl, SLcon;
            string sql;
            sql = "SELECT Soluong FROM ChitietHDB WHERE MaHoadon = N'" + Mahoadon + "' AND Masanpham = N'" + Mahang + "'";
            s = Convert.ToDouble(Functions.GetFieldValues(sql));
            sql = "DELETE ChitietHDB WHERE MaHoadon =N'" + Mahoadon + "' AND Mahang = N'"
+ Mahang + "'";
            Functions.RunSqlDel(sql);
            // Cập nhật lại số lượng cho các mặt hàng
            sql = "SELECT Soluong FROM sanpham WHERE Masanpham = N'" + Mahang + "'";
            sl = Convert.ToDouble(Functions.GetFieldValues(sql));
            SLcon = sl + s;
            sql = "UPDATE sanpham SET Soluong =" + SLcon + " WHERE Masanpham= N'" + Mahang + "'";
            Functions.RunSQL(sql);
        }
        private void DelUpdateTongtien(string Mahoadon, double Thanhtien)
        {
            Double Tong, Tongmoi;
            string sql;
            sql = "SELECT Tongtien FROM hoadon WHERE MaHoadon = N'" + Mahoadon + "'";
            Tong = Convert.ToDouble(Functions.GetFieldValues(sql));
            Tongmoi = Tong - Thanhtien;
            sql = "UPDATE hoadon SET Tongtien =" + Tongmoi + " WHERE MaHoadon = N'" +
Mahoadon + "'";
            Functions.RunSQL(sql);
            txtTongtien.Text = Tongmoi.ToString();
            txtBangchu.Text = Functions.ChuyenSoSangChu(Tongmoi.ToString());
        }
        private void cboManhanvien_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboManhanvien.Text == "")
                txtTennhanvien.Text = "";
            // Khi kich chon Ma nhan vien thi ten nhan vien se tu dong hien ra
            str = "Select Tennhanvien from Nhanvien where Manhanvien =N'" + cboManhanvien.SelectedValue + "'";
            txtTennhanvien.Text = Functions.GetFieldValues(str);
        }
        private void cboMakhach_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMakhach.Text == "")
            {
                txtTenkhach.Text = "";
                txtDiachi.Text = "";
                txtDienthoai.Text = "";
            }
            //Khi kich chon Ma khach thi ten khach, dia chi, dien thoai se tu dong hien ra
            str = "Select Tenkhachhang from Khachhang where Makhachhang = N'" + cboMakhach.SelectedValue + "'";
            txtTenkhach.Text = Functions.GetFieldValues(str);
            str = "Select Diachi from Khachhang where Makhachhang = N'" + cboMakhach.SelectedValue + "'";
            txtDiachi.Text = Functions.GetFieldValues(str);
            str = "Select SoDienthoai from Khachhang where Makhachhang = N'" + cboMakhach.SelectedValue + "'";
            txtDienthoai.Text = Functions.GetFieldValues(str);
        }
        private void cboMahang_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMahang.Text == "")
            {
                txtTenhang.Text = "";
                txtDongiaban.Text = "";
            }
            // Khi kich chon Ma hang thi ten hang va gia ban se tu dong hien ra
            str = "SELECT Tensanpham FROM sanpham WHERE Masanpham =N'" + cboMahang.SelectedValue + "'";
            txtTenhang.Text = Functions.GetFieldValues(str);
            str = "SELECT giaban FROM sanpham WHERE Masanpham =N'" + cboMahang.SelectedValue + "'";
            txtDongiaban.Text = Functions.GetFieldValues(str);
        }
        private void txtSoluong_TextChanged(object sender, EventArgs e)
        {
            //Khi thay doi So luong, Giam gia thi Thanh tien tu dong cap nhat lai gia tri
            double tt, sl, dg, gg;
            if (txtSoluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoluong.Text);
            if (txtGiamgia.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txtGiamgia.Text.Replace("%", ""));
            if (txtDongiaban.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtDongiaban.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtThanhtien.Text = tt.ToString();
        }
        private void txtGiamgia_TextChanged(object sender, EventArgs e)
        {
            //Khi thay doi So luong, Giam gia thi Thanh tien tu dong cap nhat lai gia tri
            double tt, sl, dg, gg;
            if (txtSoluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoluong.Text);
            if (txtGiamgia.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txtGiamgia.Text.Replace("%", ""));
            if (txtDongiaban.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtDongiaban.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtThanhtien.Text = tt.ToString();
        }
        private void btnIn_Click(object sender, EventArgs e)
        {
            // Khởi động chương trình Excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable tblThongtinHD, tblThongtinHang;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            // Định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:B3"].Font.Name = "Times new roman";
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5; //Màu xanh da trời
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "Cà phê ven hồ";

            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Đống Đa - Hà Nội";

            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
            exRange.Range["A3:B3"].Value = "Điện thoại: (04)37562222";


            exRange.Range["C2:E2"].Font.Size = 16;
            exRange.Range["C2:E2"].Font.Name = "Times new roman";
            exRange.Range["C2:E2"].Font.Bold = true;
            exRange.Range["C2:E2"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C2:E2"].MergeCells = true;
            exRange.Range["C2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:E2"].Value = "HÓA ĐƠN BÁN";
            // Biểu diễn thông tin chung của hóa đơn bán
            sql = "SELECT a.MaHoadon, a.Ngayban, a.Tongtien, b.Tenkhachhang, b.Diachi,b.SoDienthoai, c.Tennhanvien FROM hoadon AS a, Khachhang AS b, Nhanvien AS c " +
                "WHERE a.MaHoadon = N'" + txtMahoadonban.Text + "' AND a.Makhachhang = b.Makhachhang AND a.Manhanvien = c.Manhanvien";

            tblThongtinHD = Functions.GetDataToTable(sql);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:C9"].Font.Name = "Times new roman";
            exRange.Range["B6:B6"].Value = "Mã hóa đơn:";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = tblThongtinHD.Rows[0][0].ToString();
            exRange.Range["B7:B7"].Value = "Khách hàng:";
            exRange.Range["C7:E7"].MergeCells = true;
            exRange.Range["C7:E7"].Value = tblThongtinHD.Rows[0][3].ToString();
            exRange.Range["B8:B8"].Value = "Địa chỉ:";
            exRange.Range["C8:E8"].MergeCells = true;
            exRange.Range["C8:E8"].Value = tblThongtinHD.Rows[0][4].ToString();
            exRange.Range["B9:B9"].Value = "Điện thoại:\n" + tblThongtinHD.Rows[0][5].ToString();  // Cập nhật để số điện thoại xuất hiện ngay từ đầu dòng mới
            exRange.Range["B9:B9"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;  // Căn trái
            exRange.Range["B9:B9"].VerticalAlignment = COMExcel.XlVAlign.xlVAlignTop;  // Căn đỉnh
            exRange.Range["B9:B9"].WrapText = true;  // Cho phép tự động xuống dòng trong ô


            //Lấy thông tin các mặt hàng
            sql = "SELECT b.Tensanpham, a.Soluong, b.giaban, a.Khuyenmai, a.Thanhtien FROM ChitietHDB AS a , Sanpham AS b " +
                "WHERE a.MaHoadon = N'" + txtMahoadonban.Text + "' AND a.Masanpham = b.Masanpham ";
            tblThongtinHang = Functions.GetDataToTable(sql);
            //Tạo dòng tiêu đề bảng
            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:F11"].ColumnWidth = 12;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "Tên hàng";
            exRange.Range["C11:C11"].Value = "Số lượng";
            exRange.Range["D11:D11"].Value = "Đơn giá";
            exRange.Range["E11:E11"].Value = "Giảm giá";
            exRange.Range["F11:F11"].Value = "Thành tiền";
            for (hang = 0; hang <= tblThongtinHang.Rows.Count - 1; hang++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 12
                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot <= tblThongtinHang.Columns.Count - 1; cot++)
                    //Điền thông tin hàng từ cột thứ 2, dòng 12
                    exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString();
            }
            int totalQuantity = 0;
            foreach (DataRow row in tblThongtinHang.Rows)
            {
                totalQuantity += Convert.ToInt32(row["Soluong"]);
            }

            exRange = exSheet.Cells[cot + 1, hang + 13]; 
            exRange.Value2 = "Tổng số lượng:";
            exRange.Font.Bold = true;

            exRange = exSheet.Cells[cot + 2, hang + 13]; 
            exRange.Value2 = totalQuantity;
            exRange.Font.Bold = true;
            exRange = exSheet.Cells[cot][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng tiền:";
            exRange = exSheet.Cells[cot + 1][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = tblThongtinHD.Rows[0][2].ToString();
            exRange = exSheet.Cells[1][hang + 1]; 
            exRange.Range["A1:F1"].MergeCells = true;
            exRange.Range["A1:F1"].Font.Bold = true;
            exRange.Range["A1:F1"].Font.Italic = true;
            exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            exRange.Range["A1:F1"].Value = "Bằng chữ: " + Functions.ChuyenSoSangChu
 (tblThongtinHD.Rows[0][2].ToString());
            exRange = exSheet.Cells[4][hang + 15]; 
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(tblThongtinHD.Rows[0][1]);
            exRange.Range["A1:C1"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Nhân viên bán hàng";
            exRange.Range["A6:C6"].MergeCells = true;
            exRange.Range["A6:C6"].Font.Italic = true;
            exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A6:C6"].Value = tblThongtinHD.Rows[0][6];
            exSheet.Name = "";
            exApp.Visible = true;
        }
        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            if (cboMaHDB.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMaHDB.Focus();
                return;
            }
            txtMahoadonban.Text = cboMaHDB.Text;
            Load_ThongtinHD();
            Load_DataGridViewChitiet();
            btnXoa.Enabled = true;
            btnLuu.Enabled = true;
            btnIn.Enabled = true;
            btnSua.Enabled = true;
            //cboMaHDB.SelectedIndex = -1;
            //cboMakhach.Enabled = false;
            //cboManhanvien.Enabled = false;
        }
        private void txtSoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }
        private void txtGiamgia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }
        private void cboMaHDB_DropDown(object sender, EventArgs e)
        {
            Functions.FillCombo("SELECT Mahoadon FROM Hoadon", cboMaHDB, "MaHoadon", "MaHoadon");
            cboMaHDB.SelectedIndex = -1;
        }
        private void Hoadon_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Xóa dữ liệu trong các điều khiển trước khi đóng Form
            ResetValues();
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetValues();
            ResetValuesHang();
            btnHuy.Enabled = true;
            btnThem.Enabled = true;
            //btnXoa.Enabled = true;
            //btnSua.Enabled = true;
            btnLuu.Enabled = false;
            btnIn.Enabled = false;
            txtNgayban.Text = "";
            if (cboManhanvien.Text == "")
                txtTennhanvien.Text = "";
            if (cboMahang.Text == "")
                txtTenhang.Text = "";
            txtDongiaban.Text = "";
            if (cboMakhach.Text == "")
            {
                txtTenkhach.Text = "";
                txtDiachi.Text = "";
                txtDienthoai.Text = "";
            }
            DataGridViewChitiet.DataSource = null;
            //txtMakhachhang.Enabled = false;
        }
        private bool dataGridViewChitietClicked = false;
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (cboManhanvien.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboManhanvien.Focus();
                return;
            }
            if (cboMakhach.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbbmanv.Focus();
                return;
            }

            string sql, manhanvien, makhach;
            sql = $"SELECT manhanvien FROM hoadon WHERE mahoadon=N'{txtMahoadonban.Text.Trim()}'";
            manhanvien = Functions.GetFieldValues(sql);
            sql = $"SELECT makhachhang FROM hoadon WHERE mahoadon=N'{txtMahoadonban.Text.Trim()}'";
            makhach = Functions.GetFieldValues(sql);
            bool hasChanges = false;
            if (cboManhanvien.Text != manhanvien || cboMakhach.Text != makhach)
            {
                sql = $"UPDATE hoadon SET manhanvien= '{cboManhanvien.SelectedValue}', makhachhang = '{cboMakhach.SelectedValue}' WHERE mahoadon=N'{txtMahoadonban.Text}'";
                Functions.RunSQL(sql);
                hasChanges = true;
            }

            // Xử lý cập nhật số lượng sản phẩm nếu có
            if (!string.IsNullOrWhiteSpace(cboMahang.Text))
            {
                double slCu, slMoi;
                string masanpham = cboMahang.SelectedValue.ToString();
                slCu = Convert.ToDouble(Functions.GetFieldValues("SELECT Soluong FROM ChitietHDB WHERE mahoadon = N'" + txtMahoadonban.Text + "' AND masanpham = N'" + masanpham + "'"));
                slMoi = Convert.ToDouble(txtSoluong.Text);
                if (slMoi != slCu)
                {
                    sql = $"UPDATE ChitietHDB SET Soluong = {slMoi},thanhtien = N'{txtThanhtien.Text}' WHERE mahoadon = N'{txtMahoadonban.Text}' AND masanpham = N'{masanpham}'";
                    Functions.RunSQL(sql);
                    double slKho = Convert.ToDouble(Functions.GetFieldValues($"SELECT Soluong FROM Sanpham WHERE masanpham = N'{masanpham}'"));
                    double thayDoi = slMoi - slCu;
                    slKho -= thayDoi;
                    sql = $"UPDATE Sanpham SET Soluong = {slKho} WHERE Masanpham = N'{masanpham}'";
                    Functions.RunSQL(sql);
                    hasChanges = true;
                }
            }
            if (hasChanges)
            {
                MessageBox.Show("Thông tin hóa đơn đã được cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không có gì thay đổi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string[] mahang = new string[20];
                string sql, sql1;
                int n = 0;
                int i;
                sql = "SELECT masanpham FROM chitiethdb WHERE mahoadon = N'" + txtMahoadonban.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, Functions.conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    mahang[n] = reader.GetString(0).ToString();
                    n = n + 1;
                }
                reader.Close();
                //Xóa danh sách các mặt hàng của hóa đơn
                for (i = 0; i <= n - 1; i++)
                    DelHang(txtMahoadonban.Text, mahang[i]);
                //Xóa hóa đơn
                sql1 = "DELETE chitiethdb WHERE mahoadon = N'" + txtMahoadonban.Text + "'";
                sql = "DELETE hoadon WHERE mahoadon = N'" + txtMahoadonban.Text + "'";
                Functions.RunSQL(sql1);
                Functions.RunSQL(sql);
                MessageBox.Show("Hóa đơn " + txtMahoadonban.Text + " đã được xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetValue();
                ResetValuesmathang();
                Load_DataGridView();
                txtMahoadonban.Text = "";
                cboMaHDB.Text = "";
                btnXoa.Enabled = false;
                btnIn.Enabled = false;
            }
        }

        // Hoá đơn nhập
        DataTable hdn;
        private void ResetValue()
        {

            cbbmanv.Text = "";
            cbbmancc.Text = "";
            txttongtienhdn.Text = "0";
            lblttbangchu.Text = "Bằng chữ: ";
            cbbmahang.Text = "";
            txtgiamgiahdn.Text = "0";
            txtthanhtienhdn.Text = "0";
            txttenhanghdn.Text = "";
            txtngaynhap.Text = DateTime.Now.ToShortDateString();
            txttennv.Text = "";
            txttenncc.Text = "";
            txtdiachincc.Text = "";
            mskdienthoai.Text = "";
        }
        private void btntimkiemhdn_Click(object sender, EventArgs e)
        {
            ResetValuesmathang();
            if (cbbmahdn.Text == "")
            {
                MessageBox.Show("Bạn phải chọn mã hóa đơn nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbmahdn.Focus();
                return;
            }
            txtmahoadonnhap.Text = cbbmahdn.Text;
            Load_Thongtinhdn();
            Load_DataGridView();
            btnxoahdn.Enabled = true;
            btninhdn.Enabled = true;
            btnluuhdn.Enabled = true;
            btnsuahdn.Enabled = true;

        }

        private void Load_Thongtinhdn()
        {
            string str;

            // Lấy thông tin Ngày nhập
            str = "SELECT Ngaynhap FROM Hoadonnhap WHERE madonnhap = N'" + txtmahoadonnhap.Text + "'";
            txtngaynhap.Text = Functions.ConvertDateTime(Functions.GetFieldValues(str));

            // Lấy thông tin Mã nhân viên
            str = "SELECT manhanvien FROM Hoadonnhap WHERE madonnhap = N'" + txtmahoadonnhap.Text + "'";
            string maNV = Functions.GetFieldValues(str);
            cbbmanv.Text = maNV;

            // Lấy thông tin Tên nhân viên dựa vào Mã nhân viên
            str = "SELECT Tennhanvien FROM Nhanvien WHERE Manhanvien = N'" + maNV + "'";
            string tenNV = Functions.GetFieldValues(str);
            txttennv.Text = tenNV;

            // Lấy thông tin Mã nhà cung cấp
            str = "SELECT manhacungcap FROM Hoadonnhap WHERE madonnhap = N'" + txtmahoadonnhap.Text + "'";
            string maNCC = Functions.GetFieldValues(str);
            cbbmancc.Text = maNCC;

            // Lấy thông tin Tên nhà cung cấp dựa vào Mã nhà cung cấp
            str = "SELECT tennhacungcap FROM Nhacungcap WHERE Manhacungcap = N'" + maNCC + "'";
            string tenNCC = Functions.GetFieldValues(str);
            txttenncc.Text = tenNCC;

            str = "SELECT DiaChi FROM Nhacungcap WHERE manhacungcap = N'" + maNCC + "'";
            string diaChiNCC = Functions.GetFieldValues(str);
            txtdiachincc.Text = diaChiNCC;


            // Lấy thông tin Điện thoại nhà cung cấp dựa vào Mã nhà cung cấp
            str = "SELECT soDienThoai FROM Nhacungcap WHERE manhacungcap = N'" + maNCC + "'";
            string dienThoaiNCC = Functions.GetFieldValues(str);
            mskdienthoai.Text = dienThoaiNCC;

            // Lấy thông tin Tổng tiền
            str = "SELECT tongtien FROM Hoadonnhap WHERE madonnhap = N'" + txtmahoadonnhap.Text + "'";
            txttongtienhdn.Text = Functions.GetFieldValues(str);

            // Chuyển đổi tổng tiền sang chữ
            lblttbangchu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChu(txttongtienhdn.Text);
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT a.Masanpham, b.Tensanpham, a.Soluong, a.Dongia, a.Khuyenmai, a.Thanhtien FROM ChitietHDn AS a, Sanpham AS b WHERE " +
                "a.Madonnhap = N'" + txtmahoadonnhap.Text + "' AND a.Masanpham=b.Masanpham";
            hdn = Functions.GetDataToTable(sql);
            DataGridView.DataSource = hdn;
            DataGridView.Columns[0].HeaderText = "Mã hàng";
            DataGridView.Columns[1].HeaderText = "Tên hàng";
            DataGridView.Columns[2].HeaderText = "Số lượng";
            DataGridView.Columns[3].HeaderText = "Đơn giá nhập";
            DataGridView.Columns[4].HeaderText = "Khuyến mãi %";
            DataGridView.Columns[5].HeaderText = "Thành tiền";
            DataGridView.Columns[0].Width = 80;
            DataGridView.Columns[1].Width = 100;
            DataGridView.Columns[2].Width = 80;
            DataGridView.Columns[3].Width = 90;
            DataGridView.Columns[4].Width = 90;
            DataGridView.Columns[5].Width = 90;
            DataGridView.AllowUserToAddRows = false;
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void DataGridView_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào được chọn không

            if (DataGridView.CurrentRow != null)
            {

                // Lấy dữ liệu từ dòng được chọn
                DataGridViewRow selectedRow = DataGridView.CurrentRow;

                // Gán dữ liệu từ các cột của dòng được chọn vào các điều khiển tương ứng
                cbbmahang.Text = selectedRow.Cells["masanpham"].Value.ToString();
                txttenhanghdn.Text = selectedRow.Cells["tensanpham"].Value.ToString();
                txtsoluonghdn.Text = selectedRow.Cells["Soluong"].Value.ToString();
                txtdongianhap.Text = selectedRow.Cells["dongia"].Value.ToString();
                txtgiamgiahdn.Text = selectedRow.Cells["khuyenmai"].Value.ToString();
                txtthanhtienhdn.Text = selectedRow.Cells["Thanhtien"].Value.ToString();

            }

        }
        private void btnthemhdn_Click(object sender, EventArgs e)
        {
            btnsuahdn.Enabled = false;
            btntimkiemhdn.Enabled = false;
            btnxoahdn.Enabled = false;
            btnluuhdn.Enabled = true;
            btninhdn.Enabled = false;
            btnthemhdn.Enabled = false;
            btnboquahdn.Enabled = true;
            txtsoluonghdn.Text = "";
            cbbmahdn.Text = "";
            ResetValue();
            txtmahoadonnhap.Text = Functions.CreateHDNKey();
            txtngaynhap.Text = DateTime.Now.ToShortDateString();
            Load_DataGridView();
        }

        private void btnluuhdn_Click(object sender, EventArgs e)
        {
            string sql;
            double sl, slmoi, tong, tongmoi;
            sql = $"SELECT madonnhap FROM hoadonnhap WHERE madonnhap=N'{txtmahoadonnhap.Text}'";
            if (!Functions.CheckKey(sql))
            {

                if (cbbmanv.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbbmanv.Focus();
                    return;
                }
                if (cbbmancc.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbbmancc.Focus();
                    return;
                }

                if (cbbmahang.Text.Length != 0 && txtsoluonghdn.Text != "")
                {
                    sql = $"INSERT INTO hoadonnhap(madonnhap,manhanvien,manhacungcap,ngaynhap,tongtien) VALUES (N'{txtmahoadonnhap.Text.Trim()}',N'{cbbmanv.SelectedValue}',N'{cbbmancc.SelectedValue}','{Functions.ConvertDateTime(txtngaynhap.Text)}',{txttongtienhdn.Text})";
                    Functions.RunSQL(sql);
                }
                else
                {
                    sql = $"INSERT INTO hoadonnhap(madonnhap,manhanvien,manhacungcap,ngaynhap,tongtien) VALUES (N'{txtmahoadonnhap.Text.Trim()}',N'{cbbmanv.SelectedValue}',N'{cbbmancc.SelectedValue}','{Functions.ConvertDateTime(txtngaynhap.Text)}',{txttongtienhdn.Text})";
                    Functions.RunSQL(sql);
                    MessageBox.Show("Bạn đã lưu hóa đơn này nhưng chưa có sản phẩm nào được thêm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                sql = $"SELECT masanpham FROM chitiethdn WHERE madonnhap=N'{txtmahoadonnhap.Text.Trim()}' ";
                if (cbbmahang.Text.Length == 0 && txtsoluonghdn.Text == "" && !Functions.CheckKey(sql))
                {
                    MessageBox.Show("Mã hóa đơn này đã được lưu, bạn hãy nhập thêm thông tin sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (cbbmahang.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtsoluonghdn.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtdongianhap.Text.Length == 0)
                {

                    MessageBox.Show("Bạn phải nhập đơn giá nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                sql = $"SELECT masanpham FROM chitiethdn WHERE masanpham=N'{cbbmahang.SelectedValue}'AND madonnhap=N'{txtmahoadonnhap.Text.Trim()}'";
                if (Functions.CheckKey(sql))
                {
                    MessageBox.Show("Mã hàng này đã có, bạn phải nhập mã hàng khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbbmahang.Focus();
                    cbbmahang.Text = "";
                    return;
                }
                else
                {
                    sql = $"INSERT INTO chitiethdn(madonnhap,masanpham,soluong,dongia,thanhtien,khuyenmai) VALUES (N'{txtmahoadonnhap.Text.Trim()}',N'{cbbmahang.SelectedValue}',N'{txtsoluonghdn.Text.Trim()}','{txtdongianhap.Text.Trim()}','{txtthanhtienhdn.Text.Trim()}','{txtgiamgiahdn.Text.Trim()}')";
                    Functions.RunSQL(sql);
                    Load_DataGridView();
                    //cập nhật lại giá nhập và giá bán trong bảng hàng hóa
                    decimal gianhap = Convert.ToInt32(txtdongianhap.Text);
                    sql = $"UPDATE sanpham SET gianhap ='{txtdongianhap.Text.Trim()}',giaban= {gianhap}*1.1 WHERE masanpham=N'{cbbmahang.SelectedValue}' ";
                    Functions.RunSQL(sql);
                    //cập nhật lại số lượng trong bảng hàng hóa
                    sl = Convert.ToDouble(Functions.GetFieldValues($"SELECT soluong FROM sanpham WHERE masanpham=N'{cbbmahang.SelectedValue}'"));
                    slmoi = sl + Convert.ToInt32(txtsoluonghdn.Text);
                    sql = $"UPDATE sanpham SET soluong={slmoi} WHERE masanpham=N'{cbbmahang.SelectedValue}'";
                    Functions.RunSQL(sql);
                    // cập nhật tổng tiền cho hóa đơn nhập 
                    tong = Convert.ToDouble(Functions.GetFieldValues($"SELECT tongtien FROM hoadonnhap WHERE madonnhap=N'{txtmahoadonnhap.Text.Trim()}'"));
                    tongmoi = tong + Convert.ToDouble(txtthanhtienhdn.Text);
                    sql = $"UPDATE hoadonnhap SET tongtien={tongmoi} WHERE madonnhap=N'{txtmahoadonnhap.Text.Trim()}'";
                    Functions.RunSQL(sql);

                    txttongtienhdn.Text = tongmoi.ToString();
                    lblttbangchu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChu(tongmoi.ToString());
                    ResetValuesmathang();
                }
            }
        }
        private void ResetValuesmathang()
        {
            cbbmahang.Text = "";
            txttenhanghdn.Text = "";
            txtsoluonghdn.Text = "";
            txtgiamgiahdn.Text = "0";
            txtthanhtienhdn.Text = "0";
            txtdongianhap.Text = "";

        }


        public void DelHangHDN(string mahoadon, string mahang)
        {
            Double s, sl, SLcon;
            string sql;
            sql = "SELECT Soluong FROM Chitiethdn WHERE madonnhap = N'" + mahoadon + "' AND masanpham = N'" + mahang + "'";
            s = Convert.ToDouble(Functions.GetFieldValues(sql));
            sql = "DELETE Chitiethdn WHERE madonnhap=N'" + mahoadon + "' AND masanpham = N'" + mahang + "'";
            Functions.RunSQL(sql);
            // Cập nhật lại số lượng cho các mặt hàng
            sql = "SELECT Soluong FROM sanpham WHERE masanpham = N'" + mahang + "'";
            sl = Convert.ToDouble(Functions.GetFieldValues(sql));
            SLcon = sl - s;
            sql = "UPDATE sanpham SET Soluong =" + SLcon + " WHERE masanpham= N'" + mahang + "'";
            Functions.RunSQL(sql);
        }
        private void DelUpdateTongtienHDN(string mahoadon, double Thanhtien)
        {
            Double Tong, Tongmoi;
            string sql;
            sql = "SELECT Tongtien FROM Hoadonnhap WHERE madonnhap = N'" + mahoadon + "'";
            Tong = Convert.ToDouble(Functions.GetFieldValues(sql));
            Tongmoi = Tong - Thanhtien;
            sql = "UPDATE Hoadonnhap SET Tongtien =" + Tongmoi + " WHERE madonnhap = N'" + mahoadon + "'";
            Functions.RunSQL(sql);
            txttongtienhdn.Text = Tongmoi.ToString();
            lblttbangchu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChu(Tongmoi.ToString());
        }

        private void btnxoahdn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string[] mahang = new string[20];
                string sql;
                int n = 0;
                int i;
                sql = "SELECT masanpham FROM chitiethdn WHERE madonnhap = N'" + txtmahoadonnhap.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, Functions.conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    mahang[n] = reader.GetString(0).ToString();
                    n = n + 1;
                }
                reader.Close();
                //Xóa danh sách các mặt hàng của hóa đơn
                for (i = 0; i <= n - 1; i++)
                    DelHangHDN(txtmahoadonnhap.Text, mahang[i]);
                //Xóa hóa đơn
                sql = "DELETE hoadonnhap WHERE madonnhap =N'" + txtmahoadonnhap.Text + "'";
                Functions.RunSQL(sql);
                MessageBox.Show("Hóa đơn " + txtmahoadonnhap.Text + " đã được xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetValue();
                ResetValuesmathang();
                Load_DataGridView();
                txtmahoadonnhap.Text = "";
                cbbmahdn.Text = "";
                btnxoahdn.Enabled = false;
                btninhdn.Enabled = false;

                btnsuahdn.Enabled = false;
                btnluuhdn.Enabled = false;
            }

        }

        private void cbbmanv_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cbbmanv.Text == "")
                txttennv.Text = "";
            str = $"SELECT tennhanvien FROM nhanvien WHERE manhanvien=N'{cbbmanv.SelectedValue}'";
            txttennv.Text = Functions.GetFieldValues(str);
        }

        private void cbbmancc_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cbbmancc.Text == "")
            {
                txttenncc.Text = "";
                txtdiachincc.Text = "";
                mskdienthoai.Text = "";
            }
            str = $"SELECT tennhacungcap FROM nhacungcap WHERE manhacungcap=N'{cbbmancc.SelectedValue}'";
            txttenncc.Text = Functions.GetFieldValues(str);
            str = $"SELECT diachi FROM nhacungcap WHERE manhacungcap=N'{cbbmancc.SelectedValue}'";
            txtdiachincc.Text = Functions.GetFieldValues(str);
            str = $"SELECT sodienthoai FROM nhacungcap WHERE manhacungcap=N'{cbbmancc.SelectedValue}'";
            mskdienthoai.Text = Functions.GetFieldValues(str);
        }

        private void cbbmahang_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cbbmahang.Text == "")
            {
                txttenhanghdn.Text = "";
                txtdongianhap.Text = "";
            }
            str = $"SELECT tensanpham FROM sanpham WHERE masanpham=N'{cbbmahang.SelectedValue}'";
            txttenhanghdn.Text = Functions.GetFieldValues(str);

        }

        private void txtsoluonghdn_TextChanged(object sender, EventArgs e)
        {
            double tt, sl, dg, gg;
            if (txtsoluonghdn.Text == "")
                sl = 0;
            else sl = Convert.ToDouble(txtsoluonghdn.Text);
            if (txtgiamgiahdn.Text == "")
                gg = 0;
            else gg = Convert.ToDouble(txtgiamgiahdn.Text.Replace("%", ""));
            if (txtdongianhap.Text == "")
                dg = 0;
            else dg = Convert.ToDouble(txtdongianhap.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtthanhtienhdn.Text = tt.ToString();

        }

        private void txtgiamgiahdn_TextChanged(object sender, EventArgs e)
        {
            double tt, sl, dg, gg;
            if (txtsoluonghdn.Text == "")
                sl = 0;
            else sl = Convert.ToDouble(txtsoluonghdn.Text);
            if (txtgiamgiahdn.Text == "")
                gg = 0;
            else gg = Convert.ToDouble(txtgiamgiahdn.Text.Replace("%", ""));
            if (txtdongianhap.Text == "")
                dg = 0;
            else dg = Convert.ToDouble(txtdongianhap.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtthanhtienhdn.Text = tt.ToString();
        }

        private void btninhdn_Click(object sender, EventArgs e)
        {
            // Khởi động chương trình Excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable tblThongtinHD, tblThongtinHang;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            // Định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:B3"].Font.Name = "Times new roman";
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5; //Màu xanh da trời
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "Cafe Seemee";

            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Cầu Giấy - Hà Nội";

            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
            exRange.Range["A3:B3"].Value = "Điện thoại: (04)37562222";


            exRange.Range["C2:E2"].Font.Size = 16;
            exRange.Range["C2:E2"].Font.Name = "Times new roman";
            exRange.Range["C2:E2"].Font.Bold = true;
            exRange.Range["C2:E2"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C2:E2"].MergeCells = true;
            exRange.Range["C2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:E2"].Value = "HÓA ĐƠN NHẬP";
            // Biểu diễn thông tin chung của hóa đơn nhập
            sql = "SELECT a.madonnhap, a.Ngaynhap, a.Tongtien, b.Tennhacungcap, b.Diachi, b.soDienthoai, c.Tennhanvien FROM Hoadonnhap AS a, Nhacungcap AS b, Nhanvien AS c WHERE a.madonnhap = N'" + txtmahoadonnhap.Text + "' AND a.manhacungcap= b.manhacungcap AND a.manhanvien =c.manhanvien";
            tblThongtinHD = Functions.GetDataToTable(sql);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:C9"].Font.Name = "Times new roman";
            exRange.Range["B6:B6"].Value = "Mã hóa đơn nhập:";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = tblThongtinHD.Rows[0][0].ToString();
            exRange.Range["B7:B7"].Value = "Nhà cung cấp:";
            exRange.Range["C7:E7"].MergeCells = true;
            exRange.Range["C7:E7"].Value = tblThongtinHD.Rows[0][3].ToString();
            exRange.Range["B8:B8"].Value = "Địa chỉ:";
            exRange.Range["C8:E8"].MergeCells = true;
            exRange.Range["C8:E8"].Value = tblThongtinHD.Rows[0][4].ToString();
            exRange.Range["B9:B9"].Value = "Điện thoại:";
            exRange.Range["C9:E9"].MergeCells = true;
            exRange.Range["C9:E9"].Value = tblThongtinHD.Rows[0][5].ToString();
            //Lấy thông tin các mặt hàng
            sql = "SELECT b.tensanpham, a.Soluong, b.gianhap, a.khuyenmai, a.Thanhtien " +
                 "FROM Chitiethdn AS a , sanpham AS b WHERE a.madonnhap = N'" + txtmahoadonnhap.Text + "' AND a.masanpham = b.masanpham" 
                 ;
            tblThongtinHang = Functions.GetDataToTable(sql);
            //Tạo dòng tiêu đề bảng
            string sql1 = "select sum(soluong) from chitiethdn where madonnhap = N'" + txtmahoadonnhap.Text + "'";
            DataTable tblTongsoluong = Functions.GetDataToTable(sql1);
            //Tạo dòng tiêu đề bảng
            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:F11"].ColumnWidth = 12;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "Tên hàng";
            exRange.Range["C11:C11"].Value = "Số lượng";
            exRange.Range["D11:D11"].Value = "Đơn giá nhập";
            exRange.Range["E11:E11"].Value = "Giảm giá";
            exRange.Range["F11:F11"].Value = "Thành tiền";
            exRange.Range["G11:G11"].Value = "Tổng số lượng";
            exRange = exSheet.Cells[cot + 7][hang + 12];
            exRange.Font.Bold = true;
            exRange.Value2 = tblTongsoluong.Rows[0][0].ToString();


            for (hang = 0; hang <= tblThongtinHang.Rows.Count - 1; hang++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 12
                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot <= tblThongtinHang.Columns.Count - 1; cot++)
                    //Điền thông tin hàng từ cột thứ 2, dòng 12
                    exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString();
            }
            int totalQuantity = 0;
            foreach (DataRow row in tblThongtinHang.Rows)
            {
                totalQuantity += Convert.ToInt32(row["Soluong"]);
            }

            exRange = exSheet.Cells[cot + 1, hang + 13]; 
            exRange.Value2 = "Tổng số lượng:";
            exRange.Font.Bold = true;

            exRange = exSheet.Cells[cot + 2, hang + 13]; 
            exRange.Value2 = totalQuantity;
            exRange.Font.Bold = true;
            exRange = exSheet.Cells[cot][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng tiền:";
            exRange = exSheet.Cells[cot + 1][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = tblThongtinHD.Rows[0][2].ToString();
            exRange = exSheet.Cells[1][hang + 15]; //Ô A1 
            exRange.Range["A1:F1"].MergeCells = true;
            exRange.Range["A1:F1"].Font.Bold = true;
            exRange.Range["A1:F1"].Font.Italic = true;
            exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            exRange.Range["A1:F1"].Value = "Bằng chữ: " + Functions.ChuyenSoSangChu
 (tblThongtinHD.Rows[0][2].ToString());
            exRange = exSheet.Cells[4][hang + 17]; //Ô A1 
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(tblThongtinHD.Rows[0][1]);
            exRange.Range["A1:C1"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Nhân viên bán hàng";
            exRange.Range["A6:C6"].MergeCells = true;
            exRange.Range["A6:C6"].Font.Italic = true;
            exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A6:C6"].Value = tblThongtinHD.Rows[0][6];
            exSheet.Name = "Hóa đơn nhập";
            exApp.Visible = true;

        }

        private void txtsoluonghdn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtgiamgiahdn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void cbbmahdn_DropDown(object sender, EventArgs e)
        {
            Functions.FillCombo("SELECT madonnhap FROM Hoadonnhap", cbbmahdn, "madonnhap", "madonnhap");
            cbbmahdn.SelectedIndex = -1;
        }

        private void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string mahang;
            Double Thanhtien;
            if (hdn.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                //Xóa hàng và cập nhật lại số lượng hàng 
                mahang = DataGridView.CurrentRow.Cells["masanpham"].Value.ToString();
                DelHangHDN(txtmahoadonnhap.Text, mahang);
                //cập nhật lại tổng tiền cho hóa đơn nhập
                Thanhtien = Convert.ToDouble(DataGridView.CurrentRow.Cells["thanhtien"].Value.ToString());
                DelUpdateTongtienHDN(txtmahoadonnhap.Text, Thanhtien);
                Load_DataGridView();
                ResetValuesmathang();
            }
        }

        private void btnboquahdn_Click(object sender, EventArgs e)
        {
            ResetValue();
            ResetValuesmathang();
            txtmahoadonnhap.Text = "";
            btnboquahdn.Enabled = false;
            btnluuhdn.Enabled = false;
            btnthemhdn.Enabled = true;
            btnxoahdn.Enabled = true;
            btnxoahdn.Enabled = true;
            cbbmahdn.Enabled = true;
            btntimkiemhdn.Enabled = true;
        }

        private void btnsuahdn_Click(object sender, EventArgs e)
        {
            if (cbbmanv.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbbmanv.Focus();
                return;
            }
            if (cbbmancc.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbbmanv.Focus();
                return;
            }
            // Cập nhật thông tin về hóa đơn nhập
            string sql, manhanvien, manhacc;
            sql = $"SELECT manhanvien FROM hoadonnhap WHERE madonnhap=N'{txtmahoadonnhap.Text.Trim()}'";
            manhanvien = Functions.GetFieldValues(sql);
            sql = $"SELECT manhacungcap FROM hoadonnhap WHERE madonnhap=N'{txtmahoadonnhap.Text.Trim()}'";
            manhacc = Functions.GetFieldValues(sql);
            bool hasChanges = false;
            if (cbbmanv.Text != manhanvien || cbbmancc.Text != manhacc)
            {
                sql = $"UPDATE hoadonnhap SET manhanvien= '{cbbmanv.SelectedValue}', manhacungcap='{cbbmancc.SelectedValue}' WHERE madonnhap=N'{txtmahoadonnhap.Text}'";
                Functions.RunSQL(sql);
                hasChanges = true;
            }

            
            if (!string.IsNullOrWhiteSpace(cbbmahang.Text))
            { 
                
                if(cbbmahang.Text!= DataGridView.CurrentRow.Cells["masanpham"].Value.ToString())
                {
                    MessageBox.Show("Bạn không được sửa mã sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbbmahang.Focus();
                    cbbmahang.Text = DataGridView.CurrentRow.Cells["masanpham"].Value.ToString();
                    return;
                }
                if (txtsoluonghdn.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtdongianhap.Focus();
                    return;
                }
                if (txtdongianhap.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập đơn giá nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtdongianhap.Focus();
                    return;
                }
                if (txtgiamgiahdn.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtdongianhap.Focus();
                    return;
                }
                //cập nhật số lượng
                double slCu, slMoi;
                string masanpham = cbbmahang.SelectedValue.ToString();
                slCu = Convert.ToDouble(Functions.GetFieldValues("SELECT Soluong FROM ChitietHDn WHERE madonnhap = N'" + txtmahoadonnhap.Text + "' AND masanpham = N'" + masanpham + "'"));
                slMoi = Convert.ToDouble(txtsoluonghdn.Text);
                if (slMoi != slCu)
                {
                    sql = $"UPDATE ChitietHDn SET Soluong = {slMoi} WHERE madonnhap = N'{txtmahoadonnhap.Text}' AND masanpham = N'{masanpham}'";
                    Functions.RunSQL(sql);
                    double slKho = Convert.ToDouble(Functions.GetFieldValues($"SELECT Soluong FROM Sanpham WHERE masanpham = N'{masanpham}'"));
                    double thayDoi = slMoi - slCu;
                    slKho += thayDoi;
                    sql = $"UPDATE Sanpham SET Soluong = {slKho} WHERE Masanpham = N'{masanpham}'";
                    Functions.RunSQL(sql);
                }
                // cập nhật lại giá trong bảng sản phẩm
                decimal gianhap = Convert.ToInt32(txtdongianhap.Text);
                sql = $"UPDATE sanpham SET gianhap ='{txtdongianhap.Text.Trim()}',giaban= {gianhap}*1.1 WHERE masanpham=N'{cbbmahang.SelectedValue}' ";
                Functions.RunSQL(sql);
                // cập nhật lại giá và thành tiền trong bảng chi tiết hóa đơn nhập
                sql = $"UPDATE chitiethdn SET dongia ='{txtdongianhap.Text.Trim()}', thanhtien= '{txtthanhtienhdn.Text}',khuyenmai='{txtgiamgiahdn.Text}' WHERE madonnhap=N'{txtmahoadonnhap.Text}' and masanpham=N'{cbbmahang.SelectedValue}' ";
                Functions.RunSQL(sql);
                hasChanges = true;
                Load_DataGridView();
                // Cập nhật lại tổng tiền
                double newTotal = 0;
                foreach (DataGridViewRow row in DataGridView.Rows)
                {
                    double thanhtien = Convert.ToDouble(row.Cells["Thanhtien"].Value);
                    newTotal += thanhtien;
                }

                 sql = $"UPDATE hoadonnhap SET Tongtien = {newTotal} WHERE Madonnhap = '{txtmahoadonnhap.Text}'";
                Functions.RunSQL(sql);

                // Lấy thông tin Tổng tiền
                string str = "SELECT tongtien FROM Hoadonnhap WHERE madonnhap = N'" + txtmahoadonnhap.Text + "'";
                txttongtienhdn.Text = Functions.GetFieldValues(str);

                // Chuyển đổi tổng tiền sang chữ
                lblttbangchu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChu(txttongtienhdn.Text);
                if (hasChanges)
                {
                    MessageBox.Show("Thông tin hóa đơn đã được cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không có gì thay đổi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void txtdongianhap_TextChanged(object sender, EventArgs e)
        {
            double tt, sl, dg, gg;
            if (txtsoluonghdn.Text == "")
                sl = 0;
            else sl = Convert.ToDouble(txtsoluonghdn.Text);
            if (txtgiamgiahdn.Text == "")
                gg = 0;
            else gg = Convert.ToDouble(txtgiamgiahdn.Text.Replace("%", ""));
            if (txtdongianhap.Text == "")
                dg = 0;
            else dg = Convert.ToDouble(txtdongianhap.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtthanhtienhdn.Text = tt.ToString();
        }

        private void txtdongianhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có thực sự muốn thoát không", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
