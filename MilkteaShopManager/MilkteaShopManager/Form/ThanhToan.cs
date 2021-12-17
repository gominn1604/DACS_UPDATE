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
    public partial class FormThanhToan : Form
    {
        Table _table = new Table();
        int _tongTien;
        public FormThanhToan()
        {
            InitializeComponent();
        }
        public void LoadForm(Table table, int tongTien)
        {
            int tongThanhToan;
            txtCongTien.Text = tongTien.ToString("###,### đ");
            _tongTien = tongTien;
            _table = table;

            tongThanhToan = tongTien - Convert.ToInt32(mtxtGiamGia.Text) + Convert.ToInt32(txtThue.Text);
            txtTongThanhToan.Text = tongThanhToan.ToString("###,### đ");
        }

        private void nudGiamGia_ValueChanged(object sender, EventArgs e)
        {
            int giamGia;
            giamGia = _tongTien / 100 * Convert.ToInt32(nudGiamGia.Value);
            mtxtGiamGia.Text = giamGia.ToString();

            int tongThanhToan = _tongTien - Convert.ToInt32(mtxtGiamGia.Text) + Convert.ToInt32(txtThue.Text) + Convert.ToInt32(txtChiPhiKhac.Text);
            txtTongThanhToan.Text = tongThanhToan.ToString("###,### đ");
        }

        private void cbbThue_SelectedIndexChanged(object sender, EventArgs e)
        {
            int thue;
            thue = _tongTien / 100 * Convert.ToInt32(cbbThue.SelectedItem.ToString());
            if (cbbThue.SelectedItem.ToString() == "0")
            {
                txtThue.Text = "0 đ";
            }    
            else
            {
                txtThue.Text = thue.ToString();
            }
            int tongThanhToan = _tongTien - Convert.ToInt32(mtxtGiamGia.Text) + Convert.ToInt32(txtThue.Text) + Convert.ToInt32(txtChiPhiKhac.Text);
            txtTongThanhToan.Text = tongThanhToan.ToString("###,### đ");
        }

        private void txtChiPhiKhac_TextChanged(object sender, EventArgs e)
        { 
            if (txtChiPhiKhac.Text == "" || IsNumber(txtChiPhiKhac.Text) == false)
            {
                txtChiPhiKhac.Text = "0";
            }
                int tongThanhToan = _tongTien - Convert.ToInt32(mtxtGiamGia.Text) + Convert.ToInt32(txtThue.Text) + Convert.ToInt32(txtChiPhiKhac.Text);
                txtTongThanhToan.Text = tongThanhToan.ToString("###,### đ");
        }

        public bool IsNumber(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            BillBL billBL = new BillBL();
            BillDA billDA = new BillDA();
            int billId = billBL.GetUncheckBillIdByTableId(_table.ID);

            if (billId != -1)
            {
                if (MessageBox.Show("Bạn có muốn thanh toán hóa đơn cho " + _table.Name.ToLower(), "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    billDA.CheckOut(billId);
                }
            }
        }
    }
}
