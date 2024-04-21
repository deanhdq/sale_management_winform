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
    public partial class frmUnit : Form
    {
        frmUnitList frmUnitList;
        public frmUnit(frmUnitList frmUnitList)
        {
            InitializeComponent();
            this.frmUnitList = frmUnitList;
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
            tbName.Clear();
            tbName.Focus();
            tbNote.Clear();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Xác nhận đơn vị tính?", "Thêm đơn vị tính", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (tbName.Text.Equals(""))
                    {
                        MessageBox.Show("Tên đơn vị tính không được để trống");
                    }
                    else
                    {
                        int result = UnitDAO.Instance.addUnit(tbName.Text, tbNote.Text);
                        if (result > 0)
                        {
                            MessageBox.Show("Lưu đơn vị tính thành công.", "Thêm đơn vị tính hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                            frmUnitList.loadUnits();
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            btnSave.Visible = false;
            try
            {
                if (MessageBox.Show("Xác nhận sửa đơn vị tính?", "Sửa đơn vị tính", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (tbName.Text.Equals(""))
                    {
                        MessageBox.Show("Tên đơn vị tính không được để trống");
                    }
                    else
                    {
                        int result = UnitDAO.Instance.editUnit(tbName.Text, tbNote.Text, lbID.Text);
                        if (result > 0)
                        {
                            MessageBox.Show("Sửa đơn vị tính thành công.", "Sửa đơn vị tính", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                            frmUnitList.loadUnits();
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
    }
}
