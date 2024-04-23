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
    public partial class FrmAddCustomer : Form
    {
        FrmAddDebts frmAddDebts;
        public FrmAddCustomer(FrmAddDebts f)
        {
            InitializeComponent();
            this.frmAddDebts = f;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Xác nhận lưu khách hàng", "Thêm khách hàng", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (tbName.Text.Equals(""))
                    {
                        MessageBox.Show("Tên khách hàng không được để trống");
                    }
                    else
                    {
                        int result = CustomerDAO.Instance.addCustomer(tbName.Text, tbAddress.Text, tbPhoneNumber.Text, tbNote.Text);
                        if (result > 0)
                        {
                            MessageBox.Show("Lưu thông tin khách hàng thành công.", "Lưu thông tin khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                            frmAddDebts.loadCustomers();
                            this.Dispose();
                        }
                        else
                        {
                            MessageBox.Show("Lưu thông tin khách hàng không thành công!", "Lưu thông tin khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            frmAddDebts.loadCustomers();
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
        private void Clear()
        {
            tbName.Clear();
            tbName.Focus();
            tbAddress.Clear();
            tbPhoneNumber.Clear();
            tbNote.Clear();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
