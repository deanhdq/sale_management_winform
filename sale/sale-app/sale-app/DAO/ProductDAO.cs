using sale_app.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sale_app.DAO
{
    public class ProductDAO
    {
        private static ProductDAO instance;

        public static ProductDAO Instance
        {
            get { if (instance == null) instance = new ProductDAO(); return ProductDAO.instance; }
            private set { ProductDAO.instance = value; }
        }

        private ProductDAO() { }
        public List<Product> loadProducts()
        {
            string query = ("EXEC load_products;");
            List<Product> products = new List<Product>();
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Product product = new Product(item);
                products.Add(product);
            }
            return products;
        }

        public int saveProduct(string barcode, string name, string note)
        {
            string query = "INSERT INTO products(bar_code, name, note) VALUES ( @bar_code , @name , @note ); ";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { barcode, name, note });
        }
        public int updateProductById(string id, string barcode, string name, string note)
        {
            string query = "UPDATE products SET bar_code = @bar_code , name = @name , note = @note WHERE id = @id ";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { barcode, name, note, id });
        }
        public int deleteProduct(int product_id)
        {
            string query = "EXEC delete_product @product_id ;";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { product_id });
        }
        public List<Product> searchProductByName(string search)
        {
            string name = string.Format("%{0}%", search);
            string query = "SELECT p.id       AS product_id,\r\n       p.name     AS product_name,\r\n       p.bar_code AS product_barcode,\r\n       p.note     AS product_note,\r\n       c.name     AS category_name\r\nFROM products p\r\n         JOIN categories c ON p.category_id = c.id\r\nWHERE p.bar_code LIKE @search OR p.name LIKE @name ";
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
