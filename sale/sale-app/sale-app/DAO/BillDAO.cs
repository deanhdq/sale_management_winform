using sale_app.DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sale_app.DAO
{
    internal class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO(); return BillDAO.instance; }
            private set { BillDAO.instance = value; }
        }
        private int ConvertToInteger(string input)
        {
            // Loại bỏ dấu chấm và dấu phẩy phân tách hàng nghìn
            string cleanInput = input.Replace(".", "").Replace(",", "");

            // Thực hiện phân tích chuỗi thành số nguyên
            if (int.TryParse(cleanInput, NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out int number))
            {
                return number;
            }
            else
            {
                return -1; // Trả về -1 nếu không thể chuyển đổi
            }
        }
        private BillDAO() { }
        public int saveBill(string transactionNo)
        {
            string totalPrice = CartDAO.Instance.getTotalPrice(transactionNo);
            int convertTotalPrice = ConvertToInteger(totalPrice);
            DateTime now = DateTime.Now;
            string query = "INSERT INTO bill(transaction_no, total_price, date_buy) VALUES ( @transaction_no , @total_price , @date_buy );";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { transactionNo, convertTotalPrice, now });
        }
        public void saveBillInfo(string transactionNo)
        {
            List<Cart> carts = CartDAO.Instance.getCarts(transactionNo);
            foreach (Cart cart in carts)
            {
                int convertPrice = ConvertToInteger(cart.Price);
                DataProvider.Instance.ExecuteQuery("insert into bill_info(transaction_no, product_id, unit_name, price, quantity, total_price) VALUES ( @transaction_no , @product_id , @unit_name , @price , @quantity , @total_price );",
                    new object[] { cart.TransactionNo, cart.ProductId, cart.UnitName, convertPrice, cart.Quantity, cart.TotalPrice }
                    );
            }
        }
    }
}
