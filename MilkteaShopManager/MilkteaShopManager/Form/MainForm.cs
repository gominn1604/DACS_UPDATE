﻿using BusinessLogic;
using DataAccess;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilkteaShopManager
{
    public partial class MainForm : Form
    {
        #region Khai báo ds toàn cục từng bảng
        TableBL tableBL = new TableBL();
        DrinkDetailsBL drinkDetailsBL = new DrinkDetailsBL();
        DrinkBL drinkBL = new DrinkBL();
        CategoryBL categoryBL = new CategoryBL();
        BillBL billBL = new BillBL();
        // danh sách toàn cục bảng LoaiNuoc
        List<LoaiNuoc> listLoaiNuoc = new List<LoaiNuoc>();

        // danh sách toàn cục bảng nước uống
        List<NuocUong> listNuocUong = new List<NuocUong>();

        // đối tượng NuocUong đang chọn hiện hành
        NuocUong nuocUongCurrent = new NuocUong();

        NuocUongBL nuocUongBL = new NuocUongBL();

        LoaiNuocBL loaiNuocBL = new LoaiNuocBL();

        Table tableCurrent = new Table();

        List<Table> listTable = new List<Table>();
        string statusTable;

        LoaiNuoc loaiNuocCurrent = new LoaiNuoc();

        List<Account> listAcc = new List<Account>();

        AccountBL accBL = new AccountBL();

        Account accCurrent = new Account();
        //nhanvien
        List<Staff> listStaff = new List<Staff>();
        StaffBL staffBL = new StaffBL();
        

        //phan quyen
        //string tenTaiKhoan = "", tenNhanVien = "", matKhau = "", tenChucVu = "";

        #endregion
        public MainForm()
        {
            InitializeComponent();
            customizeDesign();
            LoadLoaiNuoc();
            LoadNuocDataToListView();
            LoadTable();
            LoadCategory();
            LoadComboBoxTable(cbbDSBan);
            LoadTableToLV();
            LoadDateTimePickerBill(); 
            TaiKhoan_DataToListView();
            NhanVien_DataToListView();

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
            tctGoiMon.SelectedIndex = 0;
        }

        public void LoadTable()
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
                    status = "Bàn trống";
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
            int totalAmount = 0;
            lvHoaDon.Items.Clear();
            List<DrinkDetails> listDrinkDetails = drinkDetailsBL.GetListDrinkDetailsByTableId(tableId);

            foreach (DrinkDetails item in listDrinkDetails)
            {
                ListViewItem lvitem = new ListViewItem(item.Name.ToString());
                lvitem.SubItems.Add(item.Price.ToString());
                lvitem.SubItems.Add(item.Count.ToString());
                lvitem.SubItems.Add(item.TotalAmount.ToString());
                totalAmount += item.TotalAmount;

                lvHoaDon.Items.Add(lvitem);
            }
            txtTongTien.Text = totalAmount.ToString("###,###");
        }

        private int TotalAmount(int tableId)
        {
            int totalAmount = 0;
            List<DrinkDetails> listDrinkDetails = drinkDetailsBL.GetListDrinkDetailsByTableId(tableId);

            foreach (DrinkDetails item in listDrinkDetails)
            {
                totalAmount += item.TotalAmount;
            }
            return totalAmount;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            lvHoaDon.Items.Clear();
            int tableId = ((sender as Button).Tag as Table).ID;
            lvHoaDon.Tag = (sender as Button).Tag;

            ShowBill(tableId);
        }

        private void LoadCategory()
        {
            List<Category> listCategory = categoryBL.GetListCategory();
            cbbLoaiThucUong.DataSource = listCategory;
            cbbLoaiThucUong.DisplayMember = "Name";
        }

        private void LoadDrinkListByCategoryId(int categoryId)
        {
            List<Drink> listDrink = drinkBL.GetListDrinkByCategoryId(categoryId);
            cbbTenThucUong.DataSource = listDrink;
            cbbTenThucUong.DisplayMember = "Name";
        }

        private void cbbLoaiThucUong_SelectedIndexChanged(object sender, EventArgs e)
        {
            int categoryId = 0;
            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null)
                return;

            Category categorySelected = cb.SelectedItem as Category;
            categoryId = categorySelected.ID;

            LoadDrinkListByCategoryId(categoryId);
        }

        private void btnThemNuoc_Click(object sender, EventArgs e)
        {
            BillDA billDA = new BillDA();
            BillInfoDA billInfoDA = new BillInfoDA();
            Table table = lvHoaDon.Tag as Table;

            if (table is null)
                MessageBox.Show("Vui lòng chọn bàn bạn muốn thêm nước!", "Thông báo");
            else
            {
                int billId = billBL.GetUncheckBillIdByTableId(table.ID);
                int drinkId = (cbbTenThucUong.SelectedItem as Drink).Id;
                int count = (int)nudSoLuong.Value;

                if (billId == -1)
                {
                    billDA.InsertBillForTable(table.ID);
                    billInfoDA.InsertBillInfoForTable(billBL.GetMaxBillId(), drinkId, count);
                }
                else
                {
                    billInfoDA.InsertBillInfoForTable(billId, drinkId, count);
                }
                ShowBill(table.ID);
                LoadTable();
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            BillDA billDA = new BillDA();
            Table table = lvHoaDon.Tag as Table;

            if (table is null)
            {
                MessageBox.Show("Bạn chưa chọn bàn để thanh toán!", "Thông báo");
            }
            else
            {
                int billId = billDA.GetUncheckBillIdByTableId(table.ID);
                if (billId != -1)
                {
                    FormThanhToan frmThanhToan = new FormThanhToan();
                    frmThanhToan.Show(this);
                    frmThanhToan.LoadForm(table, TotalAmount(table.ID));
                    frmThanhToan.FormClosed += FrmThanhToan_FormClosed;
                }
                else if (billId == -1)
                {
                    MessageBox.Show("Bàn này chưa có hóa đơn để thanh toán. Vui lòng kiểm tra lại!", "Thông báo");
                }

            }

        }

        private void FrmThanhToan_FormClosed(object sender, FormClosedEventArgs e)
        {
            Table table = lvHoaDon.Tag as Table;
            ShowBill(table.ID);
            LoadTable();
        }

        private void btnChuyenBan_Click(object sender, EventArgs e)
        {
            TableDA tableDA = new TableDA();
            Table table = lvHoaDon.Tag as Table;

            int idTable1 = (lvHoaDon.Tag as Table).ID;
            int idTable2 = (cbbDSBan.SelectedItem as Table).ID;

            if (MessageBox.Show(string.Format("Bạn có muốn chuyển bàn {0} qua bàn {1} không?", idTable1, idTable2), "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                tableDA.SwitchTable(idTable1, idTable2);
                LoadTable();
                ShowBill(table.ID);
            }
        }

        private void LoadComboBoxTable(ComboBox cbb)
        {
            cbb.DataSource = tableBL.GetAll();
            cbb.DisplayMember = "Name";
        }

        private void btnGopBan_Click(object sender, EventArgs e)
        {
            TableDA tableDA = new TableDA();
            Table table = lvHoaDon.Tag as Table;

            int idTable1 = (lvHoaDon.Tag as Table).ID;
            int idTable2 = (cbbDSBan.SelectedItem as Table).ID;

            if (MessageBox.Show(string.Format("Bạn có muốn gộp từ bàn {0} qua bàn {1} không?", idTable1, idTable2), "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                tableDA.MergeTable(idTable1, idTable2);
                LoadTable();
                ShowBill(table.ID);
            }
        }
        //Hiển thị danh sách hóa đơn trong ngày
        public void ShowBillToday()
        {
            BillDA billDA = new BillDA();
            SetColumnsFormat(billDA.GetBillListInDay());
        }
        private void SetColumnsFormat(DataTable dt)
        {
            int count = dgvHoaDonTrongNgay.Columns.Count - 1;

            dgvHoaDonTrongNgay.DataSource = dt;
            dgvHoaDonTrongNgay.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHoaDonTrongNgay.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHoaDonTrongNgay.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHoaDonTrongNgay.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHoaDonTrongNgay.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHoaDonTrongNgay.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvHoaDonTrongNgay.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvHoaDonTrongNgay.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHoaDonTrongNgay.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvHoaDonTrongNgay.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHoaDonTrongNgay.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvHoaDonTrongNgay.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            tctGoiMon.SelectedIndex = 1;
            ShowBillToday();
        }
        public void BillSearch()
        {
            BillDA billDA = new BillDA();

            //tạo bộ lọc và phân loại
            string filterExpresstion = "[Tên bàn] like '%" + txtTimKiem.Text + "%'";
            string sortExpresstion = "[Mã hóa đơn] ASC";
            DataViewRowState rowStateFilter = DataViewRowState.OriginalRows;
            DataTable billTable = billDA.GetBillListInDay();
            DataView billView = new DataView(billTable, filterExpresstion, sortExpresstion, rowStateFilter);

            dgvHoaDonTrongNgay.DataSource = billView;
        }
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            BillSearch();
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
        private void XoaMonToolStripMenuItem_Click(object sender, EventArgs e)
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
        private void WriteToExcelNuocUong(ListView lv, List<NuocUong> dsNuocUong, List<LoaiNuoc> dsLoaiNuoc, string path)
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (ExcelPackage p = new ExcelPackage())
            {
                p.Workbook.Worksheets.Add("sheet 1");
                ExcelWorksheet ws = p.Workbook.Worksheets[0];
                ws.Name = "sheet 1";
                ws.Cells.Style.Font.Size = 11;
                ws.Cells.Style.Font.Name = "Calibri";

                List<string> arrCollumHeader = new List<string>();
                foreach (ColumnHeader item in lv.Columns)
                {
                    arrCollumHeader.Add(item.Text);
                }
                var countColHeader = arrCollumHeader.Count();

                int colIndex = 1;
                int rowIndex = 1;
                foreach (var item in arrCollumHeader)
                {
                    var cell = ws.Cells[rowIndex, colIndex];
                    var style = cell.Style.Font;
                    style.Bold = true;

                    cell.Value = item;
                    colIndex++;
                }

                foreach (var item in dsNuocUong)
                {
                    colIndex = 1;
                    rowIndex++;
                    ws.Cells[rowIndex, colIndex++].Value = item.MaNuocUong;
                    ws.Cells[rowIndex, colIndex++].Value = item.TenNuocUong;
                    string tenLoai = listLoaiNuoc.Find(x => x.MaLoai == item.MaLoai).TenLoai;
                    ws.Cells[rowIndex, colIndex++].Value = tenLoai;
                    ws.Cells[rowIndex, colIndex++].Value = item.DonGia;
                    ws.Cells[rowIndex, colIndex++].Value = item.DVT;
                }
                Byte[] bin = p.GetAsByteArray();
                File.WriteAllBytes(path, bin);
            }
        }
        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = string.Format("Danh sách món của quán");
            saveFileDialog1.InitialDirectory = @"E:\";
            saveFileDialog1.DefaultExt = "xlsx";
            saveFileDialog1.Filter = "Excel 2007 files(xlsx) (*.xlsx)|*.xlsx";

            DialogResult dlg = saveFileDialog1.ShowDialog();
            if (dlg == DialogResult.OK)
            {
                string path = string.Format(@"{0}", saveFileDialog1.FileName);
                WriteToExcelNuocUong(lvNuocUong, listNuocUong, listLoaiNuoc, path);
                MessageBox.Show("Xuất danh sách món thành công!");
            }
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
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            int index = cbbLoaiNuoc.SelectedIndex;
            cbbLoaiNuoc.SelectedIndex = -1;
            cbbLoaiNuoc.SelectedIndex = index;
            LoadLoaiNuoc();
        }
        private void btnThemLoai_Click(object sender, EventArgs e)
        {
            frmAddCategory frm = new frmAddCategory();
            frm.FormClosed += new FormClosedEventHandler(MainForm_FormClosed);
            frm.Show(this);
        }
        #endregion

        #region quản lý bàn ăn
        private void btnQuanLyBan_Click(object sender, EventArgs e)
        {
            tctMain.SelectedIndex = 2;
            hideMenu();
        }

        private void LoadTableToLV()
        {
            listTable = tableBL.GetAll();
            lvBan.Items.Clear();
            int count = 1;
            foreach (var table in listTable)
            {
                ListViewItem item = lvBan.Items.Add(count.ToString());
                item.SubItems.Add(table.ID.ToString());
                item.SubItems.Add(table.Name);
                if (table.Status == 0) { statusTable = "Bàn trống"; }
                else if (table.Status == 1) { statusTable = "Có khách"; }
                item.SubItems.Add(statusTable);
                count++;
            }
        }
        private void lvBan_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lvBan.Items.Count; i++)
            {
                // nếu có thì lấy
                if (lvBan.Items[i].Selected)
                {
                    tableCurrent = listTable[i];
                    txtIDBan.Text = tableCurrent.ID.ToString();
                    txtTenBan.Text = tableCurrent.Name;
                }
            }
        }

        public int InsertBan()
        {
            Table table = new Table();
            table.ID = 0;

            if (txtTenBan.Text == "")
            {
                lblThongBaoBan.Text = "Vui lòng kiểm tra đầy đủ dữ liệu trước khi thêm!";
                lblThongBaoBan.ForeColor = Color.Red;
            }
            else
            {
                table.Name = txtTenBan.Text;
                lblThongBaoBan.Text = "Bạn đã thêm " + table.Name + " thành công!";
                lblThongBaoBan.ForeColor = Color.Green;
                tableBL = new TableBL();
                return tableBL.Insert(table);

            }
            return -1;
        }
        private void btnAddBan_Click(object sender, EventArgs e)
        {
            // gọi phương thức thêm dữ liệu
            int result = InsertBan();
            if (result > 0)
            {
                MessageBox.Show("Đã thêm dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTableToLV();
                txtTenBan.Text = "";
                txtIDBan.Text = "";
            }
            else
            {
                lblThongBaoBan.Text = "Bàn đã tồn tại!";
                lblThongBaoBan.ForeColor = Color.Red;
            }
        }

        private int UpdateTable()
        {
            Table table = tableCurrent;
            if (txtTenBan.Text == "")
            {
                lblThongBaoBan.Text = "Vui lòng điền đầy đủ thông tin để cập nhật!";
                lblThongBaoBan.ForeColor = Color.Red;
            }
            else
            {
                table.Name = txtTenBan.Text;
                lblThongBaoBan.Text = "Bạn đã sửa " + table.Name + " thành công!";
                lblThongBaoBan.ForeColor = Color.Green;
                tableBL = new TableBL();
                return tableBL.Update(table);
            }
            return -1;
        }

        private void btnUpdateBan_Click(object sender, EventArgs e)
        {
            int result = UpdateTable();
            if (lvBan.SelectedItems.Count == 0)
            {
                lblThongBaoBan.Text = "Vui lòng chọn bàn để sửa!";
                lblThongBaoBan.ForeColor = Color.Red;
            }
            else
            {
                if (result > 0)
                {
                    MessageBox.Show("Bạn đã sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTableToLV();
                }
                else
                {
                    MessageBox.Show("Sửa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void xoáBànToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvBan.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Bạn có muốn xoá " + tableCurrent.Name + " không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    tableBL = new TableBL();
                    if (tableBL.Delete(tableCurrent) > 0)
                    {
                        lblThongBaoBan.Text = "Đã xoá bàn " + tableCurrent.Name + " thành công!";
                        lblThongBaoBan.ForeColor = Color.Green;
                        LoadTableToLV();
                        txtTenBan.Text = "";
                        txtIDBan.Text = "";
                    }
                    else
                    {
                        lblThongBaoBan.Text = "Xoá bàn " + tableCurrent.Name + " thất bại, vui lòng kiểm tra lại!";
                        lblThongBaoBan.ForeColor = Color.Red;
                    }
                }
            }
            else
            {
                lblThongBaoBan.Text = "Vui lòng chọn bàn để xoá!";
                lblThongBaoBan.ForeColor = Color.Red;
            }
        }
        #endregion

        #region Quản lý hoá đơn
        private void btnQuanLyHoaDon_Click(object sender, EventArgs e)
        {
            tctMain.SelectedIndex = 3;
            hideMenu();
        }
        public void LoadListBillByDate(DateTime checkIn, DateTime checkOut)
        {
            BillDA billDA = new BillDA();
            SetColumnsFormatBillsByDate(billDA.GetBillListByDate(checkIn, checkOut));
            DataTable data = billDA.GetBillListByDate(checkIn, checkOut);

            int count = dgvDSHoaDon.Rows.Count - 1, totalAmount = 0;
            for (int i = 0; i <= count; i++)
            {
                if (dgvDSHoaDon.Rows[i].Cells[6].Value is null)
                {
                    dgvDSHoaDon.Rows[i].Cells[6].Value = 0;
                }
                totalAmount = totalAmount + Convert.ToInt32(dgvDSHoaDon.Rows[i].Cells[6].Value);
            }
            lblTongDoanhThu.Text = totalAmount.ToString("###,### đ");
        }
        private void SetColumnsFormatBillsByDate(DataTable dt)
        {
            int count = dgvDSHoaDon.Columns.Count - 1;

            dgvDSHoaDon.DataSource = dt;
            dgvDSHoaDon.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDSHoaDon.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDSHoaDon.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDSHoaDon.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDSHoaDon.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDSHoaDon.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvDSHoaDon.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDSHoaDon.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDSHoaDon.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDSHoaDon.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDSHoaDon.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDSHoaDon.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(dtpStartDay.Value, dtpEndDay.Value);

        }

        private void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dtpStartDay.Value = new DateTime(today.Year, today.Month, 1);
            dtpEndDay.Value = dtpStartDay.Value.AddMonths(1).AddDays(-1);
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
        public void NhanVien_DataToListView()
        {
            listStaff = staffBL.GetAll();
            int count = 1; // Biến số thứ tự
                           // Xoá dữ liệu trong ListView
            lvNV.Items.Clear();
            // Duyệt mảng dữ liệu để đưa vào ListView
            foreach (var tk in listStaff)
            {
                // Số thứ tự
                ListViewItem item = lvNV.Items.Add(count.ToString());
                item.SubItems.Add(tk.MaNV.ToString());
                item.SubItems.Add(tk.HoTen);
                item.SubItems.Add(tk.DiaChi);
                item.SubItems.Add(tk.GioiTinh);
                item.SubItems.Add(tk.NgaySinh.ToString());
                item.SubItems.Add(tk.SDT);
                item.SubItems.Add(tk.MaTK.ToString());
                item.SubItems.Add(tk.TrangThai.ToString());
                count++;
            }
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
            listAcc = accBL.GetAll();
            int count = 1; // Biến số thứ tự
                           // Xoá dữ liệu trong ListView
            lvTK.Items.Clear();
            // Duyệt mảng dữ liệu để đưa vào ListView
            foreach (var tk in listAcc)
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
            Account taiKhoan = new Account();
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
                AccountBL accBL = new AccountBL();
                return accBL.Insert(taiKhoan);
            }
            return -1;
        }

        private void btnThemTKNV_Click_1(object sender, EventArgs e)
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

        public int UpdateTK()
        {
            Account acc = accCurrent;
            if (txtTenTaiKhoan.Text == "" || txtMatKhau.Text == "" || txtHoTen.Text == "" || txtEmail.Text == "" || txtSDT.Text == "" || dtpDate.Value.ToString() == "")
            {
                MessageBox.Show("Vui lòng kiểm tra đầy đủ dữ liệu trước khi thêm", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                acc.TenTaiKhoan = txtTenTaiKhoan.Text;
                acc.MatKhau = txtMatKhau.Text;
                acc.HoTen = txtHoTen.Text;
                acc.SoDienThoai = txtSDT.Text;
                acc.Email = txtEmail.Text;
                acc.NgayTao = dtpDate.Value;
                AccountBL accBL = new AccountBL();
                return accBL.Update(acc);
            }
            return -1;
        }

        private void btnCapNhatTKNV_Click(object sender, EventArgs e)
        {
            int result = UpdateTK();
            if (result > 0)
            {
                MessageBox.Show("Cập nhật dữ liệu thành công");
                TaiKhoan_DataToListView();
            }
            else MessageBox.Show("Cập nhật dữ liệu không thành công. Vui lòng kiểm tra lại dữ liệu nhập");
        }

        private void lvTK_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lvTK.Items.Count; i++)
            {
                // nếu có thì lấy
                if (lvTK.Items[i].Selected)
                {
                    accCurrent = listAcc[i];
                    txtmATK.Text = accCurrent.MaTK.ToString();
                    txtTenTaiKhoan.Text = accCurrent.TenTaiKhoan;
                    txtMatKhau.Text = accCurrent.MatKhau;
                    txtHoTen.Text = accCurrent.HoTen;
                    txtEmail.Text = accCurrent.Email;
                    txtSDT.Text = accCurrent.SoDienThoai;
                    //txtNgayTao.Text = accCurrent.NgayTao;
                }
            }
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

        private void btnXoaTaiKhoanNhanVien_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xoá tài khoản này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                // Khai báo đối tượng FoodBL từ BusinessLogic
                AccountBL accBL = new AccountBL();
                if (accBL.Delete(accCurrent) > 0)// Nếu xoá thành công
                {
                    MessageBox.Show("Xoá tài khoản thành công");
                    // Tải tữ liệu lên ListView
                    TaiKhoan_DataToListView();
                }
                else MessageBox.Show("Xoá không thành công");
            }
        }
            #endregion

            #region Đăng xuất
            private void btnDangXuat_Click(object sender, EventArgs e)
        {
            //LoginForm frm = new LoginForm();
            this.Close();
            //frm.Show();
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (MessageBox.Show("Bạn có đăng xuất tài khoản hay không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }


        #endregion


    }
}