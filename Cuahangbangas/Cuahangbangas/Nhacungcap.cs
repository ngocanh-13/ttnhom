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

namespace Cuahangbangas
{
    public partial class Nhacungcap : Form
    {
        public Nhacungcap()
        {
            InitializeComponent();
        }
        DataTable tblNCC;

        private void Danhmucnhacungcap_Load(object sender, EventArgs e)
        {
            txt_mncc.Enabled = false;
            btn_Lưu.Enabled = false;
            btn_bỏ.Enabled = false;
            Load_DataGridView();
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT * FROM tblncc";
            tblNCC = Functions.GetDataToTable(sql);
            dtgvncc.DataSource = tblNCC;
            dtgvncc.Columns[0].HeaderText = "Mã nhà cung cấp";
            dtgvncc.Columns[1].HeaderText = "Tên nhà cung cấp";
            dtgvncc.Columns[2].HeaderText = "Địa chỉ";
            dtgvncc.Columns[3].HeaderText = "Điện thoại";
            dtgvncc.Columns[0].Width = 100;
            dtgvncc.Columns[1].Width = 150;
            dtgvncc.Columns[2].Width = 150;
            dtgvncc.Columns[3].Width = 150;
            dtgvncc.AllowUserToAddRows = false;
            dtgvncc.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtgvncc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btn_Thêm.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_mncc.Focus();
                return;
            }
            if (tblNCC.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txt_mncc.Text = dtgvncc.CurrentRow.Cells["mancc"].Value.ToString();
            txt_tenncc.Text = dtgvncc.CurrentRow.Cells["tenncc"].Value.ToString();
            txt_dc.Text =dtgvncc.CurrentRow.Cells["diachi"].Value.ToString();
            txt_đt.Text = dtgvncc.CurrentRow.Cells["dienthoai"].Value.ToString();
            btn_Sửa.Enabled = true;
            btn_Xóa.Enabled = true;
            btn_bỏ.Enabled = true;

        }

        private void btn_Thêm_Click(object sender, EventArgs e)
        {
            btn_Sửa.Enabled = false;
            btn_Xóa.Enabled = false;
            btn_bỏ.Enabled = true;
            btn_Lưu.Enabled = true;
            btn_Thêm.Enabled = false;
            ResetValues();
            txt_mncc.Enabled = true;
            txt_mncc.Focus();
        }
        private void ResetValues()
        {
            txt_mncc.Text = "";
            txt_tenncc.Text = "";
            txt_dc.Text = "";
            txt_đt.Text = "";
        }

        private void btn_Lưu_Click(object sender, EventArgs e)
        {

            string sql;
            if (txt_mncc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_mncc.Focus();
                return;
            }
            if (txt_tenncc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_tenncc.Focus();
                return;
            }
            if (txt_dc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_dc.Focus();
                return;
            }
            if (txt_đt.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_đt.Focus();
                return;
            }
            sql = "SELECT mancc FROM tblncc WHERE mancc=N'" + txt_mncc.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã nhà cung cấp này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_mncc.Focus();
                txt_mncc.Text = "";
                return;
            }
            sql = "INSERT INTO tblncc (mancc,tenncc,diachi,dienthoai) VALUES (N'" + txt_mncc.Text.Trim() + "',N'" + txt_tenncc.Text.Trim() + "',N'" + txt_dc.Text.Trim() + "','" + txt_đt.Text + "')";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btn_Xóa.Enabled = true;
            btn_Thêm.Enabled = true;
            btn_Sửa.Enabled = true;
            btn_bỏ.Enabled = false;
            btn_Lưu.Enabled = false;
            txt_mncc.Enabled = false;
        }

        private void btn_Sửa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblNCC.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txt_mncc.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txt_tenncc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_tenncc.Focus();
                return;
            }
            if (txt_dc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_dc.Focus();
                return;
            }
            if (txt_đt.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_đt.Focus();
                return;
            }
            sql = "UPDATE tblncc SET  tenncc=N'" + txt_tenncc.Text.Trim().ToString() + "', diachi=N'" + txt_dc.Text.Trim().ToString() + "', dienthoai='" + txt_đt.Text.ToString() + "' WHERE mancc=N'" + txt_mncc.Text + "'";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btn_bỏ.Enabled = false;
        }

        private void btn_Xóa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblNCC.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txt_mncc.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblncc WHERE mancc=N'" + txt_mncc.Text + "'";
                Functions.RunSqlDel(sql);
                Load_DataGridView();
                ResetValues();
            }
        }

        private void btn_bỏ_Click(object sender, EventArgs e)
        {
            ResetValues();
            btn_bỏ.Enabled = false;
            btn_Thêm.Enabled = true;
            btn_Xóa.Enabled = true;
            btn_Sửa.Enabled = true;
            btn_Lưu.Enabled = false;
            txt_mncc.Enabled = false;

        }
        

        private void btn_Đóng_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
