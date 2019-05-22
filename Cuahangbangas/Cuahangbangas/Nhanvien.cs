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
    public partial class Nhanvien : Form
    {
        public Nhanvien()
        {
            InitializeComponent();
        }
        DataTable tblnhanvien;

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Nhanvien_Load(object sender, EventArgs e)
        {
            txt_manv.Enabled = false;
            btn_Lưu.Enabled = false;
            btn_bỏ.Enabled = false;
            Load_DataGridView();
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT * FROM tblnhanvien";
            tblnhanvien = Functions.GetDataToTable(sql);
            dtgvnv.DataSource = tblnhanvien;
            dtgvnv.Columns[0].HeaderText = "Mã nhân viên";
            dtgvnv.Columns[1].HeaderText = "Họ và tên";
            dtgvnv.Columns[2].HeaderText = "Giới tính";
            dtgvnv.Columns[3].HeaderText = "Ngày sinh";
            dtgvnv.Columns[4].HeaderText = "Điện thoại";
            dtgvnv.Columns[5].HeaderText = "Địa chỉ";
            dtgvnv.Columns[6].HeaderText = "Chức vụ";
            dtgvnv.Columns[7].HeaderText = "Mức lương";
            dtgvnv.Columns[0].Width = 100;
            dtgvnv.Columns[1].Width = 150;
            dtgvnv.Columns[2].Width = 100;
            dtgvnv.Columns[3].Width = 150;
            dtgvnv.Columns[4].Width = 100;
            dtgvnv.Columns[5].Width = 100;
            dtgvnv.Columns[6].Width = 100;
            dtgvnv.Columns[7].Width = 100;
            dtgvnv.AllowUserToAddRows = false;
            dtgvnv.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dtgvnv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btn_Thêm.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_manv.Focus();
                return;
            }
            if (tblnhanvien.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txt_manv.Text = dtgvnv.CurrentRow.Cells["manv"].Value.ToString();
            txt_tennv.Text = dtgvnv.CurrentRow.Cells["hoten"].Value.ToString();
            cbx_gioitinh.Text = dtgvnv.CurrentRow.Cells["gioitinh"].Value.ToString();
            mskns.Text = dtgvnv.CurrentRow.Cells["ngaysinh"].Value.ToString();
            txt_dt.Text = dtgvnv.CurrentRow.Cells["dienthoai"].Value.ToString();
            txt_đc.Text = dtgvnv.CurrentRow.Cells["diachi"].Value.ToString();
            cbx_chucvu.Text = dtgvnv.CurrentRow.Cells["chucvu"].Value.ToString();
            txt_luong.Text = dtgvnv.CurrentRow.Cells["mucluong"].Value.ToString();
            btn_Sửa.Enabled = true;
            btn_Xóa.Enabled = true;
            btn_bỏ.Enabled = true;

        }
        private void ResetValues()
        {
            txt_manv.Text = "";
            txt_tennv.Text = "";
            cbx_gioitinh.Text = "";
            mskns.Text = "";
            txt_dt.Text = "";
            txt_đc.Text = "";
            cbx_chucvu.Text = "";
            txt_luong.Text = "";
        }

        private void btn_Thêm_Click(object sender, EventArgs e)
        {
            btn_Sửa.Enabled = false;
            btn_Thêm.Enabled = false;
            btn_bỏ.Enabled = true;
            btn_Xóa.Enabled = false;
            btn_Lưu.Enabled = true;
            ResetValues();
            txt_manv.Enabled = true;
            txt_manv.Focus();
        }

        private void btn_Xóa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblnhanvien.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txt_manv.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblnv WHERE manv=N'" + txt_manv.Text + "'";
                Functions.RunSqlDel(sql);
                Load_DataGridView();
                ResetValues();
            }
        }

        private void btn_Sửa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblnhanvien.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txt_manv.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txt_tennv.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_tennv.Focus();
                return;
            }
            if (txt_đc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_đc.Focus();
                return;
            }
            if (txt_dt.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_dt.Focus();
                return;
            }
            if (mskns.Text == "  /  /")
            {
                MessageBox.Show("Bạn phải nhập ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskns.Focus();
                return;
            }
            
            sql = "UPDATE tblnhanvien SET  hoten=N'" + txt_tennv.Text.Trim().ToString() + "', gioitinh=N'" + cbx_gioitinh.Text + "', ngaysinh= N'" + Functions.ConvertDateTime(mskns.Text) + "',dienthoai=N'" + txt_dt.Text.ToString() + "', diachi=N'" + txt_đc.Text.Trim().ToString() + "', chucvu=N'" + cbx_chucvu.Text.Trim().ToString() + "', mucluong='" + txt_luong.Text.ToString() + "' WHERE manv=N'" + txt_manv.Text + "'";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btn_bỏ.Enabled = false;

        }

        private void btn_Lưu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txt_manv.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_manv.Focus();
                return;
            }
            if (txt_tennv.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_tennv.Focus();
                return;
            }
            if (cbx_gioitinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbx_gioitinh.Focus();
                return;
            }


            if (mskns.Text == " / / ")
            {
                MessageBox.Show("Bạn phải nhập ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskns.Focus();
                return;
            }

           
            if (txt_dt.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_dt.Focus();
                return;
            }

            if (txt_đc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_đc.Focus();
                return;
            }

            if (cbx_chucvu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập chức vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbx_chucvu.Focus();
                return;
            }

            if (txt_luong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_luong.Focus();
                return;
            }
            sql = "SELECT manv FROM tblnhanvien WHERE manv=N'" + txt_manv.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã nhân viên này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_manv.Focus();
                txt_manv.Text = "";
                return;
            }
            sql = "INSERT INTO tblnhanvien(manv,hoten,gioitinh, ngaysinh, dienthoai, diachi, chucvu, mucluong) VALUES (N'" + txt_manv.Text.Trim() + "',N'" + txt_tennv.Text.Trim() + "',N'" + cbx_gioitinh.Text.Trim() + "','" + Functions.ConvertDateTime(mskns.Text) + "',N'" + txt_dt.Text.Trim() + "',N'" + txt_đc.Text + "',N'" + cbx_chucvu.Text.Trim() + "',N'" + txt_luong.Text + "' )";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btn_Đóng.Enabled = true;
            btn_Thêm.Enabled = true;
            btn_Sửa.Enabled = true;
            btn_bỏ.Enabled = false;
            btn_Lưu.Enabled = false;
            txt_manv.Enabled = false;

        }

        private void btn_bỏ_Click(object sender, EventArgs e)
        {
            ResetValues();
            btn_bỏ.Enabled = false;
            btn_Thêm.Enabled = true;
            btn_Xóa.Enabled = true;
            btn_Sửa.Enabled = true;
            btn_Lưu.Enabled = false;
            txt_manv.Enabled = false;

        }
        private void txtmucluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;

        }

        private void btn_Đóng_Click(object sender, EventArgs e)
        {
            this.Close();  
        }

        private void cbx_gioitinh_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void cbx_chucvu_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
