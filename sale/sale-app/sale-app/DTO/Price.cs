using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sale_app.DTO
{
    public class Price
    {
        private int iD;

        private int productId;

        private int unitId;

        private int productPrice;

        public Price(int id, int prouctId, int unitId, int price)
        {
            this.ID = id;
            this.ProductId = prouctId;
            this.UnitId = unitId;
            this.ProductPrice = price;
        }
        public Price(DataRow row)
        {
            this.ProductPrice = (int)row["price"];
        }

       
        public int ID { get => iD; set => iD = value; }
        public int ProductId { get => productId; set => productId = value; }
        public int UnitId { get => unitId; set => unitId = value; }
        public int ProductPrice { get => productPrice; set => productPrice = value; }
    }
}
