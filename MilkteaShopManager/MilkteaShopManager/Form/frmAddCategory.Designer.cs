namespace MilkteaShopManager
{
    partial class frmAddCategory
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvCategory = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtThemLoai = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnAddLoai = new System.Windows.Forms.Button();
            this.btnUpdateLoai = new System.Windows.Forms.Button();
            this.btnHuyNhap = new System.Windows.Forms.Button();
            this.lblThongBaoLoaiNuoc = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xoáLoạiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvCategory);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 164);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(765, 339);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách loại hiện tại";
            // 
            // lvCategory
            // 
            this.lvCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvCategory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3});
            this.lvCategory.ContextMenuStrip = this.contextMenuStrip1;
            this.lvCategory.FullRowSelect = true;
            this.lvCategory.GridLines = true;
            this.lvCategory.HideSelection = false;
            this.lvCategory.Location = new System.Drawing.Point(0, 27);
            this.lvCategory.Name = "lvCategory";
            this.lvCategory.Size = new System.Drawing.Size(753, 306);
            this.lvCategory.TabIndex = 3;
            this.lvCategory.UseCompatibleStateImageBehavior = false;
            this.lvCategory.View = System.Windows.Forms.View.Details;
            this.lvCategory.Click += new System.EventHandler(this.lvCategory_Click);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Mã loại";
            this.columnHeader2.Width = 133;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Tên loại";
            this.columnHeader3.Width = 603;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(235, 18);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(282, 35);
            this.label14.TabIndex = 13;
            this.label14.Text = "THÊM DANH MỤC";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(21, 81);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(109, 19);
            this.label11.TabIndex = 15;
            this.label11.Text = "Tên loại nước";
            // 
            // txtThemLoai
            // 
            this.txtThemLoai.Animated = true;
            this.txtThemLoai.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(153)))), ((int)(((byte)(149)))));
            this.txtThemLoai.BorderRadius = 6;
            this.txtThemLoai.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtThemLoai.DefaultText = "";
            this.txtThemLoai.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtThemLoai.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtThemLoai.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtThemLoai.DisabledState.Parent = this.txtThemLoai;
            this.txtThemLoai.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtThemLoai.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txtThemLoai.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtThemLoai.FocusedState.Parent = this.txtThemLoai;
            this.txtThemLoai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtThemLoai.ForeColor = System.Drawing.Color.White;
            this.txtThemLoai.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtThemLoai.HoverState.Parent = this.txtThemLoai;
            this.txtThemLoai.Location = new System.Drawing.Point(160, 74);
            this.txtThemLoai.Name = "txtThemLoai";
            this.txtThemLoai.PasswordChar = '\0';
            this.txtThemLoai.PlaceholderText = "";
            this.txtThemLoai.SelectedText = "";
            this.txtThemLoai.ShadowDecoration.Parent = this.txtThemLoai;
            this.txtThemLoai.Size = new System.Drawing.Size(306, 36);
            this.txtThemLoai.TabIndex = 16;
            // 
            // btnAddLoai
            // 
            this.btnAddLoai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnAddLoai.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddLoai.Location = new System.Drawing.Point(511, 74);
            this.btnAddLoai.Name = "btnAddLoai";
            this.btnAddLoai.Size = new System.Drawing.Size(113, 36);
            this.btnAddLoai.TabIndex = 4;
            this.btnAddLoai.Text = "Thêm loại";
            this.btnAddLoai.UseVisualStyleBackColor = false;
            this.btnAddLoai.Click += new System.EventHandler(this.btnAddLoai_Click_1);
            // 
            // btnUpdateLoai
            // 
            this.btnUpdateLoai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnUpdateLoai.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateLoai.Location = new System.Drawing.Point(12, 509);
            this.btnUpdateLoai.Name = "btnUpdateLoai";
            this.btnUpdateLoai.Size = new System.Drawing.Size(113, 36);
            this.btnUpdateLoai.TabIndex = 4;
            this.btnUpdateLoai.Text = "Sửa loại";
            this.btnUpdateLoai.UseVisualStyleBackColor = false;
            this.btnUpdateLoai.Click += new System.EventHandler(this.btnUpdateLoai_Click);
            // 
            // btnHuyNhap
            // 
            this.btnHuyNhap.BackColor = System.Drawing.Color.Silver;
            this.btnHuyNhap.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuyNhap.Location = new System.Drawing.Point(652, 509);
            this.btnHuyNhap.Name = "btnHuyNhap";
            this.btnHuyNhap.Size = new System.Drawing.Size(113, 36);
            this.btnHuyNhap.TabIndex = 4;
            this.btnHuyNhap.Text = "Huỷ nhập";
            this.btnHuyNhap.UseVisualStyleBackColor = false;
            this.btnHuyNhap.Click += new System.EventHandler(this.btnHuyNhap_Click);
            // 
            // lblThongBaoLoaiNuoc
            // 
            this.lblThongBaoLoaiNuoc.AutoSize = true;
            this.lblThongBaoLoaiNuoc.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongBaoLoaiNuoc.Location = new System.Drawing.Point(21, 123);
            this.lblThongBaoLoaiNuoc.Name = "lblThongBaoLoaiNuoc";
            this.lblThongBaoLoaiNuoc.Size = new System.Drawing.Size(0, 19);
            this.lblThongBaoLoaiNuoc.TabIndex = 31;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xoáLoạiToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(134, 28);
            // 
            // xoáLoạiToolStripMenuItem
            // 
            this.xoáLoạiToolStripMenuItem.Name = "xoáLoạiToolStripMenuItem";
            this.xoáLoạiToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.xoáLoạiToolStripMenuItem.Text = "Xoá loại";
            this.xoáLoạiToolStripMenuItem.Click += new System.EventHandler(this.xoáLoạiToolStripMenuItem_Click);
            // 
            // frmAddCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(210)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(789, 565);
            this.Controls.Add(this.lblThongBaoLoaiNuoc);
            this.Controls.Add(this.btnHuyNhap);
            this.Controls.Add(this.btnUpdateLoai);
            this.Controls.Add(this.btnAddLoai);
            this.Controls.Add(this.txtThemLoai);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddCategory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm loại";
            this.Load += new System.EventHandler(this.frmAddCategory_Load);
            this.groupBox1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ListView lvCategory;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label11;
        private Guna.UI2.WinForms.Guna2TextBox txtThemLoai;
        private System.Windows.Forms.Button btnAddLoai;
        private System.Windows.Forms.Button btnUpdateLoai;
        private System.Windows.Forms.Button btnHuyNhap;
        private System.Windows.Forms.Label lblThongBaoLoaiNuoc;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem xoáLoạiToolStripMenuItem;
    }
}