using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace sale_app.DTO
{
    public class Cart
    {
        private string transactionNo;
        private int productId;
        private string productName;
        private string price;
        private string unitName;
        private int quantity;
        private int totalPrice;


        public Cart(string tNo, int pId, string pName, string uName, string price, int quantity, int tPrice)
        {
            this.TransactionNo = tNo;
            this.ProductId = pId;
            this.ProductName = pName;
            this.UnitName = uName;
            this.Price = price;
            this.Quantity = quantity;
            this.TotalPrice = tPrice;

        }
        private string ConvertToCurrency(int number)
        {
            return string.Format("{0:#,##0}", number);
        }
        public Cart(DataRow row)
        {
            this.TransactionNo = row["transaction_no"].ToString();
            this.ProductId = (int)row["product_id"];
            this.ProductName = row["product_name"].ToString();
            this.UnitName = row["unit_name"].ToString();
            this.Price = this.ConvertToCurrency(Int32.Parse(row["price"].ToString()));
            this.Quantity = (int)row["quantity"];
            this.TotalPrice = (int)row["total_price"];

        }
        public string TransactionNo { get => transactionNo; set => transactionNo = value; }
        public int ProductId { get => productId; set => productId = value; }
        public string ProductName { get => productName; set => productName = value; }
        public string Price { get => price; set => price = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public int TotalPrice { get => totalPrice; set => totalPrice = value; }
        public string UnitName { get => unitName; set => unitName = value; }
    }
}
