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

namespace Cuahangbangas
{
    public partial class Loginf : Form
    {
        public Loginf()
        {
            InitializeComponent();
        }

        private void Loginf_Load(object sender, EventArgs e)
        {
            
        }

        

        private void btn_Login_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=ANHPC\SQLEXPRESS;Initial Catalog=CuahangGiaThinh;Integrated Security=True");
            string sqlSelect = "Select * from tbltaikhoan where taikhoan=N'" + txt_user.Text + "'and matkhau=N'" + txt_pass.Text + "'";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlSelect, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read() == true)
            {
                this.Hide();
                MessageBox.Show("Đăng nhập thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Chuongtrinhbanhang main = new Chuongtrinhbanhang();
                main.Show();
                
            }
            else
            {
                MessageBox.Show("Tên tài khoản hoặc mật khẩu không đúng. Bạn hãy nhập lại !");
                txt_user.Text = "";
                txt_pass.Text = "";
                txt_user.Focus();
            }
        }

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

