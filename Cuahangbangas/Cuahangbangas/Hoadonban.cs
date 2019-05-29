using Cửa_hàng_Gia_Thịnh;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using COMExcel = Microsoft.Office.Interop.Excel;

namespace Cuahangbangas
{
    public partial class Hoadonban : Form
    {
        public Hoadonban()
        {
            InitializeComponent();
        }
        DataTable tblCTHDB;
        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void Hoadonban_Load(object sender, EventArgs e)
        {
          btnThemmoi.Enabled = true;
            btnLuu.Enabled = false;
            btnXoaHD.Enabled = false;
            btnInhoadon.Enabled = false;
            txtTongtien.Enabled = false;
            txtMaHDBan.ReadOnly = false;
            txtTennhanvien.ReadOnly = true;
            txtTenkhachhang.ReadOnly = true;
            txtDiachi.ReadOnly = true;
            txtDienthoai.ReadOnly = true;
            txtTenhang.ReadOnly = true;
            txtSoluong.Enabled = true;
            txtDongia.ReadOnly = true;
            txtThanhtien.ReadOnly = true;
            txtTongtien.ReadOnly = true;
            cbokhuyenmai.Text = "";
            txtThanhtien.Text = "0";
            txtTongtien.Text = "0";
            Functions.FillCombo("SELECT makhach FROM tblkhach", cboMakhachhang, "makhach", "makhach");
            cboMakhachhang.SelectedIndex = -1;
            Functions.FillCombo("SELECT manv FROM tblnhanvien", cboManhanvien, "manv", "manv");
            cboManhanvien.SelectedIndex = -1;
            Functions.FillCombo("SELECT mahang FROM tblhang", cboMahang, "mahang", "mahang");
            cboMahang.SelectedIndex = -1;
            if (txtMaHDBan.Text != "")
            {
                Load_ThongtinHD();
                btnXoaHD.Enabled = true;
                btnInhoadon.Enabled = true;
            }
            Load_DataGridViewChitiet();
        }
        private void Load_DataGridViewChitiet()
        {
            string sql;
            sql = "SELECT a.mahdban, a.mahang, b.tenhang, a.soluong, b.dongiaban, a.khuyenmai, a.thanhtien FROM tblchitiethdban AS a, tblhang AS b WHERE a.mahdban = N'" + txtMaHDBan.Text + "' AND a.mahang=b.mahang";
            tblCTHDB = Functions.GetDataToTable(sql);
            dataGridViewChitiet.DataSource = tblCTHDB;
            dataGridViewChitiet.Columns[0].HeaderText = "Mã hóa đơn";
            dataGridViewChitiet.Columns[1].HeaderText = "Mã hàng";
            dataGridViewChitiet.Columns[2].HeaderText = "Tên hàng";
            dataGridViewChitiet.Columns[3].HeaderText = "Số lượng";
            dataGridViewChitiet.Columns[4].HeaderText = "Đơn giá";
            dataGridViewChitiet.Columns[5].HeaderText = "Khuyến mãi";
            dataGridViewChitiet.Columns[6].HeaderText = "Thành tiền";
            dataGridViewChitiet.Columns[0].Width = 100;
            dataGridViewChitiet.Columns[1].Width = 110;
            dataGridViewChitiet.Columns[2].Width = 110;
            dataGridViewChitiet.Columns[3].Width = 100;
            dataGridViewChitiet.Columns[4].Width = 120;
            dataGridViewChitiet.Columns[5].Width = 120;
            dataGridViewChitiet.Columns[6].Width = 120;
            dataGridViewChitiet.AllowUserToAddRows = false;
            dataGridViewChitiet.EditMode = DataGridViewEditMode.EditProgrammatically;

        }
        private void Load_ThongtinHD()
        {

            string str;
            str = "SELECT ngayban FROM tblhdban WHERE mahdban = N'" + txtMaHDBan.Text + "'";
            mskNgayban.Text = Functions.GetFieldValues(str);
            str = "SELECT manv FROM tblhdban WHERE mahdban = N'" + txtMaHDBan.Text + "'";
            cboManhanvien.Text = Functions.GetFieldValues(str);
            str = "SELECT makhach FROM tblhdban WHERE mahdban = N'" + txtMaHDBan.Text + "'";
            cboMakhachhang.Text = Functions.GetFieldValues(str);
            str = "SELECT tongtien FROM tblhdban WHERE mahdban = N'" + txtMaHDBan.Text + "'";
            txtTongtien.Text = Functions.GetFieldValues(str);
            labelbangchu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChu(txtTongtien.Text);
        }

