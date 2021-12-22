using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilkteaShopManager
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            var loginName = txtTenDangNhap.Text;
            var password = txtMatKhau.Text;
            if (loginName.CompareTo("danh") == 0 && password.CompareTo("1") == 0)
            {
                MainForm quanLy = new MainForm();
                this.Hide();
                quanLy.ShowDialog();
                this.Show();
            }
            else
            {
                lblThongBao.Text = "Sai tên đăng nhập hoặc mật khẩu!";
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát khỏi ứng dụng hay không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}
