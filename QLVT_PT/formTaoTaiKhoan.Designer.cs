﻿namespace QLVT_PT
{
    partial class formTaoTaiKhoan
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textMatKhau = new DevExpress.XtraEditors.TextEdit();
            this.textXacNhanMK = new DevExpress.XtraEditors.TextEdit();
            this.showPass = new DevExpress.XtraEditors.CheckEdit();
            this.showConfirmPass = new DevExpress.XtraEditors.CheckEdit();
            this.cmbVaiTro = new System.Windows.Forms.ComboBox();
            this.btnTaoTaiKhoan = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textTaiKhoan = new DevExpress.XtraEditors.TextEdit();
            this.boxMaNV = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.textMatKhau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textXacNhanMK.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.showPass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.showConfirmPass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textTaiKhoan.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(195, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "TẠO TÀI KHOẢN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(90, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã Nhân Viên: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(90, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mật Khẩu:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(90, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nhập Lại Mật Khẩu:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(90, 209);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Vai Trò:";
            // 
            // textMatKhau
            // 
            this.textMatKhau.Location = new System.Drawing.Point(228, 134);
            this.textMatKhau.Name = "textMatKhau";
            this.textMatKhau.Properties.PasswordChar = '*';
            this.textMatKhau.Size = new System.Drawing.Size(134, 20);
            this.textMatKhau.TabIndex = 5;
            // 
            // textXacNhanMK
            // 
            this.textXacNhanMK.Location = new System.Drawing.Point(228, 168);
            this.textXacNhanMK.Name = "textXacNhanMK";
            this.textXacNhanMK.Properties.PasswordChar = '*';
            this.textXacNhanMK.Size = new System.Drawing.Size(134, 20);
            this.textXacNhanMK.TabIndex = 6;
            // 
            // showPass
            // 
            this.showPass.Location = new System.Drawing.Point(383, 134);
            this.showPass.Name = "showPass";
            this.showPass.Properties.Caption = "";
            this.showPass.Size = new System.Drawing.Size(25, 20);
            this.showPass.TabIndex = 7;
            this.showPass.CheckedChanged += new System.EventHandler(this.showPass_CheckedChanged);
            // 
            // showConfirmPass
            // 
            this.showConfirmPass.Location = new System.Drawing.Point(383, 168);
            this.showConfirmPass.Name = "showConfirmPass";
            this.showConfirmPass.Properties.Caption = "";
            this.showConfirmPass.Size = new System.Drawing.Size(25, 20);
            this.showConfirmPass.TabIndex = 8;
            this.showConfirmPass.CheckedChanged += new System.EventHandler(this.showConfirmPass_CheckedChanged);
            // 
            // cmbVaiTro
            // 
            this.cmbVaiTro.FormattingEnabled = true;
            this.cmbVaiTro.Location = new System.Drawing.Point(228, 204);
            this.cmbVaiTro.Name = "cmbVaiTro";
            this.cmbVaiTro.Size = new System.Drawing.Size(134, 21);
            this.cmbVaiTro.TabIndex = 11;
            this.cmbVaiTro.SelectedIndexChanged += new System.EventHandler(this.cmbVaiTro_SelectedIndexChanged);
            // 
            // btnTaoTaiKhoan
            // 
            this.btnTaoTaiKhoan.BackColor = System.Drawing.Color.Blue;
            this.btnTaoTaiKhoan.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaoTaiKhoan.ForeColor = System.Drawing.Color.White;
            this.btnTaoTaiKhoan.Location = new System.Drawing.Point(132, 255);
            this.btnTaoTaiKhoan.Name = "btnTaoTaiKhoan";
            this.btnTaoTaiKhoan.Size = new System.Drawing.Size(124, 39);
            this.btnTaoTaiKhoan.TabIndex = 12;
            this.btnTaoTaiKhoan.Text = "TẠO";
            this.btnTaoTaiKhoan.UseVisualStyleBackColor = false;
            this.btnTaoTaiKhoan.Click += new System.EventHandler(this.btnTaoTaiKhoan_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.Red;
            this.btnThoat.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.Color.White;
            this.btnThoat.Location = new System.Drawing.Point(327, 255);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(124, 39);
            this.btnThoat.TabIndex = 13;
            this.btnThoat.Text = "THOÁT";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(90, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 16);
            this.label6.TabIndex = 14;
            this.label6.Text = "Tài Khoản:";
            // 
            // textTaiKhoan
            // 
            this.textTaiKhoan.Location = new System.Drawing.Point(228, 98);
            this.textTaiKhoan.Name = "textTaiKhoan";
            this.textTaiKhoan.Size = new System.Drawing.Size(134, 20);
            this.textTaiKhoan.TabIndex = 15;
            // 
            // boxMaNV
            // 
            this.boxMaNV.FormattingEnabled = true;
            this.boxMaNV.Location = new System.Drawing.Point(228, 63);
            this.boxMaNV.Name = "boxMaNV";
            this.boxMaNV.Size = new System.Drawing.Size(134, 21);
            this.boxMaNV.TabIndex = 16;
            this.boxMaNV.SelectedIndexChanged += new System.EventHandler(this.boxMaNV_SelectedIndexChanged);
            // 
            // formTaoTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 349);
            this.Controls.Add(this.boxMaNV);
            this.Controls.Add(this.textTaiKhoan);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnTaoTaiKhoan);
            this.Controls.Add(this.cmbVaiTro);
            this.Controls.Add(this.showConfirmPass);
            this.Controls.Add(this.showPass);
            this.Controls.Add(this.textXacNhanMK);
            this.Controls.Add(this.textMatKhau);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formTaoTaiKhoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tạo Tài Khoản";
            this.Load += new System.EventHandler(this.FormTaoTaiKhoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.textMatKhau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textXacNhanMK.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.showPass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.showConfirmPass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textTaiKhoan.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        
        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.TextEdit textMatKhau;
        private DevExpress.XtraEditors.TextEdit textXacNhanMK;
        private DevExpress.XtraEditors.CheckEdit showPass;
        private DevExpress.XtraEditors.CheckEdit showConfirmPass;
        private System.Windows.Forms.ComboBox cmbVaiTro;
        private System.Windows.Forms.Button btnTaoTaiKhoan;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.TextEdit textTaiKhoan;
        private System.Windows.Forms.ComboBox boxMaNV;
    }
}