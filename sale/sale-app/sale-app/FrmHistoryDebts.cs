using sale_app.DAO;
using sale_app.DTO;
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
    public partial class FrmHistoryDebts : Form
    {
        public FrmHistoryDebts()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        public void loadHistoryDebts(string custormerId)
        {
            List<HistoryDebts> historyDebts =DebtDAO.Instance.getDebtsByCustomerId(custormerId);
            dataGridView1.DataSource = historyDebts;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            dataGridView1.CurrentRow.Selected = true;
            string transactionNo = dataGridView1.Rows[e.RowIndex].Cells["TransactionNo"].Value.ToString();
            
            FrmDebtDetail frm = new FrmDebtDetail();
            frm.loadDebtDetail(transactionNo);
            frm.ShowDialog();
            /* string id = dataGridViewSearch.Rows[e.RowIndex].Cells["ID"].Value.ToString();
             string bar_code = dataGridViewSearch.Rows[e.RowIndex].Cells["Barcode"].Value.ToString();
             string name = dataGridViewSearch.Rows[e.RowIndex].Cells["ProductName"].Value.ToString();
             frmQuantity frmQuantity = new frmQuantity(this);
             frmQuantity.productDetail(Int32.Parse(id), name, lbTransaction.Text);
             frmQuantity.loadUnits();
             frmQuantity.ShowDialog();*/
        }
    }
}
