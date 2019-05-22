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
    public partial class Chuongtrinhbanhang : Form
    {
        public Chuongtrinhbanhang()
        {
            InitializeComponent();
        }

        private void Chuongtrinhbanhang_Load(object sender, EventArgs e)
        {
            Functions.Connect();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Functions.Disconnect();
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi chương trình?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes) 
                Application.Exit();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nhanvien f = new Nhanvien();
            f.Show();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Khachhang f = new Khachhang();
            f.Show();
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nhacungcap f = new Nhacungcap();
            f.Show();
        }

        private void hàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hanghoa1 f = new Hanghoa1();
            f.Show();
        }

        private void hóaĐơnBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hoadonban f = new Hoadonban();
            f.Show();
        }

        private void hóaĐơnNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hoadonnhap f = new Hoadonnhap();
            f.Show();
        }

        private void hàngTồnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Baocaohangton f = new Baocaohangton();
            f.Show();
        }

        private void doanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Baocaodoanhthu f = new Baocaodoanhthu();
            f.Show();
        }

        private void hỗTrợToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hotro f = new Hotro();
            f.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
