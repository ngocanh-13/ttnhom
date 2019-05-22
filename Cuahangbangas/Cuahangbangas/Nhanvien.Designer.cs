namespace Cuahangbangas
{
    partial class Nhanvien
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.mskns = new System.Windows.Forms.MaskedTextBox();
            this.cbx_chucvu = new System.Windows.Forms.ComboBox();
            this.cbx_gioitinh = new System.Windows.Forms.ComboBox();
            this.txt_luong = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_dt = new System.Windows.Forms.TextBox();
            this.txt_đc = new System.Windows.Forms.TextBox();
            this.txt_tennv = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_manv = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Đóng = new System.Windows.Forms.Button();
            this.btn_bỏ = new System.Windows.Forms.Button();
            this.btn_Lưu = new System.Windows.Forms.Button();
            this.btn_Sửa = new System.Windows.Forms.Button();
            this.btn_Xóa = new System.Windows.Forms.Button();
            this.btn_Thêm = new System.Windows.Forms.Button();
            this.dtgvnv = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvnv)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.mskns);
            this.panel1.Controls.Add(this.cbx_chucvu);
            this.panel1.Controls.Add(this.cbx_gioitinh);
            this.panel1.Controls.Add(this.txt_luong);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txt_dt);
            this.panel1.Controls.Add(this.txt_đc);
            this.panel1.Controls.Add(this.txt_tennv);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txt_manv);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(19, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(714, 399);
            this.panel1.TabIndex = 17;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // mskns
            // 
            this.mskns.Location = new System.Drawing.Point(170, 166);
            this.mskns.Name = "mskns";
            this.mskns.Size = new System.Drawing.Size(141, 20);
            this.mskns.TabIndex = 18;
            // 
            // cbx_chucvu
            // 
            this.cbx_chucvu.FormattingEnabled = true;
            this.cbx_chucvu.Items.AddRange(new object[] {
            "Nhân viên giao hàng",
            "Nhân viên bán hàng",
            "Quản lý"});
            this.cbx_chucvu.Location = new System.Drawing.Point(457, 131);
            this.cbx_chucvu.Name = "cbx_chucvu";
            this.cbx_chucvu.Size = new System.Drawing.Size(141, 21);
            this.cbx_chucvu.TabIndex = 17;
            this.cbx_chucvu.SelectedIndexChanged += new System.EventHandler(this.cbx_chucvu_SelectedIndexChanged);
            // 
            // cbx_gioitinh
            // 
            this.cbx_gioitinh.FormattingEnabled = true;
            this.cbx_gioitinh.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.cbx_gioitinh.Location = new System.Drawing.Point(170, 135);
            this.cbx_gioitinh.Name = "cbx_gioitinh";
            this.cbx_gioitinh.Size = new System.Drawing.Size(141, 21);
            this.cbx_gioitinh.TabIndex = 16;
            this.cbx_gioitinh.SelectedIndexChanged += new System.EventHandler(this.cbx_gioitinh_SelectedIndexChanged);
            // 
            // txt_luong
            // 
            this.txt_luong.Location = new System.Drawing.Point(457, 166);
            this.txt_luong.Name = "txt_luong";
            this.txt_luong.Size = new System.Drawing.Size(141, 20);
            this.txt_luong.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label9.Location = new System.Drawing.Point(371, 169);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 17);
            this.label9.TabIndex = 14;
            this.label9.Text = "Mức lương";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label8.Location = new System.Drawing.Point(371, 135);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 17);
            this.label8.TabIndex = 13;
            this.label8.Text = "Chức vụ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label7.Location = new System.Drawing.Point(38, 169);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 17);
            this.label7.TabIndex = 10;
            this.label7.Text = "Ngày sinh";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(38, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Giới tính";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(371, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Địa chỉ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(371, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Điện Thoại";
            // 
            // txt_dt
            // 
            this.txt_dt.Location = new System.Drawing.Point(457, 60);
            this.txt_dt.Name = "txt_dt";
            this.txt_dt.Size = new System.Drawing.Size(141, 20);
            this.txt_dt.TabIndex = 6;
            // 
            // txt_đc
            // 
            this.txt_đc.Location = new System.Drawing.Point(457, 96);
            this.txt_đc.Name = "txt_đc";
            this.txt_đc.Size = new System.Drawing.Size(141, 20);
            this.txt_đc.TabIndex = 5;
            // 
            // txt_tennv
            // 
            this.txt_tennv.Location = new System.Drawing.Point(170, 99);
            this.txt_tennv.Name = "txt_tennv";
            this.txt_tennv.Size = new System.Drawing.Size(141, 20);
            this.txt_tennv.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(38, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tên nhân viên";
            // 
            // txt_manv
            // 
            this.txt_manv.Location = new System.Drawing.Point(170, 63);
            this.txt_manv.Name = "txt_manv";
            this.txt_manv.Size = new System.Drawing.Size(141, 20);
            this.txt_manv.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(38, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã nhân viên";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(182, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "DANH MỤC NHÂN VIÊN\r\n";
            // 
            // btn_Đóng
            // 
            this.btn_Đóng.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_Đóng.Location = new System.Drawing.Point(563, 230);
            this.btn_Đóng.Name = "btn_Đóng";
            this.btn_Đóng.Size = new System.Drawing.Size(75, 23);
            this.btn_Đóng.TabIndex = 15;
            this.btn_Đóng.Text = "Đóng";
            this.btn_Đóng.UseVisualStyleBackColor = true;
            this.btn_Đóng.Click += new System.EventHandler(this.btn_Đóng_Click);
            // 
            // btn_bỏ
            // 
            this.btn_bỏ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_bỏ.Location = new System.Drawing.Point(455, 230);
            this.btn_bỏ.Name = "btn_bỏ";
            this.btn_bỏ.Size = new System.Drawing.Size(75, 23);
            this.btn_bỏ.TabIndex = 14;
            this.btn_bỏ.Text = "Bỏ qua";
            this.btn_bỏ.UseVisualStyleBackColor = true;
            this.btn_bỏ.Click += new System.EventHandler(this.btn_bỏ_Click);
            // 
            // btn_Lưu
            // 
            this.btn_Lưu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_Lưu.Location = new System.Drawing.Point(349, 230);
            this.btn_Lưu.Name = "btn_Lưu";
            this.btn_Lưu.Size = new System.Drawing.Size(75, 23);
            this.btn_Lưu.TabIndex = 13;
            this.btn_Lưu.Text = "Lưu";
            this.btn_Lưu.UseVisualStyleBackColor = true;
            this.btn_Lưu.Click += new System.EventHandler(this.btn_Lưu_Click);
            // 
            // btn_Sửa
            // 
            this.btn_Sửa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_Sửa.Location = new System.Drawing.Point(245, 230);
            this.btn_Sửa.Name = "btn_Sửa";
            this.btn_Sửa.Size = new System.Drawing.Size(75, 23);
            this.btn_Sửa.TabIndex = 12;
            this.btn_Sửa.Text = "Sửa";
            this.btn_Sửa.UseVisualStyleBackColor = true;
            this.btn_Sửa.Click += new System.EventHandler(this.btn_Sửa_Click);
            // 
            // btn_Xóa
            // 
            this.btn_Xóa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_Xóa.Location = new System.Drawing.Point(133, 230);
            this.btn_Xóa.Name = "btn_Xóa";
            this.btn_Xóa.Size = new System.Drawing.Size(75, 23);
            this.btn_Xóa.TabIndex = 11;
            this.btn_Xóa.Text = "Xóa";
            this.btn_Xóa.UseVisualStyleBackColor = true;
            this.btn_Xóa.Click += new System.EventHandler(this.btn_Xóa_Click);
            // 
            // btn_Thêm
            // 
            this.btn_Thêm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_Thêm.Location = new System.Drawing.Point(26, 230);
            this.btn_Thêm.Name = "btn_Thêm";
            this.btn_Thêm.Size = new System.Drawing.Size(75, 23);
            this.btn_Thêm.TabIndex = 10;
            this.btn_Thêm.Text = "Thêm";
            this.btn_Thêm.UseVisualStyleBackColor = true;
            this.btn_Thêm.Click += new System.EventHandler(this.btn_Thêm_Click);
            // 
            // dtgvnv
            // 
            this.dtgvnv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvnv.Location = new System.Drawing.Point(5, 10);
            this.dtgvnv.Name = "dtgvnv";
            this.dtgvnv.Size = new System.Drawing.Size(698, 199);
            this.dtgvnv.TabIndex = 9;
            this.dtgvnv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvnv_CellContentClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_Đóng);
            this.panel2.Controls.Add(this.btn_bỏ);
            this.panel2.Controls.Add(this.btn_Lưu);
            this.panel2.Controls.Add(this.btn_Sửa);
            this.panel2.Controls.Add(this.btn_Xóa);
            this.panel2.Controls.Add(this.btn_Thêm);
            this.panel2.Controls.Add(this.dtgvnv);
            this.panel2.Location = new System.Drawing.Point(19, 207);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(711, 265);
            this.panel2.TabIndex = 16;
            // 
            // Nhanvien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 499);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Nhanvien";
            this.Text = "Danh Mục Nhân Viên";
            this.Load += new System.EventHandler(this.Nhanvien_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvnv)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_Đóng;
        private System.Windows.Forms.Button btn_bỏ;
        private System.Windows.Forms.Button btn_Lưu;
        private System.Windows.Forms.Button btn_Sửa;
        private System.Windows.Forms.Button btn_Xóa;
        private System.Windows.Forms.Button btn_Thêm;
        private System.Windows.Forms.DataGridView dtgvnv;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_dt;
        private System.Windows.Forms.TextBox txt_đc;
        private System.Windows.Forms.TextBox txt_tennv;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_manv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbx_chucvu;
        private System.Windows.Forms.ComboBox cbx_gioitinh;
        private System.Windows.Forms.TextBox txt_luong;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox mskns;
    }
}