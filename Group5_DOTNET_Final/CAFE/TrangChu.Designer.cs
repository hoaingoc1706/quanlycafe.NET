namespace CAFE
{
    partial class Trangchu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Trangchu));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSidebar = new System.Windows.Forms.PictureBox();
            this.sideBar = new System.Windows.Forms.FlowLayoutPanel();
            this.pnHome = new System.Windows.Forms.Panel();
            this.btnHome = new System.Windows.Forms.Button();
            this.panel10 = new System.Windows.Forms.Panel();
            this.bthbaocaonhap = new System.Windows.Forms.Button();
            this.pnList = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnEmp = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnCus = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnProduct = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnList = new System.Windows.Forms.Button();
            this.pnBills = new System.Windows.Forms.Panel();
            this.btnBill = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnTimkiem = new System.Windows.Forms.Button();
            this.menuTrans = new System.Windows.Forms.Timer(this.components);
            this.sidebarTrans = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSidebar)).BeginInit();
            this.sideBar.SuspendLayout();
            this.pnHome.SuspendLayout();
            this.panel10.SuspendLayout();
            this.pnList.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnBills.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(223)))), ((int)(((byte)(209)))));
            this.panel1.Controls.Add(this.btnSidebar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1156, 40);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnSidebar
            // 
            this.btnSidebar.Image = global::CAFE.Properties.Resources.icons8_menu_32;
            this.btnSidebar.Location = new System.Drawing.Point(11, 3);
            this.btnSidebar.Name = "btnSidebar";
            this.btnSidebar.Size = new System.Drawing.Size(40, 34);
            this.btnSidebar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnSidebar.TabIndex = 1;
            this.btnSidebar.TabStop = false;
            this.btnSidebar.Click += new System.EventHandler(this.btnSidebar_Click);
            // 
            // sideBar
            // 
            this.sideBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(79)))), ((int)(((byte)(42)))));
            this.sideBar.Controls.Add(this.pnHome);
            this.sideBar.Controls.Add(this.panel10);
            this.sideBar.Controls.Add(this.pnList);
            this.sideBar.Controls.Add(this.pnBills);
            this.sideBar.Controls.Add(this.panel2);
            this.sideBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sideBar.Location = new System.Drawing.Point(0, 40);
            this.sideBar.Name = "sideBar";
            this.sideBar.Size = new System.Drawing.Size(66, 651);
            this.sideBar.TabIndex = 1;
            this.sideBar.Paint += new System.Windows.Forms.PaintEventHandler(this.sideBar_Paint);
            // 
            // pnHome
            // 
            this.pnHome.Controls.Add(this.btnHome);
            this.pnHome.Location = new System.Drawing.Point(3, 3);
            this.pnHome.Name = "pnHome";
            this.pnHome.Size = new System.Drawing.Size(200, 54);
            this.pnHome.TabIndex = 2;
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(79)))), ((int)(((byte)(42)))));
            this.btnHome.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnHome.ForeColor = System.Drawing.Color.White;
            this.btnHome.Image = global::CAFE.Properties.Resources.icons8_home_32;
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.Location = new System.Drawing.Point(-7, -12);
            this.btnHome.Margin = new System.Windows.Forms.Padding(0);
            this.btnHome.Name = "btnHome";
            this.btnHome.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnHome.Size = new System.Drawing.Size(216, 77);
            this.btnHome.TabIndex = 3;
            this.btnHome.Text = "Trang chủ";
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.bthbaocaonhap);
            this.panel10.Location = new System.Drawing.Point(0, 60);
            this.panel10.Margin = new System.Windows.Forms.Padding(0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(200, 54);
            this.panel10.TabIndex = 16;
            // 
            // bthbaocaonhap
            // 
            this.bthbaocaonhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(79)))), ((int)(((byte)(42)))));
            this.bthbaocaonhap.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.bthbaocaonhap.ForeColor = System.Drawing.Color.White;
            this.bthbaocaonhap.Image = global::CAFE.Properties.Resources.icons8_statistics_32;
            this.bthbaocaonhap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bthbaocaonhap.Location = new System.Drawing.Point(-12, -12);
            this.bthbaocaonhap.Margin = new System.Windows.Forms.Padding(0);
            this.bthbaocaonhap.Name = "bthbaocaonhap";
            this.bthbaocaonhap.Padding = new System.Windows.Forms.Padding(23, 0, 0, 0);
            this.bthbaocaonhap.Size = new System.Drawing.Size(216, 77);
            this.bthbaocaonhap.TabIndex = 3;
            this.bthbaocaonhap.Text = "Báo cáo";
            this.bthbaocaonhap.UseVisualStyleBackColor = false;
            this.bthbaocaonhap.Click += new System.EventHandler(this.bthbaocaonhap_Click);
            // 
            // pnList
            // 
            this.pnList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(46)))), ((int)(((byte)(21)))));
            this.pnList.Controls.Add(this.panel6);
            this.pnList.Controls.Add(this.panel7);
            this.pnList.Controls.Add(this.panel5);
            this.pnList.Controls.Add(this.panel4);
            this.pnList.Location = new System.Drawing.Point(0, 114);
            this.pnList.Margin = new System.Windows.Forms.Padding(0);
            this.pnList.Name = "pnList";
            this.pnList.Size = new System.Drawing.Size(200, 50);
            this.pnList.TabIndex = 8;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnEmp);
            this.panel6.Location = new System.Drawing.Point(0, 172);
            this.panel6.Margin = new System.Windows.Forms.Padding(0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(200, 54);
            this.panel6.TabIndex = 19;
            // 
            // btnEmp
            // 
            this.btnEmp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(46)))), ((int)(((byte)(21)))));
            this.btnEmp.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnEmp.ForeColor = System.Drawing.Color.White;
            this.btnEmp.Image = global::CAFE.Properties.Resources.icons8_employee_50;
            this.btnEmp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmp.Location = new System.Drawing.Point(-7, -12);
            this.btnEmp.Margin = new System.Windows.Forms.Padding(0);
            this.btnEmp.Name = "btnEmp";
            this.btnEmp.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnEmp.Size = new System.Drawing.Size(216, 77);
            this.btnEmp.TabIndex = 3;
            this.btnEmp.Text = "Nhân viên";
            this.btnEmp.UseVisualStyleBackColor = false;
            this.btnEmp.Click += new System.EventHandler(this.button5_Click);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btnCus);
            this.panel7.Location = new System.Drawing.Point(0, 113);
            this.panel7.Margin = new System.Windows.Forms.Padding(0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(200, 54);
            this.panel7.TabIndex = 16;
            // 
            // btnCus
            // 
            this.btnCus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(46)))), ((int)(((byte)(21)))));
            this.btnCus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnCus.ForeColor = System.Drawing.Color.White;
            this.btnCus.Image = global::CAFE.Properties.Resources.icons8_customer_50;
            this.btnCus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCus.Location = new System.Drawing.Point(-10, -12);
            this.btnCus.Margin = new System.Windows.Forms.Padding(0);
            this.btnCus.Name = "btnCus";
            this.btnCus.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnCus.Size = new System.Drawing.Size(216, 77);
            this.btnCus.TabIndex = 3;
            this.btnCus.Text = "     Khách hàng";
            this.btnCus.UseVisualStyleBackColor = false;
            this.btnCus.Click += new System.EventHandler(this.button6_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnProduct);
            this.panel5.Location = new System.Drawing.Point(3, 56);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(200, 54);
            this.panel5.TabIndex = 14;
            // 
            // btnProduct
            // 
            this.btnProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(46)))), ((int)(((byte)(21)))));
            this.btnProduct.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnProduct.ForeColor = System.Drawing.Color.White;
            this.btnProduct.Image = global::CAFE.Properties.Resources.icons8_coffee_48;
            this.btnProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProduct.Location = new System.Drawing.Point(-7, -12);
            this.btnProduct.Margin = new System.Windows.Forms.Padding(0);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnProduct.Size = new System.Drawing.Size(216, 77);
            this.btnProduct.TabIndex = 3;
            this.btnProduct.Text = "Sản phẩm";
            this.btnProduct.UseVisualStyleBackColor = false;
            this.btnProduct.Click += new System.EventHandler(this.button4_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnList);
            this.panel4.Location = new System.Drawing.Point(0, -4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 54);
            this.panel4.TabIndex = 4;
            // 
            // btnList
            // 
            this.btnList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(79)))), ((int)(((byte)(42)))));
            this.btnList.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnList.ForeColor = System.Drawing.Color.White;
            this.btnList.Image = global::CAFE.Properties.Resources.icons8_dropdown_30;
            this.btnList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnList.Location = new System.Drawing.Point(-4, -12);
            this.btnList.Margin = new System.Windows.Forms.Padding(0);
            this.btnList.Name = "btnList";
            this.btnList.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnList.Size = new System.Drawing.Size(216, 77);
            this.btnList.TabIndex = 3;
            this.btnList.Text = "Danh mục";
            this.btnList.UseVisualStyleBackColor = false;
            this.btnList.Click += new System.EventHandler(this.danhmuc_Click);
            // 
            // pnBills
            // 
            this.pnBills.Controls.Add(this.btnBill);
            this.pnBills.Location = new System.Drawing.Point(3, 167);
            this.pnBills.Name = "pnBills";
            this.pnBills.Size = new System.Drawing.Size(200, 54);
            this.pnBills.TabIndex = 5;
            // 
            // btnBill
            // 
            this.btnBill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(79)))), ((int)(((byte)(42)))));
            this.btnBill.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnBill.ForeColor = System.Drawing.Color.White;
            this.btnBill.Image = global::CAFE.Properties.Resources.icons8_bill_30;
            this.btnBill.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBill.Location = new System.Drawing.Point(-9, -12);
            this.btnBill.Name = "btnBill";
            this.btnBill.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnBill.Size = new System.Drawing.Size(216, 77);
            this.btnBill.TabIndex = 3;
            this.btnBill.Text = "     Hóa đơn";
            this.btnBill.UseVisualStyleBackColor = false;
            this.btnBill.Click += new System.EventHandler(this.btnBill_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnTimkiem);
            this.panel2.Location = new System.Drawing.Point(3, 227);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 54);
            this.panel2.TabIndex = 4;
            // 
            // btnTimkiem
            // 
            this.btnTimkiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(79)))), ((int)(((byte)(42)))));
            this.btnTimkiem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnTimkiem.ForeColor = System.Drawing.Color.White;
            this.btnTimkiem.Image = global::CAFE.Properties.Resources.icons8_search_30;
            this.btnTimkiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTimkiem.Location = new System.Drawing.Point(-7, -12);
            this.btnTimkiem.Margin = new System.Windows.Forms.Padding(0);
            this.btnTimkiem.Name = "btnTimkiem";
            this.btnTimkiem.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnTimkiem.Size = new System.Drawing.Size(216, 77);
            this.btnTimkiem.TabIndex = 3;
            this.btnTimkiem.Text = "Tìm kiếm";
            this.btnTimkiem.UseVisualStyleBackColor = false;
            this.btnTimkiem.Click += new System.EventHandler(this.btnTimkiem_Click);
            // 
            // menuTrans
            // 
            this.menuTrans.Interval = 20;
            this.menuTrans.Tick += new System.EventHandler(this.menuTrans_Tick);
            // 
            // sidebarTrans
            // 
            this.sidebarTrans.Interval = 10;
            this.sidebarTrans.Tick += new System.EventHandler(this.sidebarTrans_Tick);
            // 
            // Trangchu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::CAFE.Properties.Resources.Beige_Modern_Cafe_Banner;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1156, 691);
            this.Controls.Add(this.sideBar);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "Trangchu";
            this.Load += new System.EventHandler(this.Trangchu_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnSidebar)).EndInit();
            this.sideBar.ResumeLayout(false);
            this.pnHome.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.pnList.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.pnBills.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox btnSidebar;
        private System.Windows.Forms.FlowLayoutPanel sideBar;
        private System.Windows.Forms.Panel pnHome;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnList;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel pnList;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btnCus;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnEmp;
        private System.Windows.Forms.Timer menuTrans;
        private System.Windows.Forms.Panel pnBills;
        private System.Windows.Forms.Button btnBill;
        private System.Windows.Forms.Timer sidebarTrans;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnTimkiem;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button bthbaocaonhap;
    }
}

