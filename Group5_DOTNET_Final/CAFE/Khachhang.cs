using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAFE
{
    public partial class Khachhang : Form
    {
        public Khachhang()
        {
            InitializeComponent();
        }

        private void Khachhang_Load(object sender, EventArgs e)
        {
            CLass.Functions.connect();
            txtMakhach.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            ResetValues();
            dgridKhachHang.DataSource = null;
            Load_dgridKhachhang();
        }
        private void ResetValues()
        {
            foreach (Control Ctl in this.Controls)
                if (Ctl is TextBox)
                    Ctl.Text = "";
            txtMakhach.Text = "";
            txtTenkhach.Text = "";
            txtDiachi.Text = "";
            mskSdt.Clear();
        }
        DataTable KhachHang;
        private void Load_dgridKhachhang()
        {
            string sql;
            sql = "select MaKhachHang, TenKhachHang, DiaChi, SoDienThoai from KhachHang";
            KhachHang = CLass.Functions.GetDataToTable(sql);
            dgridKhachHang.DataSource = KhachHang;
            dgridKhachHang.Columns[0].HeaderText = "Mã khách hàng";
            dgridKhachHang.Columns[1].HeaderText = "Tên khách hàng";
            dgridKhachHang.Columns[2].HeaderText = "Địa chỉ";
            dgridKhachHang.Columns[3].HeaderText = "Số điện thoại";
            dgridKhachHang.AllowUserToAddRows = false;
            dgridKhachHang.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void dgridKhachhang_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("khong co du lieu", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtMakhach.Text = dgridKhachHang.CurrentRow.Cells["maKhachHang"].Value.ToString();
            txtTenkhach.Text = dgridKhachHang.CurrentRow.Cells["tenKhachHang"].Value.ToString();
            txtDiachi.Text = dgridKhachHang.CurrentRow.Cells["diaChi"].Value.ToString();
            mskSdt.Text = dgridKhachHang.CurrentRow.Cells["soDienThoai"].Value.ToString();


            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnBoqua.Enabled = true;
            txtMakhach.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            ResetValues();
        }
       

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMakhach.Text == "")
            {
                MessageBox.Show("Phải nhập Mã Khách Hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMakhach.Focus();
                return;
            }
            if (txtTenkhach.Text == "")
            {
                MessageBox.Show("Phải nhập Tên Khách Hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenkhach.Focus();
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtTenkhach.Text, "^[a-zA-ZÀ-ỹà-ỹ\\s]+$"))
            {
                MessageBox.Show("Tên Khách Hàng chỉ được chứa chữ cái và khoảng trắng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenkhach.Focus();
                return;
            }
            if (txtDiachi.Text == "")
            {
                MessageBox.Show("Phải nhập Địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDiachi.Focus();
                return;
            }

            string phoneNumber = mskSdt.Text.Trim();
            if (phoneNumber.Length == 0 || phoneNumber == "(   )    -")
            {
                MessageBox.Show("Phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mskSdt.Focus();
                return;
            }
            if (phoneNumber.Length < 14 )
            {
                MessageBox.Show("Phải nhập số điện thoại đủ 10 số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mskSdt.Focus();
                return;
            }

            // Kiểm tra trùng mã
            string sql;
            sql = "SELECT MaKhachHang FROM KhachHang WHERE MaKhachHang = N'" + txtMakhach.Text.Trim() + "'";
            if (CLass.Functions.CheckKey(sql))
            {
                MessageBox.Show("Bị trùng mã khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMakhach.Focus();
                txtMakhach.Text = "";
                return;
            }

            sql = "INSERT INTO KhachHang(MaKhachHang, TenKhachHang, DiaChi, SoDienThoai) VALUES(N'" + txtMakhach.Text + "', N'" + txtTenkhach.Text + "', N'" + txtDiachi.Text + "', '" + mskSdt.Text + "')";
            CLass.Functions.RunSQL(sql);
            Load_dgridKhachhang();
            btnThem.Enabled = true; // Nút Thêm nổi 
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false; // Nút Lưu ẩn 
            btnBoqua.Enabled = false;
            txtMakhach.Enabled = false;
            ResetValues();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (KhachHang.Rows.Count == 0)
            {
                MessageBox.Show("Khong co du lieu", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtMakhach.Text == "")
            {
                MessageBox.Show("Chua chon ban ghi nao de xoa", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Ban co muon xoa khong", "Thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.OK) ;
            {
                sql = "delete KhachHang where MaKhachHang=N'" + txtMakhach.Text + "'";
                CLass.Functions.RunSQL(sql);
                Load_dgridKhachhang();
                ResetValues();
            }

        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnBoqua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMakhach.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (KhachHang.Rows.Count == 0)
            {
                MessageBox.Show("khong co du lieu", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Nếu mã rỗng tức chưa click vào datagridview 
            if (txtMakhach.Text == "")
            {
                MessageBox.Show("Chua chon ban ghi nao de xoa", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtTenkhach.Text == "")
            {
                MessageBox.Show("Ban phai nhap ten khach", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenkhach.Focus();
                return;
            }
            if (txtDiachi.Text == "")
            {
                MessageBox.Show("Ban phai nhap dia chi", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDiachi.Focus();
                return;
            }
            if (mskSdt.Text == "")
            {
                MessageBox.Show("Ban phai nhap so dien thoai", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mskSdt.Focus();
                return;
            }
            string sql;
            sql = "UPDATE KhachHang SET TenKhachHang=N'" + txtTenkhach.Text.ToString() +
           "', DiaChi=N'" + txtDiachi.Text.ToString() +
           "', SoDienThoai='" + mskSdt.Text.ToString() +
           "' WHERE MaKhachHang=N'" + txtMakhach.Text + "'";

            CLass.Functions.RunSQL(sql);
            Load_dgridKhachhang();
            ResetValues();
            btnBoqua.Enabled = false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTenkhach_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
