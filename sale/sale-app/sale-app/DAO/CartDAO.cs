using sale_app.DTO;
using sale_app.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sale_app.DAO
{
    public class CartDAO
    {
        private static CartDAO instance;

        public static CartDAO Instance
        {
            get { if (instance == null) instance = new CartDAO(); return CartDAO.instance; }
            private set { CartDAO.instance = value; }
        }

        private CartDAO() { }

        // Get transactionNo
        public string getTransactionNo()
        {
            string query = "SELECT TOP 1 transaction_no FROM carts ORDER BY transaction_no DESC";
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query);
            if (dataTable.Rows.Count > 0)
            {
                DataRow first = dataTable.Rows[0];
                long transaction_no_temp = Int64.Parse(first["transaction_no"].ToString());
                return (transaction_no_temp + 1).ToString();
            }
            else
            {
                string transactionDate = DateTime.Now.ToString("yyyyMMdd") + "001";
                long result = Int64.Parse(transactionDate);
                return result.ToString();
            }
        }
 


        public int saveCart(Cart cart)
        {
            string isProductExsited = "SELECT product_id, quantity FROM carts WHERE transaction_no LIKE @transaction_no AND product_id = @product_id AND unit_name LIKE @unit_name ";
            DataTable check = DataProvider.Instance.ExecuteQuery(isProductExsited, new object[] { cart.TransactionNo, cart.ProductId, cart.UnitName });
            if (check.Rows.Count > 0)
            {
                string product_id = check.Rows[0]["product_id"].ToString();
                int quantity = (int)check.Rows[0]["quantity"] + cart.Quantity;
                string queryUpdate = "UPDATE carts SET quantity = @quantity WHERE product_id = @product_id ";
                return DataProvider.Instance.ExecuteNoneQuery(queryUpdate, new object[] { quantity, product_id });
            }
            else
            {
                string query = "insert into carts(transaction_no, product_id, product_name, unit_name, price, quantity, total_price) VALUES ( @transaction_no , @product_id , @product_name , @unit_name , @price , @quantity , @total_price )";
                int convertPrice = Int32.Parse(cart.Price);
                return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { cart.TransactionNo, cart.ProductId, cart.ProductName, cart.UnitName, convertPrice, cart.Quantity, cart.TotalPrice });
            }



        }

        public List<Cart> getCarts(string transactionNo)
        {
            List<Cart> list = new List<Cart>();
            string query = "SELECT * FROM carts WHERE transaction_no LIKE @transaction_no ";
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query, new object[] { transactionNo });
            foreach (DataRow row in dataTable.Rows)
            {
                Cart cart = new Cart(row);

                list.Add(cart);
            }
            return list;
        }

        public string getTotalPrice(string transactionNo)
        {
            int totalPrice = 0;
            List<Cart> list = this.getCarts(transactionNo);
            foreach (Cart cart in list)
            {

                totalPrice = totalPrice + cart.TotalPrice;
            }
            return NumberComon.Instance.ConvertToCurrency(totalPrice);
        }

        public int deleteProductFromCart(string tNo, int pId, string uName)
        {
            string query = "DELETE FROM carts WHERE transaction_no = @transaction_no AND product_id = @product_id AND unit_name = @unit_name ";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { tNo, pId, uName });
        }
    }
}
