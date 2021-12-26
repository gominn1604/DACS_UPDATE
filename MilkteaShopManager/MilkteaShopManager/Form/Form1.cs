using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess;
using System.Data.SqlClient;
using BusinessLogic;

namespace MilkteaShopManager
{
    public partial class LoginForm : Form
    {
        TaiKhoanBL tkBL = new TaiKhoanBL();
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
        private void txtTenDangNhap_Click(object sender, EventArgs e)
        {
            txtTenDangNhap.Text = "";
        }

        private void txtMatKhau_Click(object sender, EventArgs e)
        {
            txtMatKhau.Text = "";
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(Ultilities.ConnectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            try
            {
                sqlCommand.CommandText = "Select * From TaiKhoan Where TenTaiKhoan = @tenTaiKhoan and MatKhau=@matKhau and MaCV=@maChucVu";
                sqlCommand.Parameters.Add("@tenTaiKhoan", SqlDbType.NVarChar, 100);
                sqlCommand.Parameters.Add("@matKhau", SqlDbType.NVarChar, 100);
                sqlCommand.Parameters.Add("@maChucVu", SqlDbType.Int);
                //sqlCommand.Parameters.Add("@hoTen", SqlDbType.NVarChar, 100);
                //sqlCommand.Parameters.Add("@tenChucVu", SqlDbType.NVarChar, 200);

                sqlCommand.Parameters["@tenTaiKhoan"].Value = txtTenDangNhap.Text;
                sqlCommand.Parameters["@matKhau"].Value = txtMatKhau.Text;
                //  sqlCommand.Parameters["@maChucVu"].Value = ;

                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read() == true)
                {

                    MainForm frm = new MainForm();
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại!", "Lỗi", MessageBoxButtons.OKCancel);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Lỗi SQL");
            }
        }
        
        private string Get_QuyenID(string id_user)
        {
            SqlConnection con = new SqlConnection(Ultilities.ConnectionString);
            SqlCommand sqlCommand = con.CreateCommand();
            string id = "";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT MaCV FROM TaiKhoan WHERE id_user_rel ='" + id_user + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["suspended"].ToString() == "False")
                        {
                            id = dr["id_per_rel"].ToString();
                        }
                    }
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi xảy ra khi truy vấn dữ liệu hoặc kết nối với server thất bại !");
            }
            finally
            {
                con.Close();
            }
            return id;
        }


    }
}
