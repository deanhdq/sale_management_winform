using sale_app.DAO;
using sale_app.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace sale_app
{

    public partial class frmQuantity : Form
    {

        private POS frmPOS;
        private int productId;
        private string transactionNo;
        private string productName;

        public frmQuantity(POS pos)
        {
            InitializeComponent();
            this.frmPOS = pos;
        }

        public void productDetail(int pId, string pName, string transNo)
        {
            this.productId = pId;
            this.transactionNo = transNo;
            this.productName = pName;
        }

        public void loadUnits()
        {
            List<Unit> units = new List<Unit>();
            units = UnitDAO.Instance.getUnitByProductId(this.productId);
            if (units.Count > 0)
            {
                cbUnits.DataSource = units;
                cbUnits.ValueMember = "id";
                cbUnits.DisplayMember = "name";
                cbUnits.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Chưa thiết lập giá", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                this.Dispose();
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string tNo = this.transactionNo;
            int pId = this.productId;
            string pName = this.productName;
            int uId = Int32.Parse(cbUnits.GetItemText(cbUnits.SelectedValue));
            string uName = cbUnits.Text;
            int price = PriceDAO.Instance.getProductPrice(pId, uId);
            int quantity = Int16.Parse(tbQuantity.Text);
            int totalPrice = price * quantity;
            Cart cart = new Cart(tNo, pId, pName, uName, price.ToString(), quantity, totalPrice);
            int res = CartDAO.Instance.saveCart(cart);
            if (res > 0)
            {
                frmPOS.clearSearch();
                frmPOS.loadProductToBill(frmPOS.lbTransaction.Text);
                frmPOS.loadTotalPrice(frmPOS.lbTransaction.Text);
                frmPOS.calculatorPrice();
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Lỗi khi thêm sản phẩm vào hóa đơn!", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                this.Dispose();
            }
        }
    }
}
