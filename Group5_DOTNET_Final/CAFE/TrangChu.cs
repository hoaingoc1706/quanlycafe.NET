using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CAFE.CLass;

namespace CAFE
{
    public partial class Trangchu : Form
    {
        bool menuExpand = false;
        bool sidebarExpand = false;
        Trangchu trangchu;
        Nhanvien nv;
        Khachhang kh;
        Sanpham sp;
        Hoadon hoadon;
        Timkiem Timkiem;
        Baocao Baocao;

        public Trangchu()
        {
            InitializeComponent();
            mdiProp();
        }
        private void close_form(Form form)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f != form)
                {
                    f.Close();
                }
            }
        }
        private void mdiProp()
        {
            this.SetBevel(false);
/*            Controls.OfType<MdiClient>().FirstOrDefault().BackColor = Color.FromArgb(232, 234, 237);*/
        }
        private void menuTrans_Tick(object sender, EventArgs e)
        {
            if (menuExpand == false)
            {
                pnList.Height += 20;
                if (pnList.Height >= 228)
                {
                    menuTrans.Stop();
                    menuExpand = true;
                }
            }
            else
            {
                pnList.Height -= 20;
                if (pnList.Height <= 50)
                {
                    menuTrans.Stop();
                    menuExpand = false;
                }
            }
        }
        private void danhmuc_Click(object sender, EventArgs e)
        {
            menuTrans.Start();
        }

        private void sidebarTrans_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sideBar.Width -= 10;
                if (sideBar.Width <= 66)
                {
                    sidebarTrans.Stop();
                    sidebarExpand = false;
                    OnBackgroundImageChanged(null);
                }
            }
            else
            {
                sideBar.Width += 10;
                if (sideBar.Width >= 198)
                {
                    sidebarTrans.Stop();
                    sidebarExpand = true;
                    OnBackgroundImageChanged(null);
                }
                /*pnHome.Width= pnDash.Width = pnList.Width = pnImport.Width = pnBills.Width = pnTable.Width = sideBar.Width;
                */
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (nv == null)
            {
                nv = new Nhanvien();
                nv.FormClosed += Nhanvien_FormClosed;
                nv.MdiParent = this;
                nv.Dock = DockStyle.Fill;
                nv.Show();
                close_form(nv);
            }
            else
            {
                nv.Activate();
            }
        }

        private void Nhanvien_FormClosed(object sender, FormClosedEventArgs e)
        {
            nv = null;
        }

        private void btnSidebar_Click(object sender, EventArgs e)
        {
            sidebarTrans.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (sp == null)
            {
                sp = new Sanpham();
                sp.FormClosed += Sp_FormClosed;
                sp.MdiParent = this;
                sp.Dock = DockStyle.Fill;
                sp.Show();
                close_form(sp);
            }
            else
            {
                sp.Activate();
            }
        }

        private void Sp_FormClosed(object sender, FormClosedEventArgs e)
        {
            sp = null;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (kh == null)
            {
                kh = new Khachhang();
                kh.FormClosed += Kh_FormClosed;
                kh.MdiParent = this;
                kh.Dock = DockStyle.Fill;
                kh.Show();
                close_form(kh);
            }
            else
            {
                kh.Activate();
            }
        }

        private void Kh_FormClosed(object sender, FormClosedEventArgs e)
        {
            kh = null;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (nv == null)
            {
                nv = new Nhanvien();
                nv.FormClosed += Nhanvien_FormClosed;
                nv.MdiParent = this;
                nv.Dock = DockStyle.Fill;
                nv.Show();
                close_form(nv);
            }
            else
            {
                nv.Activate();
            }
        }

        private void btnCLose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                f.Close();
            }
        }

        private void Trangchu_FormClosed(object sender, FormClosedEventArgs e)
        {
            trangchu = null;
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            if (hoadon == null)
            {
                hoadon = new Hoadon();
                hoadon.FormClosed += HoadonFormClosed;
                hoadon.MdiParent = this;
                hoadon.Dock = DockStyle.Fill;
                hoadon.Show();
                close_form(hoadon);

            }
            else
            {
                hoadon.Activate();
            }
        }

        private void HoadonFormClosed(object sender, FormClosedEventArgs e)
        {
            hoadon = null;
        }

        private void sideBar_Paint(object sender, PaintEventArgs e)
        {
            sideBar.BringToFront();
        }




        private void Trangchu_Load(object sender, EventArgs e)
        {
            Functions.connect();
        }


        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            if (Timkiem == null)
            {
                Timkiem = new Timkiem();
                Timkiem.FormClosed += Timkiem_FormClosed;
                Timkiem.MdiParent = this;
                Timkiem.Dock = DockStyle.Fill;
                Timkiem.Show();
                close_form(Timkiem);
            }
            else
            {
                Timkiem.Activate();
            }
        }

        private void Timkiem_FormClosed(object sender, FormClosedEventArgs e)
        {
            Timkiem = null;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bthbaocaonhap_Click(object sender, EventArgs e)
        {
            if (Baocao == null)
            {
                Baocao = new Baocao();
                Baocao.FormClosed += Baocao_FormClosed;
                Baocao.MdiParent = this;
                Baocao.Dock = DockStyle.Fill;
                Baocao.Show();
                close_form(Baocao);
            }
            else
            {
                Baocao.Activate();
            }
        }

        private void Baocao_FormClosed(object sender, FormClosedEventArgs e)
        {
            Baocao = null;
        }
    }
}
