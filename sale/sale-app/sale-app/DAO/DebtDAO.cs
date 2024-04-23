using sale_app.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sale_app.DAO
{
    internal class DebtDAO
    {
        private static DebtDAO instance;

        public static DebtDAO Instance
        {
            get { if (instance == null) instance = new DebtDAO(); return DebtDAO.instance; }
            private set { DebtDAO.instance = value; }
        }

        private DebtDAO() { }
        public int addDebt( string customer_id, string transaction_no, int bill_price)
        {
            string query = "insert into debts(customer_id, transaction_no, bill_price, buy_date) values ( @customer_id , @transaction_no , @bill_price , @buy_date );";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { customer_id, transaction_no, bill_price, DateTime.Now });
        }
        public List<DebtList> getAllDebts()
        {
            List<DebtList> debts = new List<DebtList>();
            string query = "select d.customer_id, c.name, c.address, c.phone_number, sum(d.bill_price) as debts_total from debts d Join dbo.customers c on c.id = d.customer_id GROUP BY d.customer_id, c.name, c.address, c.phone_number ;";
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in dataTable.Rows)
            {
                DebtList debt = new DebtList(row);
                debts.Add(debt);
            }
            return debts;
        }
        public List<HistoryDebts> getDebtsByCustomerId(string customerId)
        {
            List<HistoryDebts> historyDebts = new List<HistoryDebts>();
            string query = "select d.customer_id, c.name, d.transaction_no, d.bill_price, d.buy_date from debts d join dbo.customers c on c.id = d.customer_id WHERE d.customer_id = @cID ;";
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query, new object[] { customerId });
            foreach (DataRow row in dataTable.Rows)
            {
                HistoryDebts history = new HistoryDebts(row);
                historyDebts.Add(history);
            }
            return historyDebts;
        }
       //0362450138 
       /* public List<Pay> getPay(string customerId)
        {

            List<HistoryDebts> historyDebts = new List<HistoryDebts>();
            string query = "select d.customer_id, c.name, d.transaction_no, d.bill_price, d.buy_date from debts d join dbo.customers c on c.id = d.customer_id WHERE d.customer_id = @cID ;";
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query, new object[] { customerId });
            foreach (DataRow row in dataTable.Rows)
            {
                HistoryDebts history = new HistoryDebts(row);
                historyDebts.Add(history);
            }
            return historyDebts;
        }*/
        public List<Cart> getDebtsDetail(string transactionNo)
        {
            List<Cart> list = new List<Cart>();
            string query = "select c.transaction_no,d.buy_date,  c.product_id, c.product_name, c.unit_name, c.price, c.quantity, c.total_price from debts d join carts c on d.transaction_no = c.transaction_no where d.transaction_no = @transaction_no ;";
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query, new object[] { transactionNo });
            foreach (DataRow row in dataTable.Rows)
            {
                Cart cart = new Cart(row);
                list.Add(cart);
            }
            return list;
        }

        public List<DebtList> getDebtsByName(string name)
        {
            List<DebtList> debts = new List<DebtList>();
            name = string.Format("%{0}%", name);
            string query = "select d.customer_id, c.name, c.address, c.phone_number, sum(d.bill_price) as debts_total from debts d Join dbo.customers c on c.id = d.customer_id WHERE c.name like @name GROUP BY d.customer_id, c.name, c.address, c.phone_number ;";
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query, new object[] {name});
            foreach (DataRow row in dataTable.Rows)
            {
                DebtList debt = new DebtList(row);
                debts.Add(debt);
            }
            return debts;
        }
    }

}
