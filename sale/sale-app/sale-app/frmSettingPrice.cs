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
    public partial class frmSettingPrice : Form
    {
        frmPriceList frmPriceList;
        public frmSettingPrice(frmPriceList frmPriceList)
        {
            InitializeComponent();
            loadUnits();
            this.frmPriceList = frmPriceList;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        void loadUnits()
        {

            cbUnits.Items.Clear();
            cbUnits.DataSource = UnitDAO.Instance.getAllUnits();
            cbUnits.ValueMember = "id";
            cbUnits.DisplayMember = "name";
        }
        public void loadUnitById(string id)
        {
            cbUnits.DataSource = UnitDAO.Instance.getUnitsById(id);
            cbUnits.ValueMember = "id";
            cbUnits.DisplayMember = "name";
        }

        private void btnSave_Click(object sender, EventArgs e)

        {
            try
            {
                if (MessageBox.Show("Xác nhận thêm giá sản phẩm?", "Thêm giá sản phẩm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (tbPrice.Text.Equals(""))
                    {
                        MessageBox.Show("Giá sản phẩm không được để trống!");
                    }
                    else
                    {
                        string query = "INSERT INTO price(product_id, unit_id, price) VALUES ( @pId , @uId , @price );";
                        DataProvider.Instance.ExecuteNoneQuery(query, new object[] { Int32.Parse(lbID.Text), Int32.Parse(cbUnits.GetItemText(cbUnits.SelectedValue)), float.Parse(tbPrice.Text) });
                        MessageBox.Show("Cập nhật giá sản phẩm thành công.", "Cập nhật giá sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmPriceList.loadProductPriceList();
                        this.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thêm giá sản phẩm không thành công!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Xác nhận sửa giá sản phẩm?", "Sửa giá sản phẩm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (tbPrice.Text.Equals(""))
                    {
                        MessageBox.Show("Giá sản phẩm không được để trống!");
                    }
                    else
                    {
                        string query = "UPDATE price SET price = @price WHERE product_id= @product_id AND unit_id = @unit_id ;";
                        int result = DataProvider.Instance.ExecuteNoneQuery(query, new object[] { float.Parse(tbPrice.Text), lbID.Text, lbUID.Text });
                        if (result > 0)
                        {
                            MessageBox.Show("Cập nhật giá sản phẩm thành công.", "Cập nhật giá sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmPriceList.loadProductPriceList();
                            this.Dispose();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sửa giá sản phẩm không thành công!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

        }


    }
}
