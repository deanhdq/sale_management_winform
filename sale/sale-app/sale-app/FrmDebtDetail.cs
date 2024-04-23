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
    public partial class FrmDebtDetail : Form
    {
        public FrmDebtDetail()
        {
            InitializeComponent();
        }
        public void loadDebtDetail(string tNo)
        {
            List<Cart> carts = DebtDAO.Instance.getDebtsDetail(tNo);
            dataGridViewDebts.DataSource = carts;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
