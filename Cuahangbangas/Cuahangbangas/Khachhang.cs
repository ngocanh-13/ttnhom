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
    public partial class Khachhang : Form
    {
        public Khachhang()
        {
            InitializeComponent();
        }
        DataTable tblKH;
        private void Khachhang_Load(object sender, EventArgs e)
        {
            txt_makh.Enabled = false;
            btn_Lưu.Enabled = false;
            btn_bỏ.Enabled = false;
            Load_DataGridView();
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT * FROM tblkhach";
            tblKH = Functions.GetDataToTable(sql);
            dtgvkh.DataSource = tblKH;
            dtgvkh.Columns[0].HeaderText = "Mã khách hàng";
            dtgvkh.Columns[1].HeaderText = "Tên khách hàng";
            dtgvkh.Columns[2].HeaderText = "Địa chỉ";
            dtgvkh.Columns[3].HeaderText = "Điện thoại";
            dtgvkh.Columns[0].Width = 100;
            dtgvkh.Columns[1].Width = 150;
            dtgvkh.Columns[2].Width = 150;
            dtgvkh.Columns[3].Width = 150;
            dtgvkh.AllowUserToAddRows = false;
            dtgvkh.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dtgvkh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btn_Thêm.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_makh.Focus();
                return;
            }
            if (tblKH.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txt_makh.Text = dtgvkh.CurrentRow.Cells["makhach"].Value.ToString();
            txt_tenkh.Text = dtgvkh.CurrentRow.Cells["tenkhach"].Value.ToString();
            txt_dc.Text = dtgvkh.CurrentRow.Cells["diachi"].Value.ToString();
            txt_đt.Text = dtgvkh.CurrentRow.Cells["dienthoai"].Value.ToString();
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
            txt_makh.Enabled = true;
            txt_makh.Focus();
        }
        private void ResetValues()
        {
            txt_makh.Text = "";
            txt_tenkh.Text = "";
            txt_dc.Text = "";
            txt_đt.Text = "";
        }

        private void btn_Lưu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txt_makh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_makh.Focus();
                return;
            }
            if (txt_tenkh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_tenkh.Focus();
                return;
            }
            if (txt_dc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_dc.Focus();
                return;
            }
            if (txt_đt.Text == "")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_đt.Focus();
                return;
            }
            sql = "SELECT makhach FROM tblkhach WHERE makhach=N'" + txt_makh.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã khách này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_makh.Focus();
                txt_makh.Text = "";
                return;
            }
            sql = "INSERT INTO tblkhach(makhach,tenkhach,diachi,dienthoai) VALUES (N'" + txt_makh.Text.Trim() + "',N'" + txt_tenkh.Text.Trim() + "',N'" + txt_dc.Text.Trim() + "', N'" + txt_đt.Text + "')";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btn_Xóa.Enabled = true;
            btn_Thêm.Enabled = true;
            btn_Sửa.Enabled = true;
            btn_bỏ.Enabled = false;
            btn_Lưu.Enabled = false;
            txt_makh.Enabled = false;

        }

        private void btn_Sửa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblKH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txt_makh.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txt_makh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_makh.Focus();
                return;
            }
            if (txt_dc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_dc.Focus();
                return;
            }
            if (txt_đt.Text == "")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_đt.Focus();
                return;
            }
            sql = "UPDATE tblkhach SET  tenkhach=N'" + txt_tenkh.Text.Trim().ToString() + "',diachi=N'" + txt_dc.Text.Trim().ToString() + "',dienthoai='" + txt_đt.Text.ToString() + "' WHERE makhach=N'" + txt_makh.Text + "'";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btn_bỏ.Enabled = false;
           
        }

        private void btn_Xóa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblKH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txt_makh.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblkhach WHERE makhach=N'" + txt_makh.Text + "'";
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
            txt_makh.Enabled = false;
            Load_DataGridView();
        }

        private void btn_Đóng_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txt_makhtk.Text == "") && (txt_dttk.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM tblkhach WHERE 1=1";
            if (txt_makhtk.Text != "")
                sql = sql + " AND makhach Like N'%" + txt_makh.Text + "%'";
            if (txt_dttk.Text != "")
                sql = sql + " AND dienthoai Like N'%" + txt_đt.Text + "%'";
            tblKH = Functions.GetDataToTable(sql);
            if (tblKH.Rows.Count == 0)
                MessageBox.Show("Không tìm thấy khách hàng này!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //else
            //MessageBox.Show("Đã tìm thấy khách hàng này!!!","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dtgvkh.DataSource = tblKH;
            string str;
            str = "select makhach from tblkhach where makhach=N'" + txt_makhtk.Text + "' or dienthoai = '" + txt_dttk.Text + "'";
            txt_makh.Text = Functions.GetFieldValues(str);
            str = "select tenkhach from tblkhach where makhach=N'" + txt_makhtk.Text + "' or dienthoai = '" + txt_dttk.Text + "'";
            txt_tenkh.Text = Functions.GetFieldValues(str);
            str = "select diachi from tblkhach where makhach=N'" + txt_makhtk.Text + "' or dienthoai = '" + txt_dttk.Text + "'";
            txt_dc.Text = Functions.GetFieldValues(str);
            str = "SELECT dienthoai FROM tblkhach WHERE makhach=N'" + txt_makhtk.Text + "' or dienthoai = '" + txt_dttk.Text + "'";
            txt_đt.Text = Functions.GetFieldValues(str);
            btn_bỏ.Enabled = true;
            txt_makhtk.Text = "";
            txt_dttk.Text = "";

        }

        private void txt_makh_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
