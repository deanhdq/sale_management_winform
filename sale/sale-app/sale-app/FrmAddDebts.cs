using sale_app.DAO;
using sale_app.DTO;
using sale_app.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sale_app
{
    public partial class FrmAddDebts : Form
    {
        POS pOS;
        public FrmAddDebts(POS pos)
        {
            InitializeComponent();
            loadCustomers();
            this.pOS = pos;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void loadCustomers()
        {
            List<Customer> customers = CustomerDAO.Instance.getAllCustomer();
            dataGridViewCustomers.DataSource = customers;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FrmAddCustomer frmCustomer = new FrmAddCustomer(this);
            frmCustomer.ShowDialog();
        }

        private void dataGridViewCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            else
            {
                if (MessageBox.Show("Xác nhận thêm mua nợ", "Thêm mua nợ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dataGridViewCustomers.CurrentRow.Selected = true;
                    string tNO = pOS.lbTransaction.Text;
                    string cId = dataGridViewCustomers.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                    int convertPrice = NumberComon.Instance.ConvertToInteger(pOS.lbTotalPrice.Text);
                    int result = DebtDAO.Instance.addDebt(cId, tNO, convertPrice);
                    if (result > 0)
                    {
                        MessageBox.Show("Thêm mua nợ thành công!", "Mua nợ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        pOS.createNewTransaction();
                    }else
                    {
                        MessageBox.Show("Thêm mua nợ không thành công!", "Mua nợ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        public void searchCustomerByName()
        {
            if (tbSearch.Text == String.Empty)
            {
                loadCustomers();
            }
            else
            {
                List<Customer> customers = CustomerDAO.Instance.searchCustomerByName(tbSearch.Text);
                dataGridViewCustomers.DataSource = customers;
            }
        }
        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            searchCustomerByName();
        }
    }
}
