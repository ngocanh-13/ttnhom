using Cửa_hàng_Gia_Thịnh;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COMExcel = Microsoft.Office.Interop.Excel;
namespace Cuahangbangas
{
    public partial class Baocaodoanhthu : Form
    {
        public Baocaodoanhthu()
        {
            InitializeComponent();
        }
        DataTable tblBCDT;
        private void Baocaodoanhthu_Load(object sender, EventArgs e)
        {
            ResetValues();
            DataGridView.DataSource = null;
            Functions.FillCombo("SELECT hoten FROM tblnhanvien", cbotennhanvien, "hoten", "hoten");
            cbotennhanvien.SelectedIndex = -1;
        }

        private void ResetValues()
        {
            foreach (Control Ctl in this.Controls)
                if (Ctl is TextBox)
                    Ctl.Text = "";
            txtNgaybatdau.Focus();
            txtDoanhthu.Enabled = false;
        }

        private void btnXemdoanhthu_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtNgaybatdau.Text == "") && (txtNgayketthuc.Text == "") && (cbotennhanvien.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!", "Yêu cầu!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtNgaybatdau.Text == "")
            {
                MessageBox.Show("Hãy nhập ngày bắt đầu!", "Yêu cầu!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtNgayketthuc.Text == "")
            {
                MessageBox.Show("Hãy nhập ngày kết thúc!", "Yêu cầu!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbotennhanvien.Text == "")
            {
                MessageBox.Show("Hãy chọn mã nhân viên báo cáo!", "Yêu cầu!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM tblhdban WHERE 1=1 AND manv =N'" + cbotennhanvien.SelectedValue + "'";
            if ((txtNgaybatdau.Text != "") && (txtNgayketthuc.Text != "") && (cbotennhanvien.Text != ""))
            /*sql = sql + " AND ngayban >= " + txtNgaybatdau.Text + " AND ngayban <=" + txtNgayketthuc.Text;
             */
            {
                sql = sql + " AND ngayban >=" + Functions.ConvertDateTime(txtNgaybatdau.Text) + " AND ngayban<=" + Functions.ConvertDateTime(txtNgayketthuc.Text);
                string s = Functions.GetFieldValues(sql);
                MessageBox.Show(s);
            }
            tblBCDT = Functions.GetDataToTable(sql);
            if (tblBCDT.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi nào thỏa mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetValues();
            }
            //else
            //    MessageBox.Show("Có " + tblBCDT.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            DataGridView.DataSource = tblBCDT;
            Load_DataGridView();
            txtDoanhthu.Text = Functions.GetFieldValues("SELECT SUM(tongtien) FROM tblhdban as a WHERE manv =N'" + cbotennhanvien.SelectedValue + "' AND ngayban >='" + txtNgaybatdau.Text + "' AND a.ngayban <='" + txtNgayketthuc.Text + "'");

        }

        private void Load_DataGridView()
        {
            DataGridView.Columns[0].HeaderText = "Mã HĐB";
            DataGridView.Columns[1].HeaderText = "Mã NV";
            DataGridView.Columns[2].HeaderText = "Mã khách";
            DataGridView.Columns[3].HeaderText = "Ngày bán";
            DataGridView.Columns[4].HeaderText = "Tổng tiền";
            DataGridView.Columns[0].Width = 170;
            DataGridView.Columns[1].Width = 100;
            DataGridView.Columns[2].Width = 110;
            DataGridView.Columns[3].Width = 110;
            DataGridView.Columns[4].Width = 110;
            DataGridView.AllowUserToAddRows = false;
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;

        }

        private void btnTimlai_Click(object sender, EventArgs e)
        {
            ResetValues();
            DataGridView.DataSource = null;
        }

        private void btnInbaocao_Click(object sender, EventArgs e)
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
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5;
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].Value = "Cửa hàng gas và bếp gas Gia Thịnh";
            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].Value = "Cầu Tó - Thanh Trì - Hà Nội";
            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].Value = "Điện thoại: 0916762011";
            exRange.Range["C2:F2"].Font.Bold = true;
            exRange.Range["C2:F2"].Font.ColorIndex = 3;
            exRange.Range["C2:F2"].Font.Size = 17;
            exRange.Range["C2:F2"].MergeCells = true;
            exRange.Range["C2:E2"].Value = "BÁO CÁO DOANH THU THÁNG " + txtNgaybatdau.Text + "/" + txtNgayketthuc.Text;
            exRange.Range["A1:E3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            sql = "SELECT mahdban, manv, makhach, CONVERT(varchar,ngayban,101),tongtien FROM tblhdban  WHERE ngayban>='" + txtNgaybatdau.Text + "' AND ngayban <='" + txtNgayketthuc.Text + "'AND manv =N'" + cbotennhanvien.SelectedValue + "'";
            tblThongtinHang = Functions.GetDataToTable(sql);
            tblThongtinHD = Functions.GetDataToTable(sql);
            exRange.Range["A5:F5"].Font.Bold = true;
            exRange.Range["C11:F11"].ColumnWidth = 12;
            exRange.Range["B11:B11"].ColumnWidth = 20;
            exRange.Range["E1:E30"].ColumnWidth = 15;
            exRange.Range["A5:A5"].Value = "STT";
            exRange.Range["B5:B5"].Value = "Mã HĐB";
            exRange.Range["C5:C5"].Value = "Mã nhân viên";
            exRange.Range["D5:D5"].Value = "Mã khách";
            exRange.Range["E5:E5"].Value = "Ngày bán";
            exRange.Range["F5:F5"].Value = "Tổng tiền";
            exRange.Range["A5:F9"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            for (hang = 0; hang <= tblThongtinHang.Rows.Count - 1; hang++)
            {
                exSheet.Cells[1][hang + 6] = hang + 1;
                for (cot = 0; cot <= tblThongtinHang.Columns.Count - 1; cot++)
                    exSheet.Cells[cot + 2][hang + 6] = tblThongtinHang.Rows[hang][cot].ToString();
            }
            string dt, nv;
            dt = txtDoanhthu.Text;
            nv = "SELECT hoten FROM tblnhanvien WHERE manv =N'" + cbotennhanvien.SelectedValue + "'";
            exRange = exSheet.Cells[cot - 2][hang + 8];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng doanh thu: " + dt;
            exRange.Range["A1:D1"].MergeCells = true;
            exRange.Range["A1:D1"].Font.Bold = true;
            exRange.Range["A1:D1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange = exSheet.Cells[1][hang + 9];
            exRange.Range["C1:F1"].MergeCells = true;
            exRange.Range["C1:F1"].Font.Bold = true;
            exRange.Range["C1:F1"].Value = "Bằng chữ: " + Functions.ChuyenSoSangChu(dt);
            exRange.Range["C1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange = exSheet.Cells[3][hang + 11];
            exRange.Range["A1:D1"].MergeCells = true;
            exRange.Range["A1:D1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = DateTime.Today;
            exRange.Range["A1:D1"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["A2:D2"].MergeCells = true;
            exRange.Range["A2:D2"].Value = "Nhân viên lập báo cáo";
            exRange.Range["A1:D2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A4:D4"].MergeCells = true;
            exRange.Range["A4:D4"].Value = Functions.GetFieldValues(nv);
            exRange.Range["A4:D4"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exSheet.Name = "Báo cáo doanh thu";
            exApp.Visible = true;

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtNgaybatdau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtNgayketthuc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }
        private void txtDoanhthu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }
        private void txtNgaybatdau_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
