using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sale_app.DTO
{
    internal class Pay
    {

        private int amount;
        private string customerId;
        private string pay_date;

        public Pay(DataRow row)
        {
            this.Amount = (int)row["amount"];
            this.CustomerId = row["customer_id"].ToString();
            this.Pay_date = row["pay_date"].ToString();
        }
        public int Amount { get => amount; set => amount = value; }
        public string CustomerId { get => customerId; set => customerId = value; }
        public string Pay_date { get => pay_date; set => pay_date = value; }
    }
}
