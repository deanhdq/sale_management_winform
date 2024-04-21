using sale_app.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sale_app.DAO
{
    public class POSDAO
    {
        private static POSDAO instance;

        public static POSDAO Instance
        {
            get { if (instance == null) instance = new POSDAO(); return POSDAO.instance; }
            private set { POSDAO.instance = value; }
        }

        private POSDAO() { }
      
        public List<Product> getProductsPOSByBarcodeOrName(string search)
        {
            string name = string.Format("%{0}%", search);
            string query = "SELECT p.id   AS product_id,  p.name     AS product_name,  p.bar_code AS product_barcode, p.note AS product_note FROM products p WHERE p.bar_code LIKE @search OR p.name LIKE @name ";
            List<Product> products = new List<Product>();
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { search, name });
            foreach (DataRow item in data.Rows)
            {
                Product product = new Product(item);
                products.Add(product);
            }
            return products;
        }
    }
}
