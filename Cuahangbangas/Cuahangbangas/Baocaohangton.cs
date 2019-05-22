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
    public partial class Baocaohangton : Form
    {
        public Baocaohangton()
        {
            InitializeComponent();
        }
        DataTable tblBCHT;
        private void Baocaohangton_Load(object sender, EventArgs e)
        {
            ResetValues();
            dataGridView1.DataSource = null;
            Functions.FillCombo("SELECT tenhang FROM tblhang", cbotenhang, "tenhang", "tenhang");
            cbotenhang.SelectedIndex = -1;
        }
        private void ResetValues()
        {
            foreach (Control Ctl in this.Controls)
                if (Ctl is TextBox)
                    Ctl.Text = "";
            cbotenhang.Text = "";
            txtsl.Text = "";
        }

        private void btnbaocao_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT mahang,tenhang, soluong FROM tblhang";
            tblBCHT = Functions.GetDataToTable(sql);
            dataGridView1.DataSource = tblBCHT;
            Load_DataGridView();
            btnbaocao.Enabled = true;
        }
        private void Load_DataGridView()
        {
            dataGridView1.Columns[0].HeaderText = "Mã hàng";
            dataGridView1.Columns[1].HeaderText = "Tên hàng";
            dataGridView1.Columns[2].HeaderText = "Số lượng tồn";
            dataGridView1.Columns[0].Width = 120;
            dataGridView1.Columns[1].Width = 120;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
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
            exRange.Range["C2:E2"].Font.Bold = true;
            exRange.Range["C2:E2"].Font.ColorIndex = 3;
            exRange.Range["C2:E2"].Font.Size = 17;
            exRange.Range["C2:E2"].MergeCells = true;
            exRange.Range["C2:E2"].Value = "BÁO CÁO HÀNG TỒN KHO";
            exRange.Range["A1:E3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            sql = "SELECT mahang, tenhang, soluong FROM tblhang";
            tblThongtinHang = Functions.GetDataToTable(sql);
            tblThongtinHD = Functions.GetDataToTable(sql);
            exRange.Range["A5:F5"].Font.Bold = true;
            exRange.Range["C11:F11"].ColumnWidth = 12;
            exRange.Range["B11:B11"].ColumnWidth = 20;
            exRange.Range["E1:E30"].ColumnWidth = 15;
            exRange.Range["B5:B5"].Value = "STT";
            exRange.Range["C5:C5"].Value = "Mã hàng";
            exRange.Range["D5:D5"].Value = "Tên hàng";
            exRange.Range["E5:E5"].Value = "Số lượng còn";
            exRange.Range["A5:F30"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            for (hang = 0; hang <= tblThongtinHang.Rows.Count - 1; hang++)
            {
                exSheet.Cells[2][hang + 6] = hang + 1;
                for (cot = 0; cot <= tblThongtinHang.Columns.Count - 1; cot++)
                    exSheet.Cells[cot + 3][hang + 6] = tblThongtinHang.Rows[hang][cot].ToString();
            }
            exSheet.Name = "Báo cáo hàng tồn kho";
            exApp.Visible = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql;
            if (cbotenhang.Text == "")
            {
                MessageBox.Show("Hãy chọn tên hàng cần tìm!", "Yêu cầu!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT mahang, tenhang, soluong FROM tblhang WHERE tenhang=N'" + cbotenhang.SelectedValue + "'";
            tblBCHT = Functions.GetDataToTable(sql);
            dataGridView1.DataSource = tblBCHT;
            Load_DataGridView();
            txtsl.Text = Functions.GetFieldValues("SELECT soluong from tblhang WHERE tenhang=N'" + cbotenhang.SelectedValue.ToString() + "'");
            //btnInbaocao.Enabled = false;
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtsl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }
    }
}
