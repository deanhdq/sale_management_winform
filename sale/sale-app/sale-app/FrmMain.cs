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

    public partial class FrmMain : Form
    {
        Form displayForm;
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            if (displayForm != null)
            {
                displayForm.Dispose();
            }
            pbExit.Visible = false;
            displayForm = new frmCustomerList();
            displayForm.TopLevel = false;
            panelRight.Controls.Add(displayForm);
            displayForm.BringToFront();
            displayForm.Show();
        }

        

        private void btnUnit_Click(object sender, EventArgs e)
        {
            if (displayForm != null)
            {
                displayForm.Dispose();
            }
            pbExit.Visible = false;
            displayForm = new frmUnitList();
            displayForm.TopLevel = false;
            panelRight.Controls.Add(displayForm);
            displayForm.BringToFront();
            displayForm.Show();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            if (displayForm != null)
            {
                displayForm.Dispose();
            }
            pbExit.Visible = false;
            displayForm = new frmProductList();
            displayForm.TopLevel = false;
            panelRight.Controls.Add(displayForm);
            displayForm.BringToFront();
            displayForm.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPOS_Click(object sender, EventArgs e)
        {
            displayForm = new POS();
            displayForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
