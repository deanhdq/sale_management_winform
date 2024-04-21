using sale_app.DAO;
using sale_app.DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace sale_app
{
    public partial class frmPriceList : Form
    {
        
        public frmPriceList(frmProductList frmProductList)
        {
            InitializeComponent();
            loadProductPriceList();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void loadProductPriceList()
        {
            string productId = lbID.Text;
            List<PriceList> list = PriceListDA0.Instance.loadListProductPrice(productId);
            dataGridView1.DataSource = list;
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            frmSettingPrice frmSettingPrice = new frmSettingPrice(this);
            frmSettingPrice.btnEdit.Visible = false;
            frmSettingPrice.lbID.Text = lbID.Text;
            frmSettingPrice.tbBarcode.Text = tbBarcode.Text;
            frmSettingPrice.tbProductName.Text = tbProductName.Text;
            frmSettingPrice.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colName == "edit")
            {
                frmSettingPrice frmSettingPrice = new frmSettingPrice(this);
                frmSettingPrice.btnSave.Visible = false;
                frmSettingPrice.lbID.Text = lbID.Text;
                frmSettingPrice.lbUID.Text = dataGridView1[3, e.RowIndex].Value.ToString();
                frmSettingPrice.loadUnitById(dataGridView1[3, e.RowIndex].Value.ToString());
                frmSettingPrice.cbUnits.Enabled = false;       
                frmSettingPrice.tbPrice.Text = ConvertToInteger(dataGridView1[6, e.RowIndex].Value.ToString()).ToString();
                frmSettingPrice.tbBarcode.Text = tbBarcode.Text;
                frmSettingPrice.tbProductName.Text = tbProductName.Text;
                
                frmSettingPrice.ShowDialog();
               
            }
            else if (colName == "remove")
            {
                try
                {
                    if (MessageBox.Show("Xác nhận xóa giá sản phẩm?", "Xóa giá sản phẩm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int result = PriceListDA0.Instance.deleteProductPrice(lbID.Text, dataGridView1[3, e.RowIndex].Value.ToString());
                        if (result > 0)
                        {
                            MessageBox.Show("Xóa giá sản phẩm thành công.", "Xóa giá sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadProductPriceList();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Xóa giá sản phẩm không thành công!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        private int ConvertToInteger(string input)
        {
            // Loại bỏ dấu chấm và dấu phẩy phân tách hàng nghìn
            string cleanInput = input.Replace(".", "").Replace(",", "");

            // Thực hiện phân tích chuỗi thành số nguyên
            if (int.TryParse(cleanInput, NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out int number))
            {
                return number;
            }
            else
            {
                return -1; // Trả về -1 nếu không thể chuyển đổi
            }
        }
    }
}
