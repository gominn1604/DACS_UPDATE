using BusinessLogic;
using DataAccess;
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
    public partial class frmAddCategory : Form
    {
        LoaiNuoc categoryCurrent = new LoaiNuoc();
        List<LoaiNuoc> listCategory = new List<LoaiNuoc>();
        LoaiNuocBL loaiNuocBL = new LoaiNuocBL();

        public frmAddCategory()
        {
            InitializeComponent();
        }
        private void frmAddCategory_Load(object sender, EventArgs e)
        {
            LoadLoaiNuoc();
        }
        public void LoadLoaiNuoc()
        {
            listCategory = loaiNuocBL.GetAll();
            int count = 1; // Biến số thứ tự
                           // Xoá dữ liệu trong ListView
            lvCategory.Items.Clear();
            // Duyệt mảng dữ liệu để đưa vào ListView
            foreach (var loaiNuoc in listCategory)
            {
                // Số thứ tự
                ListViewItem item = lvCategory.Items.Add(loaiNuoc.MaLoai.ToString());
                item.SubItems.Add(loaiNuoc.TenLoai);
                count++;
            }
        }
        private void lvCategory_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lvCategory.Items.Count; i++)
            {
                if (lvCategory.Items[i].Selected)
                {
                    categoryCurrent = listCategory[i];
                    txtThemLoai.Text = categoryCurrent.TenLoai;
                }
            }
        }

        #region Thêm loại
        public int InsertLoaiNuoc()
        {
            LoaiNuoc loaiNuoc = new LoaiNuoc();
            loaiNuoc.MaLoai = 0;
            if (txtThemLoai.Text == "")
            {
                MessageBox.Show("Lỗi khi thêm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                loaiNuoc.TenLoai = txtThemLoai.Text;
                LoaiNuocBL loaiNuocBL = new LoaiNuocBL();
                return loaiNuocBL.Insert(loaiNuoc);
            }
            return -1;
        }
        private void btnAddLoai_Click_1(object sender, EventArgs e)
        {
            int result = InsertLoaiNuoc();
            if (result > 0)
            {
                MessageBox.Show("Đã thêm dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadLoaiNuoc();
            }
            else
            {
                MessageBox.Show("Thêm dữ liệu không thành công. Vui lòng kiểm tra lại dữ liệu nhập", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Sửa loại
        private int UpdateCategory()
        {
            LoaiNuoc loaiNuoc = categoryCurrent;
            if (txtThemLoai.Text == "")
            {
                lblThongBaoLoaiNuoc.Text = "Vui lòng điền đầy đủ thông tin để cập nhật!";
                lblThongBaoLoaiNuoc.ForeColor = Color.Red;
            }
            else
            {
                loaiNuoc.TenLoai = txtThemLoai.Text;
                lblThongBaoLoaiNuoc.Text = "Bạn đã sửa " + loaiNuoc.TenLoai + " thành công!";
                lblThongBaoLoaiNuoc.ForeColor = Color.Green;
                loaiNuocBL = new LoaiNuocBL();
                return loaiNuocBL.Update(loaiNuoc);
            }
            return -1;
        }
        private void btnUpdateLoai_Click(object sender, EventArgs e)
        {
            int result = UpdateCategory();
            if (lvCategory.Items.Count == 0)
            {
                lblThongBaoLoaiNuoc.Text = "Vui lòng chọn loại để sửa!";
                lblThongBaoLoaiNuoc.ForeColor = Color.Red;
            }
            else
            {
                if (result > 0)
                {
                    MessageBox.Show("Bạn đã sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadLoaiNuoc();
                    txtThemLoai.Text = "";
                }
                else MessageBox.Show("Sửa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region Xoá loại
        private void xoáLoạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvCategory.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Bạn có muốn xoá " + categoryCurrent.TenLoai + " không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    loaiNuocBL = new LoaiNuocBL();
                    if (loaiNuocBL.Delete(categoryCurrent) > 0)
                    {
                        lblThongBaoLoaiNuoc.Text = "Đã xoá " + categoryCurrent.TenLoai + " thành công!";
                        lblThongBaoLoaiNuoc.ForeColor = Color.Green;
                        LoadLoaiNuoc();
                        txtThemLoai.Text = "";
                    }
                    else
                    {
                        lblThongBaoLoaiNuoc.Text = "Xoá " + categoryCurrent.TenLoai + " thất bại, vui lòng kiểm tra lại!";
                        lblThongBaoLoaiNuoc.ForeColor = Color.Red;
                    }
                }
            }
            else
            {
                lblThongBaoLoaiNuoc.Text = "Vui lòng chọn loại để xoá!";
                lblThongBaoLoaiNuoc.ForeColor = Color.Red;
            }
        }
        #endregion

        #region Huỷ nhập
        private void btnHuyNhap_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion       
    }
}
