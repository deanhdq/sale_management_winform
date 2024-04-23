using sale_app.DAO;
using sale_app.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sale_app
{
    public partial class frmProductList : Form
    {
        public frmProductList()
        {
            InitializeComponent();
            loadProducts();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void loadProducts()
        {
            dataGridView1.DataSource = ProductDAO.Instance.loadProducts();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            frmProduct frm = new frmProduct(this);
            frm.btnEdit.Visible = false;
            frm.ShowDialog();

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colName == "edit")
            {
                frmProduct frmProduct = new frmProduct(this);
                frmProduct.btnSave.Visible = false;
                frmProduct.lbID.Text = dataGridView1[4, e.RowIndex].Value.ToString();
                frmProduct.tbBarcode.Text = dataGridView1[5, e.RowIndex].Value.ToString();
                frmProduct.tbProductName.Text = dataGridView1[7, e.RowIndex].Value.ToString();
                frmProduct.tbNote.Text = dataGridView1[6, e.RowIndex].Value.ToString();
                frmProduct.ShowDialog();
            }
            else if (colName == "remove")
            {
                try
                {
                    string product_id = dataGridView1[4, e.RowIndex].Value.ToString();
                    if (MessageBox.Show("Xác nhận xóa sản phẩm?", "Xóa sản phẩm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int result = ProductDAO.Instance.deleteProduct(Int16.Parse(product_id));
                      
                        if (result > 0)
                        {
                            MessageBox.Show("Xoá sản phẩm thành công!", "Xóa sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadProducts();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Xóa sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (colName == "setting")
            {
                frmPriceList frmPriceList = new frmPriceList(this);
                frmPriceList.lbID.Text = dataGridView1[4, e.RowIndex].Value.ToString();
                frmPriceList.tbBarcode.Text = dataGridView1[5, e.RowIndex].Value.ToString();
                frmPriceList.tbProductName.Text = dataGridView1[7, e.RowIndex].Value.ToString();
                frmPriceList.loadProductPriceList();
                frmPriceList.ShowDialog();
            }

        }

       
        public void searchProducts()
        {
            if (tbSearch.Text == String.Empty)
            {
                loadProducts();   
            }
            else
            {
                List<Product> products = ProductDAO.Instance.searchProductByName(tbSearch.Text);
                dataGridView1.DataSource = products;
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            searchProducts();
        }
    }
}
