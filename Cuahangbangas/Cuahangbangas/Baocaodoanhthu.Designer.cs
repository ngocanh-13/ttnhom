namespace Cuahangbangas
{
    partial class Baocaodoanhthu
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
            this.txtNgaybatdau = new System.Windows.Forms.TextBox();
            this.txtNgayketthuc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DataGridView = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDoanhthu = new System.Windows.Forms.TextBox();
            this.cbotennhanvien = new System.Windows.Forms.ComboBox();
            this.btnXemdoanhthu = new System.Windows.Forms.Button();
            this.btnInbaocao = new System.Windows.Forms.Button();
            this.btnTimlai = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(32, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(337, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Đến ngày";
            // 
            // txtNgaybatdau
            // 
            this.txtNgaybatdau.Location = new System.Drawing.Point(100, 73);
            this.txtNgaybatdau.Name = "txtNgaybatdau";
            this.txtNgaybatdau.Size = new System.Drawing.Size(152, 20);
            this.txtNgaybatdau.TabIndex = 2;
            this.txtNgaybatdau.TextChanged += new System.EventHandler(this.txtNgaybatdau_TextChanged);
            // 
            // txtNgayketthuc
            // 
            this.txtNgayketthuc.Location = new System.Drawing.Point(423, 73);
            this.txtNgayketthuc.Name = "txtNgayketthuc";
            this.txtNgayketthuc.Size = new System.Drawing.Size(152, 20);
            this.txtNgayketthuc.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(180, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(306, 32);
            this.label3.TabIndex = 4;
            this.label3.Text = "BÁO CÁO DOANH THU";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DataGridView);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox1.Location = new System.Drawing.Point(37, 116);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(577, 176);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Doanh thu các ngày";
            // 
            // DataGridView
            // 
            this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView.Location = new System.Drawing.Point(15, 27);
            this.DataGridView.Name = "DataGridView";
            this.DataGridView.Size = new System.Drawing.Size(556, 136);
            this.DataGridView.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(32, 326);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Doanh thu";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(299, 322);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(172, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Mã nhân viên lập báo cáo";
            // 
            // txtDoanhthu
            // 
            this.txtDoanhthu.Location = new System.Drawing.Point(118, 319);
            this.txtDoanhthu.Name = "txtDoanhthu";
            this.txtDoanhthu.Size = new System.Drawing.Size(163, 20);
            this.txtDoanhthu.TabIndex = 8;
            // 
            // cbotennhanvien
            // 
            this.cbotennhanvien.FormattingEnabled = true;
            this.cbotennhanvien.Location = new System.Drawing.Point(477, 318);
            this.cbotennhanvien.Name = "cbotennhanvien";
            this.cbotennhanvien.Size = new System.Drawing.Size(137, 21);
            this.cbotennhanvien.TabIndex = 9;
            // 
            // btnXemdoanhthu
            // 
            this.btnXemdoanhthu.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnXemdoanhthu.Location = new System.Drawing.Point(89, 372);
            this.btnXemdoanhthu.Name = "btnXemdoanhthu";
            this.btnXemdoanhthu.Size = new System.Drawing.Size(117, 28);
            this.btnXemdoanhthu.TabIndex = 10;
            this.btnXemdoanhthu.Text = "Xem doanh thu";
            this.btnXemdoanhthu.UseVisualStyleBackColor = true;
            this.btnXemdoanhthu.Click += new System.EventHandler(this.btnXemdoanhthu_Click);
            // 
            // btnInbaocao
            // 
            this.btnInbaocao.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnInbaocao.Location = new System.Drawing.Point(221, 372);
            this.btnInbaocao.Name = "btnInbaocao";
            this.btnInbaocao.Size = new System.Drawing.Size(117, 28);
            this.btnInbaocao.TabIndex = 11;
            this.btnInbaocao.Text = "In báo cáo";
            this.btnInbaocao.UseVisualStyleBackColor = true;
            this.btnInbaocao.Click += new System.EventHandler(this.btnInbaocao_Click);
            // 
            // btnTimlai
            // 
            this.btnTimlai.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnTimlai.Location = new System.Drawing.Point(354, 372);
            this.btnTimlai.Name = "btnTimlai";
            this.btnTimlai.Size = new System.Drawing.Size(117, 28);
            this.btnTimlai.TabIndex = 12;
            this.btnTimlai.Text = "Tìm lại";
            this.btnTimlai.UseVisualStyleBackColor = true;
            this.btnTimlai.Click += new System.EventHandler(this.btnTimlai_Click);
            // 
            // btnDong
            // 
            this.btnDong.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnDong.Location = new System.Drawing.Point(491, 372);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(117, 28);
            this.btnDong.TabIndex = 13;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // Baocaodoanhthu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 423);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnTimlai);
            this.Controls.Add(this.btnInbaocao);
            this.Controls.Add(this.btnXemdoanhthu);
            this.Controls.Add(this.cbotennhanvien);
            this.Controls.Add(this.txtDoanhthu);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNgayketthuc);
            this.Controls.Add(this.txtNgaybatdau);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Baocaodoanhthu";
            this.Text = "Baocaodoanhthu";
            this.Load += new System.EventHandler(this.Baocaodoanhthu_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNgaybatdau;
        private System.Windows.Forms.TextBox txtNgayketthuc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView DataGridView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDoanhthu;
        private System.Windows.Forms.ComboBox cbotennhanvien;
        private System.Windows.Forms.Button btnXemdoanhthu;
        private System.Windows.Forms.Button btnInbaocao;
        private System.Windows.Forms.Button btnTimlai;
        private System.Windows.Forms.Button btnDong;
    }
}