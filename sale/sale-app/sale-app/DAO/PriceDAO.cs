using sale_app.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sale_app.DAO
{
    public class PriceDAO
    {
        private static PriceDAO instance;
        public static PriceDAO Instance
        {
            get { if (instance == null) instance = new PriceDAO(); return instance; }
            private set { instance = value; }
        }
        private PriceDAO() { }
        public int getProductPrice(int pId, int uId)
        {
            string query = "EXEC getProductPrice @pId , @uId ;";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { pId, uId });
            DataRow first = data.Rows[0];
            Price result = new Price(first);
            return result.ProductPrice;

        }
    }

}