        private void btnThemmoi_Click(object sender, EventArgs e)
        {
            btnXoaHD.Enabled = false;
            btnLuu.Enabled = true;
            btnInhoadon.Enabled = false;
            btnThemmoi.Enabled = false;
            ResetValues();
            Load_DataGridViewChitiet();
        }
        private void ResetValues()
        {
            txtMaHDBan.Text = "";
            mskNgayban.Text = DateTime.Now.ToShortDateString();
            cboManhanvien.Text = "";
            cboMakhachhang.Text = "";
            labelbangchu.Text = "Bằng chữ: ";
            cboMahang.Text = "";
            txtSoluong.Text = "";
            txtTennhanvien.Text = "";
            txtTenkhachhang.Text = "";
            txtDiachi.Text = "";
            txtDienthoai.Text = "";
            txtDongia.Text = "";
            txtTongtien.Enabled = false;
            txtTongtien.Text = "0";
            cbokhuyenmai.Text = "";
            txtThanhtien.Text = "0";
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            /*if (cboMaHDBan.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMaHDBan.Focus();
                return;
            }
            txtMaHDBan.Text = cboMaHDBan.Text;*/
            /*if(dtp.Text=="")
            {
                MessageBox.Show("Bạn chọn ngày!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
                return;
            }*/
            string sql;
            sql = "TKHD'"+dtp.Text.ToString()+"'";
            tblCTHDB = Functions.GetDataToTable(sql);
            dataGridViewChitiet.DataSource = tblCTHDB;
            //Load_ThongtinHD();
            //Load_DataGridViewChitiet();
            dataGridViewChitiet.Show();
            btnXoaHD.Enabled = true;
            btnLuu.Enabled = true;
            btnInhoadon.Enabled = true;
            
            //cboMaHDBan.SelectedIndex = -1;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            double sl, SLcon, tong, Tongmoi;
            sql = "SELECT mahdban FROM tblhdban WHERE mahdban=N'" + txtMaHDBan.Text + "'";
            Functions.RunSql(sql);
            if (!Functions.CheckKey(sql))
            {
                if(txtMaHDBan.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập mã hóa đơn bán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaHDBan.Focus();
                    return;
                    
                }
                if (mskNgayban.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập ngày bán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    mskNgayban.Focus();
                    return;
                }
                if (cboManhanvien.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải chọn nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboManhanvien.Focus();
                    return;
                }
                if (cboMakhachhang.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải chọn khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboMakhachhang.Focus();
                    return;
                }
                sql = "INSERT INTO tblhdban(mahdban, ngayban, manv, makhach, tongtien) VALUES (N'" + txtMaHDBan.Text.Trim() + "','" + Convert.ToDateTime(mskNgayban.Text.Trim()) + "',N'" + cboManhanvien.Text + "',N'" + cboMakhachhang.SelectedValue + "'," + txtTongtien.Text + ")";
                Functions.RunSql(sql);
            }
            if (cboMahang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMahang.Focus();
                return;
            }
            if ((txtSoluong.Text.Trim().Length == 0) || (txtSoluong.Text == "0"))
            {
                MessageBox.Show("Bạn phải nhập số lượng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoluong.Text = "";
                txtSoluong.Focus();
                return;
            }

            sql = "SELECT mahang FROM tblchitiethdban WHERE mahang=N'" + cboMahang.SelectedValue + "' AND mahdban = N'" + txtMaHDBan.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã hàng này đã có, bạn phải nhập mã khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetValuesHang();
                cboMahang.Focus();
                return;
            }
            sl = Convert.ToDouble(Functions.GetFieldValues("SELECT soluong FROM tblhang WHERE mahang = N'" + cboMahang.SelectedValue + "'"));
            if (Convert.ToDouble(txtSoluong.Text) > sl)
            {
                MessageBox.Show("Số lượng mặt hàng này chỉ còn " + sl + "!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoluong.Text = "";
                txtSoluong.Focus();
                return;
            }

            sql = "INSERT INTO tblchitiethdban( mahdban,mahang,soluong, dongia, khuyenmai, thanhtien) VALUES(N'" + txtMaHDBan.Text.Trim() + "',N'" + cboMahang.SelectedValue + "', N'" + txtSoluong.Text + "',N'" + txtDongia.Text + "',N'" + cbokhuyenmai.Text.Trim() + "',N'" + txtThanhtien.Text + "')";
            Functions.RunSql(sql);
            Load_DataGridViewChitiet();
            SLcon = sl - Convert.ToDouble(txtSoluong.Text);
            sql = "UPDATE tblhang SET soluong =" + SLcon + " WHERE mahang= N'" + cboMahang.SelectedValue + "'";
            Functions.RunSql(sql);
            tong = Convert.ToDouble(Functions.GetFieldValues("SELECT tongtien FROM tblhdban WHERE mahdban = N'" + txtMaHDBan.Text + "'"));
            Tongmoi = tong + Convert.ToDouble(txtThanhtien.Text);
            sql = "UPDATE tblhdban SET tongtien =" + Tongmoi + " WHERE mahdban = N'" + txtMaHDBan.Text + "'";
            Functions.RunSql(sql);
            txtTongtien.Text = Tongmoi.ToString();
            labelbangchu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChu(Tongmoi.ToString());
            ResetValuesHang();
            btnXoaHD.Enabled = true;
            btnThemmoi.Enabled = true;
            btnInhoadon.Enabled = true;
            //btnBoqua_Click(null, null);
        }
        private void ResetValuesHang()
        {
            cboMahang.Text = "";
            txtSoluong.Text = "";
            cbokhuyenmai.Text = "";
            txtThanhtien.Text = "0";
            txtTenhang.Text = "";
            txtDongia.Text = "";
        }

        private void dataGridViewChitiet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaHDBan.ReadOnly = true;
            int i;
            i = dataGridViewChitiet.CurrentRow.Index;
            txtMaHDBan.Text = dataGridViewChitiet.Rows[i].Cells[0].Value.ToString();
            mskNgayban.Text = dataGridViewChitiet.Rows[i].Cells[1].Value.ToString();
            cboManhanvien.Text = dataGridViewChitiet.Rows[i].Cells[2].Value.ToString();
            txtTennhanvien.Text = dataGridViewChitiet.Rows[i].Cells[3].Value.ToString();
            cboMakhachhang.Text = dataGridViewChitiet.Rows[i].Cells[4].Value.ToString();
            txtTenkhachhang.Text = dataGridViewChitiet.Rows[i].Cells[5].Value.ToString();
            txtDiachi.Text = dataGridViewChitiet.Rows[i].Cells[6].Value.ToString();
            txtDienthoai.Text = dataGridViewChitiet.Rows[i].Cells[7].Value.ToString();
            cboMahang.Text = dataGridViewChitiet.Rows[i].Cells[8].Value.ToString();
            txtTenhang.Text = dataGridViewChitiet.Rows[i].Cells[9].Value.ToString();
            txtSoluong.Text = dataGridViewChitiet.Rows[i].Cells[10].Value.ToString();
            txtDongia.Text = dataGridViewChitiet.Rows[i].Cells[11].Value.ToString();
            cbokhuyenmai.Text = dataGridViewChitiet.Rows[i].Cells[12].Value.ToString();
            txtThanhtien.Text = dataGridViewChitiet.Rows[i].Cells[13].Value.ToString();
            /*string mahang;
           Double Thanhtien;
           if (tblCTHDB.Rows.Count == 0)
           {
               MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
               return;
           }
           if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
           {
               mahang = dataGridViewChitiet.CurrentRow.Cells["mahang"].Value.ToString();
               DelHang(txtMaHDBan.Text, mahang);
               Thanhtien = Convert.ToDouble(dataGridViewChitiet.CurrentRow.Cells["thanhtien"].Value.ToString());
               DelUpdateTongtien(txtMaHDBan.Text, Thanhtien);
               Load_DataGridViewChitiet();
           } */
        }
        private void DelHang(string Mahoadon, string Mahang)
       {
           Double s, sl, SLcon;
           string sql;
           sql = "SELECT soluong FROM tblchitiethdban WHERE mahdban = N'" + Mahoadon + "' AND mahang=N'" + Mahang + "'";
           s = Convert.ToDouble(Functions.GetFieldValues(sql));
           sql = "DELETE tblchitiethdban WHERE mahdban=N'" + Mahoadon + "' AND mahang = N'" + Mahang + "'";
           Functions.RunSqlDel(sql);
           sql = "SELECT soluong FROM tblhang WHERE mahang = N'" + Mahang + "'";
           sl = Convert.ToDouble(Functions.GetFieldValues(sql));
           SLcon = sl + s;
           sql = "UPDATE tblhang SET soluong =" + SLcon + " WHERE mahang= N'" + Mahang + "'";
           Functions.RunSql(sql);
       }
       private void DelUpdateTongtien(string Mahoadon, double Thanhtien)
       {
           Double Tong, Tongmoi;
           string sql;
           sql = "SELECT tongtien FROM tblhdban WHERE mahdban = N'" + Mahoadon + "'";
           Tong = Convert.ToDouble(Functions.GetFieldValues(sql));
           Tongmoi = Tong - Thanhtien;
           sql = "UPDATE tblhdban SET tongtien =" + Tongmoi + " WHERE mahdban = N'" + Mahoadon + "'";
           Functions.RunSql(sql);
           txtTongtien.Text = Tongmoi.ToString();
           labelbangchu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChu(Tongmoi.ToString());
       }

