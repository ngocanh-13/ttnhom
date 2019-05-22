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
    public partial class Hanghoa1 : Form
    {
        public Hanghoa1()
        {
            InitializeComponent();
        }
        DataTable tblH;
        private void Hanghoa1_Load(object sender, EventArgs e)
        {
            txtMahang.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            Load_DataGridView();
            ResetValues();
        }
        private void ResetValues()
        {
            txtMahang.Text = "";
            txtTenhang.Text = "";
            cbodonvitinh.Text = "";
            txtSoluong.Text = "0";
            txtDongianhap.Text = "0";
            txtDongiaban.Text = "0";
            txtSoluong.Enabled = false;
            txtDongianhap.Enabled = false;
            txtDongiaban.Enabled = false;
            txtAnh.Text = "";
            //picAnh.Image = null;
            txtGhichu.Text = "";
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT * FROM tblhang";
            tblH = Functions.GetDataToTable(sql);
            DataGridView.DataSource = tblH;
            DataGridView.Columns[0].HeaderText = "Mã hàng";
            DataGridView.Columns[1].HeaderText = "Tên hàng";
            DataGridView.Columns[2].HeaderText = "Đơn vị tính";
            DataGridView.Columns[3].HeaderText = "Số lượng";
            DataGridView.Columns[4].HeaderText = "Đơn giá nhập";
            DataGridView.Columns[5].HeaderText = "Đơn giá bán";
            DataGridView.Columns[6].HeaderText = "Ảnh";
            DataGridView.Columns[7].HeaderText = "Ghi chú";
            DataGridView.Columns[0].Width = 80;
            DataGridView.Columns[1].Width = 140;
            DataGridView.Columns[2].Width = 80;
            DataGridView.Columns[3].Width = 80;
            DataGridView.Columns[4].Width = 100;
            DataGridView.Columns[5].Width = 100;
            DataGridView.Columns[6].Width = 200;
            DataGridView.Columns[7].Width = 200;
            DataGridView.AllowUserToAddRows = false;
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMahang.Focus();
                return;
            }
            if (tblH.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMahang.Text = DataGridView.CurrentRow.Cells["mahang"].Value.ToString();
            txtTenhang.Text = DataGridView.CurrentRow.Cells["tenhang"].Value.ToString();
            cbodonvitinh.Text = DataGridView.CurrentRow.Cells["dvt"].Value.ToString();
            txtSoluong.Text = DataGridView.CurrentRow.Cells["soluong"].Value.ToString();
            txtDongianhap.Text = DataGridView.CurrentRow.Cells["dongianhap"].Value.ToString();
            txtDongiaban.Text = DataGridView.CurrentRow.Cells["dongiaban"].Value.ToString();
            txtAnh.Text = Functions.GetFieldValues("SELECT anh FROM tblhang WHERE mahang = N'" + txtMahang.Text + "'");
            // picAnh.Image = Image.FromFile(txtAnh.Text);
            txtGhichu.Text = Functions.GetFieldValues("SELECT ghichu FROM tblhang WHERE mahang = N'" + txtMahang.Text + "'");
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoqua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtSoluong.Text = "";
            txtDongianhap.Text = "";
            txtDongiaban.Text = "";
            txtMahang.Enabled = true;
            txtSoluong.Enabled = true;
            txtDongiaban.Enabled = true;
            txtDongianhap.Enabled = true;
            txtMahang.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMahang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMahang.Focus();
                return;
            }
            if (txtTenhang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenhang.Focus();
                return;
            }
            if (cbodonvitinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập đơn vị tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbodonvitinh.Focus();
                return;
            }
            if (txtAnh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn ảnh minh họa cho hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAnh.Focus();
                return;
            }
            sql = "SELECT mahang FROM tblhang WHERE mahang=N'" + txtMahang.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã hàng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMahang.Focus();
                txtMahang.Text = "";
                return;
            }
            sql = "INSERT INTO tblhang(mahang,tenhang,dvt,soluong,dongianhap, dongiaban,anh,ghichu) VALUES(N'" + txtMahang.Text.Trim() + "',N'" + txtTenhang.Text.Trim() + "',N'" + cbodonvitinh.Text.Trim() + "','" + txtSoluong.Text.Trim() + "','" + txtDongianhap.Text + "','" + txtDongiaban.Text.Trim() + "','" + txtAnh.Text.Trim() + "',N'" + txtGhichu.Text.Trim() + "')";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtMahang.Enabled = false;

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMahang.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenhang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenhang.Focus();
                return;
            }
            if (cbodonvitinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập đơn vị tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbodonvitinh.Focus();
                return;
            }
            if (txtAnh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn ảnh minh họa cho hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAnh.Focus();
                return;
            }

            sql = "UPDATE tblhang SET  tenhang=N'" + txtTenhang.Text.Trim().ToString() + "',dvt=N'" + cbodonvitinh.Text + "',soluong='" + txtSoluong.Text.Trim() + "', dongianhap='" + txtDongianhap.Text.Trim() + "', dongiaban='" + txtDongiaban.Text.Trim() + "', anh='" + txtAnh.Text + "',ghichu=N'" + txtGhichu.Text + "' WHERE mahang=N'" + txtMahang.Text.ToString() + "'";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnBoqua.Enabled = false;

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMahang.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblhang WHERE mahang=N'" + txtMahang.Text + "'";
                Functions.RunSqlDel(sql);
                Load_DataGridView();
                ResetValues();
            }

        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnBoqua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMahang.Enabled = false;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Bitmap(*.bmp)|*.bmp|Gif(*.gif)|*.gif|All files(*.*)|*.*";
            dlgOpen.InitialDirectory = "E:\\";
            dlgOpen.FilterIndex = 3;
            dlgOpen.Title = "Chọn hình ảnh đề hiển thị";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
               // picAnh.Image = Image.FromFile(dlgOpen.FileName);
                txtAnh.Text = dlgOpen.FileName;
            }

        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtMahang.Text == "") && (txtTenhang.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM tblhang WHERE 1=1";
            if (txtMahang.Text != "")
                sql = sql + " AND mahang Like N'%" + txtMahang.Text + "%'";
            if (txtTenhang.Text != "")
                sql = sql + " AND tenhang Like N'%" + txtTenhang.Text + "%'";

            tblH = Functions.GetDataToTable(sql);
            if (tblH.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Có " + tblH.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DataGridView.DataSource = tblH;
            ResetValues();

        }

        private void btnHienthi_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT * FROM tblhang";
            tblH = Functions.GetDataToTable(sql);
            DataGridView.DataSource = tblH;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
