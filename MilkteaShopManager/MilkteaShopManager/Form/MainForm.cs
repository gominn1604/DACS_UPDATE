﻿using BusinessLogic;
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
    public partial class MainForm : Form
    {
        TableBL tableBL = new TableBL();
        DrinkDetailsBL drinkDetailsBL = new DrinkDetailsBL();
        // danh sách toàn cục bảng LoaiNuoc
        List<LoaiNuoc> listLoaiNuoc = new List<LoaiNuoc>();

        // danh sách toàn cục bảng nước uống
        List<NuocUong> listNuocUong = new List<NuocUong>();

        // đối tượng NuocUong đang chọn hiện hành
        NuocUong nuocUongCurrent = new NuocUong();

        NuocUongBL nuocUongBL = new NuocUongBL();

        LoaiNuocBL loaiNuocBL = new LoaiNuocBL();
        //ds toan cuc bang TK
        List<TaiKhoan> listTK = new List<TaiKhoan>();

        TaiKhoanBL taiKhoanBL = new TaiKhoanBL();

        TaiKhoan tkCurrent = new TaiKhoan();
        //phan quyen
        string tenTaiKhoan = "", tenNhanVien = "", matKhau = "", tenChucVu = "";
        public MainForm()
        {
            InitializeComponent();
            customizeDesign();
            LoadLoaiNuoc();
            LoadNuocDataToListView();
            LoadTable();
            TaiKhoan_DataToListView();
        }
        public MainForm(string tenTaiKhoan ,string tenNhanVien,string matKhau, string tenChucVu)
        {
            InitializeComponent();
            this.tenNhanVien = tenNhanVien;
            this.tenTaiKhoan = tenTaiKhoan;
            this.matKhau = matKhau;
            this.tenChucVu = tenChucVu;
        }

        #region Hàm đóng mở form con
        // hàm ẩn panel
        private void customizeDesign()
        {
            // ẩn panel admin
            pnlQuanLy.Visible = false;
        }

        // ẩn panel nếu đang mở thì đóng
        private void hideMenu()
        {
            if (pnlQuanLy.Visible == true)
                pnlQuanLy.Visible = false;
        }
        // xem menu con và ẩn panel chức năng
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }
        private void btnQuanLy_Click(object sender, EventArgs e)
        {
            showSubMenu(pnlQuanLy);
        }
        #endregion

        #region Gọi món
        private void btnGoiMon_Click(object sender, EventArgs e)
        {
            tctMain.SelectedIndex = 0;
        }

        private void LoadTable()
        {
            List<Table> tableList = new List<Table>();

            flpDSBan.Controls.Clear();
            string status;
            tableList = tableBL.GetAll();

            foreach (Table table in tableList)
            {
                Button btn = new Button() { Width = 110, Height = 100 };
                flpDSBan.Controls.Add(btn);
                if (table.Status == 0)
                {
                    status = "Phòng trống";
                }
                else
                {
                    status = "Có khách";
                }
                btn.Text = table.Name + Environment.NewLine + status;
                switch (table.Status)
                {
                    case 0:
                        btn.BackColor = Color.Aquamarine;
                        break;
                    case 1:
                        btn.BackColor = Color.Red;
                        break;
                    default:
                        break;
                }

                btn.Click += Btn_Click;
                btn.Tag = table;
            }
        }

        private void ShowBill(int tableId)
        {
            List<DrinkDetails> listMenu = drinkDetailsBL.GetListDrinkDetailsByTableId(tableId);

            lvHoaDon.Items.Clear();
            foreach (DrinkDetails item in listMenu)
            {
                ListViewItem lvitem = new ListViewItem(item.Name.ToString());
                lvitem.SubItems.Add(item.Price.ToString());
                lvitem.SubItems.Add(item.Count.ToString());
                lvitem.SubItems.Add(item.TotalAmount.ToString());

                lvHoaDon.Items.Add(lvitem);
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            lvHoaDon.Items.Clear();
            int tableId = ((sender as Button).Tag as Table).ID;

            ShowBill(tableId);
        }

        #endregion

        #region Quản lý món

        private void btnQuanLyMon_Click(object sender, EventArgs e)
        {
            tctMain.SelectedIndex = 1;
            hideMenu();
        }

        private void LoadLoaiNuoc()
        {

            listLoaiNuoc = loaiNuocBL.GetAll();

            cbbLoaiNuoc.DataSource = listLoaiNuoc;
            cbbLoaiNuoc.ValueMember = "MaLoai";
            cbbLoaiNuoc.DisplayMember = "TenLoai";
        }
        public void LoadNuocDataToListView()
        {
            listNuocUong = nuocUongBL.GetAll();
            int count = 1; // Biến số thứ tự
                           // Xoá dữ liệu trong ListView
            lvNuocUong.Items.Clear();
            // Duyệt mảng dữ liệu để đưa vào ListView
            foreach (var nuocUong in listNuocUong)
            {
                // Số thứ tự
                ListViewItem item = lvNuocUong.Items.Add(count.ToString());
                // Đưa dữ liệu TenNuoc, TenLoai, DonGia, DVT vào cột tiếp theo
                item.SubItems.Add(nuocUong.TenNuocUong);
                string tenLoai = listLoaiNuoc.Find(x => x.MaLoai == nuocUong.MaLoai).TenLoai;
                item.SubItems.Add(tenLoai);
                item.SubItems.Add(nuocUong.DonGia.ToString());
                item.SubItems.Add(nuocUong.DVT);
                // Theo dữ liệu của bảng MaLoaiNuoc, lấy Name để hiển thị
                count++;
            }
        }
        private void lvNuocUong_Click(object sender, EventArgs e)
        {
            // duyệt trong lv
            for (int i = 0; i < lvNuocUong.Items.Count; i++)
            {
                // nếu có thì lấy
                if (lvNuocUong.Items[i].Selected)
                {
                    nuocUongCurrent = listNuocUong[i];
                    txtTenNuocUong.Text = nuocUongCurrent.TenNuocUong;
                    txtIDNuoc.Text = nuocUongCurrent.MaNuocUong.ToString();
                    txtDonGia.Text = nuocUongCurrent.DonGia.ToString();
                    txtDVT.Text = nuocUongCurrent.DVT.ToString();
                    // lấy index của cbb theo mã loại nước uống
                    cbbLoaiNuoc.SelectedIndex = listLoaiNuoc.FindIndex(x => x.MaLoai == nuocUongCurrent.MaLoai);
                }
            }
        }
        public int InsertNuoc()
        {
            NuocUong nuocUong = new NuocUong();
            nuocUong.MaNuocUong = 0;
            // kiểm tra các ô đã đầy đủ thông tin hay chưa
            if (txtTenNuocUong.Text == "" || txtDVT.Text == "" || txtDonGia.Text == "" || cbbLoaiNuoc.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng kiểm tra đầy đủ dữ liệu trước khi thêm", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // giá trị DonGia là số nên bắt lỗi khi người dùng vô tình nhập sai
                int donGia = 0;
                try
                {
                    // lấy giá trị trong ô
                    donGia = int.Parse(txtDonGia.Text);
                }
                catch (Exception)
                {
                    // nếu sai thì gán giá trị lại cho DonGia = 0
                    donGia = 0;
                }
                nuocUong.DonGia = donGia;
                nuocUong.TenNuocUong = txtTenNuocUong.Text;
                nuocUong.DVT = txtDVT.Text;
                // giá trị của MaLoai được lấy từ cbb
                nuocUong.MaLoai = int.Parse(cbbLoaiNuoc.SelectedValue.ToString());
                // khai báo đối tượng NuocUongBL từ tầng Business
                NuocUongBL nuocUongBL = new NuocUongBL();
                // chèn dữ liệu vào
                return nuocUongBL.Insert(nuocUong);

            }
            return -1;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            // gọi phương thức thêm dữ liệu
            int result = InsertNuoc();
            if (result > 0)
            {
                MessageBox.Show("Đã thêm dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadNuocDataToListView();
            }
            else
            {
                MessageBox.Show("Thêm dữ liệu không thành công. Vui lòng kiểm tra lại dữ liệu nhập", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public int UpdateNuocUong()
        {
            NuocUong nuocUong = nuocUongCurrent;
            if (txtDonGia.Text == "" || txtDVT.Text == "" || txtIDNuoc.Text == "" || txtTenNuocUong.Text == "")
            {
                MessageBox.Show("Kiểm tra bạn đã nhập thông tin đã đủ hay chưa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                nuocUong.TenNuocUong = txtTenNuocUong.Text;
                nuocUong.DVT = txtDVT.Text;
                nuocUong.MaLoai = int.Parse(cbbLoaiNuoc.SelectedValue.ToString());
                int donGia;
                try
                {
                    donGia = int.Parse(txtDonGia.Text);
                }
                catch (Exception)
                {
                    donGia = 0;
                }
                nuocUong.DonGia = donGia;

                NuocUongBL nuocUongBL = new NuocUongBL();

                return nuocUongBL.Update(nuocUong);
            }
            return -1;
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            int result = UpdateNuocUong();
            if (result > 0)
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadNuocDataToListView();
            }
            else MessageBox.Show("Cập nhật dữ liệu không thành công. Vui lòng kiểm lại dữ liệu nhập");
        }
        private void btnXoaMonAn_Click(object sender, EventArgs e)
        {
            if (lvNuocUong.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xoá món ăn không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    NuocUongBL nuocUongBL = new NuocUongBL();
                    if (nuocUongBL.Delete(nuocUongCurrent) > 0)
                    {
                        MessageBox.Show("Xoá thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadNuocDataToListView();
                    }
                    else MessageBox.Show("Xoá không thành công, vui lòng kiểm tra lại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else MessageBox.Show("Bạn phải chọn đối tượng để xoá!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnHuyNhap_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muón thực hiện thao tác này?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                txtIDNuoc.Text = "";
                txtTenNuocUong.Text = "";
                cbbLoaiNuoc.Text = "";
                txtDonGia.Text = "";
                txtDVT.Text = "";
                txtTenNuocUong.Focus();
            }
        }
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
        private void btnThemLoai_Click(object sender, EventArgs e)
        {
            txtThemLoai.Visible = true;
            btnDongYLoai.Visible = true;
        }
        private void btnDongYLoai_Click(object sender, EventArgs e)
        {
            int result = InsertLoaiNuoc();
            if (result > 0)
            {
                MessageBox.Show("Đã thêm dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadLoaiNuoc();
                txtThemLoai.Visible = false;
                btnDongYLoai.Visible = false;
            }
            else
            {
                MessageBox.Show("Thêm dữ liệu không thành công. Vui lòng kiểm tra lại dữ liệu nhập", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region quản lý bàn ăn
        private void btnQuanLyBan_Click(object sender, EventArgs e)
        {
            tctMain.SelectedIndex = 2;
            hideMenu();
        }
        #endregion

        #region Quản lý hoá đơn
        private void btnQuanLyHoaDon_Click(object sender, EventArgs e)
        {
            tctMain.SelectedIndex = 3;
            hideMenu();
        }
        #endregion

        #region Thống kê nhân viên
        private void btnThongKeNhanVien_Click(object sender, EventArgs e)
        {
            tctMain.SelectedIndex = 4;
            hideMenu();
        }

        //thực hiện mở form thêm nhân viên
        private void btnThemNhanVien_Click(object sender, EventArgs e)
        {
            frmThemNhanVien frm = new frmThemNhanVien();
            frm.ShowDialog();
        }

        #endregion

        #region Đổi mật khẩu
        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            tctMain.SelectedIndex = 5;
            hideMenu();
        }

        public void TaiKhoan_DataToListView()
        {
            listTK = taiKhoanBL.GetAll();
            int count = 1; // Biến số thứ tự
                           // Xoá dữ liệu trong ListView
            lvTK.Items.Clear();
            // Duyệt mảng dữ liệu để đưa vào ListView
            foreach (var tk in listTK)
            {
                // Số thứ tự
                ListViewItem item = lvTK.Items.Add(count.ToString());
                item.SubItems.Add(tk.MaTK.ToString());
                item.SubItems.Add(tk.TenTaiKhoan);
                item.SubItems.Add(tk.MatKhau);
                item.SubItems.Add(tk.HoTen);
                item.SubItems.Add(tk.Email);
                item.SubItems.Add(tk.SoDienThoai);
                item.SubItems.Add(tk.NgayTao.ToString());
                count++;
            }
        }

        public int InsertTaiKhoan()
        {
            TaiKhoan taiKhoan = new TaiKhoan();
            taiKhoan.TenTaiKhoan = "";

            // kiểm tra các ô đã đầy đủ thông tin hay chưa
            if (txtTenTaiKhoan.Text == "" || txtMatKhau.Text == "" || txtHoTen.Text == "" || txtEmail.Text == "" || txtSDT.Text == "" || dtpDate.Value.ToString() == "")
            {
                MessageBox.Show("Vui lòng kiểm tra đầy đủ dữ liệu trước khi thêm", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                taiKhoan.TenTaiKhoan = txtTenTaiKhoan.Text;
                taiKhoan.MatKhau = txtMatKhau.Text;
                taiKhoan.HoTen = txtHoTen.Text;
                taiKhoan.SoDienThoai = txtSDT.Text;
                taiKhoan.Email = txtEmail.Text;
                taiKhoan.NgayTao = dtpDate.Value;
                //taiKhoan.NgayTao = txtNgayTao.Text;
                TaiKhoanBL taiKhoanBL = new TaiKhoanBL();
                return taiKhoanBL.Insert(taiKhoan);
            }
            return -1;
        }
        private void btnADDTK_Click(object sender, EventArgs e)
        {
            int result = InsertTaiKhoan();
            if (result > 0)
            {
                MessageBox.Show("Đã thêm dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TaiKhoan_DataToListView();
            }
            else
            {
                MessageBox.Show("Thêm dữ liệu không thành công. Vui lòng kiểm tra lại dữ liệu nhập", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        #endregion

        #region Đăng xuất
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (MessageBox.Show("Bạn có đăng xuất tài khoản hay không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
        #endregion

        private void lvTK_Click_1(object sender, EventArgs e)
        {
            // duyệt trong lv
            for (int i = 0; i < lvTK.Items.Count; i++)
            {
                // nếu có thì lấy
                if (lvTK.Items[i].Selected)
                {
                    tkCurrent = listTK[i];
                    txtmATK.Text = tkCurrent.MaTK.ToString();
                    txtTenTaiKhoan.Text = tkCurrent.TenTaiKhoan;
                    txtMatKhau.Text = tkCurrent.MatKhau;
                    txtHoTen.Text = tkCurrent.HoTen;
                    txtEmail.Text = tkCurrent.Email;
                    txtSDT.Text = tkCurrent.SoDienThoai;
                    //txtNgayTao.Text = tkCurrent.NgayTao;
                }
            }
        }

        public int UpdateTK()
        {
            TaiKhoan taiKhoan = tkCurrent;
            if (txtTenTaiKhoan.Text == "" || txtMatKhau.Text == "" || txtHoTen.Text == "" || txtEmail.Text == "" || txtSDT.Text == "" || dtpDate.Value.ToString() == "")
            {
                MessageBox.Show("Vui lòng kiểm tra đầy đủ dữ liệu trước khi thêm", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                taiKhoan.TenTaiKhoan = txtTenTaiKhoan.Text;
                taiKhoan.MatKhau = txtMatKhau.Text;
                taiKhoan.HoTen = txtHoTen.Text;
                taiKhoan.SoDienThoai = txtSDT.Text;
                taiKhoan.Email = txtEmail.Text;
                taiKhoan.NgayTao = dtpDate.Value;
                TaiKhoanBL taiKhoanBL = new TaiKhoanBL();
                return taiKhoanBL.Update(taiKhoan);
            }
            return -1;
        }

        private void btnUpdTK_Click(object sender, EventArgs e)
        {
            int result = UpdateTK();
            if (result>0)
            {
                MessageBox.Show("Cập nhật dữ liệu thành công");
                TaiKhoan_DataToListView();
            }
            else MessageBox.Show("Cập nhật dữ liệu không thành công. Vui lòng kiểm tra lại dữ liệu nhập");
        }


        private void btnCancelTK_Click(object sender, EventArgs e)
        {
            txtmATK.Text = "";
            txtTenTaiKhoan.Text = "";
            txtMatKhau.Text = "";
            txtHoTen.Text = "";
            txtEmail.Text = "";
            txtSDT.Text = "";
    
        }

        private void btnDelTK_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xoá tài khoản này?", "Thông báo",MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                // Khai báo đối tượng FoodBL từ BusinessLogic
                TaiKhoanBL taikhoanBL = new TaiKhoanBL();
                if (taiKhoanBL.Delete(tkCurrent) > 0)// Nếu xoá thành công
                {
                    MessageBox.Show("Xoá tài khoản thành công");
                    // Tải tữ liệu lên ListView
                    TaiKhoan_DataToListView();
                }
                else MessageBox.Show("Xoá không thành công");
            }

        }
    }
}