       private void btnXoaHD_Click(object sender, EventArgs e)
       {
           if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
           {
               string[] Mahang = new string[20];
               string sql;
               int n = 0;
               int i;
               sql = "SELECT mahang FROM tblchitiethdban WHERE mahdban = N'" + txtMaHDBan.Text + "'";
               SqlCommand cmd = new SqlCommand(sql, Functions.Conn);
               SqlDataReader reader = cmd.ExecuteReader();
               while (reader.Read())
               {
                   Mahang[n] = reader.GetString(0).ToString();
                   n = n + 1;
               }
               reader.Close();
               for (i = 0; i <= n - 1; i++)
                   DelHang(txtMaHDBan.Text, Mahang[i]);
               sql = "DELETE tblhdban WHERE mahdban=N'" + txtMaHDBan.Text + "'";
               Functions.RunSqlDel(sql);
               ResetValues();
               mskNgayban.Text = "";
               Load_DataGridViewChitiet();
               btnXoaHD.Enabled = false;
               btnInhoadon.Enabled = false;
           }
       }

       private void cboManhanvien_SelectedIndexChanged(object sender, EventArgs e)
       {
           string str;
           if (cboManhanvien.Text == "")
               txtTennhanvien.Text = "";
           str = "Select hoten from tblnhanvien where manv =N'" + cboManhanvien.SelectedValue + "'";
           txtTennhanvien.Text = Functions.GetFieldValues(str);
       }

