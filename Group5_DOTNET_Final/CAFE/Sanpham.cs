using CAFE.CLass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace CAFE
{
    public partial class Sanpham : Form
    {
        public Sanpham()
        {
            InitializeComponent();
        }
        DataTable sp;
        private void Sanpham_Load(object sender, EventArgs e)
        {
            btnhienthi.Enabled = false;
            btntimkiem.Enabled = true;
            btnxoa.Enabled = false;
            CLass.Functions.connect();
            txtsoluong.ReadOnly = true;
            btnsua.Enabled = false;
            btnluu.Enabled = false;
            btnboqua.Enabled = false;
            txtdongianhap.ReadOnly = true;
            Load_DataGridView();
            
            Functions.FillCombo("SELECT maloai,tenloai FROM loai", cbbmaloai, "maloai", "tenloai");
            Functions.FillCombo("SELECT macongdung,tencongdung FROM congdung", cbbmacongdung, "macongdung", "tencongdung");
            cbbmaloai.SelectedIndex = -1;
            cbbmacongdung.SelectedIndex = -1;
            txtdongiaban.ReadOnly = true;
            ResetValue();
        }
        private void Load_DataGridView()
        {
            string sql = "SELECT masanpham,tensanpham,maloai,giaban,soluong,hinhanh,macongdung,gianhap FROM sanpham";
            sp = CLass.Functions.GetDataToTable(sql);
            DataGridView.DataSource = sp;
            DataGridView.Columns[0].HeaderText = "Mã sản phẩm";
            DataGridView.Columns[1].HeaderText = "Tên sản phẩm";
            DataGridView.Columns[2].HeaderText = "Mã loại";
            DataGridView.Columns[3].HeaderText = "Giá bán";
            DataGridView.Columns[4].HeaderText = "Số lượng";
            DataGridView.Columns[5].HeaderText = "Hình Ảnh";
            DataGridView.Columns[6].HeaderText = "Mã công dụng";
            DataGridView.Columns[7].HeaderText = "Giá nhập";
            DataGridView.AllowUserToAddRows = false;
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void ResetValue()
        {
            txtmasp.Text = "";
            txttensp.Text = "";
            cbbmaloai.Text = "";
            txtsoluong.Text = "";
            txtdongiaban.Text = "";
            txtanh.Text = "";
            txtdongianhap.Text = "";
            cbbmacongdung.Text = "";
            pictureBox1.Image = null;
        }

        private void DataGridView_Click(object sender, EventArgs e)
        {
           
            if (DataGridView.Rows.Count == 0)
            {
                MessageBox.Show("Không còn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (btnthem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmasp.Focus();
                return;
            }
            else
            {
                txtmasp.Text = DataGridView.CurrentRow.Cells["masanpham"].Value.ToString();
                txttensp.Text = DataGridView.CurrentRow.Cells["tensanpham"].Value.ToString();
                string maloai = DataGridView.CurrentRow.Cells["maloai"].Value.ToString();
                cbbmaloai.Text = Functions.GetFieldValues($"SELECT tenloai FROM Loai WHERE maloai = N'{maloai}'");
                txtdongiaban.Text = DataGridView.CurrentRow.Cells["giaban"].Value.ToString();
                txtdongianhap.Text = DataGridView.CurrentRow.Cells["gianhap"].Value.ToString();
                string macongdung = DataGridView.CurrentRow.Cells["macongdung"].Value.ToString();
                txtsoluong.Text = DataGridView.CurrentRow.Cells["soluong"].Value.ToString();
                cbbmacongdung.Text = Functions.GetFieldValues($"SELECT tencongdung FROM congdung where macongdung =N'{macongdung}'");
                txtanh.Text = DataGridView.CurrentRow.Cells["hinhanh"].Value.ToString();
                if (File.Exists(txtanh.Text))
                {
                    pictureBox1.Image = Image.FromFile(txtanh.Text);
                }
                else
                {
                    pictureBox1.Image = null;
                }
            }
            btnhienthi.Enabled = true;
            btntimkiem.Enabled = true;
            btnxoa.Enabled = true;
            btnsua.Enabled = true;
            txtmasp.ReadOnly = true;
            cbbmacongdung.Enabled = false;
            cbbmaloai.Enabled = false; 
            
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            ResetValue();
            txtmasp.Text = Functions.CreateCodeWithPrefix("sanpham", "masanpham", "SP");
            txtmasp.Enabled = false;
            cbbmacongdung.Enabled = false;
            cbbmaloai.Enabled = false;
            btnthem.Enabled = false;
            btnluu.Enabled = true;
            btnboqua.Enabled = true;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            cbbmaloai.Enabled = true;
            btnhienthi.Enabled = false;
            cbbmacongdung.Enabled = true;
            btntimkiem.Enabled = false;

        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string sql;


            if (string.IsNullOrWhiteSpace(txttensp.Text))
            {
                MessageBox.Show("Bạn phải nhập tên sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttensp.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(cbbmacongdung.Text))
            {
                MessageBox.Show("Bạn phải nhập mã công dụng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbbmacongdung.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(cbbmaloai.Text))
            {
                MessageBox.Show("Bạn phải chọn mã loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbbmaloai.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtanh.Text))
            {
                MessageBox.Show("Bạn phải nhập ảnh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtanh.Focus();
                return;
            }
          

            sql = $"INSERT INTO sanpham(masanpham,tensanpham,maloai,giaban,soluong,hinhanh,macongdung,gianhap) VALUES " +
$"(N'{txtmasp.Text.Trim()}',N'{txttensp.Text.Trim()}',N'{cbbmaloai.SelectedValue}',N'{txtdongiaban.Text.Trim()}',N'{txtsoluong.Text.Trim()}',N'{txtanh.Text.Trim()}',N'{cbbmacongdung.SelectedValue}',N'{txtdongianhap.Text.Trim()}')";
            CLass.Functions.RunSQL(sql);
            MessageBox.Show("Bạn đã thêm 1 sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Load_DataGridView();
            ResetValue();
            btnxoa.Enabled = true;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnboqua.Enabled = false;
            btnluu.Enabled = false;
            txtmasp.Enabled = false;
            cbbmacongdung.Enabled = false;
            cbbmaloai.Enabled = false;
        }

        private void btnboqua_Click(object sender, EventArgs e)
        {
            ResetValue();
            btnboqua.Enabled = false;
            btnluu.Enabled = false;
            btnxoa.Enabled = false;
            btnsua.Enabled = false;
            btntimkiem.Enabled = true;
            btnthem.Enabled = true;
            txtmasp.Enabled = true;


        }

        private void btndong_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có thực sự muốn thoát không", "Thông báo", MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                this.Close();
            }

        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string sql;
            sql = $"SELECT masanpham FROM chitiethdn WHERE masanpham=N'{txtmasp.Text.Trim()}'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Bạn không được xóa sản phẩm này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (sp.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtmasp.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE sanpham WHERE masanpham= N'" + txtmasp.Text + "'";
                Functions.RunSQL(sql);
                Load_DataGridView();
                ResetValue();
            }


        }

        private void btnsua_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txttensp.Text))
            {
                MessageBox.Show("Bạn phải chọn 1 bản ghi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttensp.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtanh.Text))
            {
                MessageBox.Show("Bạn phải nhập ảnh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtanh.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtdongiaban.Text))
            {
                MessageBox.Show("Bạn phải nhập đơn giá bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtdongiaban.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtdongianhap.Text))
            {
                MessageBox.Show("Bạn phải nhập đơn giá nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtdongiaban.Focus();
                return;
            }
             
            string sql = $"UPDATE sanpham SET tensanpham=N'{txttensp.Text}', soluong={txtsoluong.Text.Trim()}, hinhanh=N'{txtanh.Text.Trim()}', giaban={txtdongiaban.Text.Trim()}, gianhap={txtdongianhap.Text.Trim()} WHERE masanpham=N'{txtmasp.Text.Trim()}'";
            Functions.RunSQL(sql);
            MessageBox.Show("Bạn đã cập nhật sản phẩm thành công","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
            Load_DataGridView();
            ResetValue();

            btnboqua.Enabled = false;
            
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {

            string sql;
            if ((txtmasp.Text == "") && (txttensp.Text == "") && (cbbmaloai.Text == "") && (cbbmacongdung.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM sanpham WHERE 1=1";
            if (txtmasp.Text != "")
                sql = sql + " AND masanpham Like N'%" + txtmasp.Text + "%'";
            if (txttensp.Text != "")
                sql = sql + " AND tensanpham Like N'%" + txttensp.Text + "%'";
            if (cbbmaloai.Text != "")
                sql = sql + " AND maloai Like N'%" + cbbmaloai.SelectedValue + "%'";
            if (cbbmacongdung.Text != "")
                sql = sql + " AND macongdung Like N'%" + cbbmacongdung.SelectedValue + "%'";
            sp = Functions.GetDataToTable(sql);
            if (sp.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Có " + sp.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DataGridView.DataSource = sp;
            btnhienthi.Enabled = true;

        }

        private void btnopen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "All Files (*.*)|*.*|Bitmap Files (*.bmp)|*.bmp|GIF Files (*.gif)|*.gif";
            dlgOpen.InitialDirectory = "C:\\Users\\Admin\\Pictures";
            dlgOpen.FilterIndex = 0;
            dlgOpen.Title = "Chọn hình ảnh để hiển thị";

            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(dlgOpen.FileName);
                txtanh.Text = dlgOpen.FileName;
            }
        }

        private void btnhienthi_Click(object sender, EventArgs e)
        {
            ResetValue();
            Load_DataGridView();
            txtmasp.ReadOnly = false;
            cbbmaloai.Enabled = true;
            cbbmacongdung.Enabled = true;
        }

        

        
        }
    }
