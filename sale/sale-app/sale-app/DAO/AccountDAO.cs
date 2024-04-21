using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sale_app.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return AccountDAO.instance; }
            private set { AccountDAO.instance = value; }
        }

        private AccountDAO() { }
        public bool Login(string username, string password)
        {
            string query = "EXEC login @username , @password ;";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { username, password });
            return result.Rows.Count >0;
        }
        public string getNameByUserName(string userName)
        {
            string query = "SELECT name FROM accounts WHERE username LIKE @username ";
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query, new object[] { userName });
            DataRow row = dataTable.Rows[0];
            return row[0].ToString();
        }
    }
}
