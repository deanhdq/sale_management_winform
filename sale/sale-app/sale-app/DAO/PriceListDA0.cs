using sale_app.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sale_app.DAO
{
   
    public class PriceListDA0
    {
        private static PriceListDA0 instance;

        public static PriceListDA0 Instance
        {
            get { if (instance == null) instance = new PriceListDA0(); return PriceListDA0.instance; }
            private set { PriceListDA0.instance = value; }
        }

        private PriceListDA0() { }

        public List<PriceList> loadListProductPrice(string product_id)
        {
            List<PriceList> priceLists = new List<PriceList>();
            string query = "EXEC getListProductPrice @product_id ";
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query, new object[] { product_id });
            foreach (DataRow row in dataTable.Rows)
            {
                PriceList priceList = new PriceList(row);
                priceLists.Add(priceList);
            }
            return priceLists;
        }
        public int deleteProductPrice(string product_id, string unit_id)
        {
            string query = "DELETE price WHERE product_id= @product_id AND unit_id = @unit_id ;";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { product_id , unit_id});
        }
    }
}