       private void cboMakhachhang_SelectedIndexChanged(object sender, EventArgs e)
       {
           string str;
           if (cboMakhachhang.Text == "")
           {
               txtTenkhachhang.Text = "";
               txtDiachi.Text = "";
               txtDienthoai.Text = "";
           }
           str = "Select tenkhach from tblkhach where makhach = N'" + cboMakhachhang.SelectedValue + "'";
           txtTenkhachhang.Text = Functions.GetFieldValues(str);
           str = "Select diachi from tblkhach where makhach = N'" + cboMakhachhang.SelectedValue + "'";
           txtDiachi.Text = Functions.GetFieldValues(str);
           str = "Select dienthoai from tblkhach where makhach= N'" + cboMakhachhang.SelectedValue + "'";
           txtDienthoai.Text = Functions.GetFieldValues(str);
       }

       private void cboMahang_SelectedIndexChanged(object sender, EventArgs e)
       {
           string str;
           if (cboMahang.Text == "")
           {
               txtTenhang.Text = "";
               txtDongia.Text = "";
           }
           str = "SELECT tenhang FROM tblhang WHERE mahang =N'" + cboMahang.SelectedValue + "'";
           txtTenhang.Text = Functions.GetFieldValues(str);
           str = "SELECT dongiaban FROM tblhang WHERE mahang =N'" + cboMahang.SelectedValue + "'";
           txtDongia.Text = Functions.GetFieldValues(str);
       }

