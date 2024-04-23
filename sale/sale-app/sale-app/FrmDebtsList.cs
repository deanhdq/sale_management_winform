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
    public partial class FrmDebtsList : Form
    {
        public FrmDebtsList()
        {
            InitializeComponent();
            loadDebts();
        }
        public void loadDebts()
        {
            dataGridViewDebts.DataSource = DebtDAO.Instance.getAllDebts();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewDebts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridViewDebts.Columns[e.ColumnIndex].Name;
            if (colName == "history")
            {
                string customer_id = dataGridViewDebts.Rows[e.RowIndex].Cells["customer_id"].Value.ToString();
                FrmHistoryDebts frm = new FrmHistoryDebts();
                frm.loadHistoryDebts(customer_id);
                this.Hide();
                frm.ShowDialog();
                this.Show();
            }
            else if (colName == "pay")
            {
                MessageBox.Show("Chức năng chưa phát triển");
            }
        }
        public void searchDebts()
        {
            if (tbSearch.Text == String.Empty)
            {
                loadDebts();
            }
            else
            {
                dataGridViewDebts.DataSource = DebtDAO.Instance.getDebtsByName(tbSearch.Text);
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            searchDebts();
        }
    }
}
