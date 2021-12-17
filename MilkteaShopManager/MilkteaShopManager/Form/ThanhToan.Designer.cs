
namespace MilkteaShopManager
{
    partial class FormThanhToan
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
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.txtChiPhiKhac = new System.Windows.Forms.TextBox();
            this.cbbThue = new System.Windows.Forms.ComboBox();
            this.mtxtGiamGia = new System.Windows.Forms.MaskedTextBox();
            this.nudGiamGia = new System.Windows.Forms.NumericUpDown();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtTongThanhToan = new System.Windows.Forms.TextBox();
            this.txtThue = new System.Windows.Forms.TextBox();
            this.txtCongTien = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGiamGia)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(210)))), ((int)(((byte)(225)))));
            this.guna2Panel1.Controls.Add(this.txtChiPhiKhac);
            this.guna2Panel1.Controls.Add(this.cbbThue);
            this.guna2Panel1.Controls.Add(this.mtxtGiamGia);
            this.guna2Panel1.Controls.Add(this.nudGiamGia);
            this.guna2Panel1.Controls.Add(this.btnThanhToan);
            this.guna2Panel1.Controls.Add(this.guna2TextBox1);
            this.guna2Panel1.Controls.Add(this.txtTongThanhToan);
            this.guna2Panel1.Controls.Add(this.txtThue);
            this.guna2Panel1.Controls.Add(this.txtCongTien);
            this.guna2Panel1.Controls.Add(this.label6);
            this.guna2Panel1.Controls.Add(this.label5);
            this.guna2Panel1.Controls.Add(this.label4);
            this.guna2Panel1.Controls.Add(this.label3);
            this.guna2Panel1.Controls.Add(this.label2);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Location = new System.Drawing.Point(6, 7);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(505, 606);
            this.guna2Panel1.TabIndex = 0;
            // 
            // txtChiPhiKhac
            // 
            this.txtChiPhiKhac.Location = new System.Drawing.Point(337, 224);
            this.txtChiPhiKhac.Name = "txtChiPhiKhac";
            this.txtChiPhiKhac.Size = new System.Drawing.Size(140, 30);
            this.txtChiPhiKhac.TabIndex = 8;
            this.txtChiPhiKhac.Text = "0";
            this.txtChiPhiKhac.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtChiPhiKhac.TextChanged += new System.EventHandler(this.txtChiPhiKhac_TextChanged);
            // 
            // cbbThue
            // 
            this.cbbThue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbThue.FormattingEnabled = true;
            this.cbbThue.Items.AddRange(new object[] {
            "0",
            "5",
            "10"});
            this.cbbThue.Location = new System.Drawing.Point(218, 271);
            this.cbbThue.Name = "cbbThue";
            this.cbbThue.Size = new System.Drawing.Size(80, 30);
            this.cbbThue.TabIndex = 7;
            this.cbbThue.SelectedIndexChanged += new System.EventHandler(this.cbbThue_SelectedIndexChanged);
            // 
            // mtxtGiamGia
            // 
            this.mtxtGiamGia.Location = new System.Drawing.Point(337, 177);
            this.mtxtGiamGia.Name = "mtxtGiamGia";
            this.mtxtGiamGia.ReadOnly = true;
            this.mtxtGiamGia.Size = new System.Drawing.Size(140, 30);
            this.mtxtGiamGia.TabIndex = 6;
            this.mtxtGiamGia.Text = "0";
            this.mtxtGiamGia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nudGiamGia
            // 
            this.nudGiamGia.Location = new System.Drawing.Point(218, 177);
            this.nudGiamGia.Name = "nudGiamGia";
            this.nudGiamGia.Size = new System.Drawing.Size(80, 30);
            this.nudGiamGia.TabIndex = 5;
            this.nudGiamGia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudGiamGia.ValueChanged += new System.EventHandler(this.nudGiamGia_ValueChanged);
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnThanhToan.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnThanhToan.Location = new System.Drawing.Point(118, 504);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(282, 57);
            this.btnThanhToan.TabIndex = 4;
            this.btnThanhToan.Text = "Hoàn thành";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // guna2TextBox1
            // 
            this.guna2TextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox1.DefaultText = "";
            this.guna2TextBox1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox1.DisabledState.Parent = this.guna2TextBox1;
            this.guna2TextBox1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox1.FocusedState.Parent = this.guna2TextBox1;
            this.guna2TextBox1.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.guna2TextBox1.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox1.HoverState.Parent = this.guna2TextBox1;
            this.guna2TextBox1.Location = new System.Drawing.Point(34, 381);
            this.guna2TextBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.guna2TextBox1.Name = "guna2TextBox1";
            this.guna2TextBox1.PasswordChar = '\0';
            this.guna2TextBox1.PlaceholderText = "Nhập ghi chú";
            this.guna2TextBox1.SelectedText = "";
            this.guna2TextBox1.ShadowDecoration.Parent = this.guna2TextBox1;
            this.guna2TextBox1.Size = new System.Drawing.Size(443, 68);
            this.guna2TextBox1.TabIndex = 3;
            // 
            // txtTongThanhToan
            // 
            this.txtTongThanhToan.Location = new System.Drawing.Point(337, 318);
            this.txtTongThanhToan.Name = "txtTongThanhToan";
            this.txtTongThanhToan.ReadOnly = true;
            this.txtTongThanhToan.Size = new System.Drawing.Size(140, 30);
            this.txtTongThanhToan.TabIndex = 2;
            this.txtTongThanhToan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtThue
            // 
            this.txtThue.Location = new System.Drawing.Point(337, 271);
            this.txtThue.Name = "txtThue";
            this.txtThue.ReadOnly = true;
            this.txtThue.Size = new System.Drawing.Size(140, 30);
            this.txtThue.TabIndex = 2;
            this.txtThue.Text = "0";
            this.txtThue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCongTien
            // 
            this.txtCongTien.Location = new System.Drawing.Point(337, 132);
            this.txtCongTien.Name = "txtCongTien";
            this.txtCongTien.ReadOnly = true;
            this.txtCongTien.Size = new System.Drawing.Size(140, 30);
            this.txtCongTien.TabIndex = 2;
            this.txtCongTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 326);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 22);
            this.label6.TabIndex = 1;
            this.label6.Text = "Tổng thanh toán:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 279);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 22);
            this.label5.TabIndex = 1;
            this.label5.Text = "Thuế:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 232);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 22);
            this.label4.TabIndex = 1;
            this.label4.Text = "Chi phí khác:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 22);
            this.label3.TabIndex = 1;
            this.label3.Text = "Giảm giá:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cộng tiền:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(117, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(283, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thông tin thanh toán";
            // 
            // FormThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(516, 618);
            this.Controls.Add(this.guna2Panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormThanhToan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin thanh toán";
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGiamGia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTongThanhToan;
        private System.Windows.Forms.TextBox txtThue;
        private System.Windows.Forms.TextBox txtCongTien;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.NumericUpDown nudGiamGia;
        private System.Windows.Forms.MaskedTextBox mtxtGiamGia;
        private System.Windows.Forms.ComboBox cbbThue;
        private System.Windows.Forms.TextBox txtChiPhiKhac;
    }
}