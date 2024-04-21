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
    public partial class frmUnitList : Form
    {
        public frmUnitList()
        {
            InitializeComponent();
            loadUnits();
            tbSearch.Focus();
        }

        public void loadUnits()
        {
            dataGridView1.DataSource = UnitDAO.Instance.getAllUnits();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            frmUnit frmUnit = new frmUnit(this);
            frmUnit.btnEdit.Visible = false;
            frmUnit.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colName == "edit")
            {
                frmUnit frmCategory = new frmUnit(this);
                frmCategory.btnSave.Visible = false;
                frmCategory.lbID.Text = dataGridView1[3, e.RowIndex].Value.ToString();
                frmCategory.tbName.Text = dataGridView1[4, e.RowIndex].Value.ToString();
                frmCategory.tbNote.Text = dataGridView1[5, e.RowIndex].Value.ToString();
                frmCategory.ShowDialog();
            }
            else if (colName == "remove")
            {
                try
                {
                    if (MessageBox.Show("Xác nhận xóa đơn vị tính?", "Xóa đơn vị tính", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int result = UnitDAO.Instance.deleteUnit(dataGridView1[3, e.RowIndex].Value.ToString());
                        if (result > 0)
                        {
                            MessageBox.Show("Xoá đơn vị tính thành công!", "Xóa đơn vị tính", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadUnits();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Xóa đơn vị tính", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            searchUnits();
        }
        public void searchUnits()
        {
            if (tbSearch.Text == String.Empty)
            {
                loadUnits();
            }
            else
            {
                List<Unit> products = UnitDAO.Instance.searchUnitByName(tbSearch.Text);
                dataGridView1.DataSource = products;
            }
        }
    }
}
