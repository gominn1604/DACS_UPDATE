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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dlg = MessageBox.Show("Bạn có muốn thoát ứng dụng hay không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == DialogResult.Yes)
            {
                Application.Exit();
            }
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
                
            }
            else
            {
                lblThongBao.Text = "Sai tên đăng nhập hoặc mật khẩu!";
            }
        }
    }
}
