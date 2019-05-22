namespace Cuahangbangas
{
    partial class Nhacungcap
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_mncc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_tenncc = new System.Windows.Forms.TextBox();
            this.txt_đt = new System.Windows.Forms.TextBox();
            this.txt_dc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtgvncc = new System.Windows.Forms.DataGridView();
            this.btn_Thêm = new System.Windows.Forms.Button();
            this.btn_Xóa = new System.Windows.Forms.Button();
            this.btn_Sửa = new System.Windows.Forms.Button();
            this.btn_Lưu = new System.Windows.Forms.Button();
            this.btn_bỏ = new System.Windows.Forms.Button();
            this.btn_Đóng = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvncc)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(182, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(326, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "DANH MỤC NHÀ CUNG CẤP";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(38, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã nhà cung cấp";
            // 
            // txt_mncc
            // 
            this.txt_mncc.Location = new System.Drawing.Point(170, 63);
            this.txt_mncc.Name = "txt_mncc";
            this.txt_mncc.Size = new System.Drawing.Size(141, 20);
            this.txt_mncc.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(38, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tên nhà cung cấp";
            // 
            // txt_tenncc
            // 
            this.txt_tenncc.Location = new System.Drawing.Point(170, 99);
            this.txt_tenncc.Name = "txt_tenncc";
            this.txt_tenncc.Size = new System.Drawing.Size(141, 20);
            this.txt_tenncc.TabIndex = 4;
            // 
            // txt_đt
            // 
            this.txt_đt.Location = new System.Drawing.Point(457, 96);
            this.txt_đt.Name = "txt_đt";
            this.txt_đt.Size = new System.Drawing.Size(141, 20);
            this.txt_đt.TabIndex = 5;
            // 
            // txt_dc
            // 
            this.txt_dc.Location = new System.Drawing.Point(457, 60);
            this.txt_dc.Name = "txt_dc";
            this.txt_dc.Size = new System.Drawing.Size(141, 20);
            this.txt_dc.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(370, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Điện Thoại";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(370, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Địa chỉ";
            // 
            // dtgvncc
            // 
            this.dtgvncc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvncc.Location = new System.Drawing.Point(7, 143);
            this.dtgvncc.Name = "dtgvncc";
            this.dtgvncc.Size = new System.Drawing.Size(698, 199);
            this.dtgvncc.TabIndex = 9;
            this.dtgvncc.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvncc_CellContentClick);
            // 
            // btn_Thêm
            // 
            this.btn_Thêm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_Thêm.Location = new System.Drawing.Point(28, 363);
            this.btn_Thêm.Name = "btn_Thêm";
            this.btn_Thêm.Size = new System.Drawing.Size(75, 23);
            this.btn_Thêm.TabIndex = 10;
            this.btn_Thêm.Text = "Thêm";
            this.btn_Thêm.UseVisualStyleBackColor = true;
            this.btn_Thêm.Click += new System.EventHandler(this.btn_Thêm_Click);
            // 
            // btn_Xóa
            // 
            this.btn_Xóa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_Xóa.Location = new System.Drawing.Point(135, 363);
            this.btn_Xóa.Name = "btn_Xóa";
            this.btn_Xóa.Size = new System.Drawing.Size(75, 23);
            this.btn_Xóa.TabIndex = 11;
            this.btn_Xóa.Text = "Xóa";
            this.btn_Xóa.UseVisualStyleBackColor = true;
            this.btn_Xóa.Click += new System.EventHandler(this.btn_Xóa_Click);
            // 
            // btn_Sửa
            // 
            this.btn_Sửa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_Sửa.Location = new System.Drawing.Point(247, 363);
            this.btn_Sửa.Name = "btn_Sửa";
            this.btn_Sửa.Size = new System.Drawing.Size(75, 23);
            this.btn_Sửa.TabIndex = 12;
            this.btn_Sửa.Text = "Sửa";
            this.btn_Sửa.UseVisualStyleBackColor = true;
            this.btn_Sửa.Click += new System.EventHandler(this.btn_Sửa_Click);
            // 
            // btn_Lưu
            // 
            this.btn_Lưu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_Lưu.Location = new System.Drawing.Point(351, 363);
            this.btn_Lưu.Name = "btn_Lưu";
            this.btn_Lưu.Size = new System.Drawing.Size(75, 23);
            this.btn_Lưu.TabIndex = 13;
            this.btn_Lưu.Text = "Lưu";
            this.btn_Lưu.UseVisualStyleBackColor = true;
            this.btn_Lưu.Click += new System.EventHandler(this.btn_Lưu_Click);
            // 
            // btn_bỏ
            // 
            this.btn_bỏ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_bỏ.Location = new System.Drawing.Point(457, 363);
            this.btn_bỏ.Name = "btn_bỏ";
            this.btn_bỏ.Size = new System.Drawing.Size(75, 23);
            this.btn_bỏ.TabIndex = 14;
            this.btn_bỏ.Text = "Bỏ qua";
            this.btn_bỏ.UseVisualStyleBackColor = true;
            this.btn_bỏ.Click += new System.EventHandler(this.btn_bỏ_Click);
            // 
            // btn_Đóng
            // 
            this.btn_Đóng.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_Đóng.Location = new System.Drawing.Point(565, 363);
            this.btn_Đóng.Name = "btn_Đóng";
            this.btn_Đóng.Size = new System.Drawing.Size(75, 23);
            this.btn_Đóng.TabIndex = 15;
            this.btn_Đóng.Text = "Đóng";
            this.btn_Đóng.UseVisualStyleBackColor = true;
            this.btn_Đóng.Click += new System.EventHandler(this.btn_Đóng_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_Đóng);
            this.panel1.Controls.Add(this.btn_bỏ);
            this.panel1.Controls.Add(this.btn_Lưu);
            this.panel1.Controls.Add(this.btn_Sửa);
            this.panel1.Controls.Add(this.btn_Xóa);
            this.panel1.Controls.Add(this.btn_Thêm);
            this.panel1.Controls.Add(this.dtgvncc);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txt_dc);
            this.panel1.Controls.Add(this.txt_đt);
            this.panel1.Controls.Add(this.txt_tenncc);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txt_mncc);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(714, 399);
            this.panel1.TabIndex = 16;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // Nhacungcap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 418);
            this.Controls.Add(this.panel1);
            this.Name = "Nhacungcap";
            this.Text = "Danh Mục Nhà Cung Cấp";
            this.Load += new System.EventHandler(this.Danhmucnhacungcap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvncc)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_mncc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_tenncc;
        private System.Windows.Forms.TextBox txt_đt;
        private System.Windows.Forms.TextBox txt_dc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dtgvncc;
        private System.Windows.Forms.Button btn_Thêm;
        private System.Windows.Forms.Button btn_Xóa;
        private System.Windows.Forms.Button btn_Sửa;
        private System.Windows.Forms.Button btn_Lưu;
        private System.Windows.Forms.Button btn_bỏ;
        private System.Windows.Forms.Button btn_Đóng;
        private System.Windows.Forms.Panel panel1;
    }
}