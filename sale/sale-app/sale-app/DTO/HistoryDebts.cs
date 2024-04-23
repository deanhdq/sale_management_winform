using sale_app.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sale_app.DTO
{
    internal class HistoryDebts
    {
        private int customerId;
        private string customerName;
        private string transactionNo;
        private string billPrice;
        private string buyDate;

        public HistoryDebts(DataRow row)
        {
            this.CustomerId = (int)row["customer_id"];
            this.CustomerName = (string)row["name"];
            this.TransactionNo = (string)row["transaction_no"];
            this.BillPrice = NumberComon.Instance.ConvertToCurrency(Int32.Parse(row["bill_price"].ToString()));
            this.BuyDate = row["buy_date"].ToString();
        }


        public int CustomerId { get => customerId; set => customerId = value; }
        public string CustomerName { get => customerName; set => customerName = value; }
        public string TransactionNo { get => transactionNo; set => transactionNo = value; }
        public string BuyDate { get => buyDate; set => buyDate = value; }
        public string BillPrice { get => billPrice; set => billPrice = value; }
    }
}
