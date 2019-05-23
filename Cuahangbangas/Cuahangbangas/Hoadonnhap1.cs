using Cửa_hàng_Gia_Thịnh;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COMExcel = Microsoft.Office.Interop.Excel;


namespace Cuahangbangas
{
    public partial class Hoadonnhap1 : Form
    {
        public Hoadonnhap1()
        {
            InitializeComponent();
        }
        DataTable tblCTHDN;
        private void Hoadonnhap1_Load(object sender, EventArgs e)
        {
            btnThemmoi.Enabled = true;
            btnLuu.Enabled = false;
            btnXoaHD.Enabled = false;
            btnInhoadon.Enabled = false;
            txtTongtien.Enabled = false;
            txtmahdnhap.ReadOnly = false;
            txtTennhanvien.ReadOnly = true;
            txttenncc.ReadOnly = true;
            txtdiachi.ReadOnly = true;
            txtdienthoai.ReadOnly = true;
            txtTenhang.ReadOnly = true;
            txtDongia.ReadOnly = true;
            txtThanhtien.ReadOnly = true;
            txtTongtien.ReadOnly = true;
            cbochietkhau.Text = "";
            txtThanhtien.Text = "0";
            txtTongtien.Text = "0";
            Functions.FillCombo("SELECT mancc FROM tblncc", cboncc, "mancc", "mancc");
            cboncc.SelectedIndex = -1;
            Functions.FillCombo("SELECT manv FROM tblnhanvien", cbomanhanvien, "manv", "manv");
            cbomanhanvien.SelectedIndex = -1;
            Functions.FillCombo("SELECT mahang FROM tblhang", cboMahang, "mahang", "mahang");
            cboMahang.SelectedIndex = -1;
            if (txtmahdnhap.Text != "")
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
            sql = "SELECT a.mahang, b.tenhang, a.soluong, b.dongianhap, a.chietkhau, a.thanhtien FROM tblchitiethdnhap AS a, tblhang AS b WHERE a.mahdnhap = N'" + txtmahdnhap.Text + "' AND a.mahang=b.mahang";

            tblCTHDN = Functions.GetDataToTable(sql);
            dataGridViewChitiet.DataSource = tblCTHDN;
            dataGridViewChitiet.Columns[0].HeaderText = "Mã hàng";
            dataGridViewChitiet.Columns[1].HeaderText = "Tên hàng";
            dataGridViewChitiet.Columns[2].HeaderText = "Số lượng";
            dataGridViewChitiet.Columns[3].HeaderText = "Đơn giá";
            dataGridViewChitiet.Columns[4].HeaderText = "Chiết khấu";
            dataGridViewChitiet.Columns[5].HeaderText = "Thành tiền";
            dataGridViewChitiet.Columns[0].Width = 100;
            dataGridViewChitiet.Columns[1].Width = 110;
            dataGridViewChitiet.Columns[2].Width = 110;
            dataGridViewChitiet.Columns[3].Width = 100;
            dataGridViewChitiet.Columns[4].Width = 120;
            dataGridViewChitiet.Columns[5].Width = 120;
            dataGridViewChitiet.AllowUserToAddRows = false;
            dataGridViewChitiet.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void Load_ThongtinHD()
        {
            string str;
            str = "SELECT ngaynhap FROM tblhdnhap WHERE mahdnhap = N'" + txtmahdnhap.Text + "'";
            mskngaynhap.Text = Functions.GetFieldValues(str);
            str = "SELECT manv FROM tblhdnhap WHERE mahdnhap = N'" + txtmahdnhap.Text + "'";
            cbomanhanvien.Text = Functions.GetFieldValues(str);
            str = "SELECT mancc FROM tblhdnhap WHERE mahdnhap = N'" + txtmahdnhap.Text + "'";
            cboncc.Text = Functions.GetFieldValues(str);
            str = "SELECT tongtien FROM tblhdnhap WHERE mahdnhap = N'" + txtmahdnhap.Text + "'";
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
            //txtmahdnhap.Text = Functions.CreateKey("HDN");
            Load_DataGridViewChitiet();
        }
        private void ResetValues()
        {
            txtmahdnhap.Text = "";
            DateTime d = DateTime.Now;
            string s = d.ToString("dd/MM/yyyy");
            mskngaynhap.Text = s;
            cbomanhanvien.Text = "";
            cboncc.Text = "";
            labelbangchu.Text = "Bằng chữ: ";
            cboMahang.Text = "";
            txtSoluong.Text = "";
            txtTennhanvien.Text = "";
            txttenncc.Text = "";
            txtdiachi.Text = "";
            txtdienthoai.Text = "";
            txtDongia.Text = "";
            txtTongtien.Enabled = false;
            txtTongtien.Text = "0";
            cbochietkhau.Text = "0";
            txtThanhtien.Text = "0";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            double sl, SLcon, tong, Tongmoi;
            sql = "SELECT mahdnhap FROM tblhdnhap WHERE mahdnhap =N'" + txtmahdnhap.Text + "'";
            if (!Functions.CheckKey(sql))
            {
                if (mskngaynhap.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập ngày nhập hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    mskngaynhap.Focus();
                    return;
                }
                if (cbomanhanvien.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải chọn nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbomanhanvien.Focus();
                    return;
                }
                if (cboncc.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải chọn nhà cung cấp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboncc.Focus();
                    return;
                }
                sql = "INSERT INTO tblhdnhap(mahdnhap, manv, mancc, ngaynhap, tongtien) VALUES (N'" + txtmahdnhap.Text.Trim() + "', N'" + cbomanhanvien.SelectedValue + "', N'" + cboncc.SelectedValue + "', '" +
                        Functions.ConvertDateTime(mskngaynhap.Text.Trim()) + "'," + txtTongtien.Text + ")";
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
            if (cbochietkhau.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giảm giá!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbochietkhau.Focus();
                return;
            }
            sql = "SELECT mahang FROM tblchitiethdnhap WHERE mahang=N'" + cboMahang.SelectedValue + "' AND mahdnhap = N'" + txtmahdnhap.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã hàng này đã có, bạn phải nhập mã khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetValuesHang();
                cboMahang.Focus();
                return;
            }
            sl = Convert.ToDouble(Functions.GetFieldValues("SELECT soluong FROM tblhang WHERE mahang = N'" + cboMahang.SelectedValue + "'"));
            sql = "INSERT INTO tblchitiethdnhap (mahdnhap ,mahang ,soluong, dongia, chietkhau, thanhtien) VALUES(N'" + txtmahdnhap.Text.Trim() + "',N'" + cboMahang.SelectedValue + "', '" + txtSoluong.Text + "', '" + txtDongia.Text + "', N'" + cbochietkhau.Text + "', '" + txtThanhtien.Text + "')";
            Functions.RunSql(sql);
            Load_DataGridViewChitiet();
            SLcon = sl + Convert.ToDouble(txtSoluong.Text);
            sql = "UPDATE tblhang SET soluong =" + SLcon + " WHERE mahang= N'" + cboMahang.SelectedValue + "'";
            Functions.RunSql(sql);
            tong = Convert.ToDouble(Functions.GetFieldValues("SELECT tongtien FROM tblhdnhap WHERE mahdnhap = N'" + txtmahdnhap.Text + "'"));
            Tongmoi = tong + Convert.ToDouble(txtThanhtien.Text);
            sql = "UPDATE tblhdnhap SET tongtien =" + Tongmoi + " WHERE mahdnhap = N'" + txtmahdnhap.Text + "'";
            Functions.RunSql(sql);
            txtTongtien.Text = Tongmoi.ToString();
            labelbangchu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChu(Tongmoi.ToString());
            ResetValuesHang();
            btnXoaHD.Enabled = true;
            btnThemmoi.Enabled = true;
            btnInhoadon.Enabled = true;

        }
        private void ResetValuesHang()
        {
            cboMahang.Text = "";
            txtSoluong.Text = "";
            cbochietkhau.Text = "0";
            txtThanhtien.Text = "0";
            txtTenhang.Text = "";
            txtDongia.Text = "";
        }

        private void dataGridViewChitiet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string mahang;
            Double Thanhtien;
            if (tblCTHDN.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                mahang = dataGridViewChitiet.CurrentRow.Cells["mahang"].Value.ToString();
                DelHang(txtmahdnhap.Text, mahang);
                Thanhtien = Convert.ToDouble(dataGridViewChitiet.CurrentRow.Cells["thanhtien"].Value.ToString());
                DelUpdateTongtien(txtmahdnhap.Text, Thanhtien);
                Load_DataGridViewChitiet();
            }
        }
        private void DelHang(string Mahoadon, string Mahang)
        {
            Double s, sl, SLcon;
            string sql;
            sql = "SELECT soluong FROM tblchitiethdnhap WHERE mahdnhap = N'" + Mahoadon + "' AND mahang=N'" + Mahang + "'";
            s = Convert.ToDouble(Functions.GetFieldValues(sql));
            sql = "DELETE tblchitiethdnhap WHERE mahdnhap=N'" + Mahoadon + "' AND mahang = N'" + Mahang + "'";
            Functions.RunSqlDel(sql);
            sql = "SELECT soluong FROM tblhang WHERE mahang = N'" + Mahang + "'";
            sl = Convert.ToDouble(Functions.GetFieldValues(sql));
            SLcon = sl - s;
            sql = "UPDATE tblhang SET soluong =" + SLcon + " WHERE mahang= N'" + Mahang + "'";
            Functions.RunSql(sql);
        }
        private void DelUpdateTongtien(string Mahoadon, double Thanhtien)
        {
            Double Tong, Tongmoi;
            string sql;
            sql = "SELECT tongtien FROM tblhdnhap WHERE mahdnhap = N'" + Mahoadon + "'";
            Tong = Convert.ToDouble(Functions.GetFieldValues(sql));
            Tongmoi = Tong - Thanhtien;
            sql = "UPDATE tblhdnhap SET tongtien =" + Tongmoi + " WHERE mahdnhap = N'" + Mahoadon + "'";
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
                sql = "SELECT mahang FROM tblchitiethdnhap WHERE mahdnhap = N'" + txtmahdnhap.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, Functions.Conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Mahang[n] = reader.GetString(0).ToString();
                    n = n + 1;
                }
                reader.Close();
                for (i = 0; i <= n - 1; i++)
                    DelHang(txtmahdnhap.Text, Mahang[i]);
                sql = "DELETE tblhdnhap WHERE mahdnhap=N'" + txtmahdnhap.Text + "'";
                Functions.RunSqlDel(sql);
                ResetValues();
                mskngaynhap.Text = "";
                Load_DataGridViewChitiet();
                btnXoaHD.Enabled = false;
                btnInhoadon.Enabled = false;
            }
        }

        private void cbomanhanvien_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cbomanhanvien.Text == "")
                txtTennhanvien.Text = "";
            str = "Select hoten from tblnhanvien where manv =N'" + cbomanhanvien.SelectedValue + "'";
            txtTennhanvien.Text = Functions.GetFieldValues(str);
        }

        private void cboncc_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboncc.Text == "")
            {
                txttenncc.Text = "";
                txtdiachi.Text = "";
                txtdienthoai.Text = "";
            }
            str = "Select tenncc from tblncc where mancc = N'" + cboncc.SelectedValue + "'";
            txttenncc.Text = Functions.GetFieldValues(str);
            str = "Select diachi from tblncc where mancc = N'" + cboncc.SelectedValue + "'";
            txtdiachi.Text = Functions.GetFieldValues(str);
            str = "Select dienthoai from tblncc where MaNCC = N'" + cboncc.SelectedValue + "'";
            txtdienthoai.Text = Functions.GetFieldValues(str);
        }

        private void cboMahang_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMahang.Text == "")
            {
                txtTenhang.Text = "";
                txtDongia.Text = "";
            }
            str = "SELECT tenhang FROM tblhang WHERE mahang =N'" + cboMahang.SelectedValue + "'";
            txtTenhang.Text = Functions.GetFieldValues(str);
            str = "SELECT dongianhap FROM tblhang WHERE mahang =N'" + cboMahang.SelectedValue + "'";
            txtDongia.Text = Functions.GetFieldValues(str);
        }

        private void txtSoluong_TextChanged(object sender, EventArgs e)
        {
            double tt, sl, dg, gg;
            if (txtSoluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoluong.Text);
            if (cbochietkhau.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(cbochietkhau.Text.Trim());
            if (txtDongia.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtDongia.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtThanhtien.Text = tt.ToString();
        }

        private void cbochietkhau_TextChanged(object sender, EventArgs e)
        {
            double tt, sl, dg, gg;
            if (txtSoluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoluong.Text);
            if (cbochietkhau.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(cbochietkhau.Text.Trim());
            if (txtDongia.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtDongia.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtThanhtien.Text = tt.ToString();
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
            exRange.Range["A1:A1"].ColumnWidth = 7;
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
            exRange.Range["C2:F2"].Value = "HÓA ĐƠN NHẬP HÀNG";
            sql = "SELECT a.mahdnhap, a.ngaynhap, a.tongtien, b.tenncc, b.diachi, b.dienthoai, c.hoten FROM tblhdnhap AS a, tblncc AS b, tblnhanvien AS c WHERE a.mahdnhap = N'" + txtmahdnhap.Text + "' AND a.mancc = b.mancc AND a.manv = c.manv";
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
            exRange.Range["B9:B9"].Value = "Điện thoại: ";
            exRange.Range["C9:E9"].MergeCells = true;
            exRange.Range["C9:E9"].Value = "'" + tblThongtinHD.Rows[0][5].ToString();
            sql = "SELECT b.tenhang, a.soluong, b.dongianhap, a.chietkhau, a.thanhtien " + "FROM tblchitiethdnhap AS a , tblhang AS b WHERE a.mahdnhap = N'" + txtmahdnhap.Text + "' AND a.mahang = b.mahang";
            tblThongtinHang = Functions.GetDataToTable(sql);
            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F16"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:F11"].ColumnWidth = 12;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["A2:F12"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["B11:B11"].Value = "Tên hàng";
            exRange.Range["C11:C11"].Value = "Số lượng";
            exRange.Range["D11:D11"].Value = "Đơn giá";
            exRange.Range["E11:E11"].Value = "Chiết khấu";
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
            exRange.Range["A2:D2"].Value = "Nhân viên nhập hàng";
            exRange.Range["A4:D4"].MergeCells = true;
            exRange.Range["A4:D4"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A4:D4"].Value = tblThongtinHD.Rows[0][6];
            exSheet.Name = "Hóa đơn nhập hàng";
            exApp.Visible = true;

        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            if (cbbmahdnhap.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbbmahdnhap.Focus();
                return;
            }
            txtmahdnhap.Text = cbbmahdnhap.Text;
            Load_ThongtinHD();
            Load_DataGridViewChitiet();
            btnXoaHD.Enabled = true;
            btnLuu.Enabled = true;
            btnInhoadon.Enabled = true;
            cbbmahdnhap.SelectedIndex = -1;
        }

        private void cbbmahdnhap_DropDown(object sender, EventArgs e)
        {
            Functions.FillCombo("SELECT mahdnhap FROM tblhdnhap", cbbmahdnhap, "mahdnhap", "mahdnhap");
            cbbmahdnhap.SelectedIndex = -1;
        }

        private void Hoadonnhap1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ResetValues();
        }

        private void txtSoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            mskngaynhap.Text = "";
            txtTenhang.Text = "";
            txtTongtien.Text = "";
            cbochietkhau.Text = "";
            txtThanhtien.Text = "";
            txtTongtien.Enabled = false;
            btnBoqua.Enabled = false;
            btnThemmoi.Enabled = true;
            btnXoaHD.Enabled = true;
            btnLuu.Enabled = false;
        }

        private void cbochietkhau_DropDown(object sender, EventArgs e)
        {
            cbochietkhau.Items.Clear();
            cbochietkhau.Items.Add("3");
            cbochietkhau.Items.Add("5");
            cbochietkhau.Items.Add("1");
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
