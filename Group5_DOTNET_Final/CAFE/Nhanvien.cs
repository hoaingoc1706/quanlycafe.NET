using CAFE.CLass;
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
    public partial class Nhanvien : Form
    {
        public Nhanvien()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void Nhanvien_Load(object sender, EventArgs e)
        {
            CLass.Functions.connect();
            CLass.Functions.FillCombo("select MaQue from Que", cmbMaque, "MaQue", "MaQue");
            cmbMaque.SelectedIndex = -1;
            txtMaNV.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            ResetValues();
            daGridNhanvien.DataSource = true;
            Load_daGridNhanvien();
            
        }

        private void ResetValues()
        {
            foreach (Control Ctl in this.Controls)
                if (Ctl is TextBox)
                    Ctl.Text = "";
        }

        DataTable NhanVien;
        private void Load_daGridNhanvien()
        {
            string sql;
            sql = "select * from NhanVien";
            NhanVien = CLass.Functions.GetDataToTable(sql);
            daGridNhanvien.DataSource = NhanVien;
            daGridNhanvien.Columns[0].HeaderText = "Mã nhân viên";
            daGridNhanvien.Columns[1].HeaderText = "Tên nhân viên";
            daGridNhanvien.Columns[2].HeaderText = "Địa chỉ";
            daGridNhanvien.Columns[3].HeaderText = "Mã quê";
            daGridNhanvien.Columns[4].HeaderText = "Ngày sinh";
            daGridNhanvien.Columns[5].HeaderText = "Giới tính";
            daGridNhanvien.Columns[6].HeaderText = "Số điện thoại";
            daGridNhanvien.AllowUserToAddRows = true;
            daGridNhanvien.EditMode = DataGridViewEditMode.EditProgrammatically;
            
        }

        private void daGridNhanvien_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo",
    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNV.Focus();
                return;
            }
            if (NhanVien.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK,
    MessageBoxIcon.Information);
                return;
            }
            txtMaNV.Text = daGridNhanvien.CurrentRow.Cells["MaNhanVien"].Value.ToString();
            txtTenNV.Text = daGridNhanvien.CurrentRow.Cells["TenNhanVien"].Value.ToString();
            if (daGridNhanvien.CurrentRow.Cells["GioiTinh"].Value.ToString() == "Nam")
                chkGioitinh.Checked = true;
            else
                chkGioitinh.Checked = false;
            txtDiachi.Text = daGridNhanvien.CurrentRow.Cells["DiaChi"].Value.ToString();
            mskSDT.Text = daGridNhanvien.CurrentRow.Cells["SoDienThoai"].Value.ToString();
            mskNgaysinh.Text = daGridNhanvien.CurrentRow.Cells["NgaySinh"].Value.ToString();
            cmbMaque.Text = daGridNhanvien.CurrentRow.Cells["MaQue"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql, gt;
            if (txtMaNV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nhân viên", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNV.Focus();
                return;
            }
            if (txtTenNV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNV.Focus();
                return;
            }
            if (txtDiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK,
MessageBoxIcon.Warning);
                txtDiachi.Focus();
                return;
            }
            if (mskSDT.Text == "(   )   -    ") 
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskSDT.Focus();
                return;
            }
            if (mskNgaysinh.Text == "  /  /")
            {
                MessageBox.Show("Bạn phải nhập ngày sinh", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskNgaysinh.Focus();
                return;
            }
            if (!Functions.IsDate(mskNgaysinh.Text))
            {
                MessageBox.Show("Bạn phải nhập lại ngày sinh", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskNgaysinh.Text = "";
                mskNgaysinh.Focus();
                return;
            }
            if (chkGioitinh.Checked == true)
                gt = "Nam";
            else
                gt = "Nữ";
            sql = "SELECT MaNhanVien FROM NhanVien WHERE MaNhanVien=N'" + txtMaNV.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã nhân viên này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNV.Focus();
                txtMaNV.Text = "";
                return;
            }
            mskSDT.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            string rawText = mskSDT.Text;

            sql = "INSERT INTO NhanVien(MaNhanVien,TenNhanVien,DiaChi,MaQue,NgaySinh,GioiTinh,SoDienThoai) VALUES(N'" + txtMaNV.Text.Trim() + "', N'" + txtTenNV.Text.Trim() + "', N'" + txtDiachi.Text.Trim() + "', N'" + cmbMaque.Text.Trim() + "', '" + Functions.ConvertDateTime(mskNgaysinh.Text) + "', '" + gt + "', '" +  rawText + "')";
            Functions.RunSQL(sql);
            Load_daGridNhanvien();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaNV.Enabled = false;
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoqua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = true;
            ResetValues();
            txtMaNV.Enabled = true;
            txtMaNV.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql, gt;
            if (NhanVien.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            if (txtMaNV.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenNV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNV.Focus();
                return;
            }
            if (txtDiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtDiachi.Focus();
                return;
            }
            if (mskSDT.Text == "(   )     -   ")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskSDT.Focus();
                return;
            }
            if (mskNgaysinh.Text == "  /  /")
            {
                MessageBox.Show("Bạn phải nhập ngày sinh", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskNgaysinh.Focus();
                return;
            }
            if (cmbMaque.Items.Count == 0)
            {
                MessageBox.Show("Bạn phải chọn mã quê", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMaque.Focus();
                return;
            }
            if (!Functions.IsDate(mskNgaysinh.Text))
            {
                MessageBox.Show("Bạn phải nhập lại ngày sinh", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskNgaysinh.Text = "";
                mskNgaysinh.Focus();
                return;
            }
            if (chkGioitinh.Checked == true)
                gt = "Nam";
            else
                gt = "Nữ";
            string phone = mskSDT.Text.Trim().Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ","");
            sql = "UPDATE NhanVien SET  TenNhanVien=N'" +
                    txtTenNV.Text.Trim().ToString() +
                    "',DiaChi=N'" + txtDiachi.Text.Trim().ToString() +
                    "',SoDienThoai='" + phone + "',GioiTinh=N'" + gt +
                    "',NgaySinh='" + Functions.ConvertDateTime(mskNgaysinh.Text) + "',MaQue='" + cmbMaque.Text +
                    "' WHERE MaNhanVien=N'" + txtMaNV.Text.Trim() + "'";
            Functions.RunSQL(sql);
            Load_daGridNhanvien();
            ResetValues();
            btnBoqua.Enabled = false;
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (NhanVien.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK,
MessageBoxIcon.Information);
                return;
            }
            if (txtMaNV.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo",
MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE NhanVien WHERE MaNhanVien=N'" + txtMaNV.Text + "'";
                Functions.RunSQL(sql);
                Load_daGridNhanvien();
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
            txtMaNV.Enabled = false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void mskNgaysinh_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
