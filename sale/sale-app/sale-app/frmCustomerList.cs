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
    public partial class frmCustomerList : Form
    {
        public frmCustomerList()
        {
            InitializeComponent();
            loadCustomers();
        }
        public void loadCustomers()
        {
            dataGridView1.DataSource = CustomerDAO.Instance.getAllCustomer();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            frmCustomer frmCustomer = new frmCustomer(this);
            frmCustomer.btnEdit.Visible = false;
            frmCustomer.ShowDialog();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colName == "edit")
            {
                frmCustomer frmCustomer = new frmCustomer(this);
                frmCustomer.btnSave.Visible = false;
                frmCustomer.lbID.Text = dataGridView1[3, e.RowIndex].Value.ToString();
                frmCustomer.tbName.Text = dataGridView1[4, e.RowIndex].Value.ToString();
                frmCustomer.tbPhoneNumber.Text = dataGridView1[6, e.RowIndex].Value.ToString();
                frmCustomer.tbAddress.Text = dataGridView1[5, e.RowIndex].Value.ToString();
                frmCustomer.tbNote.Text = dataGridView1[7, e.RowIndex].Value.ToString();
                frmCustomer.ShowDialog();
            }
            else if (colName == "remove")
            {
                if (MessageBox.Show("Xác nhận xóa khách hàng?", "Xóa khách hàng", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int result = CustomerDAO.Instance.deleteCustomerById(dataGridView1[3, e.RowIndex].Value.ToString());
                    if (result > 0)
                    {
                        MessageBox.Show("Xoá khách hàng thành công!", "Xóa khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadCustomers();
                    }
                    else
                    {
                        MessageBox.Show("Xoá khách hàng không thành công!", "Xóa khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        loadCustomers();
                    }
                }
            }
        }
        public void searchCustomer()
        {
            if (tbSearch.Text == String.Empty)
            {
                loadCustomers();
            }
            else
            {
                List<Customer> customers = CustomerDAO.Instance.searchCustomerByName(tbSearch.Text);
                dataGridView1.DataSource = customers;
            }
        }
        private void tbSearch_TextChanged_1(object sender, EventArgs e)
        {
            searchCustomer();
        }
    }
}
