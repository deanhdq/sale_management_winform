using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sale_app.DTO
{
    internal class Bill
    {
        private int iD;
        private string transactionNo;
        private int totalPrice;
        private DateTime dateBuy;

        public Bill(int id, string tNo, int tPrice, DateTime dateBuy)
        {
            this.ID = id;
            this.TransactionNo = tNo;
            this.TotalPrice = tPrice;
            this.DateBuy = dateBuy;
        }
        public int ID { get => iD; set => iD = value; }
        public string TransactionNo { get => transactionNo; set => transactionNo = value; }
        public int TotalPrice { get => totalPrice; set => totalPrice = value; }
        public DateTime DateBuy { get => dateBuy; set => dateBuy = value; }
    }
}
