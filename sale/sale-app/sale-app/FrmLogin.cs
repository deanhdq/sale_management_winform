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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;
            if (Login(username, password) && username.Equals("admin"))
            {
                FrmMain frmMain = new FrmMain();
                this.Hide();
                string name = AccountDAO.Instance.getNameByUserName(username);
                frmMain.labelUserName.Text = name;
                frmMain.ShowDialog();
                this.Dispose();
            }
            else if (Login(username, password) && username.Equals("banhang"))
            {
                POS frmPOS = new POS();
                this.Hide();
                frmPOS.ShowDialog();
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc tài khoản", "Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        bool Login(string username, string password)
        {
            return AccountDAO.Instance.Login(username, password);
        }

    }
}
