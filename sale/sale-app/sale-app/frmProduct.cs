using sale_app.DAO;
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
    public partial class frmProduct : Form
    {
        frmProductList frmProductList;
        public frmProduct(frmProductList frmProductList)
        {
            InitializeComponent();
            this.frmProductList = frmProductList;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Clear()
        {
            tbBarcode.Clear();
            tbBarcode.Focus();
            tbProductName.Clear();
            tbNote.Clear();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Xác nhận lưu sản phẩm?", "Thêm sản phẩm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (tbBarcode.Text.Equals("") || tbProductName.Text.Equals(""))
                    {
                        MessageBox.Show("Mã sản phẩm, Tên sản phẩm không được để trống");
                    }
                    else
                    {
                        int result = ProductDAO.Instance.saveProduct(tbBarcode.Text, tbProductName.Text, tbNote.Text);
                        if (result > 0)
                        {
                            MessageBox.Show("Lưu sản phẩm thành công.", "Thêm sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                            frmProductList.loadProducts();
                            this.Dispose();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Xác nhận sửa thông tin sản phẩm?", "Sửa sản phẩm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (tbBarcode.Text.Equals("") || tbProductName.Text.Equals(""))
                    {
                        MessageBox.Show("Mã sản phẩm, Tên sản phẩm không được để trống", "Sửa thông tin sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        int result = ProductDAO.Instance.updateProductById(lbID.Text, tbBarcode.Text, tbProductName.Text, tbNote.Text);
                        if (result > 0)
                        {
                            MessageBox.Show("Sửa sản phẩm thành công.", "Sửa sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                            frmProductList.loadProducts();
                            this.Dispose();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }


    }
}
