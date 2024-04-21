using sale_app.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sale_app.DTO
{
    public class PriceList
    {
        private int iD;
        private String name;
        private String note;
        private string price;
        public PriceList(int id, string name, string note, string price)
        {
            this.ID = id;
            this.Name = name;
            this.Note = note;
            this.Price = price;
        }
        public PriceList(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["name"].ToString();
            this.Note = row["note"].ToString();
            this.Price = ConvertToCurrency(Int32.Parse(row["price"].ToString()));
        }
        private string ConvertToCurrency(int number)
        {
            return string.Format("{0:#,##0}", number);
        }
        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public string Note { get => note; set => note = value; }
        public string Price { get => price; set => price = value; }



    }
}