       private void btnInhoadon_Click(object sender, EventArgs e)
       {
           COMExcel.Application exApp = new COMExcel.Application();
           COMExcel.Workbook exBook;
           COMExcel.Worksheet exSheet;
           COMExcel.Range exRange;
           string sql;
           int hang = 0, cot = 0;
           DataTable tblThongtinHD, tblThongtinHang;
           exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
           exSheet = exBook.Worksheets[1];
           exRange = exSheet.Cells[1, 1];
           exRange.Range["A1:B3"].Font.Size = 10;
           exRange.Range["A1:B3"].Font.Name = "Times new roman";
           exRange.Range["A1:B3"].Font.Bold = true;
           exRange.Range["A1:B3"].Font.ColorIndex = 5;
           exRange.Range["A1:A1"].ColumnWidth = 10;
           exRange.Range["B1:B1"].ColumnWidth = 15;
           exRange.Range["A1:B1"].MergeCells = true;
           exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
           exRange.Range["A1:B1"].Value = "Cửa hàng gas và bếp ga Gia Thịnh";
           exRange.Range["A2:B2"].MergeCells = true;
           exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
           exRange.Range["A2:B2"].Value = "Cầu Tó - Thanh Trì - Hà Nội";
           exRange.Range["A3:B3"].MergeCells = true;
           exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
           exRange.Range["A3:B3"].Value = "Điện thoại: 0916762011";
           exRange.Range["C2:F2"].Font.Size = 16;
           exRange.Range["C2:F2"].Font.Name = "Times new roman";
           exRange.Range["C2:F2"].Font.Bold = true;
           exRange.Range["C2:F2"].Font.ColorIndex = 3;
           exRange.Range["C2:F2"].MergeCells = true;
           exRange.Range["C2:F2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
           exRange.Range["C2:F2"].Value = "HÓA ĐƠN BÁN HÀNG";
           sql = "SELECT a.mahdban, a.ngayban, a.tongtien, b.tenkhach, b.diachi, b.dienthoai, c.hoten FROM tblhdban AS a, tblkhach AS b, tblnhanvien AS c WHERE a.mahdban = N'" + txtMaHDBan.Text + "' AND a.makhach = b.makhach AND a.manv = c.manv";
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
           exRange.Range["B9:B9"].Value = "Điện thoại:";
           exRange.Range["C9:E9"].MergeCells = true;
           exRange.Range["C9:E9"].Value = "'" + tblThongtinHD.Rows[0][5].ToString();
           sql = "SELECT b.tenhang, a.soluong, b.dongiaban, a.khuyenmai, a.thanhtien " + "FROM tblchitiethdban AS a , tblhang AS b WHERE a.mahdban = N'" +
                 txtMaHDBan.Text + "' AND a.mahang = b.mahang";
           tblThongtinHang = Functions.GetDataToTable(sql);
           exRange.Range["A11:F11"].Font.Bold = true;
           exRange.Range["A11:F16"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
           exRange.Range["C11:F11"].ColumnWidth = 12;
           exRange.Range["A11:A11"].Value = "STT";
           exRange.Range["A2:F12"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
           exRange.Range["B11:B11"].Value = "Tên hàng";
           exRange.Range["C11:C11"].Value = "Số lượng";
           exRange.Range["D11:D11"].Value = "Đơn giá";
           exRange.Range["E11:E11"].Value = "Khuyến mãi";
           exRange.Range["F11:F11"].Value = "Thành tiền";
           for (hang = 0; hang <= tblThongtinHang.Rows.Count - 1; hang++)
           {
               exSheet.Cells[1][hang + 12] = hang + 1;
               for (cot = 0; cot <= tblThongtinHang.Columns.Count - 1; cot++)
                   exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString();
           }
           string tong;
           tong = txtTongtien.Text;
           exRange = exSheet.Cells[cot - 2][hang + 14];
           exRange.Font.Bold = true;
           exRange.Value2 = "Tổng tiền: " + tong;
           exRange.Range["A1:D1"].MergeCells = true;
           exRange.Range["A1:D1"].Font.Bold = true;
           exRange.Range["A1:D1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
           exRange = exSheet.Cells[1][hang + 15];
           exRange.Range["C1:F1"].MergeCells = true;
           exRange.Range["C1:F1"].Font.Bold = true;
           exRange.Range["C1:F1"].Value = "Bằng chữ: " + Functions.ChuyenSoSangChu(tblThongtinHD.Rows[0][2].ToString());
           exRange.Range["C1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
           exRange = exSheet.Cells[3][hang + 17];
           exRange.Range["A1:D1"].MergeCells = true;
           exRange.Range["A1:D1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
           DateTime d = DateTime.Today;
           exRange.Range["A1:D1"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
           exRange.Range["A2:D2"].MergeCells = true;
           exRange.Range["A2:D2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
           exRange.Range["A2:D2"].Value = "Nhân viên bán hàng";
           exRange.Range["A4:D4"].MergeCells = true;
           exRange.Range["A4:D4"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
           exRange.Range["A4:D4"].Value = tblThongtinHD.Rows[0][6];
           exSheet.Name = "Hóa đơn bán hàng";
           exApp.Visible = true;
       }

       private void cboMaHDBan_SelectedIndexChanged(object sender, EventArgs e)
       {

       }

       private void btnBoqua_Click(object sender, EventArgs e)
       {
           ResetValues();
           mskNgayban.Text = "";
           txtTenhang.Text = "";
           txtTongtien.Text = "";
           cbokhuyenmai.Text = "";
           txtThanhtien.Text = "";
           txtTongtien.Enabled = false;
           btnBoqua.Enabled = false;
           btnThemmoi.Enabled = true;
           btnXoaHD.Enabled = true;
           btnLuu.Enabled = false;
       }

       private void cbokhuyenmai_SelectedIndexChanged(object sender, EventArgs e)
       {

       }

       private void btnDong_Click(object sender, EventArgs e)
       {
           this.Close();
       }

       private void txtSoluong_TextChanged(object sender, EventArgs e)
       {
           double tt, sl, dg;
           if (txtSoluong.Text == "")
               sl = 0;
           else
               sl = Convert.ToDouble(txtSoluong.Text);

           if (txtDongia.Text == "")
               dg = 0;
           else
               dg = Convert.ToDouble(txtDongia.Text);
           tt = sl * dg;
           txtThanhtien.Text = tt.ToString();
       }



       private void groupBox1_Enter(object sender, EventArgs e)
       {

       }

       private void cboMaHDBan_SelectedIndexChanged_1(object sender, EventArgs e)
       {

       }

       private void cboMaHDBan_DropDown(object sender, EventArgs e)
       {
           Functions.FillCombo("SELECT mahdban FROM tblhdban", cboMaHDBan, "mahdban", "mahdban");
           cboMaHDBan.SelectedIndex = -1;
       }



       private void button1_Click_1(object sender, EventArgs e)
       {
           string sql;
           sql = "select a.mahdban,ngayban,c.manv,hoten, d.makhach,tenkhach,d.diachi,d.dienthoai,a.mahang, tenhang, a.soluong, dongia,khuyenmai,thanhtien from tblchitiethdban as a, tblhang as b,tblnhanvien as c, tblkhach as d, tblhdban as e where a.mahang=b.mahang and a.mahdban=e.mahdban and e.makhach=d.makhach and e.manv=c.manv";
           tblCTHDB = Functions.GetDataToTable(sql);
           dataGridViewChitiet.DataSource = tblCTHDB;
            dataGridViewChitiet.Columns[0].HeaderText = "Mã hóa đơn";
            dataGridViewChitiet.Columns[1].HeaderText = "Ngày bán";
            dataGridViewChitiet.Columns[2].HeaderText = "Mã nhân viên";
            dataGridViewChitiet.Columns[3].HeaderText = "tên nhân viên bán";
            dataGridViewChitiet.Columns[4].HeaderText = "Mã khách hàng";
            dataGridViewChitiet.Columns[5].HeaderText = "Tên khách";
            dataGridViewChitiet.Columns[6].HeaderText = "Địa chỉ khách";
            dataGridViewChitiet.Columns[7].HeaderText = "Điện thoại khách";
            dataGridViewChitiet.Columns[8].HeaderText = "Mã hàng";
           dataGridViewChitiet.Columns[9].HeaderText = "Tên hàng";
           dataGridViewChitiet.Columns[10].HeaderText = "Số lượng";
           dataGridViewChitiet.Columns[11].HeaderText = "Đơn giá";
           dataGridViewChitiet.Columns[12].HeaderText = "Khuyến mãi";
           dataGridViewChitiet.Columns[13].HeaderText = "Thành tiền";
           dataGridViewChitiet.Columns[0].Width = 100;
           dataGridViewChitiet.Columns[1].Width = 110;
           dataGridViewChitiet.Columns[2].Width = 120;
           dataGridViewChitiet.Columns[3].Width = 100;
           dataGridViewChitiet.Columns[4].Width = 120;
           dataGridViewChitiet.Columns[5].Width = 120;
            dataGridViewChitiet.Columns[6].Width = 120;
            dataGridViewChitiet.Columns[7].Width = 120;
            dataGridViewChitiet.Columns[8].Width = 120;
            dataGridViewChitiet.Columns[9].Width = 120;
            dataGridViewChitiet.Columns[10].Width = 120;
            dataGridViewChitiet.Columns[11].Width = 120;
            dataGridViewChitiet.Columns[12].Width = 120;
            dataGridViewChitiet.Columns[13].Width = 120;
            dataGridViewChitiet.AllowUserToAddRows = false;
           dataGridViewChitiet.EditMode = DataGridViewEditMode.EditProgrammatically;
           txtMaHDBan.Text = Functions.GetFieldValues(sql);
           Functions.RunSql(sql);
           btnXoaHD.Enabled = true;
           dataGridViewChitiet.Show();

       }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if(tblCTHDB.Rows.Count==0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaHDBan.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (mskNgayban.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskNgayban.Focus();
                return;
            }
            if(cboMahang.Text.Trim().Length==0)
            {
                MessageBox.Show("Bạn phải chọn mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMahang.Focus();
                return;
            }
            if(txtSoluong.Text.Length==0)
            {
                MessageBox.Show("Bạn phải chọn số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoluong.Focus();
                return;
            }
            if(cbokhuyenmai.Text.Trim().Length==0)
            {
                MessageBox.Show("Bạn phải chọn hàng khuyến mãi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMahang.Focus();
                return;
            }
            sql = "update tblchitiethdban set mahang=N'"+cboMahang.Text.ToString()+"',soluong=N'"+txtSoluong.Text.ToString()+"',khuyenmai=N'"+cbokhuyenmai.Text.ToString()+"',thanhtien=N'"+txtThanhtien.Text+"' where mahdban=N'"+txtMaHDBan.Text+"' ";
            Functions.RunSql(sql);
            Load_DataGridViewChitiet();
            ResetValues();
            btnBoqua.Enabled = false;
        }

        private void cbokhuyenmai_DropDown(object sender, EventArgs e)
        {
            cbokhuyenmai.Items.Clear();
            cbokhuyenmai.Items.Add("5");
            cbokhuyenmai.Items.Add("10");
            cbokhuyenmai.Items.Add("15");
        }
    }
    }
