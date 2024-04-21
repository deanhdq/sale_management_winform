using sale_app.DAO;
using sale_app.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sale_app
{
    public partial class POS : Form
    {
        public POS()
        {
            InitializeComponent();
            getTransactionAndDate();
        }
        public void getTransactionAndDate()
        {
            lbTransaction.Text = CartDAO.Instance.getTransactionNo();
            lbDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
        }

        public void loadProducts()
        {
            if (tbSearch.Text == String.Empty)
            {
                List<Product> products = new List<Product>();
                dataGridViewSearch.DataSource = products;
                return;
            }
            else
            {
                List<Product> products = POSDAO.Instance.getProductsPOSByBarcodeOrName(tbSearch.Text);
                dataGridViewSearch.DataSource = products;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            loadProducts();
        }

        private void dataGridViewSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            dataGridViewSearch.CurrentRow.Selected = true;
            string id = dataGridViewSearch.Rows[e.RowIndex].Cells["ID"].Value.ToString();
            string bar_code = dataGridViewSearch.Rows[e.RowIndex].Cells["Barcode"].Value.ToString();
            string name = dataGridViewSearch.Rows[e.RowIndex].Cells["ProductName"].Value.ToString();
            frmQuantity frmQuantity = new frmQuantity(this);
            frmQuantity.productDetail(Int32.Parse(id), name, lbTransaction.Text);
            frmQuantity.loadUnits();
            frmQuantity.ShowDialog();
        }
        public void loadProductToBill(string tNo)
        {
            dataGridViewBill.DataSource = CartDAO.Instance.getCarts(tNo);
            dataGridViewBill.Columns["TransactionNo"].DisplayIndex = 0;
            dataGridViewBill.Columns["ProductId"].DisplayIndex = 1;
            dataGridViewBill.Columns["product_name"].DisplayIndex = 2;
            dataGridViewBill.Columns["UnitName"].DisplayIndex = 3;
            dataGridViewBill.Columns["Price"].DisplayIndex = 4;
            dataGridViewBill.Columns["Quantity"].DisplayIndex = 5;
            dataGridViewBill.Columns["TotalPrice"].DisplayIndex = 6;
        }
        public void clearSearch()
        {
            this.tbSearch.Clear();
            this.tbSearch.Focus();
        }
        public void loadTotalPrice(string tNo)
        {
            lbTotalPrice.Text = CartDAO.Instance.getTotalPrice(tNo);
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
        private string ConvertToCurrency(int number)
        {
            return string.Format("{0:#,##0}", number);
        }
        public void createNewTransaction()
        {
            getTransactionAndDate();
            loadProductToBill(lbTransaction.Text);
            tbCustomerPay.Clear();
            tbDiscount.Clear();
            lbChange.Text = "0";
            loadTotalPrice(lbTransaction.Text);
            tbSearch.Focus();
        }
        public void calculatorPrice()
        {
            if (tbCustomerPay.Text == String.Empty)
            {
                return;
            }
            else
            {
                int customerPay = Int32.Parse(tbCustomerPay.Text);
                int discount;
                if (tbDiscount.Text == String.Empty)
                {
                    discount = 0;
                }
                else
                {
                    discount = Int32.Parse(tbDiscount.Text);
                }
                int changePrice = customerPay - ConvertToInteger(lbTotalPrice.Text) - discount;
                if (changePrice >= 0)
                {
                    lbChange.Text = ConvertToCurrency(changePrice);
                }
                else
                {
                    lbChange.Text = "Không hợp lệ";
                }

            }
        }

        private void tbCustomerPay_TextChanged(object sender, EventArgs e)
        {
            calculatorPrice();
        }

        private void tbCustomerPay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbDiscount_TextChanged(object sender, EventArgs e)
        {
            calculatorPrice();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            int check = dataGridViewBill.Rows.Count;
            if (check > 0)
            {
                if (tbCustomerPay.Text.Length > 0 && lbChange.Text != "Không hợp lệ")
                {
                    if (MessageBox.Show("Xác nhận hoàn thành đơn hàng?", "Bán hàng", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        BillDAO.Instance.saveBill(lbTransaction.Text);
                        BillDAO.Instance.saveBillInfo(lbTransaction.Text);
                        createNewTransaction();
                    }
                }
                else
                {
                    MessageBox.Show("Chưa nhập tiền khách trả hoặc tiền khách trả không hợp lệ", "Hoàn tất thanh toán", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Chưa có sản phẩm.", "Hoàn tất thanh toán", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            int check = dataGridViewBill.Rows.Count;
            if (check > 0)
            {
                if (MessageBox.Show("Xác nhận Hủy đơn hàng?", "Bán hàng", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    createNewTransaction();
                }
            }
            else
            {
                createNewTransaction();
            }
        }

        private void dataGridViewBill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridViewBill.Columns[e.ColumnIndex].Name;
            if (colName == "remove_product")
            {
                DataGridViewRow row = dataGridViewBill.Rows[e.RowIndex];
                string transactionNo = row.Cells[1].Value.ToString();
                string productId = row.Cells[2].Value.ToString();
                string unitName = row.Cells[7].Value.ToString();
                int result = CartDAO.Instance.deleteProductFromCart(transactionNo, Int32.Parse(productId), unitName);
                if (result > 0)
                {
                    loadProductToBill(transactionNo);
                    loadTotalPrice(transactionNo);
                }
                else
                {
                    MessageBox.Show("Xóa sản phẩm thất bại!", "Xóa sản phẩm", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                }
            }
        }
    }
}
