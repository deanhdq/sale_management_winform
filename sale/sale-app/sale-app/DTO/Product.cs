using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sale_app.DTO
{
    public class Product
    {
        private int iD;
        private string barcode;
        private string productName;
        private string note;

        public Product(int id, string barcode, string name, string note)
        {
            this.ID = id;
            this.Barcode = barcode;
            this.ProductName = name;
            this.Note = note;
        }
        public Product(DataRow row)
        {
            this.ID = (int)row["product_id"];
            this.ProductName = row["product_name"].ToString();
            this.Barcode = row["product_barcode"].ToString();
            this.Note = row["product_note"].ToString();
        }
       
        public int ID { get => iD; set => iD = value; }
        public string Barcode { get => barcode; set => barcode = value; }
       
        public string Note { get => note; set => note = value; }
        public string ProductName { get => productName; set => productName = value; }
    }
}
