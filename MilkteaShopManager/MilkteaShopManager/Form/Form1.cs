using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DataAccess;

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
            //SqlConnection sqlConnection = new SqlConnection(Ultilities.ConnectionString);
            //SqlCommand sqlCommand = sqlConnection.CreateCommand();
            //try
            //{
            //    sqlCommand.CommandText = "Select * From TaiKhoan Where TenTaiKhoan = @tenTaiKhoan and MatKhau=@matKhau";
            //    sqlCommand.Parameters.Add("@tenTaiKhoan", SqlDbType.NVarChar, 100);
            //    sqlCommand.Parameters.Add("@matKhau", SqlDbType.NVarChar, 100);
            //    //sqlCommand.Parameters.Add("@maChucVu", SqlDbType.Int);
            //    //sqlCommand.Parameters.Add("@hoTen", SqlDbType.NVarChar, 100);
            //    //sqlCommand.Parameters.Add("@tenChucVu", SqlDbType.NVarChar, 200);

            //    sqlCommand.Parameters["@tenTaiKhoan"].Value = txtTenDangNhap.Text;
            //    sqlCommand.Parameters["@matKhau"].Value = txtMatKhau.Text;
            //    //  sqlCommand.Parameters["@maChucVu"].Value = ;

            //    sqlConnection.Open();

            //    SqlDataReader reader = sqlCommand.ExecuteReader();

            //    if (reader.Read() == true)
            //    {

            //        MainForm frm = new MainForm();
            //        frm.Show();
            //        this.Hide();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Đăng nhập thất bại!", "Lỗi", MessageBoxButtons.OKCancel);
            //    }
            //}
            //catch (Exception)
            //{

            //    MessageBox.Show("Lỗi SQL");
            //}
            MainForm frm = new MainForm();
            this.Hide();
            frm.Show();
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

        private void txtTenDangNhap_Click(object sender, EventArgs e)
        {
            txtMatKhau.Text = "";
        }

        private void txtMatKhau_Click(object sender, EventArgs e)
        {
            txtMatKhau.Text = "";
        }
    }
}
