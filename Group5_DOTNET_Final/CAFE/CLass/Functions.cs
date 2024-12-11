using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAFE.CLass
{
    internal class Functions
    {
        public static SqlConnection conn;
        public static string connString;
          
        public static void connect()
        {
            connString = @"Data Source=HOAINGOC\MSSQLSERVER02;Initial Catalog=QLCafe;Integrated Security=True;Encrypt=False";
            conn = new SqlConnection();
            conn.ConnectionString = connString;
            conn.Open();
        }
        public static void disconnect() {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();   	//Đóng kết nối
                conn.Dispose();     //Giải phóng tài nguyên
                conn = null;
            }
        }
        public static DataTable GetDataToTable(string sql)
        {
            SqlDataAdapter Mydata = new SqlDataAdapter(sql, Functions.conn);
            DataTable table = new DataTable();
            Mydata.Fill(table);
            return table;
        }
        public static void RunSQL(string sql)
        {
            SqlCommand cmd;	// Khai báo đối tượng SqlCommand
            cmd = new SqlCommand();	// Khởi tạo đối tượng
            cmd.Connection = Functions.conn;	// Kết nối
            cmd.CommandText = sql;	// Gán câu lệnh SQL
            try
            {
                cmd.ExecuteNonQuery();	// Thực hiện câu lệnh SQL
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            cmd.Dispose();	// Giải phóng bộ nhớ
            cmd = null;
        }
        public static bool CheckKey(string sql)
        {
            SqlDataAdapter Mydata = new SqlDataAdapter(sql, Functions.conn);
            DataTable table = new DataTable();
            Mydata.Fill(table);
            if (table.Rows.Count > 0)
                return true;
            else return false;
        }
        public static bool IsDate(string d)
        {
            string[] parts = d.Split('/');
            if ((Convert.ToInt32(parts[0]) >= 1) && (Convert.ToInt32(parts[0]) <= 31) &&
(Convert.ToInt32(parts[1]) >= 1) && (Convert.ToInt32(parts[1]) <= 12) && (Convert.ToInt32(parts[2]) >= 1900))
                return true;
            else
                return false;
        }

        public static void FillCombo(string sql, ComboBox cbo, string ma, string ten)
        {
            SqlDataAdapter Mydata = new SqlDataAdapter(sql, Functions.conn);
            DataTable table = new DataTable();
            Mydata.Fill(table);
            cbo.DataSource = table;
            cbo.ValueMember = ma;	//Trường giá trị
            cbo.DisplayMember = ten;	//Trường hiển thị
        }
        public static string GetFieldValues(string sql)
        {
            string ma = "";
            SqlCommand cmd = new SqlCommand(sql, Functions.conn);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
                ma = reader.GetValue(0).ToString();
            reader.Close();
            return ma;
        }
        public static void RunSqlDel(string sql)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Functions.conn;
            cmd.CommandText = sql;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (System.Exception)
            {
                MessageBox.Show("Dữ liệu đang được dùng, không thể xóa...", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            cmd.Dispose();
            cmd = null;
        }



        private static string GetLastCustomerID()
        {
            string query = "SELECT TOP 1 MaKhachHang FROM Khachhang ORDER BY MaKhachHang DESC";
            SqlCommand cmd = new SqlCommand(query, conn);
            object result = cmd.ExecuteScalar();
            return result != null ? result.ToString() : null;
        }
        public static string CreateCustomerKey()
        {
            string lastCustomerID = GetLastCustomerID();
            if (string.IsNullOrEmpty(lastCustomerID))
            {
                return "KH01"; // Nếu không có nhân viên nào, bắt đầu từ NV01
            }
            // Tách phần số từ mã nhân viên
            int soPart = int.Parse(lastCustomerID.Substring(2));
            soPart++; // Tăng số lên 1

            // Tạo mã nhân viên mới
            return "KH" + soPart.ToString("D2");
        }
        private static string GetLastHDBID()
        {
            string query = "SELECT TOP 1 MaHoaDon FROM Hoadon ORDER BY MahoaDon DESC";
            SqlCommand cmd = new SqlCommand(query, conn);
            object result = cmd.ExecuteScalar();
            return result != null ? result.ToString() : null;
        }
        private static string GetLastHDNID()
        {
            string query = "SELECT TOP 1 MaDonNhap FROM HoadonNhap ORDER BY MaDonNhap DESC";
            SqlCommand cmd = new SqlCommand(query, conn);
            object result = cmd.ExecuteScalar();
            return result != null ? result.ToString() : null;
        }
        public static string CreateHDNKey()
        {
            string lastHDNID = GetLastHDNID();
            if (string.IsNullOrEmpty(lastHDNID))
            {
                return "HDN01"; // Nếu không có hoadon nào, bắt đầu từ NV01
            }
            // Tách phần số từ mã nhân viên
            int soPart = int.Parse(lastHDNID.Substring(3));
            soPart++; // Tăng số lên 1

            // Tạo mã mới
            return "HDN" + soPart.ToString("D2");
        }
        public static string CreateHDBKey()
        {
            string lastHDBID = GetLastHDBID();
            if (string.IsNullOrEmpty(lastHDBID))
            {
                return "HD01"; // Nếu không có hoadon nào, bắt đầu từ NV01
            }
            // Tách phần số từ mã nhân viên
            int soPart = int.Parse(lastHDBID.Substring(2));
            soPart++; // Tăng số lên 1

            // Tạo mã nhân viên mới
            return "HD" + soPart.ToString("D2");
        }
        public static string ConvertDateTime(string d)
        {
            string[] parts = d.Split('/');
            string dt = String.Format("{0}/{1}/{2}", parts[1], parts[0], parts[2]);
            return dt;
        }

        public static string ChuyenSoSangChu(string sNumber)
        {
            int mLen, mDigit;
            string mTemp = "";
            string[] mNumText;
            //Xóa các dấu "," nếu có
            sNumber = sNumber.Replace(",", "");
            mNumText = "không;một;hai;ba;bốn;năm;sáu;bảy;tám;chín".Split(';');
            mLen = sNumber.Length - 1; // trừ 1 vì thứ tự đi từ 0
            for (int i = 0; i <= mLen; i++)
            {
                mDigit = Convert.ToInt32(sNumber.Substring(i, 1));
                mTemp = mTemp + " " + mNumText[mDigit];
                if (mLen == i) // Chữ số cuối cùng không cần xét tiếp
                    break;
                switch ((mLen - i) % 9)
                {
                    case 0:
                        mTemp = mTemp + " tỷ";
                        if (sNumber.Substring(i + 1, 3) == "000")
                            i = i + 3;
                        if (sNumber.Substring(i + 1, 3) == "000")
                            i = i + 3;
                        if (sNumber.Substring(i + 1, 3) == "000")
                            i = i + 3;
                        break;
                    case 6:
                        mTemp = mTemp + " triệu";
                        if (sNumber.Substring(i + 1, 3) == "000")
                            i = i + 3;
                        if (sNumber.Substring(i + 1, 3) == "000")
                            i = i + 3;
                        break;
                    case 3:
                        mTemp = mTemp + " nghìn";
                        if (sNumber.Substring(i + 1, 3) == "000")
                            i = i + 3;
                        break;
                    default:
                        switch ((mLen - i) % 3)
                        {
                            case 2:
                                mTemp = mTemp + " trăm";
                                break;
                            case 1:
                                mTemp = mTemp + " mươi";
                                break;
                        }
                        break;
                }
            }
            //Loại bỏ trường hợp x00
            mTemp = mTemp.Replace("không mươi không ", "");
            mTemp = mTemp.Replace("không mươi không", "");
            //Loại bỏ trường hợp 00x
            mTemp = mTemp.Replace("không mươi ", "linh ");
            //Loại bỏ trường hợp x0, x>=2
            mTemp = mTemp.Replace("mươi không", "mươi");
            //Fix trường hợp 10
            mTemp = mTemp.Replace("một mươi", "mười");
            //Fix trường hợp x4, x>=2
            mTemp = mTemp.Replace("mươi bốn", "mươi tư");
            //Fix trường hợp x04
            mTemp = mTemp.Replace("linh bốn", "linh tư");
            //Fix trường hợp x5, x>=2
            mTemp = mTemp.Replace("mươi năm", "mươi lăm");
            //Fix trường hợp x1, x>=2
            mTemp = mTemp.Replace("mươi một", "mươi mốt");
            //Fix trường hợp x15
            mTemp = mTemp.Replace("mười năm", "mười lăm");
            //Bỏ ký tự space
            mTemp = mTemp.Trim();
            //Viết hoa ký tự đầu tiên
            mTemp = mTemp.Substring(0, 1).ToUpper() + mTemp.Substring(1) + " đồng";
            return mTemp;
        }
        //Hàm tạo khóa có dạng: TientoNgaythangnam_giophutgiay
        public static string CreateKey(string tiento)
        {
            string key = tiento;
            string[] partsDay;
            partsDay = DateTime.Now.ToShortDateString().Split('/');
            //Ví dụ 07/08/2009
            string d = String.Format("{0}{1}{2}", partsDay[0], partsDay[1], partsDay[2]);
            key = key + d;
            string[] partsTime;
            partsTime = DateTime.Now.ToLongTimeString().Split(':');
            //Ví dụ 7:08:03 PM hoặc 7:08:03 AM
            if (partsTime[2].Substring(3, 2) == "PM")
                partsTime[0] = ConvertTimeTo24(partsTime[0]);
            if (partsTime[2].Substring(3, 2) == "AM")
                if (partsTime[0].Length == 1)
                    partsTime[0] = "0" + partsTime[0];
            //Xóa ký tự trắng và PM hoặc AM
            partsTime[2] = partsTime[2].Remove(2, 3);
            string t;
            t = String.Format("{0}{1}{2}", partsTime[0], partsTime[1], partsTime[2]);
            key = key + t;
            return key;
        }
        public static string ConvertTimeTo24(string hour)
        {
            string h = "";
            switch (hour)
            {
                case "1":
                    h = "13";
                    break;
                case "2":
                    h = "14";
                    break;
                case "3":
                    h = "15";
                    break;
                case "4":
                    h = "16";
                    break;
                case "5":
                    h = "17";
                    break;
                case "6":
                    h = "18";
                    break;
                case "7":
                    h = "19";
                    break;
                case "8":
                    h = "20";
                    break;
                case "9":
                    h = "21";
                    break;
                case "10":
                    h = "22";
                    break;
                case "11":
                    h = "23";
                    break;
                case "12":
                    h = "0";
                    break;
            }
            return h;
        }
        public static int GetMaxNumberFromCode(string table, string column, string prefix)
        {
            string sql = $"SELECT MAX({column}) FROM {table} WHERE {column} LIKE '{prefix}%'";
            object result = GetFieldValues(sql);
            if (result != null && result.ToString() != "")
            {
                string maxCode = result.ToString();
                // Lấy phần số sau tiền tố
                int numberStartIndex = prefix.Length;
                string numberPart = maxCode.Substring(numberStartIndex);
                if (int.TryParse(numberPart, out int maxNumber))
                {
                    return maxNumber;
                }
            }
            return 0;  // Trả về 0 nếu không tìm thấy mã nào
        }
        public static string CreateCodeWithPrefix(string table, string column, string prefix)
        {
            int maxNumber = GetMaxNumberFromCode(table, column, prefix);
            maxNumber++;  // Tăng số lên
            return $"{prefix}{maxNumber:D2}";  // Tạo mã mới, ví dụ SP03
        }

    }
}
